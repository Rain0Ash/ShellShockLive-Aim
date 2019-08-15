// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;
using Ruler.Common.Forms;
using Ruler.Gui;
using SharpDX.Windows;

namespace Ruler
{
    internal sealed partial class RulerRender : RenderForm
    {
        internal readonly MainForm MainForm;
        internal RulerRender(ref MainForm mainForm)
        {
            MainForm = mainForm;
            InitializeComponent();
            MainForm.Closed += (sender, args) => Close();
        }
        

        internal void Start()
        {
            Manager.Start();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // turn on WS_EX_TOOLWINDOW style bit
                cp.ExStyle |= 0x80;
                return cp;
            }
        }
        
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x0021) //WM_MOUSEACTIVATE
            {
                m.Result = (IntPtr) 0x0003; //MA_NOACTIVATE
                return;
            }
            base.WndProc(ref m);
        }
        
        protected override Boolean ShowWithoutActivation
        {
            get { return true; }
        }
    }
}