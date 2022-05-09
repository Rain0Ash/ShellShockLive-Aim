// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Configuration.Common;
using NetExtender.Localization.Common;
using NetExtender.Localization.Properties.Interfaces;
using NetExtender.Localization.Property.Localization.Initializers;
using NetExtender.Localization.Utilities;
using NetExtender.Types.Culture;

namespace ShellShockLive.View
{
    public partial class SettingsWindow
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
                Settings.Instance.Localization.GetLocalizationProperty("Title", new LocalizationContainer
                {
                    { CultureIdentifier.En, "ShellShockLive: Settings" },
                    { CultureIdentifier.Ru, "ShellShockLive: Настройки" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
        
            public IReadOnlyLocalizationProperty Language { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Language", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Language" },
                    { CultureIdentifier.Ru, "Язык" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
        
            public IReadOnlyLocalizationProperty Volume { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Volume", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Volume" },
                    { CultureIdentifier.Ru, "Громкость" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty Scanning { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Scanning", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Scan every: {0} ms." },
                    { CultureIdentifier.Ru, "Сканировать каждые: {0} мc." }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty WithoutScanning { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("WithoutScanning", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Scanning inactive!" },
                    { CultureIdentifier.Ru, "Сканирование отключено!" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty Transparent { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Transparent", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Transparency" },
                    { CultureIdentifier.Ru, "Прозрачность" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
        
            public IReadOnlyLocalizationProperty DebugAnalysis { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("ShowGrid", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Debug analysis" },
                    { CultureIdentifier.Ru, "Отладка анализов" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
        
            public IReadOnlyLocalizationProperty ShowGrid { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("ShowGrid", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Show debug grid" },
                    { CultureIdentifier.Ru, "Отобразить сетку" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty Save { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Save", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Save" },
                    { CultureIdentifier.Ru, "Сохранить" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty Reset { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("Reset", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Reset" },
                    { CultureIdentifier.Ru, "Сбросить" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty ResetTitle { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("ResetTitle", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Reset settings" },
                    { CultureIdentifier.Ru, "Сбросить настройки" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
            
            public IReadOnlyLocalizationProperty ResetMessage { get; } =
                Settings.Instance.Localization.GetLocalizationProperty("ResetMessage", new LocalizationContainer
                {
                    { CultureIdentifier.En, "Are you sure you want to reset settings?" },
                    { CultureIdentifier.Ru, "Вы уверены, что хотите сбросить настройки?" }
                }, ConfigPropertyOptions.Caching, "Windows", "Settings");
        }
    }
}