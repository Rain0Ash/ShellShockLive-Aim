// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NetExtender.Types.Attributes;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Core;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Internal;
using ShellShockLive.Models.Sight;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Physics.Guidances
{
    public abstract class Guidance : IGuidance
    {
        public static implicit operator Guidance(GuidanceType value)
        {
            return (Guidance) (value switch
            {
                GuidanceType.Parabola => Parabola,
                GuidanceType.Direct => Direct,
                GuidanceType.Custom => throw new NotSupportedException(),
                _ => throw new EnumUndefinedOrNotSupportedException<GuidanceType>(value, nameof(value), null)
            });
        }
        
        public static IGuidance Parabola
        {
            get
            {
                return ParabolaGuidance.Instance;
            }
        }

        public static IGuidance Direct
        {
            get
            {
                return DirectGuidance.Instance;
            }
        }

        public abstract GuidanceType GuidanceType { get; }

        public Boolean IsParabola
        {
            get
            {
                return GuidanceType == GuidanceType.Parabola;
            }
        }

        public Boolean IsDirect
        {
            get
            {
                return GuidanceType == GuidanceType.Direct;
            }
        }

        public Boolean IsCustom
        {
            get
            {
                return GuidanceType == GuidanceType.Custom;
            }
        }

        public abstract Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract Enumerator Evaluate(IShell shell, Point center, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo Search(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, EnvironmentInfo? environment);
        public abstract GuidanceSearchInfo SearchAll(IShell shell, Point center, Point position, PhysicsInfo physics, GuidanceStep step, EnvironmentInfo? environment);
        
#pragma warning disable CS0649
        [StaticInitializerRequired]
        public unsafe struct Enumerator : IGuidanceUnsafeEnumerator
        {
            private const Int32 Maximum = 200;
            
            static Enumerator()
            {
                Type[] enumerators = AppDomain.CurrentDomain.GetTypes().Where(type => type.IsValueType).Where(type => type.IsAssignableFrom<IGuidanceUnsafeEnumerator>()).ToArray();

                if (enumerators.FirstOrDefault(type => !type.IsLayoutSequential || type.GetSize() > Maximum) is not { } enumerator)
                {
                    return;
                }

                StringBuilder message = new StringBuilder($"Enumerator type '{enumerator}' isn't supported.");
                
                if (!enumerator.IsLayoutSequential)
                {
                    message.Append($" It must be {nameof(System.Type.IsLayoutSequential)}.");
                }

                if (enumerator.GetSize() > Maximum)
                {
                    message.Append($" It size must be less or equal '{Maximum}' but real is '{enumerator.GetSize()}'.");
                }

                throw new NotSupportedException(message.ToString());
            }

            private fixed Byte Internal[Maximum];

            public Type Type
            {
                get
                {
                    fixed (void* pointer = Internal)
                    {
                        return _type(pointer);
                    }
                }
            }

            public Int32 Length
            {
                get
                {
                    return sizeof(Enumerator);
                }
            }
            
            public Int32 Size { get; }

            public readonly TrajectoryPoint Current
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
                get
                {
                    fixed (void* pointer = Internal)
                    {
                        return _current(pointer);
                    }
                }
            }
            
            readonly Object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public readonly Boolean IsEmpty
            {
                get
                {
                    return Size <= 0;
                }
            }

            private readonly delegate*<void*, Type> _type;
            private readonly delegate*<void*, TrajectoryPoint> _current;
            private readonly delegate*<void*, Boolean> _next;
            private readonly delegate*<void*, void> _reset;
            private readonly delegate*<void*, void> _dispose;

            public Enumerator(Span<Byte> value, delegate*<void*, Type> type, delegate*<void*, TrajectoryPoint> current, delegate*<void*, Boolean> next, delegate*<void*, void> reset, delegate*<void*, void> dispose)
            {
                if (value.Length > Maximum)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value.Length, "Size of value greater than maximum size");
                }
                
                fixed (void* source = value)
                fixed (void* destination = Internal)
                {
                    UnsafeUtilities.CopyBlock(destination, source, Size = value.Length);
                }

                _type = type;
                _current = current;
                _next = next;
                _reset = reset;
                _dispose = dispose;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public readonly Boolean MoveNext()
            {
                fixed (void* pointer = Internal)
                {
                    return _next(pointer);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public readonly void Reset()
            {
                fixed (void* pointer = Internal)
                {
                    _reset(pointer);
                }
            }

            public readonly Enumerator GetEnumerator()
            {
                Enumerator enumerator = this;
                enumerator.Reset();
                return enumerator;
            }
            
            readonly IEnumerator<TrajectoryPoint> IEnumerable<TrajectoryPoint>.GetEnumerator()
            {
                // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
                foreach (Point point in this)
                {
                    yield return point;
                }
            }

            readonly IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<TrajectoryPoint>) this).GetEnumerator();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public ref Byte GetPinnableReference()
            {
                fixed (Byte* pointer = this)
                {
                    return ref *pointer;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public readonly void Dispose()
            {
                fixed (void* pointer = Internal)
                {
                    _dispose(pointer);
                }
            }
        }
#pragma warning restore CS0649
    }
}