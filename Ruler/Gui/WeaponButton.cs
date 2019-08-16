// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Weapons;

namespace Ruler.Gui
{
    public sealed class WeaponButton : Button
    {
        private Weapon weapon;
        public WeaponButton(Weapon weapon)
        {
            this.weapon = weapon;
            Name = weapon.Name;
            Text = weapon.Name;
            BackColor = weapon.Color;
            ForeColor = Color.Azure;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = BackColor;
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