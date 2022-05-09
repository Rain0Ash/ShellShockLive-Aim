// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Globalization;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using NetExtender.WindowsPresentation.Types.Converters;

namespace ShellShockLive
{
    public class AngleViewConverter : WindowConverter<ShellShockLiveWindow>
    {
        public override Object? Convert(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            if (value is not Int16 number)
            {
                return value;
            }

            Int16 angle = (Int16) number.ToQuarterDegree(out Quarter quarter);
            return $@"{angle}° ({(Int16) quarter})";
        }

        public override Object? ConvertBack(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            if (targetType != typeof(Int16))
            {
                throw new NotSupportedException();
            }

            return Int16.TryParse(value?.ToString(), out Int16 angle) ? angle : value;
        }
    }
}