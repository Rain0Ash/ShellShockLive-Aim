// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Globalization;
using NetExtender.WindowsPresentation.Types.Converters;
using ShellShockLive.ViewModels.Physics;

namespace ShellShockLive
{
    public class PowerViewConverter : WindowConverter<ShellShockLiveWindow>
    {
        public override Object? Convert(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            return value is Int16 number ? PhysicsViewModel.Instance.ToPower(number) + "%" : value;
        }

        public override Object? ConvertBack(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            if (targetType != typeof(Int16))
            {
                throw new NotSupportedException();
            }

            return Int16.TryParse(value?.ToString(), out Int16 power) ? power : value;
        }
    }
}