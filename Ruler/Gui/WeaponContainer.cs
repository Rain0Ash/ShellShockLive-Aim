// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Weapons;

namespace Ruler.Gui
{
    public class WeaponContainer : Label
    {
        public WeaponContainer()
        {
            InitializeWeaponsButton();
        }
        
        
        private void InitializeWeaponsButton()
        {
            foreach (Weapon weapon in Weapons.Common.Weapons.WeaponList)
            {
                // ReSharper disable once HeapView.ClosureAllocation
                WeaponButton button = new WeaponButton(weapon)
                {
                    FlatAppearance = {BorderSize = 0, BorderColor = BackColor},
                    Size = new Size(90, 35),
                };
                button.Location = new Point(50 + (button.Size.Width + 30) * weapon.LevelInGroup, (button.Size.Height + 5) * (weapon.GroupID + 1));

                Button imageLabel = new Button()
                {
                    BackColor = button.BackColor,
                    Size = new Size(button.Height, button.Height),
                    Location = new Point(button.Location.X - 25, button.Location.Y),
                    FlatAppearance = {BorderSize = 0, BorderColor = button.BackColor},
                    FlatStyle = FlatStyle.Flat,
                    TabStop = false,
                    Image = weapon.Image != null ? new Bitmap(weapon.Image, new Size(button.Height, button.Height)) : null
                };
                imageLabel.Click += (sender, args) => button.PerformClick();

                #region Label with weapon level
                if (weapon.LevelInGroup == 0)
                {
                    TransparentLabel levelLabel = new TransparentLabel
                    {
                        Name = weapon.GroupID.ToString(),
                        Font = new Font(Font.Name, Font.Size - 1, FontStyle.Bold | FontStyle.Italic),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(25, button.Size.Height),
                        Location = new Point(0,
                            button.Location.Y),
                        Parent = Parent
                    };
                    Byte lvl = weapon.AvailabilityLevel;
                    if (lvl > 0 && lvl <= 100)
                    {
                        levelLabel.Text = lvl.ToString();
                        levelLabel.ForeColor = lvl < 100 ? weapon.Color : Color.Orange;
                    }
                    else if (lvl == 101)
                    {
                        levelLabel.Text = @"M";
                        levelLabel.ForeColor = Color.GreenYellow;
                    }
                    else if (lvl == 102)
                    {
                        levelLabel.Text = @"C";
                        levelLabel.ForeColor = Color.LightCoral;
                    }
                    else if (lvl == 103)
                    {
                        levelLabel.Text = @"GS";
                        levelLabel.ForeColor = Color.DarkGoldenrod;
                    }
                    else
                    {
                        levelLabel.Text = @"U";
                        levelLabel.ForeColor = Color.DarkGray;
                    }
                    Controls.Add(levelLabel);
                }
                #endregion
                Controls.Add(imageLabel);
                Controls.Add(button);
            }
        }
    }
}