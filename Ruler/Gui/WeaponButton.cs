using System;
using System.Drawing;
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
            ForeColor = Color.Azure;
            Font = new Font(Font.Name, Font.Size, FontStyle.Bold | FontStyle.Italic);
            FlatStyle = FlatStyle.Flat;
            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;
            AllowDrop = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            System.Windows.MessageBox.Show($"Clicked '{Name}' button!");
        }
    }
}