// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NetExtender.Utilities.Core;
using NetExtender.Utilities.Numerics;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight;
using ShellShockLive.Models.Weapons.Shells;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances.Internal
{
    public sealed class DirectGuidance : InternalGuidance<DirectGuidance>
    {
        public override GuidanceType GuidanceType
        {
            get
            {
                return GuidanceType.Direct;
            }
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Evaluate(shell, center, physics, new GuidanceStep(Int16.MaxValue, 0.03F), environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return new Enumerator(shell, center, physics, step, environment);
        }

        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Search(shell, center, position, physics, new GuidanceStep(Int16.MaxValue, 0.03F), environment);
        }
        
        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return SearchAll(shell, center, position, physics, new GuidanceStep(Int16.MaxValue, 0.03F), environment);
        }

        protected override IEnumerable<GuidanceSearchResult> SearchInternal(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            PhysicsInfo result = physics;
            Single minimum = Single.PositiveInfinity;
            
            for (Int16 angle = physics.Binding.Angle.Minimum; angle < physics.Binding.Angle.Maximum; angle++)
            {
                PhysicsInfo next = new PhysicsInfo(physics.Binding, angle, physics.Wind, physics.Binding.Power.Maximum, physics.Resolution);

                foreach (TrajectoryPoint point in Evaluate(shell, center, next, step, environment))
                {
                    Single distance = (Single) position.Distance(point);
                        
                    if (distance <= step.Epsilon)
                    {
                        yield return next;
                        continue;
                    }

                    if (distance >= minimum)
                    {
                        continue;
                    }

                    result = next;
                    minimum = distance;
                }
            }

            yield return result;
        }

        [StructLayout(LayoutKind.Sequential)]
        public new struct Enumerator : IGuidanceUnsafeEnumerator
        {
            public static unsafe implicit operator Guidance.Enumerator(in Enumerator value)
            {
                fixed (void* pointer = &value)
                {
                    Span<Byte> span = new Span<Byte>(pointer, sizeof(Enumerator));
                    return new Guidance.Enumerator(span, &AsCurrent, &MoveNext, &Reset, &Dispose);
                }
            }
            
            public unsafe Int32 Size
            {
                get
                {
                    return sizeof(Enumerator);
                }
            }

            public TrajectoryPoint Current { get; private set; }

            readonly Object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public Int32 Iteration { get; private set; }
            
            public readonly Boolean CanMove
            {
                get
                {
                    return Iteration < Step.Iterations;
                }
            }

            private readonly Single Position
            {
                get
                {
                    return Step * Iteration;
                }
            }

            private Single Next
            {
                get
                {
                    return Step * Iteration++;
                }
            }

            private Point Offset { get; set; }
            private Single Degree { get; }
            private Single X { get; }
            private Single Y { get; }
            private Rectangle Bounds { get; }
            
            public Shell.Unsafe Shell { get; }
            public Point Center { get; }
            public PhysicsInfo.Unsafe Physics { get; }
            public GuidanceStep Step { get; }
            /*public EnvironmentInfo? Environment { get; }*/

            [SuppressMessage("ReSharper", "MergeConditionalExpression")]
            public Enumerator(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
                : this(shell is not null ? shell.Unsafe() : throw new ArgumentNullException(nameof(shell)), center, physics, step, environment)
            {
            }
            
            public Enumerator(Shell.Unsafe shell, Point center, PhysicsInfo.Unsafe physics, GuidanceStep step, EnvironmentInfo? environment)
            {
                Shell = shell;
                Current = center;
                Iteration = 0;
                Offset = Point.Empty;
                Center = center;
                Physics = physics;
                Step = step;
                
                Degree = MathF.PI * Physics.Angle / AngleUtilities.SingleDegree.Straight;
                X = Physics.Binding.Length * MathF.Cos(Degree);
                Y = Physics.Binding.Length * MathF.Sin(Degree);
                
                Int32 left = Physics.Resolution.Left;
                Int32 top = Physics.Resolution.Top;
                Int32 right = Physics.Resolution.Right;
                Int32 bottom = Physics.Resolution.Height - Physics.Binding.Size.Height + Physics.Binding.Bounds.Bottom;
                Bounds = Rectangle.FromLTRB(left, top, right, bottom);
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static unsafe TrajectoryPoint AsCurrent(void* self)
            {
                return UnsafeUtilities.AsRef<Enumerator>(self).Current;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Boolean MoveNext()
            {
                if (!CanMove)
                {
                    return false;
                }
                
                Vector2 vector = Vector(Next);

                if (!InBounds(vector))
                {
                    return false;
                }
                
                Current = Trajectory(vector);
                return true;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Vector2 Vector(Single position)
            {
                Single x = Center.X + X * position;
                Single y = Center.Y - Y * position;

                return new Vector2(x, y);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Boolean InBounds(Vector2 vector)
            {
                return vector.X >= Bounds.Left && vector.X <= Bounds.Right && vector.Y >= Bounds.Top && vector.Y <= Bounds.Bottom;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [SuppressMessage("Performance", "CA1822:Пометьте члены как статические")]
            [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
            private readonly TrajectoryPoint Trajectory(Vector2 vector)
            {
                return new TrajectoryPoint((Int32) MathF.Round(vector.X), (Int32) MathF.Round(vector.Y));
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static unsafe Boolean MoveNext(void* self)
            {
                return UnsafeUtilities.AsRef<Enumerator>(self).MoveNext();
            }

            public void Reset()
            {
                Current = Center;
                Offset = Point.Empty;
                Iteration = 0;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static unsafe void Reset(void* self)
            {
                UnsafeUtilities.AsRef<Enumerator>(self).Reset();
            }

            public Enumerator GetEnumerator()
            {
                Enumerator enumerator = this;
                enumerator.Reset();
                return enumerator;
            }

            IEnumerator<TrajectoryPoint> IEnumerable<TrajectoryPoint>.GetEnumerator()
            {
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (TrajectoryPoint point in this)
                {
                    yield return point;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            
            public void Dispose()
            {
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static unsafe void Dispose(void* self)
            {
                UnsafeUtilities.AsRef<Enumerator>(self).Dispose();
            }
        }
    }
}