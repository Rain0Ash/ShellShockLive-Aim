// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Physics.Bindings;
using ShellShockLive.Models.Physics.Bindings.Interfaces;

namespace ShellShockLive.ViewModels.Settings
{
    public class SettingsViewModel : SettingsReactiveViewModelSingleton<SettingsViewModel>
    {
        public new static ShellShockLive.Settings Settings
        {
            get
            {
                return ShellShockLive.Settings.Instance;
            }
        }

        [Reactive]
        public IPhysicsBinding Binding { get; set; } = (PhysicsBinding) Settings.Physics.Value;

        [Reactive]
        public Boolean IsDebug { get; set; } = Settings.IsDebug;

        [Reactive]
        public Boolean ShowGrid { get; set; }

        public SettingsViewModel()
            : base(Settings)
        {
        }
    }
}