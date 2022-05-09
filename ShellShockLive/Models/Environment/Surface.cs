// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using NetExtender.Utilities.Core;
using ReactiveUI;
using ShellShockLive.Models.Environment.Interfaces;

namespace ShellShockLive.Models.Environment
{
    public abstract class Surface : ReactiveObject, ISurface
    {
        public virtual SurfaceType Type
        {
            get
            {
                return SurfaceType.None;
            }
        }

        public abstract Boolean Interactive { get; }
        
        public virtual Boolean Intersect(Point point)
        {
            return false;
        }

        public abstract Object Clone();
        
        Unsafe ISurface.Unsafe()
        {
            throw new NotSupportedException();
        }
        
#pragma warning disable CS0649
        public unsafe struct Unsafe : IUnsafeSurface
        {
            private const Int32 Maximum = 60;
            
            static Unsafe()
            {
                Type[] enumerators = AppDomain.CurrentDomain.GetTypes().Where(type => type.IsValueType).Where(type => type.IsAssignableFrom<IUnsafeSurface>()).ToArray();

                if (enumerators.FirstOrDefault(type => !type.IsLayoutSequential || type.GetSize() > Maximum) is not Type enumerator)
                {
                    return;
                }

                StringBuilder message = new StringBuilder($"Surface type '{enumerator}' isn't supported.");
                
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
            public Int32 Size { get; }

            public readonly SurfaceType Type
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
                get
                {
                    fixed (void* pointer = Internal)
                    {
                        return _type(pointer);
                    }
                }
            }

            public readonly Boolean Interactive
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
                get
                {
                    fixed (void* pointer = Internal)
                    {
                        return _interactive(pointer);
                    }
                }
            }
            
            public readonly Boolean IsEmpty
            {
                get
                {
                    return Size <= 0;
                }
            }
            
            private readonly delegate*<void*, SurfaceType> _type;
            private readonly delegate*<void*, Boolean> _interactive;
            private readonly delegate*<void*, Point, Boolean> _intersect;
            
            public Unsafe(Span<Byte> value, delegate*<void*, SurfaceType> type, delegate*<void*, Boolean> interactive, delegate*<void*, Point, Boolean> intersect)
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
                _interactive = interactive;
                _intersect = intersect;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            public readonly Boolean Intersect(Point point)
            {
                fixed (void* pointer = Internal)
                {
                    return _intersect(pointer, point);
                }
            }
        }
#pragma warning restore CS0649
    }
}