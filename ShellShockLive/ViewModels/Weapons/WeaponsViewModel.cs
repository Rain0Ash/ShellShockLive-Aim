// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using DynamicData.Binding;
using NetExtender.Utilities.IO;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Internal;
using ShellShockLive.ViewModels.Physics;

namespace ShellShockLive.ViewModels.Weapons
{
    public class WeaponsViewModel : ReactiveViewModelSingleton<WeaponsViewModel>
    {
        [Reactive]
        public IWeapon Weapon { get; set; } = ParabolaWeapon.Instance;

        public IGuidanceInfo GuidanceInfo
        {
            get
            {
                return new GuidanceWeaponInfo(PhysicsViewModel.Instance.Physics, Weapon);
            }
        }

        [Reactive]
        public Boolean ShowPanel { get; set; }
        
        public WeaponsViewModel()
        {
            this.WhenPropertyChanged(value => value.Weapon, false).Subscribe(weapon => weapon.Value.ToConsole());
        }

        public void Reset()
        {
            Weapon = ParabolaWeapon.Instance;
        }
    }
}