using System;
using System.Windows.Forms;
using Ruler.Weapons;

namespace Ruler.Gui
{
    public class WeaponButton : Button
    {
        private Weapon weapon;
        public WeaponButton(Weapon weapon)
        {
            this.weapon = weapon;
            Name = weapon.Name;
            Text = weapon.Name;
            BackColor = weapon.Color;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}