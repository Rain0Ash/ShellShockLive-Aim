using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ruler.Forms
{
    class WaterMarkTextBox : TextBox
    {
        private Font oldFont = null;
        private Boolean waterMarkTextEnabled = false;

        #region Attributes 
        private Color waterMarkColor = Color.Gray;
        public Color WaterMarkColor
        {
            get { return waterMarkColor; }
            set
            {
                waterMarkColor = value; Invalidate();
            }
        }

        private String waterMarkText = "Water Mark";
        public String WaterMarkText
        {
            get { return waterMarkText; }
            set { waterMarkText = value; Invalidate(); }
        }
        #endregion

        public WaterMarkTextBox()
        {
            JoinEvents(true);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            WaterMark_Toggel(null, null);
        }

        protected override void OnPaint(PaintEventArgs args)
        {

            System.Drawing.Font drawFont = new Font(Font.FontFamily,
                Font.Size, Font.Style, Font.Unit);

            SolidBrush drawBrush = new SolidBrush(WaterMarkColor);
            
            args.Graphics.DrawString((waterMarkTextEnabled ? WaterMarkText : Text),
                drawFont, drawBrush, new PointF(0.0F, 0.0F));
            base.OnPaint(args);
        }

        private void JoinEvents(Boolean join)
        {
            if (!join)
            {
                return;
            }

            this.TextChanged += new EventHandler(this.WaterMark_Toggel);
            this.LostFocus += new EventHandler(this.WaterMark_Toggel);
            this.FontChanged += new EventHandler(this.WaterMark_FontChanged);
        }

        private void WaterMark_Toggel(Object sender, EventArgs args)
        {
            if (this.Text.Length <= 0)
                EnableWaterMark();
            else
                DisbaleWaterMark();
        }

        private void EnableWaterMark()
        {
            oldFont = new System.Drawing.Font(Font.FontFamily, Font.Size, Font.Style,
               Font.Unit);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.waterMarkTextEnabled = true;
            Refresh();
        }

        private void DisbaleWaterMark()
        {
            this.waterMarkTextEnabled = false;
            this.SetStyle(ControlStyles.UserPaint, false);
            if (oldFont != null)
                this.Font = new Font(oldFont.FontFamily, oldFont.Size,
                    oldFont.Style, oldFont.Unit);
        }

        private void WaterMark_FontChanged(Object sender, EventArgs args)
        {
            if (!waterMarkTextEnabled)
            {
                return;
            }

            oldFont = new Font(Font.FontFamily, Font.Size, Font.Style,
                Font.Unit);
            Refresh();
        }
    }
}
