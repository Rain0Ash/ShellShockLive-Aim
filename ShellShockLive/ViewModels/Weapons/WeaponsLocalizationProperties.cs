// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NetExtender.Configuration.Common;
using NetExtender.Localization.Common;
using NetExtender.Localization.Properties.Interfaces;
using NetExtender.Localization.Utilities;
using NetExtender.Types.Culture;

namespace ShellShockLive.ViewModels.Weapons
{
    public partial class WeaponsLocalization
    {
        public IReadOnlyLocalizationProperty None { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("None", new LocalizationContainer
            {
                { CultureIdentifier.En, "None" },
                { CultureIdentifier.Ru, "Отсутствует" }
            }, ConfigPropertyOptions.Caching, "Weapons");
        
        #region Guidance

        public IReadOnlyLocalizationProperty Parabola { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Parabola", new LocalizationContainer
            {
                { CultureIdentifier.En, "Parabola Guidance" },
                { CultureIdentifier.Ru, "Парабольная наводка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Direct { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Direct", new LocalizationContainer
            {
                { CultureIdentifier.En, "Direct Guidance" },
                { CultureIdentifier.Ru, "Прямая наводка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Shot

        public IReadOnlyLocalizationProperty Shot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shot" },
                { CultureIdentifier.Ru, "Выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BigShot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BigShot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Big Shot" },
                { CultureIdentifier.Ru, "Средний выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyShot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyShot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Shot" },
                { CultureIdentifier.Ru, "Мощный выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MassiveShot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MassiveShot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Massive Shot" },
                { CultureIdentifier.Ru, "Массивный выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Ball

        public IReadOnlyLocalizationProperty ThreeBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ThreeBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Three-Ball" },
                { CultureIdentifier.Ru, "3-выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FiveBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FiveBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Five-Ball" },
                { CultureIdentifier.Ru, "5-выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ElevenBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ElevenBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Eleven-Ball" },
                { CultureIdentifier.Ru, "11-выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TwentyFiveBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TwentyFiveBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "TwentyFive-Ball" },
                { CultureIdentifier.Ru, "25-выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bounce

        public IReadOnlyLocalizationProperty OneBounce { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("OneBounce", new LocalizationContainer
            {
                { CultureIdentifier.En, "One-Bounce" },
                { CultureIdentifier.Ru, "Раз-отскок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ThreeBounce { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ThreeBounce", new LocalizationContainer
            {
                { CultureIdentifier.En, "Three-Bounce" },
                { CultureIdentifier.Ru, "Три-отскок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FiveBounce { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FiveBounce", new LocalizationContainer
            {
                { CultureIdentifier.En, "Five-Bounce" },
                { CultureIdentifier.Ru, "Пять-отскок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SevenBounce { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SevenBounce", new LocalizationContainer
            {
                { CultureIdentifier.En, "Seven-Bounce" },
                { CultureIdentifier.Ru, "Семь-отскок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Digger

        public IReadOnlyLocalizationProperty Digger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Digger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Digger" },
                { CultureIdentifier.Ru, "Копатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaDigger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaDigger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mega-Digger" },
                { CultureIdentifier.Ru, "Мегакопатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Excavation { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Excavation", new LocalizationContainer
            {
                { CultureIdentifier.En, "Excavation" },
                { CultureIdentifier.Ru, "Экскаватор" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Grenade

        public IReadOnlyLocalizationProperty Grenade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Grenade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Grenade" },
                { CultureIdentifier.Ru, "Граната" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TriNade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TriNade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tri-Nade" },
                { CultureIdentifier.Ru, "3-граната" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MultiNade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MultiNade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Multi-Nade" },
                { CultureIdentifier.Ru, "Мульти-граната" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty GrenadeStorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GrenadeStorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Grenade Storm" },
                { CultureIdentifier.Ru, "Буря гранат" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Stream

        public IReadOnlyLocalizationProperty Stream { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Stream", new LocalizationContainer
            {
                { CultureIdentifier.En, "Stream" },
                { CultureIdentifier.Ru, "Поток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Creek { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Creek", new LocalizationContainer
            {
                { CultureIdentifier.En, "Creek" },
                { CultureIdentifier.Ru, "Ручей" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty River { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("River", new LocalizationContainer
            {
                { CultureIdentifier.En, "River" },
                { CultureIdentifier.Ru, "Река" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Tsunami { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tsunami", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tsunami" },
                { CultureIdentifier.Ru, "Цунами" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Flame

        public IReadOnlyLocalizationProperty Flame { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flame", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flame" },
                { CultureIdentifier.Ru, "Огонь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Blaze { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Blaze", new LocalizationContainer
            {
                { CultureIdentifier.En, "Blaze" },
                { CultureIdentifier.Ru, "Пламя" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Inferno { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Inferno", new LocalizationContainer
            {
                { CultureIdentifier.En, "Inferno" },
                { CultureIdentifier.Ru, "Преисподняя" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Roller

        public IReadOnlyLocalizationProperty Roller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Roller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Roller" },
                { CultureIdentifier.Ru, "Каток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyRoller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyRoller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Roller" },
                { CultureIdentifier.Ru, "Тяжелый каток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Groller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Groller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Groller" },
                { CultureIdentifier.Ru, "Суперкаток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BackRoller

        public IReadOnlyLocalizationProperty BackRoller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BackRoller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Back-Roller" },
                { CultureIdentifier.Ru, "Назад-каток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyBackRoller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyBackRoller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Back-Roller" },
                { CultureIdentifier.Ru, "Тяжелый назад-каток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BackGroller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BackGroller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Back-Groller" },
                { CultureIdentifier.Ru, "Назад-суперкаток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Splitter

        public IReadOnlyLocalizationProperty Splitter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Splitter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Splitter" },
                { CultureIdentifier.Ru, "Шрапнель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleSplitter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleSplitter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double-Splitter" },
                { CultureIdentifier.Ru, "Двойная шрапнель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperSplitter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperSplitter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super-Splitter" },
                { CultureIdentifier.Ru, "Супершрапнель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SplitterChain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SplitterChain", new LocalizationContainer
            {
                { CultureIdentifier.En, "SplitterChain" },
                { CultureIdentifier.Ru, "Ультрашрапнель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Breaker

        public IReadOnlyLocalizationProperty Breaker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Breaker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Breaker" },
                { CultureIdentifier.Ru, "Осколочный" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleBreaker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleBreaker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double-Breaker" },
                { CultureIdentifier.Ru, "Двойной осколочный" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperBreaker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperBreaker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super-Breaker" },
                { CultureIdentifier.Ru, "Супер-осколочный" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BreakerChain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BreakerChain", new LocalizationContainer
            {
                { CultureIdentifier.En, "BreakerChain" },
                { CultureIdentifier.Ru, "Ультра-осколочный" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Twinkler

        public IReadOnlyLocalizationProperty Twinkler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Twinkler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Twinkler" },
                { CultureIdentifier.Ru, "Искорка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Sparkler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sparkler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sparkler" },
                { CultureIdentifier.Ru, "Светлячок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Crackler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Crackler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Crackler" },
                { CultureIdentifier.Ru, "Фейерверк" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sniper

        public IReadOnlyLocalizationProperty Sniper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sniper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sniper" },
                { CultureIdentifier.Ru, "Прицел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SubSniper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SubSniper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sub-Sniper" },
                { CultureIdentifier.Ru, "Точный прицел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SmartSnipe { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SmartSnipe", new LocalizationContainer
            {
                { CultureIdentifier.En, "Smart Snipe" },
                { CultureIdentifier.Ru, "Умный прицел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Cactus

        public IReadOnlyLocalizationProperty Cactus { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Cactus", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cactus" },
                { CultureIdentifier.Ru, "Кактус" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty CactusStrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CactusStrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cactus Strike" },
                { CultureIdentifier.Ru, "Кактус-бомбы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bulger

        public IReadOnlyLocalizationProperty Bulger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bulger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bulger" },
                { CultureIdentifier.Ru, "Бугор" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BigBulger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BigBulger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Big Bulger" },
                { CultureIdentifier.Ru, "Большой бугор" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sinkhole

        public IReadOnlyLocalizationProperty Sinkhole { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sinkhole", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sinkhole" },
                { CultureIdentifier.Ru, "Выгребатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AreaStrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AreaStrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Area Strike" },
                { CultureIdentifier.Ru, "Удар по площади" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AreaAttack { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AreaAttack", new LocalizationContainer
            {
                { CultureIdentifier.En, "Area Attack" },
                { CultureIdentifier.Ru, "Атака по площади" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region RapidFire

        public IReadOnlyLocalizationProperty RapidFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("RapidFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "RapidFire" },
                { CultureIdentifier.Ru, "Скорострел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Shotgun { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shotgun", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shotgun" },
                { CultureIdentifier.Ru, "Дробовик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BurstFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BurstFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "Burst-Fire" },
                { CultureIdentifier.Ru, "Очередь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty GatlingGun { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GatlingGun", new LocalizationContainer
            {
                { CultureIdentifier.En, "Gatling Gun" },
                { CultureIdentifier.Ru, "Гатлинг" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Tunneler

        public IReadOnlyLocalizationProperty Tunneler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tunneler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tunneler" },
                { CultureIdentifier.Ru, "Туннельщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Torpedoes { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Torpedoes", new LocalizationContainer
            {
                { CultureIdentifier.En, "Torpedoes" },
                { CultureIdentifier.Ru, "Торпеды" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TunnelStrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TunnelStrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tunnel Strike" },
                { CultureIdentifier.Ru, "Удар из туннеля" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaTunneler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaTunneler", new LocalizationContainer
            {
                { CultureIdentifier.En, "MegaTunneler" },
                { CultureIdentifier.Ru, "Мегатуннельщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Horizon

        public IReadOnlyLocalizationProperty Horizon { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Horizon", new LocalizationContainer
            {
                { CultureIdentifier.En, "Horizon" },
                { CultureIdentifier.Ru, "Горизонт" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Sweeper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sweeper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sweeper" },
                { CultureIdentifier.Ru, "Горизонталь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region AirStrike

        public IReadOnlyLocalizationProperty AirStrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AirStrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Air Strike" },
                { CultureIdentifier.Ru, "Удар с воздуха" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HelicopterStrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HelicopterStrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Helicopter Strike" },
                { CultureIdentifier.Ru, "Удар с вертолета" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AC130 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AC130", new LocalizationContainer
            {
                { CultureIdentifier.En, "AC-130" },
                { CultureIdentifier.Ru, "АС-130" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Artillery { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Artillery", new LocalizationContainer
            {
                { CultureIdentifier.En, "Artillery" },
                { CultureIdentifier.Ru, "Артиллерия" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Flower

        public IReadOnlyLocalizationProperty Flower { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flower", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flower" },
                { CultureIdentifier.Ru, "Цветок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Bouquet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bouquet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bouquet" },
                { CultureIdentifier.Ru, "Букет" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Guppies

        public IReadOnlyLocalizationProperty Guppies { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Guppies", new LocalizationContainer
            {
                { CultureIdentifier.En, "Guppies" },
                { CultureIdentifier.Ru, "Гуппи" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Minnows { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Minnows", new LocalizationContainer
            {
                { CultureIdentifier.En, "Minnows" },
                { CultureIdentifier.Ru, "Караси" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Goldfish { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Goldfish", new LocalizationContainer
            {
                { CultureIdentifier.En, "Goldfish" },
                { CultureIdentifier.Ru, "Золотые рыбки" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Earthquake

        public IReadOnlyLocalizationProperty Earthquake { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Earthquake", new LocalizationContainer
            {
                { CultureIdentifier.En, "Earthquake" },
                { CultureIdentifier.Ru, "Землетрясение" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaQuake { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaQuake", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mega-Quake" },
                { CultureIdentifier.Ru, "Мегатрясение" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Banana

        public IReadOnlyLocalizationProperty Banana { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Banana", new LocalizationContainer
            {
                { CultureIdentifier.En, "Banana" },
                { CultureIdentifier.Ru, "Банан" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BananaSplit { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BananaSplit", new LocalizationContainer
            {
                { CultureIdentifier.En, "Banana Split" },
                { CultureIdentifier.Ru, "Банана-сплит" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BananaBunch { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BananaBunch", new LocalizationContainer
            {
                { CultureIdentifier.En, "Banana Bunch" },
                { CultureIdentifier.Ru, "Гроздь бананов" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Snake

        public IReadOnlyLocalizationProperty Snake { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Snake", new LocalizationContainer
            {
                { CultureIdentifier.En, "Snake" },
                { CultureIdentifier.Ru, "Змея" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Python { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Python", new LocalizationContainer
            {
                { CultureIdentifier.En, "Python" },
                { CultureIdentifier.Ru, "Питон" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Cobra { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Cobra", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cobra" },
                { CultureIdentifier.Ru, "Кобра" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Zipper

        public IReadOnlyLocalizationProperty Zipper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Zipper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Zipper" },
                { CultureIdentifier.Ru, "Вжик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleZipper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleZipper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double Zipper" },
                { CultureIdentifier.Ru, "Двойной вжик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ZipperQuad { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ZipperQuad", new LocalizationContainer
            {
                { CultureIdentifier.En, "Zipper Quad" },
                { CultureIdentifier.Ru, "Квадро-вжик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bounsplode

        public IReadOnlyLocalizationProperty Bounsplode { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bounsplode", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bounsplode" },
                { CultureIdentifier.Ru, "Скакун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleBounsplode { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleBounsplode", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double-Bounsplode" },
                { CultureIdentifier.Ru, "Двойной скакун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TripleBounsplode { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TripleBounsplode", new LocalizationContainer
            {
                { CultureIdentifier.En, "Triple-Bounsplode" },
                { CultureIdentifier.Ru, "Тройной скакун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pistol

        public IReadOnlyLocalizationProperty Glock { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Glock", new LocalizationContainer
            {
                { CultureIdentifier.En, "Glock" },
                { CultureIdentifier.Ru, "Глок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty M9 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("M9", new LocalizationContainer
            {
                { CultureIdentifier.En, "M9" },
                { CultureIdentifier.Ru, "М9" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DesertEagle { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DesertEagle", new LocalizationContainer
            {
                { CultureIdentifier.En, "Desert Eagle" },
                { CultureIdentifier.Ru, "Дезерт Игл" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region DeadWeight

        public IReadOnlyLocalizationProperty DeadWeight { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DeadWeight", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dead Weight" },
                { CultureIdentifier.Ru, "Автоспуск" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DeadRiser { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DeadRiser", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dead Riser" },
                { CultureIdentifier.Ru, "Автоподъем" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pixel

        public IReadOnlyLocalizationProperty Pixel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pixel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pixel" },
                { CultureIdentifier.Ru, "Пиксель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaPixel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaPixel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mega-Pixel" },
                { CultureIdentifier.Ru, "Мегапиксель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperPixel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperPixel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super-Pixel" },
                { CultureIdentifier.Ru, "Супер-пиксель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty UltraPixel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("UltraPixel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ultra-Pixel" },
                { CultureIdentifier.Ru, "Ультра-пиксель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion
        
        #region Builder

        public IReadOnlyLocalizationProperty Builder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Builder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Builder" },
                { CultureIdentifier.Ru, "Строитель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaBuilder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaBuilder", new LocalizationContainer
            {
                { CultureIdentifier.En, "MegaBuilder" },
                { CultureIdentifier.Ru, "Мегастроитель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Construction { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Construction", new LocalizationContainer
            {
                { CultureIdentifier.En, "Construction" },
                { CultureIdentifier.Ru, "Construction" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Static

        public IReadOnlyLocalizationProperty Static { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Static", new LocalizationContainer
            {
                { CultureIdentifier.En, "Static" },
                { CultureIdentifier.Ru, "Электро" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty StaticLink { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StaticLink", new LocalizationContainer
            {
                { CultureIdentifier.En, "Static Link" },
                { CultureIdentifier.Ru, "Электро-связь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty StaticChain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StaticChain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Static Chain" },
                { CultureIdentifier.Ru, "Электро-цепь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Molehill

        public IReadOnlyLocalizationProperty Molehill { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Molehill", new LocalizationContainer
            {
                { CultureIdentifier.En, "Molehill" },
                { CultureIdentifier.Ru, "Крот" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Moles { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Moles", new LocalizationContainer
            {
                { CultureIdentifier.En, "Moles" },
                { CultureIdentifier.Ru, "Три крота" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Counter

        public IReadOnlyLocalizationProperty Counter3000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Counter3000", new LocalizationContainer
            {
                { CultureIdentifier.En, "Counter 3000" },
                { CultureIdentifier.Ru, "3 залпа" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Counter4000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Counter4000", new LocalizationContainer
            {
                { CultureIdentifier.En, "Counter 4000" },
                { CultureIdentifier.Ru, "4 залпа" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Counter5000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Counter5000", new LocalizationContainer
            {
                { CultureIdentifier.En, "Counter 5000" },
                { CultureIdentifier.Ru, "5 залпов" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Counter6000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Counter6000", new LocalizationContainer
            {
                { CultureIdentifier.En, "Counter 6000" },
                { CultureIdentifier.Ru, "6 залпов" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region HoverBall

        public IReadOnlyLocalizationProperty HoverBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HoverBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Hover-Ball" },
                { CultureIdentifier.Ru, "Гравишар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyHoverBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyHoverBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Hover-Ball" },
                { CultureIdentifier.Ru, "Тяжелый гравишар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Ringer

        public IReadOnlyLocalizationProperty Ringer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Ringer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ringer" },
                { CultureIdentifier.Ru, "Кольцо" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyRinger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyRinger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Ringer" },
                { CultureIdentifier.Ru, "Тяжелое кольцо" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty OlympicRinger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("OlympicRinger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Olympic Ringer" },
                { CultureIdentifier.Ru, "Олимпийские кольца" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Rainbow

        public IReadOnlyLocalizationProperty Rainbow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rainbow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rainbow" },
                { CultureIdentifier.Ru, "Радуга" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaRainbow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaRainbow", new LocalizationContainer
            {
                { CultureIdentifier.En, "MegaRainbow" },
                { CultureIdentifier.Ru, "Мегарадуга" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Moons

        public IReadOnlyLocalizationProperty Moons { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Moons", new LocalizationContainer
            {
                { CultureIdentifier.En, "Moons" },
                { CultureIdentifier.Ru, "Луны" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Orbitals { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Orbitals", new LocalizationContainer
            {
                { CultureIdentifier.En, "Orbitals" },
                { CultureIdentifier.Ru, "Орбитали" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pinger

        public IReadOnlyLocalizationProperty MiniPinger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MiniPinger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mini-Pinger" },
                { CultureIdentifier.Ru, "Мини-разброс" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Pinger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pinger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pinger" },
                { CultureIdentifier.Ru, "Излучатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty PingFlood { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("PingFlood", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ping Flood" },
                { CultureIdentifier.Ru, "Поток излучений" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Dagger

        public IReadOnlyLocalizationProperty Shank { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shank", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shank" },
                { CultureIdentifier.Ru, "Заточка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Dagger { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Dagger", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dagger" },
                { CultureIdentifier.Ru, "Кинжал" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Sword { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sword", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sword" },
                { CultureIdentifier.Ru, "Меч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bolt

        public IReadOnlyLocalizationProperty Bolt { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bolt", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bolt" },
                { CultureIdentifier.Ru, "Разряд" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Lightning { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Lightning", new LocalizationContainer
            {
                { CultureIdentifier.En, "Lightning" },
                { CultureIdentifier.Ru, "Молния" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty _2012 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("_2012", new LocalizationContainer
            {
                { CultureIdentifier.En, "2012" },
                { CultureIdentifier.Ru, "2012" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Gravies

        public IReadOnlyLocalizationProperty Gravies { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Gravies", new LocalizationContainer
            {
                { CultureIdentifier.En, "Gravies" },
                { CultureIdentifier.Ru, "Ассорти" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Gravits { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Gravits", new LocalizationContainer
            {
                { CultureIdentifier.En, "Gravits" },
                { CultureIdentifier.Ru, "Конфетти" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Spiker

        public IReadOnlyLocalizationProperty Spiker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spiker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spiker" },
                { CultureIdentifier.Ru, "Шипы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperSpiker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperSpiker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super Spiker" },
                { CultureIdentifier.Ru, "Супершипы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region DiscoBall

        public IReadOnlyLocalizationProperty DiscoBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DiscoBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Disco Ball" },
                { CultureIdentifier.Ru, "Диско-шар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty GroovyBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GroovyBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Groovy Ball" },
                { CultureIdentifier.Ru, "Космо-шар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Boomerang

        public IReadOnlyLocalizationProperty Boomerang { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Boomerang", new LocalizationContainer
            {
                { CultureIdentifier.En, "Boomerang" },
                { CultureIdentifier.Ru, "Бумеранг" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BigBoomerang { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BigBoomerang", new LocalizationContainer
            {
                { CultureIdentifier.En, "BigBoomerang" },
                { CultureIdentifier.Ru, "Большой бумеранг" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Tadpoles

        public IReadOnlyLocalizationProperty Tadpoles { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tadpoles", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tadpoles" },
                { CultureIdentifier.Ru, "Головастики" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Frogs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Frogs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Frogs" },
                { CultureIdentifier.Ru, "Лягушки" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Bullfrog { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bullfrog", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bullfrog" },
                { CultureIdentifier.Ru, "Жаба" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region MiniV

        public IReadOnlyLocalizationProperty MiniV { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MiniV", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mini-V" },
                { CultureIdentifier.Ru, "Мини-V" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FlyingV { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FlyingV", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flying-V" },
                { CultureIdentifier.Ru, "Макси-V" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region YinYang

        public IReadOnlyLocalizationProperty YinYang { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("YinYang", new LocalizationContainer
            {
                { CultureIdentifier.En, "Yin Yang" },
                { CultureIdentifier.Ru, "Инь Ян" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty YinYangYong { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("YinYangYong", new LocalizationContainer
            {
                { CultureIdentifier.En, "Yin Yang Yong" },
                { CultureIdentifier.Ru, "Инь Ян Юн" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Fireworks

        public IReadOnlyLocalizationProperty Fireworks { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fireworks", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fireworks" },
                { CultureIdentifier.Ru, "Салют" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty GrandFinale { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GrandFinale", new LocalizationContainer
            {
                { CultureIdentifier.En, "Grand Finale" },
                { CultureIdentifier.Ru, "Последний залп" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Pyrotechnics { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pyrotechnics", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pyrotechnics" },
                { CultureIdentifier.Ru, "Пиротехника" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region WaterBalloon

        public IReadOnlyLocalizationProperty WaterBalloon { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WaterBalloon", new LocalizationContainer
            {
                { CultureIdentifier.En, "Water Balloon" },
                { CultureIdentifier.Ru, "Шарик с водой" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty WaterTrio { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WaterTrio", new LocalizationContainer
            {
                { CultureIdentifier.En, "Water Trio" },
                { CultureIdentifier.Ru, "Три шарика" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty WaterFight { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WaterFight", new LocalizationContainer
            {
                { CultureIdentifier.En, "Water Fight" },
                { CultureIdentifier.Ru, "Водяная битва" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Magnets

        public IReadOnlyLocalizationProperty Magnets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Magnets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Magnets" },
                { CultureIdentifier.Ru, "Магниты" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Attractoids { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Attractoids", new LocalizationContainer
            {
                { CultureIdentifier.En, "Attractoids" },
                { CultureIdentifier.Ru, "Аттракторы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Arrow

        public IReadOnlyLocalizationProperty Arrow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Arrow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Arrow" },
                { CultureIdentifier.Ru, "Стрела" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BowAndArrow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BowAndArrow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bow & Arrow" },
                { CultureIdentifier.Ru, "Лук и стрела" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FlamingArrow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FlamingArrow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flaming Arrow" },
                { CultureIdentifier.Ru, "Горящая стрела" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Driller

        public IReadOnlyLocalizationProperty Driller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Driller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Driller" },
                { CultureIdentifier.Ru, "Бурильщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Slammer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Slammer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Slammer" },
                { CultureIdentifier.Ru, "Громила" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Quicksand

        public IReadOnlyLocalizationProperty Quicksand { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Quicksand", new LocalizationContainer
            {
                { CultureIdentifier.En, "Quicksand" },
                { CultureIdentifier.Ru, "Пески" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Desert { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Desert", new LocalizationContainer
            {
                { CultureIdentifier.En, "Desert" },
                { CultureIdentifier.Ru, "Пустыня" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Jumper

        public IReadOnlyLocalizationProperty Jumper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Jumper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jumper" },
                { CultureIdentifier.Ru, "Попрыгун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TripleJumper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TripleJumper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Triple-Jumper" },
                { CultureIdentifier.Ru, "Тройной попрыгун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Spaz

        public IReadOnlyLocalizationProperty Spaz { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spaz", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spaz" },
                { CultureIdentifier.Ru, "Дурачок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Spazzer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spazzer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spazzer" },
                { CultureIdentifier.Ru, "Дурак" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Spaztastic { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spaztastic", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spaztastic" },
                { CultureIdentifier.Ru, "Дурень" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pinata

        public IReadOnlyLocalizationProperty Pinata { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pinata", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pinata" },
                { CultureIdentifier.Ru, "Пиньята" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Fiesta { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fiesta", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fiesta" },
                { CultureIdentifier.Ru, "Фиеста" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Shockwave

        public IReadOnlyLocalizationProperty Shockwave { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shockwave", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shockwave" },
                { CultureIdentifier.Ru, "Ударная волна" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SonicPulse { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SonicPulse", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sonic Pulse" },
                { CultureIdentifier.Ru, "Звуковая волна" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bounder

        public IReadOnlyLocalizationProperty Bounder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bounder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bounder" },
                { CultureIdentifier.Ru, "Искатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleBounder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleBounder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double Bounder" },
                { CultureIdentifier.Ru, "Двойной искатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TripleBounder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TripleBounder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Triple Bounder" },
                { CultureIdentifier.Ru, "Тройной искатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Uzi

        public IReadOnlyLocalizationProperty Uzi { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Uzi", new LocalizationContainer
            {
                { CultureIdentifier.En, "UZI" },
                { CultureIdentifier.Ru, "UZI" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Mp5 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Mp5", new LocalizationContainer
            {
                { CultureIdentifier.En, "MP5" },
                { CultureIdentifier.Ru, "MP5" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty P90 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("P90", new LocalizationContainer
            {
                { CultureIdentifier.En, "P90" },
                { CultureIdentifier.Ru, "P90" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region StickyBomb

        public IReadOnlyLocalizationProperty StickyBomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StickyBomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sticky Bomb" },
                { CultureIdentifier.Ru, "Липкая бомба" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty StickyTrio { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StickyTrio", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sticky Trio" },
                { CultureIdentifier.Ru, "Липкое трио" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MineLayer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MineLayer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mine Layer" },
                { CultureIdentifier.Ru, "Миноносец" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty StickyRain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StickyRain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sticky Rain" },
                { CultureIdentifier.Ru, "Липкий дождь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Fleet

        public IReadOnlyLocalizationProperty Fleet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fleet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fleet" },
                { CultureIdentifier.Ru, "Залп" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyFleet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyFleet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Fleet" },
                { CultureIdentifier.Ru, "Тяжелый залп" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperFleet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperFleet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super Fleet" },
                { CultureIdentifier.Ru, "Суперзалп" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Squadron { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Squadron", new LocalizationContainer
            {
                { CultureIdentifier.En, "Squadron" },
                { CultureIdentifier.Ru, "Барраж" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Rain

        public IReadOnlyLocalizationProperty Rain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rain" },
                { CultureIdentifier.Ru, "Дождь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Hail { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Hail", new LocalizationContainer
            {
                { CultureIdentifier.En, "Hail" },
                { CultureIdentifier.Ru, "Град" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sillyballs

        public IReadOnlyLocalizationProperty Sillyballs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sillyballs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sillyballs" },
                { CultureIdentifier.Ru, "Глуповыстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Wackyballs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Wackyballs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Wackyballs" },
                { CultureIdentifier.Ru, "Туповыстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Crazyballs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Crazyballs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Crazyballs" },
                { CultureIdentifier.Ru, "Закидон-выстрел" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Napalm

        public IReadOnlyLocalizationProperty Napalm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Napalm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Napalm" },
                { CultureIdentifier.Ru, "Напалм" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyNapalm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyNapalm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Napalm" },
                { CultureIdentifier.Ru, "Тяжелый напалм" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FireStorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FireStorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "FireStorm" },
                { CultureIdentifier.Ru, "Огненный шторм" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region SawBlade

        public IReadOnlyLocalizationProperty SawBlade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SawBlade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Saw Blade" },
                { CultureIdentifier.Ru, "Дисковая пила" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty RipSaw { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("RipSaw", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rip Saw" },
                { CultureIdentifier.Ru, "Разрезная пила" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DiamondBlade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DiamondBlade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Diamond Blade" },
                { CultureIdentifier.Ru, "Алмазный диск" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sunburst

        public IReadOnlyLocalizationProperty Sunburst { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sunburst", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sunburst" },
                { CultureIdentifier.Ru, "Солнечный луч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SolarFlare { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SolarFlare", new LocalizationContainer
            {
                { CultureIdentifier.En, "Solar Flare" },
                { CultureIdentifier.Ru, "Солнечная вспышка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Synclets

        public IReadOnlyLocalizationProperty Synclets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Synclets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Synclets" },
                { CultureIdentifier.Ru, "Синклеты" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperSynclets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperSynclets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super-Synclets" },
                { CultureIdentifier.Ru, "Суперсинклеты" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Payload

        public IReadOnlyLocalizationProperty Payload { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Payload", new LocalizationContainer
            {
                { CultureIdentifier.En, "Payload" },
                { CultureIdentifier.Ru, "Бомбомет" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MagicShower { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MagicShower", new LocalizationContainer
            {
                { CultureIdentifier.En, "Magic Shower" },
                { CultureIdentifier.Ru, "Волшебный душ" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Shadow

        public IReadOnlyLocalizationProperty Shadow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shadow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shadow" },
                { CultureIdentifier.Ru, "Тень" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Darkshadow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Darkshadow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Darkshadow" },
                { CultureIdentifier.Ru, "Темная тень" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Deathshadow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Deathshadow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Deathshadow" },
                { CultureIdentifier.Ru, "Тень смерти" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Attack

        public IReadOnlyLocalizationProperty XAttack { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("XAttack", new LocalizationContainer
            {
                { CultureIdentifier.En, "X Attack" },
                { CultureIdentifier.Ru, "Атака Х" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty OAttack { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("OAttack", new LocalizationContainer
            {
                { CultureIdentifier.En, "O Attack" },
                { CultureIdentifier.Ru, "Атака О" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region CarpetBomb

        public IReadOnlyLocalizationProperty CarpetBomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CarpetBomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "Carpet Bomb" },
                { CultureIdentifier.Ru, "Бомбардировка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty CarpetFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CarpetFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "Carpet Fire" },
                { CultureIdentifier.Ru, "Ковровая бомбард." }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty IncendiaryBombs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("IncendiaryBombs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Incendiary Bombs" },
                { CultureIdentifier.Ru, "Зажигат. бомбы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Seagull

        public IReadOnlyLocalizationProperty BabySeagull { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BabySeagull", new LocalizationContainer
            {
                { CultureIdentifier.En, "Baby Seagull" },
                { CultureIdentifier.Ru, "Чаечка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Seagull { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Seagull", new LocalizationContainer
            {
                { CultureIdentifier.En, "Seagull" },
                { CultureIdentifier.Ru, "Чайка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MamaSeagull { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MamaSeagull", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mama Seagull" },
                { CultureIdentifier.Ru, "Мама-чайка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Shrapnel

        public IReadOnlyLocalizationProperty Shrapnel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shrapnel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shrapnel" },
                { CultureIdentifier.Ru, "Разрывной" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Shredders { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Shredders", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shredders" },
                { CultureIdentifier.Ru, "Измельчитель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Penetrator

        public IReadOnlyLocalizationProperty Penetrator { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Penetrator", new LocalizationContainer
            {
                { CultureIdentifier.En, "Penetrator" },
                { CultureIdentifier.Ru, "Проникатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Penetratorv2 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Penetratorv2", new LocalizationContainer
            {
                { CultureIdentifier.En, "Penetrator v2" },
                { CultureIdentifier.Ru, "Проникатель v2" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Jammer

        public IReadOnlyLocalizationProperty Jammer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Jammer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jammer" },
                { CultureIdentifier.Ru, "Джаз" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Jiver { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Jiver", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jiver" },
                { CultureIdentifier.Ru, "Джайв" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Rocker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rocker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rocker" },
                { CultureIdentifier.Ru, "Рок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Chunklet

        public IReadOnlyLocalizationProperty Chunklet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Chunklet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chunklet" },
                { CultureIdentifier.Ru, "Здоровяк" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Chunker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Chunker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chunker" },
                { CultureIdentifier.Ru, "Великан" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BouncyBall

        public IReadOnlyLocalizationProperty BouncyBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BouncyBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bouncy Ball" },
                { CultureIdentifier.Ru, "Мяч-попрыгун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperBall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperBall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Super Ball" },
                { CultureIdentifier.Ru, "Супермяч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Minions

        public IReadOnlyLocalizationProperty Minions { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Minions", new LocalizationContainer
            {
                { CultureIdentifier.En, "Minions" },
                { CultureIdentifier.Ru, "Миньоны" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ManyMinions { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ManyMinions", new LocalizationContainer
            {
                { CultureIdentifier.En, "Many-Minions" },
                { CultureIdentifier.Ru, "Мульти-миньоны" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Ram

        public IReadOnlyLocalizationProperty BatteringRam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BatteringRam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Battering Ram" },
                { CultureIdentifier.Ru, "Таран" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleRam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleRam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double Ram" },
                { CultureIdentifier.Ru, "Двойной таран" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty RamSquad { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("RamSquad", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ram-Squad" },
                { CultureIdentifier.Ru, "Отряд таранов" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoubleRamSquad { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoubleRamSquad", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double Ram-Squad" },
                { CultureIdentifier.Ru, "Отряд дв. таранов" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Asteroids

        public IReadOnlyLocalizationProperty Asteroids { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Asteroids", new LocalizationContainer
            {
                { CultureIdentifier.En, "Asteroids" },
                { CultureIdentifier.Ru, "Метеориты" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Comets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Comets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Comets" },
                { CultureIdentifier.Ru, "Кометы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AsteroidStorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AsteroidStorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Asteroid Storm" },
                { CultureIdentifier.Ru, "Метеоритная буря" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Spider

        public IReadOnlyLocalizationProperty Spider { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spider", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spider" },
                { CultureIdentifier.Ru, "Паук" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Tarantula { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tarantula", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tarantula" },
                { CultureIdentifier.Ru, "Тарантул" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DaddyLonglegs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DaddyLonglegs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Daddy Longlegs" },
                { CultureIdentifier.Ru, "Сенокосец" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BlackWidow { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BlackWidow", new LocalizationContainer
            {
                { CultureIdentifier.En, "Black Widow" },
                { CultureIdentifier.Ru, "Черная вдова" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Rampage

        public IReadOnlyLocalizationProperty Rampage { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rampage", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rampage" },
                { CultureIdentifier.Ru, "Безумие" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Riot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Riot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Riot" },
                { CultureIdentifier.Ru, "Бунт" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Rifle

        public IReadOnlyLocalizationProperty M4 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("M4", new LocalizationContainer
            {
                { CultureIdentifier.En, "M4" },
                { CultureIdentifier.Ru, "M4" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty M16 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("M16", new LocalizationContainer
            {
                { CultureIdentifier.En, "M16" },
                { CultureIdentifier.Ru, "M16" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AK47 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AK47", new LocalizationContainer
            {
                { CultureIdentifier.En, "AK-47" },
                { CultureIdentifier.Ru, "AK-47" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Clover

        public IReadOnlyLocalizationProperty Clover { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Clover", new LocalizationContainer
            {
                { CultureIdentifier.En, "Clover" },
                { CultureIdentifier.Ru, "Клевер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FourLeafClover { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FourLeafClover", new LocalizationContainer
            {
                { CultureIdentifier.En, "Four Leaf Clover" },
                { CultureIdentifier.Ru, "Четырехлистный клевер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bomb

        public IReadOnlyLocalizationProperty _3DBomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("_3DBomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "3D-Bomb" },
                { CultureIdentifier.Ru, "3D-бомба" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty _2x3D { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("_2x3D", new LocalizationContainer
            {
                { CultureIdentifier.En, "2x3D" },
                { CultureIdentifier.Ru, "2x3D" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty _3x3D { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("_3x3D", new LocalizationContainer
            {
                { CultureIdentifier.En, "3x3D" },
                { CultureIdentifier.Ru, "3x3D" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Snowball

        public IReadOnlyLocalizationProperty Snowball { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Snowball", new LocalizationContainer
            {
                { CultureIdentifier.En, "Snowball" },
                { CultureIdentifier.Ru, "Снежок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Snowstorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Snowstorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Snowstorm" },
                { CultureIdentifier.Ru, "Метель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Spotter

        public IReadOnlyLocalizationProperty Spotter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spotter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spotter" },
                { CultureIdentifier.Ru, "Корректировщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SpotterXL { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SpotterXL", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spotter XL" },
                { CultureIdentifier.Ru, "Корректировщик XL" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SpotterXXL { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SpotterXXL", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spotter XXL" },
                { CultureIdentifier.Ru, "Корректировщик XXL" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region FighterJet

        public IReadOnlyLocalizationProperty FighterJet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FighterJet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fighter Jet" },
                { CultureIdentifier.Ru, "Истребитель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyJet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyJet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Jet" },
                { CultureIdentifier.Ru, "Тяжелый истребитель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Bounstrike

        public IReadOnlyLocalizationProperty Bounstrike { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bounstrike", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bounstrike" },
                { CultureIdentifier.Ru, "Прыг-удар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Bounstream { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bounstream", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bounstream" },
                { CultureIdentifier.Ru, "Прыг-поток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Bounstorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bounstorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bounstorm" },
                { CultureIdentifier.Ru, "Прыг-шторм" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region StarFire

        public IReadOnlyLocalizationProperty StarFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("StarFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "StarFire" },
                { CultureIdentifier.Ru, "Звездный огонь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ShootingStar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ShootingStar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Shooting Star" },
                { CultureIdentifier.Ru, "Звездопад" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BeeHive

        public IReadOnlyLocalizationProperty BeeHive { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BeeHive", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bee Hive" },
                { CultureIdentifier.Ru, "Пчелиный улей" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty KillerBees { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("KillerBees", new LocalizationContainer
            {
                { CultureIdentifier.En, "Killer Bees" },
                { CultureIdentifier.Ru, "Пчелы-убийцы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Wasps { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Wasps", new LocalizationContainer
            {
                { CultureIdentifier.En, "Wasps" },
                { CultureIdentifier.Ru, "Осы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region DualRoller

        public IReadOnlyLocalizationProperty DualRoller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DualRoller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dual-Roller" },
                { CultureIdentifier.Ru, "Двойной каток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Spreader { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Spreader", new LocalizationContainer
            {
                { CultureIdentifier.En, "Spreader" },
                { CultureIdentifier.Ru, "Раскидыватель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Partition

        public IReadOnlyLocalizationProperty Partition { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Partition", new LocalizationContainer
            {
                { CultureIdentifier.En, "Partition" },
                { CultureIdentifier.Ru, "Перегородка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Division { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Division", new LocalizationContainer
            {
                { CultureIdentifier.En, "Division" },
                { CultureIdentifier.Ru, "Барьер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BFG

        public IReadOnlyLocalizationProperty BFG1000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BFG1000", new LocalizationContainer
            {
                { CultureIdentifier.En, "BFG-1000" },
                { CultureIdentifier.Ru, "BFG-1000" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BFG9000 { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BFG9000", new LocalizationContainer
            {
                { CultureIdentifier.En, "BFG-9000" },
                { CultureIdentifier.Ru, "BFG-9000" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Train

        public IReadOnlyLocalizationProperty Train { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Train", new LocalizationContainer
            {
                { CultureIdentifier.En, "Train" },
                { CultureIdentifier.Ru, "Поезд" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Express { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Express", new LocalizationContainer
            {
                { CultureIdentifier.En, "Express" },
                { CultureIdentifier.Ru, "Экспресс" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Turret

        public IReadOnlyLocalizationProperty MiniTurret { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MiniTurret", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mini-Turret" },
                { CultureIdentifier.Ru, "Мини-туррель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TurretMob { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TurretMob", new LocalizationContainer
            {
                { CultureIdentifier.En, "TurretMob" },
                { CultureIdentifier.Ru, "Мульти-турель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Kamikaze

        public IReadOnlyLocalizationProperty Kamikaze { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Kamikaze", new LocalizationContainer
            {
                { CultureIdentifier.En, "Kamikaze" },
                { CultureIdentifier.Ru, "Камикадзе" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuicideBomber { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuicideBomber", new LocalizationContainer
            {
                { CultureIdentifier.En, "Suicide Bomber" },
                { CultureIdentifier.Ru, "Самоубийца" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Nuke

        public IReadOnlyLocalizationProperty Nuke { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Nuke", new LocalizationContainer
            {
                { CultureIdentifier.En, "Nuke" },
                { CultureIdentifier.Ru, "Кузькина мать" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaNuke { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaNuke", new LocalizationContainer
            {
                { CultureIdentifier.En, "MegaNuke" },
                { CultureIdentifier.Ru, "Ядрена бомба" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BlackHole

        public IReadOnlyLocalizationProperty BlackHole { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BlackHole", new LocalizationContainer
            {
                { CultureIdentifier.En, "Black Hole" },
                { CultureIdentifier.Ru, "Черная дыра" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty CosmicRift { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CosmicRift", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cosmic Rift" },
                { CultureIdentifier.Ru, "Косморазлом" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BumperBombs

        public IReadOnlyLocalizationProperty BumperBombs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BumperBombs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bumper Bombs" },
                { CultureIdentifier.Ru, "Bumper Bombs" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BumperArray { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BumperArray", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bumper Array" },
                { CultureIdentifier.Ru, "Bumper Array" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BumperAssault { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BumperAssault", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bumper Assault" },
                { CultureIdentifier.Ru, "Bumper Assault" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region BreakerMadness

        public IReadOnlyLocalizationProperty BreakerMadness { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BreakerMadness", new LocalizationContainer
            {
                { CultureIdentifier.En, "BreakerMadness" },
                { CultureIdentifier.Ru, "Разлом" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BreakerMania { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BreakerMania", new LocalizationContainer
            {
                { CultureIdentifier.En, "BreakerMania" },
                { CultureIdentifier.Ru, "Разломания" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region HomingMissile

        public IReadOnlyLocalizationProperty HomingMissile { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HomingMissile", new LocalizationContainer
            {
                { CultureIdentifier.En, "Homing Missile" },
                { CultureIdentifier.Ru, "Homing Missile" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HomingRockets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HomingRockets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Homing Rockets" },
                { CultureIdentifier.Ru, "Homing Rockets" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Puzzler

        public IReadOnlyLocalizationProperty Puzzler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Puzzler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Puzzler" },
                { CultureIdentifier.Ru, "Загадочник" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Deceiver { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Deceiver", new LocalizationContainer
            {
                { CultureIdentifier.En, "Deceiver" },
                { CultureIdentifier.Ru, "Мошенник" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Baffler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Baffler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Baffler" },
                { CultureIdentifier.Ru, "Обманщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region RocketFire

        public IReadOnlyLocalizationProperty RocketFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("RocketFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rocket Fire" },
                { CultureIdentifier.Ru, "Rocket Fire" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty RocketCluster { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("RocketCluster", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rocket Cluster" },
                { CultureIdentifier.Ru, "Rocket Cluster" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Flurry { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flurry", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flurry" },
                { CultureIdentifier.Ru, "Flurry" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pentagram

        public IReadOnlyLocalizationProperty Pentagram { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pentagram", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pentagram" },
                { CultureIdentifier.Ru, "Pentagram" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Pentaslam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pentaslam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pentaslam" },
                { CultureIdentifier.Ru, "Pentaslam" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Radar

        public IReadOnlyLocalizationProperty Radar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Radar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Radar" },
                { CultureIdentifier.Ru, "Radar" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Sonar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sonar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sonar" },
                { CultureIdentifier.Ru, "Sonar" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Lidar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Lidar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Lidar" },
                { CultureIdentifier.Ru, "Lidar" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region LaserBeam

        public IReadOnlyLocalizationProperty LaserBeam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("LaserBeam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Laser Beam" },
                { CultureIdentifier.Ru, "Лазерный луч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty GreatBeam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GreatBeam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Great Beam" },
                { CultureIdentifier.Ru, "Большой луч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty UltraBeam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("UltraBeam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ultra Beam" },
                { CultureIdentifier.Ru, "Ультралуч" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MasterBeam { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MasterBeam", new LocalizationContainer
            {
                { CultureIdentifier.En, "Master Beam" },
                { CultureIdentifier.Ru, "Король лучей" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Tweeter

        public IReadOnlyLocalizationProperty Tweeter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tweeter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tweeter" },
                { CultureIdentifier.Ru, "Tweeter" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Squawker { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Squawker", new LocalizationContainer
            {
                { CultureIdentifier.En, "Squawker" },
                { CultureIdentifier.Ru, "Squawker" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Woofer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Woofer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Woofer" },
                { CultureIdentifier.Ru, "Woofer" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region AcidRain

        public IReadOnlyLocalizationProperty AcidRain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AcidRain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Acid Rain" },
                { CultureIdentifier.Ru, "Acid Rain" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty AcidHail { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("AcidHail", new LocalizationContainer
            {
                { CultureIdentifier.En, "Acid Hail" },
                { CultureIdentifier.Ru, "Acid Hail" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sunflower

        public IReadOnlyLocalizationProperty Sunflower { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sunflower", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sunflower" },
                { CultureIdentifier.Ru, "Подсолнух" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Helianthus { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Helianthus", new LocalizationContainer
            {
                { CultureIdentifier.En, "Helianthus" },
                { CultureIdentifier.Ru, "Подсолнечник" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Taser

        public IReadOnlyLocalizationProperty Taser { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Taser", new LocalizationContainer
            {
                { CultureIdentifier.En, "Taser" },
                { CultureIdentifier.Ru, "Taser" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyTaser { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyTaser", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Taser" },
                { CultureIdentifier.Ru, "Heavy Taser" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sausage

        public IReadOnlyLocalizationProperty Sausage { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sausage", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sausage" },
                { CultureIdentifier.Ru, "Sausage" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Bratwurst { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Bratwurst", new LocalizationContainer
            {
                { CultureIdentifier.En, "Bratwurst" },
                { CultureIdentifier.Ru, "Bratwurst" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Kielbasa { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Kielbasa", new LocalizationContainer
            {
                { CultureIdentifier.En, "Kielbasa" },
                { CultureIdentifier.Ru, "Kielbasa" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Jackpot

        public IReadOnlyLocalizationProperty Jackpot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Jackpot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jackpot" },
                { CultureIdentifier.Ru, "Джекпот" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MegaJackpot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MegaJackpot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mega-Jackpot" },
                { CultureIdentifier.Ru, "Мегаджекпот" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty UltraJackpot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("UltraJackpot", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ultra-Jackpot" },
                { CultureIdentifier.Ru, "Ультраджекпот" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Lottery { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Lottery", new LocalizationContainer
            {
                { CultureIdentifier.En, "Lottery" },
                { CultureIdentifier.Ru, "Лотерея" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region EarlyBird

        public IReadOnlyLocalizationProperty EarlyBird { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("EarlyBird", new LocalizationContainer
            {
                { CultureIdentifier.En, "Early Bird" },
                { CultureIdentifier.Ru, "Early Bird" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty EarlyWorm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("EarlyWorm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Early Worm" },
                { CultureIdentifier.Ru, "Early Worm" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Recruiter

        public IReadOnlyLocalizationProperty Recruiter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Recruiter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Recruiter" },
                { CultureIdentifier.Ru, "Recruiter" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Enroller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Enroller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Enroller" },
                { CultureIdentifier.Ru, "Enroller" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Enlister { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Enlister", new LocalizationContainer
            {
                { CultureIdentifier.En, "Enlister" },
                { CultureIdentifier.Ru, "Enlister" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Fury

        public IReadOnlyLocalizationProperty Fury { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fury", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fury" },
                { CultureIdentifier.Ru, "Fury" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Rage { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rage", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rage" },
                { CultureIdentifier.Ru, "Rage" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Relocator

        public IReadOnlyLocalizationProperty Relocator { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Relocator", new LocalizationContainer
            {
                { CultureIdentifier.En, "Relocator" },
                { CultureIdentifier.Ru, "Relocator" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DisplacementBomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DisplacementBomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "Displacement Bomb" },
                { CultureIdentifier.Ru, "Displacement Bomb" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Imploder

        public IReadOnlyLocalizationProperty Imploder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Imploder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Imploder" },
                { CultureIdentifier.Ru, "Imploder" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty UltimateImploder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("UltimateImploder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ultimate Imploder" },
                { CultureIdentifier.Ru, "Ultimate Imploder" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Stone

        public IReadOnlyLocalizationProperty Stone { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Stone", new LocalizationContainer
            {
                { CultureIdentifier.En, "Stone" },
                { CultureIdentifier.Ru, "Камень" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Boulder { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Boulder", new LocalizationContainer
            {
                { CultureIdentifier.En, "Boulder" },
                { CultureIdentifier.Ru, "Валун" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Fireball { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fireball", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fireball" },
                { CultureIdentifier.Ru, "Огненный шар" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Cat

        public IReadOnlyLocalizationProperty Cat { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Cat", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cat" },
                { CultureIdentifier.Ru, "Кошка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Kittens { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Kittens", new LocalizationContainer
            {
                { CultureIdentifier.En, "Kittens" },
                { CultureIdentifier.Ru, "Котята" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SuperCat { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SuperCat", new LocalizationContainer
            {
                { CultureIdentifier.En, "SuperCat" },
                { CultureIdentifier.Ru, "Суперкошка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty CatsandDogs { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CatsandDogs", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cats and Dogs" },
                { CultureIdentifier.Ru, "Кошки-собаки" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region GhostBomb

        public IReadOnlyLocalizationProperty GhostBomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GhostBomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ghost Bomb" },
                { CultureIdentifier.Ru, "Бомба-призрак" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Ghostlets { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Ghostlets", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ghostlets" },
                { CultureIdentifier.Ru, "Призраки" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Flasher

        public IReadOnlyLocalizationProperty Flasher { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flasher", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flasher" },
                { CultureIdentifier.Ru, "Мерцалка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Strobie { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Strobie", new LocalizationContainer
            {
                { CultureIdentifier.En, "Strobie" },
                { CultureIdentifier.Ru, "Стробик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Rave { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Rave", new LocalizationContainer
            {
                { CultureIdentifier.En, "Rave" },
                { CultureIdentifier.Ru, "Рейв" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Sprouter

        public IReadOnlyLocalizationProperty Sprouter { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sprouter", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sprouter" },
                { CultureIdentifier.Ru, "Росток" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Blossom { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Blossom", new LocalizationContainer
            {
                { CultureIdentifier.En, "Blossom" },
                { CultureIdentifier.Ru, "Соцветие" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Square

        public IReadOnlyLocalizationProperty Square { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Square", new LocalizationContainer
            {
                { CultureIdentifier.En, "Square" },
                { CultureIdentifier.Ru, "Квадрат" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Hexagon { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Hexagon", new LocalizationContainer
            {
                { CultureIdentifier.En, "Hexagon" },
                { CultureIdentifier.Ru, "Гексагон" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Octagon { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Octagon", new LocalizationContainer
            {
                { CultureIdentifier.En, "Octagon" },
                { CultureIdentifier.Ru, "Октагон" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region WackyCluster

        public IReadOnlyLocalizationProperty WackyCluster { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WackyCluster", new LocalizationContainer
            {
                { CultureIdentifier.En, "Wacky Cluster" },
                { CultureIdentifier.Ru, "Глупый кластер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty KookyCluster { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("KookyCluster", new LocalizationContainer
            {
                { CultureIdentifier.En, "Kooky Cluster" },
                { CultureIdentifier.Ru, "Безумный кластер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty CrazyCluster { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("CrazyCluster", new LocalizationContainer
            {
                { CultureIdentifier.En, "Crazy Cluster" },
                { CultureIdentifier.Ru, "Закидон-кластер" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Satellite

        public IReadOnlyLocalizationProperty Satellite { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Satellite", new LocalizationContainer
            {
                { CultureIdentifier.En, "Satellite" },
                { CultureIdentifier.Ru, "Спутник" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty UFO { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("UFO", new LocalizationContainer
            {
                { CultureIdentifier.En, "UFO" },
                { CultureIdentifier.Ru, "НЛО" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Palm

        public IReadOnlyLocalizationProperty Palm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Palm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Palm" },
                { CultureIdentifier.Ru, "Пальма" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DoublePalm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DoublePalm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Double Palm" },
                { CultureIdentifier.Ru, "Двойная пальма" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TriplePalm { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TriplePalm", new LocalizationContainer
            {
                { CultureIdentifier.En, "Triple Palm" },
                { CultureIdentifier.Ru, "Тройная пальма" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region ShockShell

        public IReadOnlyLocalizationProperty ShockShell { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ShockShell", new LocalizationContainer
            {
                { CultureIdentifier.En, "ShockShell" },
                { CultureIdentifier.Ru, "Панцирь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ShockShellTrio { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ShockShellTrio", new LocalizationContainer
            {
                { CultureIdentifier.En, "ShockShell Trio" },
                { CultureIdentifier.Ru, "Трио-панцирь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Fountain

        public IReadOnlyLocalizationProperty Fountain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fountain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fountain" },
                { CultureIdentifier.Ru, "Фонтан" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Waterworks { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Waterworks", new LocalizationContainer
            {
                { CultureIdentifier.En, "Waterworks" },
                { CultureIdentifier.Ru, "Водомет" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Sprinkler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Sprinkler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Sprinkler" },
                { CultureIdentifier.Ru, "Поливатель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Flattener

        public IReadOnlyLocalizationProperty Flattener { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flattener", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flattener" },
                { CultureIdentifier.Ru, "Равнятель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Wall { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Wall", new LocalizationContainer
            {
                { CultureIdentifier.En, "Wall" },
                { CultureIdentifier.Ru, "Стена" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Fortress { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Fortress", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fortress" },
                { CultureIdentifier.Ru, "Крепость" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Funnel { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Funnel", new LocalizationContainer
            {
                { CultureIdentifier.En, "Funnel" },
                { CultureIdentifier.Ru, "Воронка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Chicken

        public IReadOnlyLocalizationProperty ChickenFling { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ChickenFling", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chicken-Fling" },
                { CultureIdentifier.Ru, "Куроброс" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ChickenHurl { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ChickenHurl", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chicken-Hurl" },
                { CultureIdentifier.Ru, "Курозалп" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ChickenLaunch { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ChickenLaunch", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chicken-Launch" },
                { CultureIdentifier.Ru, "Курозапуск" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Birds

        public IReadOnlyLocalizationProperty MadBirds { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MadBirds", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mad Birds" },
                { CultureIdentifier.Ru, "Злые птицы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty FuriousBirds { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FuriousBirds", new LocalizationContainer
            {
                { CultureIdentifier.En, "Furious Birds" },
                { CultureIdentifier.Ru, "Яростные птицы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty LividBirds { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("LividBirds", new LocalizationContainer
            {
                { CultureIdentifier.En, "Livid Birds" },
                { CultureIdentifier.Ru, "Бешеные птицы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pepper

        public IReadOnlyLocalizationProperty Pepper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pepper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pepper" },
                { CultureIdentifier.Ru, "Перец" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SaltAndPepper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SaltAndPepper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Salt and Pepper" },
                { CultureIdentifier.Ru, "Соль и перец" }
            }, ConfigPropertyOptions.Caching, "Weapons");
        
        public IReadOnlyLocalizationProperty Paprika { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Paprika", new LocalizationContainer
            {
                { CultureIdentifier.En, "Paprika" },
                { CultureIdentifier.Ru, "Paprika" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Cayenne { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Cayenne", new LocalizationContainer
            {
                { CultureIdentifier.En, "Cayenne" },
                { CultureIdentifier.Ru, "Cayenne" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Needler

        public IReadOnlyLocalizationProperty Needler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Needler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Needler" },
                { CultureIdentifier.Ru, "Игольщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DualNeedler { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DualNeedler", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dual Needler" },
                { CultureIdentifier.Ru, "Двойной игольщик" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Beacon

        public IReadOnlyLocalizationProperty Beacon { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Beacon", new LocalizationContainer
            {
                { CultureIdentifier.En, "Beacon" },
                { CultureIdentifier.Ru, "Маяк" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Beaconator { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Beaconator", new LocalizationContainer
            {
                { CultureIdentifier.En, "Beaconator" },
                { CultureIdentifier.Ru, "Маячище" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Kernels

        public IReadOnlyLocalizationProperty Kernels { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Kernels", new LocalizationContainer
            {
                { CultureIdentifier.En, "Kernels" },
                { CultureIdentifier.Ru, "Ядра" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Popcorn { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Popcorn", new LocalizationContainer
            {
                { CultureIdentifier.En, "Popcorn" },
                { CultureIdentifier.Ru, "Попкорн" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty BurntPopcorn { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("BurntPopcorn", new LocalizationContainer
            {
                { CultureIdentifier.En, "Burnt Popcorn" },
                { CultureIdentifier.Ru, "Жженый попкорн" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Chopper

        public IReadOnlyLocalizationProperty Chopper { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Chopper", new LocalizationContainer
            {
                { CultureIdentifier.En, "Chopper" },
                { CultureIdentifier.Ru, "Вертолет" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Apache { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Apache", new LocalizationContainer
            {
                { CultureIdentifier.En, "Apache" },
                { CultureIdentifier.Ru, "Апач" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Flintlock

        public IReadOnlyLocalizationProperty Flintlock { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Flintlock", new LocalizationContainer
            {
                { CultureIdentifier.En, "Flintlock" },
                { CultureIdentifier.Ru, "Мушкет" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Blunderbuss { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Blunderbuss", new LocalizationContainer
            {
                { CultureIdentifier.En, "Blunderbuss" },
                { CultureIdentifier.Ru, "Мушкетон" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region SkullShot

        public IReadOnlyLocalizationProperty SkullShot { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SkullShot", new LocalizationContainer
            {
                { CultureIdentifier.En, "SkullShot" },
                { CultureIdentifier.Ru, "Черепок" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Skeleton { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Skeleton", new LocalizationContainer
            {
                { CultureIdentifier.En, "Skeleton" },
                { CultureIdentifier.Ru, "Скелетон" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Pinpoint

        public IReadOnlyLocalizationProperty Pinpoint { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Pinpoint", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pinpoint" },
                { CultureIdentifier.Ru, "Точечка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Needles { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Needles", new LocalizationContainer
            {
                { CultureIdentifier.En, "Needles" },
                { CultureIdentifier.Ru, "Иглы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty PinsandNeedles { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("PinsandNeedles", new LocalizationContainer
            {
                { CultureIdentifier.En, "Pins and Needles" },
                { CultureIdentifier.Ru, "Булавки и иглы" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region FatStacks

        public IReadOnlyLocalizationProperty FatStacks { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("FatStacks", new LocalizationContainer
            {
                { CultureIdentifier.En, "Fat Stacks" },
                { CultureIdentifier.Ru, "Бабки" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty DollaBills { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("DollaBills", new LocalizationContainer
            {
                { CultureIdentifier.En, "Dolla Bills" },
                { CultureIdentifier.Ru, "Капуста" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MakeItRain { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MakeItRain", new LocalizationContainer
            {
                { CultureIdentifier.En, "Make-It-Rain" },
                { CultureIdentifier.Ru, "Тонна кэша" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region GodRays

        public IReadOnlyLocalizationProperty GodRays { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("GodRays", new LocalizationContainer
            {
                { CultureIdentifier.En, "God Rays" },
                { CultureIdentifier.Ru, "Лучи бога" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Deity { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Deity", new LocalizationContainer
            {
                { CultureIdentifier.En, "Deity" },
                { CultureIdentifier.Ru, "Божество" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region HiddenBlade

        public IReadOnlyLocalizationProperty HiddenBlade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HiddenBlade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Hidden Blade" },
                { CultureIdentifier.Ru, "Скрытое лезвие" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty SecretBlade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("SecretBlade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Secret Blade" },
                { CultureIdentifier.Ru, "Секретное лезвие" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ConcealedBlade { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ConcealedBlade", new LocalizationContainer
            {
                { CultureIdentifier.En, "Concealed Blade" },
                { CultureIdentifier.Ru, "Потайное лезвие" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region PortalGun

        public IReadOnlyLocalizationProperty PortalGun { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("PortalGun", new LocalizationContainer
            {
                { CultureIdentifier.En, "Portal Gun" },
                { CultureIdentifier.Ru, "Портальная пушка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty ASHPD { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ASHPD", new LocalizationContainer
            {
                { CultureIdentifier.En, "ASHPD" },
                { CultureIdentifier.Ru, "Улучш. ПП" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion
        
        #region Drone

        public IReadOnlyLocalizationProperty Drone { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Drone", new LocalizationContainer
            {
                { CultureIdentifier.En, "Drone" },
                { CultureIdentifier.Ru, "Drone" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyDrone { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyDrone", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Drone" },
                { CultureIdentifier.Ru, "Heavy Drone" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Volcano

        public IReadOnlyLocalizationProperty Volcano { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Volcano", new LocalizationContainer
            {
                { CultureIdentifier.En, "Volcano" },
                { CultureIdentifier.Ru, "Вулкан" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Eruption { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Eruption", new LocalizationContainer
            {
                { CultureIdentifier.En, "Eruption" },
                { CultureIdentifier.Ru, "Извержение" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region ThrowingStar

        public IReadOnlyLocalizationProperty ThrowingStar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("ThrowingStar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Throwing Star" },
                { CultureIdentifier.Ru, "Звездочка" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty MultiStar { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("MultiStar", new LocalizationContainer
            {
                { CultureIdentifier.En, "Multi-Star" },
                { CultureIdentifier.Ru, "Сюрикен" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Ninja { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Ninja", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ninja" },
                { CultureIdentifier.Ru, "Ниндзя" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Skeet

        public IReadOnlyLocalizationProperty Skeet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Skeet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Skeet" },
                { CultureIdentifier.Ru, "Скит" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty OlympicSkeet { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("OlympicSkeet", new LocalizationContainer
            {
                { CultureIdentifier.En, "Olympic Skeet" },
                { CultureIdentifier.Ru, "Спортинг" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region TangentFire

        public IReadOnlyLocalizationProperty TangentFire { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TangentFire", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tangent Fire" },
                { CultureIdentifier.Ru, "Навесной огонь" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TangentAttack { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TangentAttack", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tangent Attack" },
                { CultureIdentifier.Ru, "Навесная атака" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty TangentAssault { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("TangentAssault", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tangent Assault" },
                { CultureIdentifier.Ru, "Навесной штурм" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Summoner

        public IReadOnlyLocalizationProperty Summoner { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Summoner", new LocalizationContainer
            {
                { CultureIdentifier.En, "Summoner" },
                { CultureIdentifier.Ru, "Призыватель" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Mage { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Mage", new LocalizationContainer
            {
                { CultureIdentifier.En, "Mage" },
                { CultureIdentifier.Ru, "Маг" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Travelers

        public IReadOnlyLocalizationProperty Travelers { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Travelers", new LocalizationContainer
            {
                { CultureIdentifier.En, "Travelers" },
                { CultureIdentifier.Ru, "Скиталец" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Scavengers { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Scavengers", new LocalizationContainer
            {
                { CultureIdentifier.En, "Scavengers" },
                { CultureIdentifier.Ru, "Бродяга" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region JackoLantern

        public IReadOnlyLocalizationProperty JackoLantern { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("JackoLantern", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jack-o-Lantern" },
                { CultureIdentifier.Ru, "Тыква Джек" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty JackoVomit { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("JackoVomit", new LocalizationContainer
            {
                { CultureIdentifier.En, "Jack-o-Vomit" },
                { CultureIdentifier.Ru, "Рвота Джек" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region WickedWitch

        public IReadOnlyLocalizationProperty WickedWitch { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WickedWitch", new LocalizationContainer
            {
                { CultureIdentifier.En, "Wicked Witch" },
                { CultureIdentifier.Ru, "Злая ведьма" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty WitchesBroom { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("WitchesBroom", new LocalizationContainer
            {
                { CultureIdentifier.En, "Witches Broom" },
                { CultureIdentifier.Ru, "Ведьмина метла" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Ghouls { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Ghouls", new LocalizationContainer
            {
                { CultureIdentifier.En, "Ghouls" },
                { CultureIdentifier.Ru, "Упыри" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion

        #region Botherer

        public IReadOnlyLocalizationProperty Botherer { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Botherer", new LocalizationContainer
            {
                { CultureIdentifier.En, "Botherer" },
                { CultureIdentifier.Ru, "Botherer" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Tormentor { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Tormentor", new LocalizationContainer
            {
                { CultureIdentifier.En, "Tormentor" },
                { CultureIdentifier.Ru, "Tormentor" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Punisher { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Punisher", new LocalizationContainer
            {
                { CultureIdentifier.En, "Punisher" },
                { CultureIdentifier.Ru, "Punisher" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion
        
        #region Oddball

        public IReadOnlyLocalizationProperty Oddball { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Oddball", new LocalizationContainer
            {
                { CultureIdentifier.En, "Oddball" },
                { CultureIdentifier.Ru, "Oddball" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty Oddbomb { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Oddbomb", new LocalizationContainer
            {
                { CultureIdentifier.En, "Oddbomb" },
                { CultureIdentifier.Ru, "Oddbomb" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion
        
        #region Permaroller

        public IReadOnlyLocalizationProperty Permaroller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("Permaroller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Permaroller" },
                { CultureIdentifier.Ru, "Permaroller" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        public IReadOnlyLocalizationProperty HeavyPermaroller { get; } =
            ShellShockLive.Settings.Instance.Localization.GetLocalizationProperty("HeavyPermaroller", new LocalizationContainer
            {
                { CultureIdentifier.En, "Heavy Permaroller" },
                { CultureIdentifier.Ru, "Heavy Permaroller" }
            }, ConfigPropertyOptions.Caching, "Weapons");

        #endregion
    }
}