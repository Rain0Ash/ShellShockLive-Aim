// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;

namespace ShellShockLive.ViewModels.Vision
{
    public class FuelVisionTemplate : TextVisionTemplate
    {
        public override VisionTemplate Background { get; init; } = new VisionTemplate(new[]
        {
            Color.FromArgb(250, 0, 0),
            Color.FromArgb(240, 0, 0),
            Color.FromArgb(230, 0, 0),
            Color.FromArgb(220, 0, 0),
            Color.FromArgb(210, 0, 0),
            Color.FromArgb(200, 0, 0),
        }) { Epsilon = 8 };
    }
}