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
        private const Int32 MaxWeaponsInColumn = 21;
        private const Int32 MaxWeaponsInLine = 4;
        internal const Int32 ButtonWidth = 120;
        internal const Int32 ButtonHeight = 35;
        internal const Int32 LevelLabelWidth = 25;
        internal const Int32 DistanceBetweenButtons = 5;
        private Button Extender { get; }
        private WeaponsContainer WeaponButtonsContainer { get; }

        private CurrentWeaponButton currentWeaponButton;
        public WeaponsPanel()
        {
            currentWeaponButton = new CurrentWeaponButton()
            {
                Weapon = Weapons.Common.Weapons.WeaponList[0],
                Size = new Size(ButtonWidth, ButtonHeight),
            };
            currentWeaponButton.Location = new Point(LevelLabelWidth, 0);

            Extender = new Button()
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
            Extender.Click += Extender_OnClick;
            
            BackColor = Color.Transparent;
            Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            Location = new Point(EventsAndGlobalsController.CurrentMonitor.Resolution.X, EventsAndGlobalsController.CurrentMonitor.Resolution.Y);
            Size = new Size(Extender.Size.Width + DistanceBetweenButtons + (MaxWeaponsInLine+1)*(ButtonWidth+DistanceBetweenButtons),
                MaxWeaponsInColumn*(Extender.Size.Height+DistanceBetweenButtons));
            WeaponButtonsContainer = new WeaponsContainer()
            {
                Font = Font,
                BackColor = Color.FromArgb(0, 255, 255, 255),
                Location = Location,
                Size = Size,
                Visible = false
            };

            Controls.Add(Extender);
            Controls.Add(WeaponButtonsContainer);
            Controls.Add(currentWeaponButton);
            EventsAndGlobalsController.ChangedWeaponMenuState += Extender_OnClick;
        }
        
        private void Extender_OnClick(Object sender, EventArgs e)
        {
            WeaponButtonsContainer.Visible = !WeaponButtonsContainer.Visible;
            currentWeaponButton.BringToFront();
        }
    }
    
    internal sealed class CurrentWeaponButton : WeaponButton
    {
        internal static event EventsAndGlobalsController.SwitchedState ResetWeaponButtons;
        internal CurrentWeaponButton()
        {
            Brush = Brushes.Cyan;
            EventsAndGlobalsController.ChangedWeapon += weapon => Weapon = weapon;
        }

        protected override void ActivateAndDeactivate(String name){}

        protected override void OnClick(EventArgs e)
        {
            EventsAndGlobalsController.Weapon = Weapons.Common.Weapons.WeaponList[0];
            ResetWeaponButtons?.Invoke(Name);
        }
    }
}