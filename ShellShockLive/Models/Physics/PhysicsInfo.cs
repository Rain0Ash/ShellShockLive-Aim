// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Physics.Bindings;
using ShellShockLive.Models.Physics.Bindings.Interfaces;

namespace ShellShockLive.Models.Physics
{
    public readonly struct PhysicsInfo : IEquatable<PhysicsInfo>, IComparable<PhysicsInfo>, IFormattable
    {
        public static Boolean operator ==(PhysicsInfo first, PhysicsInfo second)
        {
            return first.Equals(second);
        }

        public static Boolean operator !=(PhysicsInfo first, PhysicsInfo second)
        {
            return !(first == second);
        }
        
        public IPhysicsBinding Binding { get; }
        public Int16 Angle { get; }
        public Int16 Wind { get; }
        public Int16 Power { get; }
        public Rectangle Resolution { get; }

        public Int16 Degree
        {
            get
            {
                return ToDegree(Angle);
            }
        }

        public Quarter Quarter
        {
            get
            {
                return ToQuarter(Angle);
            }
        }
        
        public Point Center
        {
            get
            {
                return ToCenter(Resolution);
            }
        }
        
        public PhysicsInfo(IPhysicsBinding binding, Int16 angle, Int16 wind, Int16 power, Rectangle resolution)
        {
            Binding = binding ?? throw new ArgumentNullException(nameof(binding));
            Angle = angle;
            Wind = wind;
            Power = power;
            Resolution = resolution;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Int16 ToDegree(Int16 angle)
        {
            return unchecked((Int16) angle.ToQuarterDegree(out _));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Quarter ToQuarter(Int16 angle)
        {
            angle.ToQuarterDegree(out Quarter quarter);
            return quarter;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Point ToCenter(Rectangle resolution)
        {
            return new Point(resolution.Width / 2, resolution.Height / 2);
        }

        public override Int32 GetHashCode()
        {
            return HashCode.Combine(Binding, Angle, Wind, Power, Resolution);
        }

        public override Boolean Equals(Object? obj)
        {
            return obj is PhysicsInfo info && Equals(info);
        }

        public Boolean Equals(PhysicsInfo other)
        {
            return Binding == other.Binding && Angle == other.Angle && Wind == other.Wind && Power == other.Power && Resolution == other.Resolution;
        }

        public Int32 CompareTo(PhysicsInfo other)
        {
            Int32 angle1 = Angle.ToQuarterDegree(out Quarter quarter1);
            Int32 angle2 = other.Angle.ToQuarterDegree(out Quarter quarter2);

            Int32 comparison = quarter1 switch
            {
                Quarter.First or Quarter.Second when quarter2 is Quarter.First or Quarter.Second => angle1.CompareTo(angle2),
                Quarter.Third or Quarter.Fourth when quarter2 is Quarter.Third or Quarter.Fourth => angle2.CompareTo(angle1),
                _ => -Angle.CompareTo(other.Angle)
            };

            if (comparison != 0)
            {
                return comparison;
            }
            
            comparison = Power.CompareTo(other.Power);
            return comparison != 0 ? comparison : Wind.CompareTo(other.Wind);
        }
        
        public override String ToString()
        {
            return $"{nameof(Resolution)}:{Resolution.Width}x{Resolution.Height} {nameof(Angle)}:{Angle} {nameof(Degree)}:{Degree} {nameof(Quarter)}:{(Int32) Quarter} {nameof(Wind)}:{Wind} {nameof(Power)}:{Power} {nameof(Binding)}:{Binding}";
        }

        public String ToString(String? format)
        {
            return ToString(format, null);
        }

        public String ToString(String? format, IFormatProvider? provider)
        {
            if (String.IsNullOrEmpty(format))
            {
                return ToString();
            }

            return new StringBuilder(format)
                .Replace("{RESOLUTION}", $"{Resolution.Width.ToString(provider)}x{Resolution.Height.ToString(provider)}")
                .Replace("{WIDTH}", Resolution.Width.ToString(provider))
                .Replace("{HEIGHT}", Resolution.Height.ToString(provider))
                .Replace("{ANGLE}", Angle.ToString(provider))
                .Replace("{DEGREE}", Degree.ToString(provider))
                .Replace("{QUARTER}", Quarter.ToString())
                .Replace("{NUMQUARTER}", Quarter.ToInt32().ToString(provider))
                .Replace("{WIND}", Wind.ToString(provider))
                .Replace("{POWER}", Power.ToString(provider))
                .ToString();
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct Unsafe
        {
            public static implicit operator PhysicsInfo(Unsafe value)
            {
                PhysicsBinding binding = value.Binding;
                return new PhysicsInfo(binding, value.Angle, value.Wind, value.Power, value.Resolution);
            }
            
            public static implicit operator Unsafe(PhysicsInfo value)
            {
                return new Unsafe
                {
                    Binding = value.Binding.Unsafe(),
                    Angle = value.Angle,
                    Wind = value.Wind,
                    Power = value.Power,
                    Resolution = value.Resolution
                };
            }
            
            public PhysicsBinding.Unsafe Binding { get; init; }
            public Int16 Angle { get; init; }
            public Int16 Wind { get; init; }
            public Int16 Power { get; init; }
            public Rectangle Resolution { get; init; }

            public Int16 Degree
            {
                get
                {
                    return ToDegree(Angle);
                }
            }

            public Quarter Quarter
            {
                get
                {
                    return ToQuarter(Angle);
                }
            }
        
            public Point Center
            {
                get
                {
                    return ToCenter(Resolution);
                }
            }
        }
    }
}