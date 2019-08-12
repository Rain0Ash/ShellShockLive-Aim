using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Properties;
using Ruler.Weapons;
using Ruler.Weapons.Common;
using SharpDX.Windows;

namespace Ruler.Gui
{
    internal class WeaponsPanel : Label
    {
        internal Int32 MaxWeaponInLine { get; set; } = 10;
        internal Int32 MaxWeaponInColumn { get; set; } = 4;
        private Boolean IsExtend { get; set; }

        private Button Extender { get; set; }
        private Label WeaponButtonsContainer { get; set; }
        
        internal Manager Manager;
        public WeaponsPanel(ref RenderForm renderForm)
        {
            BackColor = Color.Transparent;
            Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            Location = new Point(renderForm.Location.X, renderForm.Location.Y);
            Size = new Size(renderForm.Size.Width * 1/7, renderForm.Size.Height - Location.Y - renderForm.Size.Height * 1/12);
            
            WeaponButtonsContainer = new Label()
            {
                Font = Font,
                BackColor = Color.FromArgb(100, 120, 120, 120),
                Location = Location,
                Size = Size,
                Visible = false
            };
            
            Extender = new Button()
            {
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                BackgroundImage = Resources.nuclear,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255)},
                ForeColor = Color.White,
                Location = new Point(0, (Int32)(Size.Height / 2.3)),
                Size = new Size(20, 80),
            };

            Extender.Click += Extender_OnClick;

            Controls.Add(Extender);
            Controls.Add(WeaponButtonsContainer);
        }
        
        private void Extender_OnClick(Object sender, EventArgs e)
        {
            IsExtend = !IsExtend;
            Manager.ForceNextFrame();
            if (IsExtend)
            {
                WeaponButtonsContainer.Visible = true;
                return;
            }
            WeaponButtonsContainer.Visible = false;
        }

        private void InitializeWeaponsButton()
        {
            Weapon previousWeapon = Weapons.Common.Weapons.WeaponList[0];
            Int32 weaponIDInGroup = 0;
            for (Int32 weaponID = 1; weaponID < (false ? Weapons.Common.Weapons.WeaponList.Count : 4); weaponID++)
            {
                Weapon weapon = Weapons.Common.Weapons.WeaponList[weaponID];
                WeaponButtonsContainer.Container.Add(
                    new WeaponButton(weapon)
                    {
                        Font = Font,
                        ForeColor = ForeColor,
                        AllowDrop = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(50, 20),
                        Location = new Point()
                    });
                previousWeapon = weapon;
            }
        }
    }
}