// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Common;
using Ruler.Common;
using Common_Localization = Common.Localization;

namespace Ruler
{
    internal sealed partial class MainForm : Form
    {
        private readonly IContainer components = null;
        private readonly Licence licence;
        private readonly Monitor monitor;
        private static RulerLocalization _localization = new RulerLocalization(Common_Localization.GetCurrentCulture());
        private readonly Boolean isDisguise;

        protected override Boolean ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys != Keys.None || keyData != Keys.Escape)
                return base.ProcessDialogKey(keyData);
            Close();
            return true;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 33554432;
                return createParams;
            }
        }
        
        internal MainForm(Licence licence, Monitor monitor, String gameResolution, String languageCode = null, Boolean isDisguise = false)
        {
            this.licence = licence;
            this.monitor = monitor;
            EventsAndGlobalsController.CurrentMonitor = monitor;
            EventsAndGlobalsController.Parameters = Parameter.GetParameters(gameResolution);
            _localization = new RulerLocalization(languageCode);
            this.isDisguise = isDisguise;
            EventsAndGlobalsController.RegisterHotKeys(Handle);
            InitializeComponent();
        }
        
        internal static String GetLocalCultureCode()
        {
            return _localization.GetLocalCultureCode();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            manager.NextFrame(graphics);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 786)
            {
                if (EventsAndGlobalsController.RecognizeInputAndThrowEvent(ref m))
                {
                    Invalidate();
                }
            }
            base.WndProc(ref m);
        }
        
        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}