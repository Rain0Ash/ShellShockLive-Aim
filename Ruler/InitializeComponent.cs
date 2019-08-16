// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Common.Forms;
using Ruler.Gui;
using Ruler.Properties;
using SharpDX.Windows;

namespace Ruler
{
    internal sealed partial class MainForm
    {
        private ValueBox powerValueBox;
        private ValueBox angleValueBox;
        private ValueBox windValueBox;
        private WeaponsPanel weaponsPanel;
        
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(resolution.Width, resolution.Height);

            #region Power Angle Wind valueBox defines
            powerValueBox = new ValueBox("Power")
            {
                BackColor = Color.FromArgb(75, 0, 0),
                Location = new Point(1500, 960),
                Size = new Size(200, 30),
                EndString = @"%",
                DefaultValue = 100,
                MaxValue = 100,
            };
            powerValueBox.Text = powerValueBox.MaxValue.ToString();
            powerValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref powerValueBox);
            powerValueBox.KeyDown += CheckAndIgnoreKeyboardPaste;
            
            angleValueBox = new ValueBox("Angle")
            {
                BackColor = Color.FromArgb(0, 75, 0),
                Location = new Point(1500, 920),
                Size = new Size(95, 30),
                EndString = @"°",
                Text = @"90",
                DefaultValue = 90,
                MaxValue = 359,
            };
            angleValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref angleValueBox);
            angleValueBox.KeyDown += CheckAndIgnoreKeyboardPaste;
            
            windValueBox = new ValueBox("Wind")
            {
                BackColor = Color.FromArgb(0, 0, 75),
                Location = new Point(1605, 920),
                Size = new Size(95, 30),
                EndString = $@"{localization.Meters}",
                Text = @"0",
                DefaultValue = 0,
                MaxValue = 100,
            };
            windValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref windValueBox);
            windValueBox.KeyDown += CheckAndIgnoreKeyboardPaste;
            #endregion
            
            weaponsPanel = new WeaponsPanel(monitor);

            MainForm thisForm = this;
            RulerRender ruler = new RulerRender(ref thisForm);

            TopMost = true;
            ControlBox = false;
            AutoScaleMode = AutoScaleMode.Font;
            Text = !isDisguise ? localization.RulerVersion : localization.MaskName;
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Icon = !isDisguise ? Resources.icon : Resources.notepad;
            ShowInTaskbar = !isDisguise;
            Location = new Point(resolution.X, resolution.Y);
            Size = new Size(resolution.Width, resolution.Height);
            Controls.Add(powerValueBox);
            Controls.Add(angleValueBox);
            Controls.Add(windValueBox);
            Controls.Add(weaponsPanel);
            ResumeLayout(false);
            PerformLayout();
            ruler.Start();
        }
    }
}