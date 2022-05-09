// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class TextVisionTemplate : ColorVisionTemplate
    {
        public abstract VisionTemplate Background { get; init; }

        public virtual VisionTemplate Foreground { get; init; } = new VisionTemplate(new[]
        {
            Color.FromArgb(250, 250, 250),
            Color.FromArgb(240, 240, 240),
            Color.FromArgb(230, 230, 230),
            Color.FromArgb(220, 220, 220),
            Color.FromArgb(210, 210, 210),
            Color.FromArgb(200, 200, 200)
        }) { Epsilon = 15 };

        public sealed override VisionTemplate Template
        {
            get
            {
                return Background;
            }
            init
            {
                Background = value;
            }
        }
    }
}