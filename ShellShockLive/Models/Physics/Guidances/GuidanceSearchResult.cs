// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Environment;

namespace ShellShockLive.Models.Physics.Guidances
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct GuidanceSearchResult : IReadOnlyCollection<KeyValuePair<SurfaceType, Byte>>, IEquatable<PhysicsInfo>, IEquatable<GuidanceSearchResult>, IComparable<PhysicsInfo>, IComparable<GuidanceSearchResult>
    {
        public static implicit operator GuidanceSearchResult(PhysicsInfo value)
        {
            return new GuidanceSearchResult(value);
        }
        
        public static implicit operator PhysicsInfo(GuidanceSearchResult value)
        {
            return value.Physics;
        }

        public PhysicsInfo.Unsafe Physics { get; }
        private fixed Byte Internal[(Int32) SurfaceType.LifeBox];

        public Int32 Count
        {
            get
            {
                return EnumUtilities.CountWithoutDefault<SurfaceType>();
            }
        }
        
        public GuidanceSearchResult(PhysicsInfo physics)
        {
            Physics = physics;
        }

        public readonly override Int32 GetHashCode()
        {
            return Physics.GetHashCode();
        }

        public readonly override Boolean Equals(Object? obj)
        {
            return obj switch
            {
                null => false,
                PhysicsInfo physics => Equals(physics),
                GuidanceSearchResult search => Equals(search),
                _ => false
            };
        }

        public readonly Boolean Equals(PhysicsInfo other)
        {
            return Physics == other;
        }

        public readonly Boolean Equals(GuidanceSearchResult other)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (SurfaceType surface in EnumUtilities.GetValuesWithoutDefault<SurfaceType>())
            {
                if (this[surface] != other[surface])
                {
                    return false;
                }
            }

            return (PhysicsInfo) Physics == other.Physics;
        }
        
        public readonly Int32 CompareTo(PhysicsInfo other)
        {
            PhysicsInfo physics = Physics;
            return physics.CompareTo(other);
        }

        public readonly Int32 CompareTo(GuidanceSearchResult other)
        {
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (SurfaceType surface in EnumUtilities.GetValuesWithoutDefault<SurfaceType>())
            {
                Int32 compare = this[surface].CompareTo(other[surface]);
                if (compare != 0)
                {
                    return compare;
                }
            }
            
            PhysicsInfo physics = Physics;
            return physics.CompareTo(other.Physics);
        }

        public readonly Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<KeyValuePair<SurfaceType, Byte>> IEnumerable<KeyValuePair<SurfaceType, Byte>>.GetEnumerator()
        {
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (KeyValuePair<SurfaceType, Byte> pair in this)
            {
                yield return pair;
            }
        }

        readonly IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<SurfaceType, Byte>>) this).GetEnumerator();
        }

        public readonly Byte this[SurfaceType type]
        {
            get
            {
                if (!type.In())
                {
                    throw new EnumUndefinedOrNotSupportedException<SurfaceType>(type, nameof(type), null);
                }

                if (type == SurfaceType.None)
                {
                    return 0;
                }

                fixed (Byte* pointer = Internal)
                {
                    return *(pointer + (Int32) type - 1);
                }
            }
            set
            {
                if (!type.In())
                {
                    throw new EnumUndefinedOrNotSupportedException<SurfaceType>(type, nameof(type), null);
                }

                if (type == SurfaceType.None)
                {
                    return;
                }
                
                fixed (Byte* pointer = Internal)
                {
                    *(pointer + (Int32) type - 1) = value;
                }
            }
        }
        
        public struct Enumerator
        {
            public GuidanceSearchResult Result { get; }
            public SurfaceType Index { get; private set; }

            public readonly KeyValuePair<SurfaceType, Byte> Current
            {
                get
                {
                    return new KeyValuePair<SurfaceType, Byte>(Index, Result[Index]);
                }
            }

            public Enumerator(GuidanceSearchResult result)
            {
                Result = result;
                Index = default;
            }

            public Boolean MoveNext()
            {
                SurfaceType next = Index.Next();
                if (next == default)
                {
                    return false;
                }

                Index = next;
                return true;
            }

            public void Reset()
            {
                Index = default;
            }
        }
    }
}