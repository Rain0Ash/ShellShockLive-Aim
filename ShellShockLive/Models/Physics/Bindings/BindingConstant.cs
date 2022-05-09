// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Physics.Bindings
{
    [Serializable]
    public readonly struct BindingConstant<T>
    {
        public static implicit operator T(BindingConstant<T> value)
        {
            return value.Start;
        }
        
        public T Minimum { get; }
        public T Maximum { get; }
        public T Start { get; }
        
        public BindingConstant(T minimum, T maximum, T start)
        {
            Minimum = minimum;
            Maximum = maximum;
            Start = start;
        }
    }
}