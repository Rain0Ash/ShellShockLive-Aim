// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Threading.Tasks;
using NetExtender.Utilities.Types;
using NetExtender.Utilities.Windows;
using NetExtender.Windows.Types;
using ShellShockLive.ViewModels.Game;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    public class VisionController
    {
        public GameController Game { get; } = new GameController();
        public VisionAnalyzer Analyzer { get; } = new VisionAnalyzer();
        public ScreenshotType ScreenshotType { get; init; } = ScreenshotType.Content;
        
        public Bitmap? MakeScreenshot(out Rectangle screen)
        {
            return MakeScreenshot(out screen, out _, null);
        }

        public Bitmap? MakeScreenshot(out Rectangle screen, VisionBinding? binding)
        {
            return MakeScreenshot(out screen, out _, binding);
        }

        public virtual Bitmap? MakeScreenshot(out Rectangle screen, out Boolean outbound, VisionBinding? binding)
        {
            IntPtr window = Game.Window(binding, out screen, out outbound);

            if (window != IntPtr.Zero && !outbound)
            {
                return ScreenshotUtilities.MakeScreenshot(window, ScreenshotType);
            }

            screen = default;
            return null;
        }
        
        public virtual async Task<VisionResult> VisionAsync(VisionType type, VisionBinding binding)
        {
            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            using Bitmap? screenshot = MakeScreenshot(out Rectangle screen, binding);
            return screenshot is not null ? await VisionAsync(type, screen, screenshot, binding).ConfigureAwait(false) : default;
        }

        public virtual async Task<VisionResult> VisionAsync(VisionType type, Rectangle screen, Bitmap screenshot, VisionBinding binding)
        {
            if (screenshot is null)
            {
                throw new ArgumentNullException(nameof(screenshot));
            }

            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }

            using DirectBitmap bitmap = screenshot.Direct();
            return await Analyzer.AnalyzeAsync(type, screen, bitmap, binding).ConfigureAwait(false);
        }
    }
}