// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace Ruler.Gui
{
    public class SearchTextBox : TextBox
    {
        private Color color = Color.Azure;
        private readonly RulerLocalization localization = new RulerLocalization(MainForm.GetLocalCultureCode());
        internal SearchTextBox()
        {
            OnLeave(EventArgs.Empty);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            color = ForeColor;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Text.Length < 20 && (Char.IsDigit(e.KeyChar) || Char.IsLetter(e.KeyChar) || (e.KeyChar == ' ' && SelectionStart != 0 && Text[SelectionStart-1] != ' ') ||
                e.KeyChar == '-'))
            {
                return;
            }

            e.Handled = true;
            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (Text != String.Empty)
            {
                return;
            }

            ForeColor = Color.Gray;
            Text = localization.Search;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (Text != localization.Search)
            {
                return;
            }

            ForeColor = color;
            Text = String.Empty;
        }
    }
}