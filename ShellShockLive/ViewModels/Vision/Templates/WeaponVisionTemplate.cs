// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

namespace ShellShockLive.ViewModels.Vision
{
    public class WeaponVisionTemplate : TextVisionTemplate
    {
        public override VisionTemplate Background { get; init; } = new VisionTemplate();
    }
}