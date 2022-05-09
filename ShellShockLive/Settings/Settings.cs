// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Configuration.Ini;
using NetExtender.Configuration.Interfaces;
using NetExtender.Configuration.Json;
using NetExtender.Configuration.Memory;
using NetExtender.Configuration.Properties.Interfaces;
using NetExtender.Configuration.Utilities;
using NetExtender.Localization.Behavior.Settings;
using NetExtender.Localization.Common;
using NetExtender.Localization.Interfaces;
using NetExtender.Localization.Utilities;
using NetExtender.Types.Culture;
using NetExtender.Types.Monitors;
using NetExtender.Utilities.Configuration;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Windows;
using ShellShockLive.Models.Physics.Bindings;

namespace ShellShockLive
{
    [Flags]
    public enum InterfaceType
    {
        None = 0,
        Render = 1,
        Interface = 2,
        Full = Render | Interface,
    }
    
    public sealed class Settings : SettingsLocalizationSynchronizedBehavior<Settings>
    {
        protected override IConfig Config { get; }
        public override IReadOnlyLocalizationConfig Localization { get; }

        public override IConfigProperty<Int32> Identifier { get; }
        public IConfigProperty<PhysicsBindings> Physics { get; }
        public IConfigProperty<Byte> Volume { get; }
        public IConfigProperty<UInt16> Scanning { get; }
        public IConfigProperty<Boolean> DebugAnalysis { get; }
        public IConfigProperty<Byte> Transparent { get; }

        private IConfig Memory { get; }
        public IConfigProperty<Monitor> Monitor { get; }
        public IConfigProperty<InterfaceType> Interface { get; }

        public static class Constants
        {
            public static BindingConstant<Byte> Volume
            {
                get
                {
                    return new BindingConstant<Byte>(0, 100, 20);
                }
            }
            
            public static BindingConstant<UInt16> Scanning
            {
                get
                {
                    return new BindingConstant<UInt16>(400, 3000, 1000);
                }
            }
            
            public static BindingConstant<Byte> Transparent
            {
                get
                {
                    return new BindingConstant<Byte>(20, Byte.MaxValue, 40);
                }
            }
        }

        public Settings()
            : base(CultureIdentifier.En, CultureIdentifier.Ru)
        {
            Config = new IniConfigBehavior().Create();
            Identifier = Config.GetConfigurationProperty<Int32>(nameof(Localization), LocalizationIdentifier.System, nameof(Settings)).Synchronize(Synchronizer);
            Physics = Config.GetConfigurationProperty(nameof(Physics), PhysicsBindings.Default, nameof(Settings)).Synchronize(Synchronizer);
            Volume = Config.GetConfigurationProperty(nameof(Volume), Constants.Volume.Start, VolumeValidate, nameof(Settings)).Synchronize(Synchronizer);
            Scanning = Config.GetConfigurationProperty(nameof(Scanning), Constants.Scanning.Start, ScanningValidate, nameof(Settings)).Synchronize(Synchronizer);
            DebugAnalysis = Config.GetConfigurationProperty(nameof(DebugAnalysis), false, nameof(Settings)).Synchronize(Synchronizer);
            Transparent = Config.GetConfigurationProperty(nameof(Transparent), Constants.Transparent.Start, TransparentValidate, nameof(Settings)).Synchronize(Synchronizer);

            Memory = new MemoryConfigBehavior().Create();
            Monitor = Memory.GetConfigurationProperty(nameof(Monitor), MonitorUtilities.GetPrimaryMonitor());
            Interface = Memory.GetConfigurationProperty(nameof(Interface), InterfaceType.Full);

            Localization = new JsonConfigBehavior("Localization.json").Localization(Identifier.Value, LocalizationOptions.WithoutSystem, Comparer).Create().AsReadOnly();
        }

        private static Boolean ScanningValidate(UInt16 value)
        {
            return value.InRange(Constants.Scanning.Minimum, Constants.Scanning.Maximum) && value % 100 == 0;
        }

        private static Boolean VolumeValidate(Byte value)
        {
            return value.InRange(Constants.Volume.Minimum, Constants.Volume.Maximum);
        }
        
        private static Boolean TransparentValidate(Byte value)
        {
            return value.InRange(Constants.Transparent.Minimum, Constants.Transparent.Maximum);
        }
    }
}