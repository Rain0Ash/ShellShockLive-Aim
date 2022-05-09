// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Globalization;
using NetExtender.Utilities.Types;
using NetExtender.WindowsPresentation.Types.Converters;

namespace ShellShockLive
{
    public class QuarterViewConverter : WindowConverter<ShellShockLiveWindow>
    {
        public override Object? Convert(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            return value is Quarter quarter ? (Int32) quarter : value;
        }

        public override Object? ConvertBack(Object? value, Type? targetType, Object? parameter, CultureInfo? culture)
        {
            if (targetType != typeof(Quarter))
            {
                throw new NotSupportedException();
            }

            Quarter? result = value switch
            {
                Int32 integer => (Quarter) integer,
                IConvertible convertible => (Quarter) convertible.ToInt32(),
                _ => default(Quarter?)
            };

            return result.HasValue && result.Value.In() ? result.Value : default(Object?);
        }
    }
}