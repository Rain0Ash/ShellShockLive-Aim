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
    public sealed class ParabolaGuidance : InternalGuidance<ParabolaGuidance>
    {
        public override GuidanceType GuidanceType
        {
            get
            {
                return GuidanceType.Parabola;
            }
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Evaluate(shell, center, physics, new GuidanceStep(Int16.MaxValue, 0.15F), environment);
        }

        public override Guidance.Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            return new Enumerator(shell, center, physics, step, environment);
        }
        
        public override GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return Search(shell, center, position, physics, new GuidanceStep(Int16.MaxValue, 0.15F), environment);
        }
        
        public override GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment)
        {
            return SearchAll(shell, center, position, physics, new GuidanceStep(Int16.MaxValue, 0.15F), environment);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static Int16 Counter(Int16 counter)
        {
            return unchecked((Int16) (((counter & 1) == 1 ? counter : -counter) >> 1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        private static Int16 Angle(Int32 current, Int16 maximum)
        {
            return unchecked((Int16) (current >= 0 ? current : maximum + current));
        }

        protected override IEnumerable<GuidanceSearchResult> SearchInternal(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment)
        {
            PhysicsInfo result = physics;
            Single minimum = Single.PositiveInfinity;

            Int16 start = unchecked((Int16) (physics.Binding.Angle.Maximum >> 2));
            for (Int16 counter = 1; counter <= physics.Binding.Angle.Maximum; counter++)
            {
                Int16 angle = Angle(start + Counter(counter), physics.Binding.Angle.Maximum);
                
                for (Int16 power = physics.Binding.Power.Maximum; power >= physics.Binding.Power.Minimum; power--)
                {
                    PhysicsInfo next = new PhysicsInfo(physics.Binding, angle, physics.Wind, power, physics.Resolution);

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
            private Single Sin { get; }
            private Single Cos { get; }
            private Single RadiusSin { get; }
            private Single RadiusCos { get; }
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
                Sin = MathF.Sin(Degree);
                Cos = MathF.Cos(Degree);
                RadiusSin = Physics.Binding.Radius * Sin;
                RadiusCos = Physics.Binding.Radius * Cos;

                Int32 left = Physics.Resolution.Left;
                Int32 top = Physics.Binding.Bounds.Top;
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

                while (true)
                {
                    Vector2 vector = Vector(Next);

                    if (!InBounds(vector))
                    {
                        return false;
                    }

                    if (vector.Y < 0)
                    {
                        continue;
                    }

                    Current = Trajectory(vector);
                    return true;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Single Wind(Single position)
            {
                return 0.5F * Shell.Wind * Physics.Wind * Physics.Binding.WindOffset * position * position;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Single Gravity(Single position)
            {
                return 0.5F * Shell.Gravitation * Physics.Binding.Gravity * position * position;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Single Velocity(Single position)
            {
                return Physics.Power * Physics.Binding.Velocity * position;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Vector2 Vector(Single position)
            {
                Single wind = Wind(position);
                Single gravity = Gravity(position);
                Single velocity = Velocity(position);
                
                Single x = Center.X + velocity * Cos + wind;
                Single y = Center.Y - velocity * Sin + gravity;

                return new Vector2(x, y);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly Boolean InBounds(Vector2 vector)
            {
                return vector.X >= Bounds.Left && vector.X <= Bounds.Right && vector.Y >= Bounds.Top && vector.Y <= Bounds.Bottom;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            private readonly TrajectoryPoint Trajectory(Vector2 vector)
            {
                return new TrajectoryPoint((Int32) (vector.X + RadiusCos - 1F), (Int32) (vector.Y - RadiusSin - 1F));
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