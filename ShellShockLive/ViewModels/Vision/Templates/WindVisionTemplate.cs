// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;

namespace ShellShockLive.ViewModels.Vision
{
    public class WindVisionTemplate : TextVisionTemplate
    {
        public override VisionTemplate Background { get; init; } = new VisionTemplate(new[]
        {
            Color.FromArgb(185, 188, 208),
            Color.FromArgb(181, 190, 203),
            Color.FromArgb(179, 189, 198),
            Color.FromArgb(176, 186, 197),
            Color.FromArgb(176, 185, 193),
            Color.FromArgb(171, 180, 192),
            Color.FromArgb(156, 160, 179),
            Color.FromArgb(110, 110, 130),
        }) { Epsilon = 4 };

        public override VisionTemplate Foreground { get; init; } = new VisionTemplate();
    }
}