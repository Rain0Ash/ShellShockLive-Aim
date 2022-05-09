// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel;
using System.Windows;
using NetExtender.Localization.Properties.Interfaces;
using NetExtender.WindowsPresentation.Utilities.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.ViewModels;
using ShellShockLive.ViewModels.Weapons;
using ShellShockLive.ViewModels.Weapons.Images;

namespace ShellShockLive.View.WeaponPanel
{
    public partial class WeaponButton
    {
        public static readonly DependencyProperty WeaponProperty = DependencyPropertyUtilities.Register(nameof(Weapon), false);
        public static readonly DependencyProperty TitleProperty = DependencyPropertyUtilities.Register(nameof(Title), false);
        public static readonly DependencyProperty ImageProperty = DependencyPropertyUtilities.Register(nameof(Image), false);
        public static readonly DependencyProperty IsActiveProperty = DependencyPropertyUtilities.Register(nameof(IsActive));

        [Bindable(true)]
        public IWeapon? Weapon
        {
            get
            {
                return (IWeapon?) GetValue(WeaponProperty);
            }
            set
            {
                SetValue(WeaponProperty, value);
            }
        }

        [Bindable(true)]
        public IReadOnlyLocalizationProperty? Title
        {
            get
            {
                return (IReadOnlyLocalizationProperty?) GetValue(TitleProperty);
            }
            private set
            {
                SetValue(TitleProperty, value);
            }
        }

        [Bindable(true)]
        public WeaponImage? Image
        {
            get
            {
                return (WeaponImage?) GetValue(ImageProperty);
            }
            private set
            {
                SetValue(ImageProperty, value);
            }
        }

        [Bindable(true)]
        public Boolean IsActive
        {
            get
            {
                return (Boolean) GetValue(IsActiveProperty);
            }
            private set
            {
                SetValue(IsActiveProperty, value);
            }
        }

        public WeaponButton()
        {
            InitializeComponent();
        }
        
        private static void WeaponChanged(DependencyObject sender)
        {
            IWeapon? weapon = (IWeapon?) sender.GetValue(WeaponProperty);

            if (weapon is null)
            {
                sender.SetValue(TitleProperty, null);
                sender.SetValue(ImageProperty, null);
                sender.SetValue(IsActiveProperty, false);
                return;
            }

            sender.SetValue(TitleProperty, WeaponsLocalization.Instance.Get(weapon));
            sender.SetValue(ImageProperty, ImageStorage.Get(weapon));

            if (sender is WeaponButton button)
            {
                button.Update(weapon);
            }
        }

        public virtual void Update(IWeapon? weapon)
        {
            IsActive = weapon is not null && weapon == Weapon;
        }
    }
}