using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ruler.Common.Forms
{
    public sealed class ValueBox : TextBox, INotifyPropertyChanged
    {
        public Label label = new Label(){};

        private String endString;
        public String EndString
        {
            get
            {
                return endString;
            }
            set
            {
                endString = value;
                OnPropertyChanged("EndString");
            }
        }

        public Int32 MaxValue { get; set; }
        public Int32 DefaultValue { get; set; }

        public ValueBox(String name)
        {
            Name = name;
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Font = new Font("Microsoft Sans Serif", 24f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            ForeColor = Color.FromArgb(255, 255, 255);
            Margin = new Padding(0);
            ShortcutsEnabled = false;
            AllowDrop = false;
            RightToLeft = RightToLeft.No;
            TextAlign = HorizontalAlignment.Center;
            BorderStyle = BorderStyle.None;
            Visible = true;

            label.Click += (sender, e) =>
            {
                Focus();
                SelectionStart = Text.Length;
            };
            label.Font = Font;
            label.Margin = Margin;
            label.Parent = this;
            label.AutoSize = false;
            label.RightToLeft = RightToLeft.Yes;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.ForeColor = ForeColor;
            label.Visible = true;
            DataBindings.Add(new Binding("EndString", this, "EndString"));
            PropertyChanged += OnEndStringChanged;
            Controls.Add(label);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateLabelSize();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SelectionStart = Text.Length;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (Text.Length == 0)
            {
                Text = DefaultValue.ToString();
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            label.Font = Font;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            UpdateLabelLocation();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            UpdateLabelLocation();
        }

        private void UpdateLabelLocation()
        {
            label.Location = new Point(Size.Width / 2 + (Int32) Math.Floor(Font.SizeInPoints * Text.Length / (Name == "Wind" ? 2.1 : 2.2)), 0);
        }

        private void UpdateLabelSize()
        {
            label.Size = new Size((Int32)(TextRenderer.MeasureText(label.Text, label.Font, Size, TextFormatFlags.Bottom).Width * 0.65), Size.Height);
        }

        private void OnEndStringChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "EndString")
            {
                return;
            }

            label.Text = EndString;
            UpdateLabelSize();
        }
        
        
        #region INotifyPropertyChanged Members
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}