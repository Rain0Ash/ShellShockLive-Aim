// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Configuration.Common;
using NetExtender.Localization.Common;
using NetExtender.Localization.Properties.Interfaces;
using NetExtender.Localization.Property.Localization.Initializers;
using NetExtender.Localization.Utilities;
using NetExtender.Types.Culture;

namespace ShellShockLive
{
    public partial class ShellShockLiveWindow
    {
        public override WindowLocalization Localization
        {
            get
            {
                return WindowLocalization.Instance;
            }
        }
        
        public class WindowLocalization : LocalizationAutoInitializerSingleton<WindowLocalization>
        {
            public IReadOnlyLocalizationProperty Title { get; } =
                ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Title", new LocalizationContainer
                {
                    { CultureIdentifier.En, "ShellShockLive" },
                    { CultureIdentifier.Ru, "ShellShockLive" }
                }, ConfigPropertyOptions.Caching, "Windows", "Main");
            
            public IReadOnlyLocalizationProperty Angle { get; } =
                ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Angle", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Angle" },
                    { CultureIdentifier.Ru, "Угол" }
                }, ConfigPropertyOptions.Caching, "Windows", "Physics");

            public IReadOnlyLocalizationProperty Quarter { get; } =
                ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Quarter", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Quarter" },
                    { CultureIdentifier.Ru, "Квартиль" }
                }, ConfigPropertyOptions.Caching, "Windows", "Physics");

            public IReadOnlyLocalizationProperty Wind { get; } =
                ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Wind", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Wind" },
                    { CultureIdentifier.Ru, "Ветер" }
                }, ConfigPropertyOptions.Caching, "Windows", "Physics");
            
            public IReadOnlyLocalizationProperty Power { get; } =
                ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Power", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Power" },
                    { CultureIdentifier.Ru, "Сила" }
                }, ConfigPropertyOptions.Caching, "Windows", "Physics");
        }
    }
}