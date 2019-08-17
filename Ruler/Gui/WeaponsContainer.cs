// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Weapons;
using SharpDX.Direct2D1;

namespace Ruler.Gui
{
    public sealed class WeaponsContainer : Label
    {
        public WeaponsContainer()
        {
            InitializeWeaponsButton();
        }
        
        
        private void InitializeWeaponsButton()
        {
            foreach (Weapon weapon in Weapons.Common.Weapons.WeaponList)
            {
                // ReSharper disable once HeapView.ClosureAllocation
                WeaponButton button = new WeaponButton()
                {
                    Weapon = weapon,
                    Size = new Size(WeaponsPanel.ButtonWidth, WeaponsPanel.ButtonHeight),
                };
                button.Location = new Point(WeaponsPanel.LevelLabelWidth + (button.Size.Width + WeaponsPanel.DistanceBetweenButtons) * weapon.LevelInGroup,
                    (button.Size.Height + WeaponsPanel.DistanceBetweenButtons) * (weapon.GroupID + 1));

                #region Label with weapon level
                if (weapon.LevelInGroup == 0)
                {
                    TransparentLabel levelLabel = new TransparentLabel
                    {
                        Name = weapon.GroupID.ToString(),
                        Font = new Font(Font.Name, Font.Size, FontStyle.Bold | FontStyle.Italic),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Size = new Size(WeaponsPanel.LevelLabelWidth, button.Size.Height),
                        Location = new Point(0,
                            button.Location.Y),
                        Parent = Parent
                    };
                    
                    switch (weapon.AvailabilityLevel)
                    {
                        case Byte lvl when lvl > 0 && lvl <= 100:
                            levelLabel.Text = lvl.ToString();
                            levelLabel.ForeColor = lvl == 100 ? Color.Orange : weapon.Color;
                            break;
                        case 101:
                            levelLabel.Text = @"M";
                            levelLabel.ForeColor = Color.GreenYellow;
                            break;
                        case 102:
                            levelLabel.Text = @"C";
                            levelLabel.ForeColor = Color.LightCoral;
                            break;
                        case 103:
                            levelLabel.Text = @"GS";
                            levelLabel.ForeColor = Color.DarkGoldenrod;
                            break;
                        default:
                            levelLabel.Text = @"U";
                            levelLabel.ForeColor = Color.DarkGray;
                            break;
                    }
                    Controls.Add(levelLabel);
                }
                #endregion
                Controls.Add(button);
            }
        }
    }
}