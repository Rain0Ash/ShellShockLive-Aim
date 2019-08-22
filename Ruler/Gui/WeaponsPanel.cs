// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Properties;

namespace Ruler.Gui
{
    internal sealed class WeaponsPanel : Label
    {
        internal const Int32 MaxWeaponsInColumn = 21;
        internal const Int32 MaxWeaponsInLine = 4;
        internal const Int32 ButtonWidth = 120;
        internal const Int32 ButtonHeight = 35;
        internal const Int32 LevelLabelWidth = 25;
        internal const Int32 DistanceBetweenButtons = 5;
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly Button extenderButton;
        private readonly WeaponsContainer weaponButtonsContainer;
        private readonly SearchTextBox searchTextBox;
        private readonly CurrentWeaponButton currentWeaponButton;
        private readonly PageSwitcher pageSwitcher;
        private Int32 currentPage = 0;
        public WeaponsPanel()
        {
            pageSwitcher = new PageSwitcher
            {
                Location = new Point(LevelLabelWidth + ButtonWidth + DistanceBetweenButtons, 0),
                Size = new Size(ButtonWidth, ButtonHeight),
                ForeColor = Color.Azure,
                BackColor = Color.Red,
                Visible = false,
            };
            pageSwitcher.CurrentPageChanged += page => currentPage = page;
            
            searchTextBox = new SearchTextBox
            {
                ForeColor = Color.Azure,
                BackColor = Color.DarkBlue,
                Font = new Font(Font.Name, Font.Size+6, FontStyle.Italic),
                Location = new Point(LevelLabelWidth + (ButtonWidth + DistanceBetweenButtons)*2, 0),
                Size = new Size(2*ButtonWidth+DistanceBetweenButtons, ButtonHeight),
                TextAlign = HorizontalAlignment.Center,
                AllowDrop = false,
                AutoSize = false,
                Visible = false,
            };

            currentWeaponButton = new CurrentWeaponButton
            {
                Weapon = Weapons.Common.Weapons.WeaponsArray[0,0],
                Size = new Size(ButtonWidth, ButtonHeight),
                Location = new Point(LevelLabelWidth, 0),
            };

            extenderButton = new Button
            {
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                BackgroundImage = Resources.nuclear,
                BackgroundImageLayout = ImageLayout.Stretch,
                FlatAppearance = { BorderSize = 0, BorderColor = Color.FromArgb(0, 255, 255, 255)},
                ForeColor = Color.White,
                Location = new Point(0, 0),
                Size = new Size(LevelLabelWidth - DistanceBetweenButtons, ButtonHeight),
            };
            extenderButton.Click += ExtenderButtonOnClick;
            
            BackColor = Color.Transparent;
            Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            Location = new Point(EventsAndGlobalsController.CurrentMonitor.Resolution.X, EventsAndGlobalsController.CurrentMonitor.Resolution.Y);
            Size = new Size(extenderButton.Size.Width + DistanceBetweenButtons + (MaxWeaponsInLine+1)*(ButtonWidth+DistanceBetweenButtons),
                MaxWeaponsInColumn*(extenderButton.Size.Height+DistanceBetweenButtons));
            
            weaponButtonsContainer = new WeaponsContainer
            {
                Font = Font,
                BackColor = Color.FromArgb(0, 255, 255, 255),
                Location = Location,
                Size = Size,
                Visible = false
            };

            Controls.Add(searchTextBox);
            Controls.Add(extenderButton);
            Controls.Add(weaponButtonsContainer);
            Controls.Add(currentWeaponButton);
            Controls.Add(pageSwitcher);
            EventsAndGlobalsController.ChangedWeaponMenuState += () => ExtenderButtonOnClick(new Object(), EventArgs.Empty);
        }
        
        private void ExtenderButtonOnClick(Object sender, EventArgs e)
        {
            weaponButtonsContainer.Visible =
                searchTextBox.Visible = 
                    pageSwitcher.Visible = !weaponButtonsContainer.Visible;
                currentWeaponButton.BringToFront();
                pageSwitcher.BringToFront();
        }
    }
}