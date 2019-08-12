using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ruler.Common.Forms;
using Ruler.Gui;
using Ruler.Properties;
using SharpDX.Windows;

namespace Ruler
{
    internal sealed partial class Ruler
    {
        private ValueBox boxPower;
        private ValueBox boxAngle;
        private ValueBox boxWind;
        private WeaponsPanel weaponsPanel;
        
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(resolution.Width, resolution.Height);
            boxPower = new ValueBox("Power")
            {
                BackColor = Color.FromArgb(75, 0, 0),
                Location = new Point(1500, 960),
                Size = new Size(200, 30),
                EndString = @"%",
                DefaultValue = 100,
                MaxValue = 100,
            };
            boxPower.Text = boxPower.MaxValue.ToString();
            boxPower.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref boxPower);
            boxPower.KeyDown += valueBoxKeyDown;
            
            boxAngle = new ValueBox("Angle")
            {
                BackColor = Color.FromArgb(0, 75, 0),
                Location = new Point(1500, 920),
                Size = new Size(95, 30),
                EndString = @"°",
                Text = @"90",
                DefaultValue = 90,
                MaxValue = 359,
            };
            boxAngle.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref boxAngle);
            boxAngle.KeyDown += valueBoxKeyDown;
            
            boxWind = new ValueBox("Wind")
            {
                BackColor = Color.FromArgb(0, 0, 75),
                Location = new Point(1605, 920),
                Size = new Size(95, 30),
                EndString = $@"{localization.Meters}",
                Text = @"0",
                DefaultValue = 0,
                MaxValue = 100,
            };
            boxWind.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref boxWind);
            boxWind.KeyDown += valueBoxKeyDown;

            RenderForm thisForm = this;
            weaponsPanel = new WeaponsPanel(ref thisForm);

            TopMost = true;
            ControlBox = false;
            AutoScaleMode = AutoScaleMode.Font;
            Name = nameof(Ruler);
            Text = !isDisguise ? localization.RulerVersion : localization.MaskName;
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Icon = !isDisguise ? Resources.icon : Resources.notepad;
            ShowInTaskbar = !isDisguise;
            Location = new Point(resolution.X, resolution.Y);
            Size = new Size(resolution.Width, resolution.Height);
            Controls.Add(boxPower);
            Controls.Add(boxAngle);
            Controls.Add(boxWind);
            Controls.Add(weaponsPanel);
            ResumeLayout(false);
            PerformLayout();
            InitializeForm();
        }
    }
}