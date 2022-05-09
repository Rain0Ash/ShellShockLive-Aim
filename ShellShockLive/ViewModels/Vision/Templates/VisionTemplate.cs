// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NetExtender.Types.Drawing.Colors;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;

namespace ShellShockLive.ViewModels.Vision
{
    public sealed record VisionTemplate
    {
        public static implicit operator Byte(VisionTemplate? value)
        {
            return value?.Epsilon ?? default;
        }
        
        public static implicit operator ReadOnlySpan<Color>(VisionTemplate? value)
        {
            return value?.Values ?? default;
        }

        public Int32 Limit { get; init; } = 30;
        public Byte Epsilon { get; init; } = 1;
        private Color[] Values { get; }

        public VisionTemplate()
        {
            Values = Array.Empty<Color>();
        }

        public VisionTemplate(IEnumerable<Color> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            Values = values.ToArray();
        }

        public Boolean In(ColorPoint point)
        {
            return In(point.Color);
        }

        public Boolean In(Color color)
        {
            foreach (Color request in this)
            {
                if (color.DifferenceCie1976(request) < Epsilon)
                {
                    return true;
                }
            }

            return false;
        }

        public Task<TResult> PointsAsync<TResult>(DirectBitmap.Enumerator enumerator, Func<ParallelQuery<ColorPoint>, TResult> selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return Task.Run(() => selector(enumerator.AsParallel()));
        }

        public Task<ColorPoint[]> PointsInAsync(DirectBitmap.Enumerator enumerator)
        {
            return PointsInAsync(enumerator, ParallelEnumerable.ToArray);
        }

        public Task<TResult> PointsInAsync<TResult>(DirectBitmap.Enumerator enumerator, Func<ParallelQuery<ColorPoint>, TResult> selector)
        {
            if (selector is null)
            {
                throw new ArgumentNullException(nameof(selector));
            }

            return Task.Run(() => selector(enumerator.AsParallel().Where(In)));
        }

        public ReadOnlySpan<Color>.Enumerator GetEnumerator()
        {
            ReadOnlySpan<Color> template = this;
            return template.GetEnumerator();
        }
    }
}