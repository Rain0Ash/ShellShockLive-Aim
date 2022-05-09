// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Physics.Guidances
{
    [Serializable]
    public readonly struct GuidanceStep
    {
        public static implicit operator GuidanceStep(Single value)
        {
            return new GuidanceStep(value);
        }

        public static Single operator *(GuidanceStep first, Int32 second)
        {
            return first.Step * second;
        }

        public static Single operator *(GuidanceStep first, UInt32 second)
        {
            return first.Step * second;
        }
        
        public UInt32 Iterations { get; }
        public Single Step { get; }
        public Single Epsilon { get; init; } = 3;

        public GuidanceStep(Single step)
            : this(UInt16.MaxValue, step)
        {
        }

        public GuidanceStep(Int32 iterations, Single step)
            : this(iterations >= 0 ? (UInt32) iterations : throw new ArgumentOutOfRangeException(nameof(iterations), iterations, null), step)
        {
        }

        public GuidanceStep(UInt32 iterations, Single step)
        {
            Iterations = iterations;
            Step = step;
        }

        public GuidanceStep With(Int32 iterations)
        {
            return new GuidanceStep(iterations, Step);
        }

        public GuidanceStep With(UInt32 iterations)
        {
            return new GuidanceStep(iterations, Step);
        }

        public GuidanceStep With(Single step)
        {
            return new GuidanceStep(Iterations, step);
        }
    }
}