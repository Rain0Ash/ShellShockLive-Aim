// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NetExtender.Types.Culture;
using NetExtender.Types.Monads;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.Utilities.ViewModels.Vision;
using ShellShockLive.ViewModels.Vision.Bindings;
using Tesseract;

namespace ShellShockLive.ViewModels.Vision
{
    public class FuelVisionAnalyzer : DigitVisionAnalyzer<UInt16>
    {
        protected override FuelVisionTemplate Template { get; }
        
        public FuelVisionAnalyzer()
            : this(null)
        {
        }
        
        public FuelVisionAnalyzer(FuelVisionTemplate? template)
        {
            Template = template ?? new FuelVisionTemplate();
        }

        public override async Task<Maybe<UInt16>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            if (!await Template.Background.PointsInAsync(bitmap.GetEnumerator(binding.Fuel.Image), query => query.Skip(Template.Background.Limit).Any()).ConfigureAwait(false))
            {
                return default;
            }

            using Bitmap image = bitmap.Clone(binding.Fuel.Text);
            using Bitmap? analyze = Text(image);
            
            String? main = null;
            LocalizationIdentifier current = default;
            foreach (LocalizationIdentifier identifier in this.Where(identifier => current != identifier))
            {
                using TesseractEngine? engine = identifier == LocalizationIdentifier.Invariant ? Engine(out current) : Engine(identifier);

                if (engine is null)
                {
                    continue;
                }
                
                using Page page = await engine.ProcessAsync(analyze ?? image, PageSegMode.SingleLine).ConfigureAwait(false);
                String text = page.GetText().Trim();

                if (!String.IsNullOrEmpty(text) && UInt16.TryParse(text, out UInt16 fuel))
                {
                    return fuel;
                }

                main ??= text;
            }
            
            if (!ShellShockLive.Settings.Instance.DebugAnalysis.Value)
            {
                return default;
            }
            
            String filename = $"Analysis/FuelAnalysis.{DateTime.UtcNow:dd.MM.yy hh.mm.ss}{main}.png";
            (analyze ?? image).Save(filename);

            return default;
        }
    }
}