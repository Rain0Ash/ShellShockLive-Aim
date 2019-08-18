// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Common;

namespace Ruler.Gui
{
    internal sealed class CurrentWeaponButton : WeaponButton
    {
        internal static event EventsAndGlobalsController.SwitchedState ResetWeaponButtons;
        internal CurrentWeaponButton()
        {
            ID = Weapons.Common.Weapons.WeaponsArray[0, 0].Name.GetHashCode();
            Brush = Brushes.Cyan;
            EventsAndGlobalsController.ChangedWeapon += weapon => Weapon = weapon;
        }

        protected override void ActivateAndDeactivate(Int32 id){}

        protected override void InitializeButton()
        {
            BackColor = Weapon.Color;
            FlatAppearance.BorderColor = BackColor;
        }

        protected override void OnClick(EventArgs e)
        {
            EventsAndGlobalsController.Weapon = Weapons.Common.Weapons.WeaponsArray[0,0];
            ResetWeaponButtons?.Invoke(ID);
        }
    }
}