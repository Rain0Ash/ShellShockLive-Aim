// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;
using System.Windows.Forms;

namespace Ruler
{
    internal sealed partial class RulerRender
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            Enabled = false;
            TopMost = true;
            ControlBox = false;
            ShowInTaskbar = false;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Location = new Point(0, 0);
            Size = new Size(MainForm.Width, MainForm.Height);
            ResumeLayout(false);
            PerformLayout();
            InitializeForm();
        }
    }
}