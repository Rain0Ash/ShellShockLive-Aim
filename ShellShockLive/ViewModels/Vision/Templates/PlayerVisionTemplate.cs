// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;

namespace ShellShockLive.ViewModels.Vision
{
    public class PlayerVisionTemplate : ColorVisionTemplate
    {
        public override VisionTemplate Template { get; init; } = new VisionTemplate(new []
        {
            Color.FromArgb(82,255,84),
            Color.FromArgb(44,255,54),
            Color.FromArgb(41,255,44),
            Color.FromArgb(37,246,39),
            Color.FromArgb(32,241,35),
            Color.FromArgb(34,239,42),
            Color.FromArgb(12,237,48),
            Color.FromArgb(6,228,37),
            Color.FromArgb(20,226,22),
            Color.FromArgb(6,209,8),
            Color.FromArgb(3,205,16),
            Color.FromArgb(0,205,11),
            Color.FromArgb(0,201,10),
            Color.FromArgb(0,198,7),
            Color.FromArgb(0,196,5),
            Color.FromArgb(0,195,5),
            Color.FromArgb(0,192,13),
            Color.FromArgb(0,190,17),
            Color.FromArgb(0,190,6),
            Color.FromArgb(0,189,6),
            Color.FromArgb(0,187,20),
            Color.FromArgb(0,186,3),
            Color.FromArgb(0,185,7),
            Color.FromArgb(0,184,17),
            Color.FromArgb(0,182,18),
            Color.FromArgb(0,174,21),
            Color.FromArgb(2,174,15),
            Color.FromArgb(0,169,19),
            Color.FromArgb(0,167,16),
            Color.FromArgb(0,163,21),
            Color.FromArgb(0,161,20),
            Color.FromArgb(9,160,29),
            Color.FromArgb(0,159,24),
            Color.FromArgb(0,146,23),
            Color.FromArgb(0,143,18),
            Color.FromArgb(0,129,28)
        }) { Epsilon = 2 };
    }
}