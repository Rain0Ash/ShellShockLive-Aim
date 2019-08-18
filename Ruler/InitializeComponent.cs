// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;
using Ruler.Common.Forms;
using Ruler.Gui;
using Ruler.Properties;

namespace Ruler
{
    internal sealed partial class MainForm
    {
        private const Int32 DistanceBetweenValueBox = 5;
        private const Int32 ValueBoxWidth = 100;
        private const Int32 ValueBoxHeight = 30;
        
        private ValueBox powerValueBox;
        private ValueBox angleValueBox;
        private ValueBox windValueBox;
        private WeaponsPanel weaponsPanel;
        
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new Size(resolution.Width, resolution.Height);

            Int32 valueBoxWidthPosition = (Int32) (0.75 * monitor.Resolution.Width);
            Int32 valueBoxHeightPosition = (Int32) (0.85 * EventsAndGlobalsController.CurrentMonitor.Resolution.Height);
            
            #region Power Angle Wind valueBox defines
            
            angleValueBox = new ValueBox("Angle")
            {
                BackColor = Color.FromArgb(0, 75, 0),
                Location = new Point(valueBoxWidthPosition, valueBoxHeightPosition),
                Size = new Size(ValueBoxWidth, ValueBoxHeight),
                EndString = @"°",
                DefaultValue = EventsAndGlobalsController.Angle,
                MaxValue = 359,
            };
            angleValueBox.Text = angleValueBox.DefaultValue.ToString();
            //angleValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref angleValueBox);

            windValueBox = new ValueBox("Wind")
            {
                BackColor = Color.FromArgb(0, 0, 75),
                Location = new Point(ValueBoxWidth + valueBoxWidthPosition + DistanceBetweenValueBox, valueBoxHeightPosition),
                Size = new Size(ValueBoxWidth, ValueBoxHeight),
                EndString = $@"{_localization.Meters}",
                DefaultValue = EventsAndGlobalsController.Wind,
                MaxValue = 100,
                MinValue = -100
            };
            windValueBox.Text = windValueBox.DefaultValue.ToString();
            //windValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref windValueBox);

            powerValueBox = new ValueBox("Power")
            {
                BackColor = Color.FromArgb(75, 0, 0),
                Location = new Point(valueBoxWidthPosition, ValueBoxHeight + valueBoxHeightPosition),
                Size = new Size(2*ValueBoxWidth + DistanceBetweenValueBox, ValueBoxHeight),
                EndString = @"%",
                DefaultValue = EventsAndGlobalsController.Power,
                MaxValue = 100,
            };
            powerValueBox.Text = powerValueBox.DefaultValue.ToString();
            //powerValueBox.TextChanged += (sender, e) => ValueBoxOnTextChanged(ref powerValueBox);

            #endregion
            
            weaponsPanel = new WeaponsPanel();

            MainForm thisForm = this;
            RulerRender ruler = new RulerRender(ref thisForm);

            TopMost = true;
            ControlBox = false;
            AutoScaleMode = AutoScaleMode.Font;
            Text = !isDisguise ? _localization.RulerVersion : _localization.MaskName;
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