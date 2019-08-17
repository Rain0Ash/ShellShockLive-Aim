// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Weapons;

namespace Ruler.Gui
{
    public class WeaponButton : Button
    {
        internal static event EventsAndGlobalsController.EmptyHandler WeaponChanged;
        private static event EventsAndGlobalsController.SwitchedState ClickedButtonAlert;
        
        private Weapon weapon;
        internal Weapon Weapon
        {
            get
            {
                return weapon;
            }
            set
            {
                weapon = value;
                WeaponChanged?.Invoke();
            }
        }
        protected Brush Brush = Brushes.Azure;
        public WeaponButton()
        {
            Font = new Font(Font.Name, Font.Size, FontStyle.Bold | FontStyle.Italic);
            FlatStyle = FlatStyle.Flat;
            TabStop = false;
            TextAlign = ContentAlignment.MiddleCenter;
            AllowDrop = false;
            FlatAppearance.BorderSize = 0;
            WeaponChanged += InitializeButton;

            ClickedButtonAlert += ActivateAndDeactivate;
            CurrentWeaponButton.ResetWeaponButtons += ActivateAndDeactivate;
        }

        private void InitializeButton()
        {
            Name = Weapon.Name;
            BackColor = Weapon.Color;
            FlatAppearance.BorderColor = BackColor;
        }

        protected virtual void ActivateAndDeactivate(String name)
        {
            if (Name == name)
            {
                Brush = Brushes.Blue;
                BackColor = Color.LightSteelBlue;
                FlatAppearance.BorderColor = Color.Red;
                FlatAppearance.BorderSize = 1;
            }
            else
            {
                Brush = Brushes.Azure;
                BackColor = weapon.Color;
                FlatAppearance.BorderColor = BackColor;
                FlatAppearance.BorderSize = 0;
            }
        }
        protected override void OnClick(EventArgs e)
        {
            EventsAndGlobalsController.Weapon = Weapon;
            ClickedButtonAlert?.Invoke(Name);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawButtonImage(e);
            DrawButtonText(e);
        }
        private void DrawButtonImage(PaintEventArgs e)
        {
            e.Graphics.DrawImage(Weapon.Image, 0, 0, Height, Height);
        }

        private void DrawButtonText(PaintEventArgs e)
        {
            Single height = Font.Size;
            String weaponName = Weapon.Name;
            if (e.Graphics.MeasureString(weaponName, Font).Width >= (Width - Height) - 1.5f*WeaponsPanel.DistanceBetweenButtons)
            {
                height *= 0.5f;
                
                weaponName = weaponName.Contains(" ") ? weaponName.Replace(' ', '\n') : 
                    weaponName.Contains("-") ? weaponName.Replace('-', '\n') : 
                    String.Join("\n", Regex.Split(weaponName, @"(?<!^)(?=[A-Z])"));
            }
            e.Graphics.DrawString(weaponName, Font, Brush, new PointF((Width - Height) * 0.50f,height));
        }
        
        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);
            Brush.Dispose();
        }
    }
}