// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Properties;
using SharpDX.Windows;

namespace Ruler.Gui
{
    internal sealed class WeaponsPanel : Label
    {
        internal Int32 MaxWeaponInLine { get; set; } = 10;
        internal Int32 MaxWeaponInColumn { get; set; } = 4;
        private Button Extender { get; set; }
        private WeaponContainer WeaponButtonsContainer { get; set; }
        
        internal Manager Manager;
        public WeaponsPanel(ref RenderForm renderForm)
        {
            BackColor = Color.Transparent;
            Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            Location = new Point(renderForm.Location.X, renderForm.Location.Y);
            Size = new Size(renderForm.Size.Width * 29/112, 40*21);
            
            WeaponButtonsContainer = new WeaponContainer()
            {
                Font = Font,
                BackColor = Color.FromArgb(50, 255, 255, 255),
                Location = Location,
                Size = Size,
                Visible = true
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
                Location = new Point(0, 0),
                Size = new Size(20, 35),
            };

            Extender.Click += Extender_OnClick;

            Controls.Add(Extender);
            Controls.Add(WeaponButtonsContainer);

            EventController.ChangeWeaponMenuState += Extender_OnClick;
        }
        
        private void Extender_OnClick(Object sender, EventArgs e)
        {
            WeaponButtonsContainer.Visible = !WeaponButtonsContainer.Visible;
        }
    }
}