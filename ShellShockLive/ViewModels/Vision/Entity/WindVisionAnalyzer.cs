// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NetExtender.Types.Culture;
using NetExtender.Types.Monads;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.Utilities.ViewModels.Vision;
using ShellShockLive.ViewModels.Vision.Bindings;
using Tesseract;

namespace ShellShockLive.ViewModels.Vision
{
    public class WindVisionAnalyzer : DigitVisionAnalyzer<Int16>
    {
        protected override WindVisionTemplate Template { get; }
        
        public WindVisionAnalyzer()
            : this(null)
        {
        }
        
        public WindVisionAnalyzer(WindVisionTemplate? template)
        {
            Template = template ?? new WindVisionTemplate();
        }

        public override async Task<Maybe<Int16>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            Maybe<Int16> center = await AnalyzeCenterAsync(screen, bitmap, binding).ConfigureAwait(false);

            if (!center)
            {
                return default;
            }

            if (center == 0)
            {
                return center;
            }

            Boolean left = await AnalyzeSideAsync(screen, bitmap, binding.Wind.Left, binding).ConfigureAwait(false);
            if (left)
            {
                return (Int16) (-center.Value);
            }

            Boolean right = await AnalyzeSideAsync(screen, bitmap, binding.Wind.Right, binding).ConfigureAwait(false);
            return right ? center : default;
        }

        protected virtual Task<Boolean> AnalyzeSideAsync(Rectangle screen, DirectBitmap bitmap, Rectangle rectangle, VisionBinding binding)
        {
            return Template.Background.PointsInAsync(bitmap.GetEnumerator(rectangle), query => query.Skip(Template.Background.Limit).Any());
        }

        protected virtual async Task<Maybe<Int16>> AnalyzeCenterAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            if (!await Template.Background.PointsInAsync(bitmap.GetEnumerator(binding.Wind.Center), query => query.Skip(Template.Background.Limit).Any()).ConfigureAwait(false))
            {
                return 0;
            }

            using TesseractEngine? engine = Engine(CultureIdentifier.En);

            if (engine is null)
            {
                return default;
            }
            
            using Bitmap image = bitmap.Clone(binding.Wind.Text);
            using Page page = await engine.ProcessAsync(image, PageSegMode.SingleLine).ConfigureAwait(false);
            String text = page.GetText().Trim();

            Int16 wind = 0;
            if (!String.IsNullOrEmpty(text) && Int16.TryParse(text, out wind) && wind.InRange(binding.Physics.Wind.Minimum, binding.Physics.Wind.Maximum))
            {
                return wind;
            }

            if (!ShellShockLive.Settings.Instance.DebugAnalysis.Value)
            {
                return default;
            }

            String filename = $"Analysis/WindAnalysis.{DateTime.UtcNow:dd.MM.yy hh.mm.ss}{(wind != 0 ? '|' + wind : String.Empty)}.png";
            image.Save(filename);

            return default;
        }
    }
}