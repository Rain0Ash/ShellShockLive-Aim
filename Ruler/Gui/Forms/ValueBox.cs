// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ruler.Common.Forms
{
    public sealed class ValueBox : TextBox, INotifyPropertyChanged
    {
        public readonly Label Label = new Label();

        private String endString;

        public String EndString
        {
            get
            {
                return endString;
            }
            set
            {
                if (endString == value)
                {
                    return;
                }

                endString = value;
                OnPropertyChanged("EndString");
            }
        }

        public Int32 MaxValue { get; set; }

        public Int32 MinValue { get; set; }

        private Int32 defaultValue;

        public Int32 DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                if (defaultValue == value)
                {
                    return;
                }

                defaultValue = value;
                OnPropertyChanged("DefaultValue");
            }
        }

        private String value;

        public String Value
        {
            get
            {
                return value;
            }
            set
            {
                if (this.value == value)
                {
                    return;
                }

                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public ValueBox(String name)
        {
            Name = name;
            Value = @"0";
            Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Font = new Font("Microsoft Sans Serif", 20f, FontStyle.Bold, GraphicsUnit.Pixel, 204);
            ForeColor = Color.FromArgb(255, 255, 255);
            Margin = new Padding(0);
            ShortcutsEnabled = false;
            AllowDrop = false;
            RightToLeft = RightToLeft.No;
            TextAlign = HorizontalAlignment.Center;
            BorderStyle = BorderStyle.None;
            Visible = true;

            Label.Click += (sender, e) =>
            {
                Focus();
                SelectionStart = Text.Length;
            };
            Label.Font = Font;
            Label.Margin = Margin;
            Label.Parent = this;
            Label.AutoSize = false;
            Label.RightToLeft = RightToLeft.Yes;
            Label.TextAlign = ContentAlignment.MiddleCenter;
            Label.ForeColor = ForeColor;
            Label.Visible = true;
            DataBindings.Add(new Binding("EndString", this, "EndString"));
            PropertyChanged += OnEndStringChanged;
            PropertyChanged += OnDefaultValueChanged;
            PropertyChanged += OnValueChanged;
            Label.BringToFront();
            Controls.Add(Label);
            AngleToQuarter();
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (Text == Value)
            {
                return;
            }

            Text = Value;
            SelectionStart = Value.Length;
            Label.Visible = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (Name != "Angle")
            {
                return;
            }
            AngleToQuarter();
            Label.Visible = false;
        }

        private void AngleToQuarter()
        {
            if (Name != "Angle")
            {
                return;
            }
            Int32 number = Int32.Parse(Value == "" || Value == @"-" ? "0" : Value);
            Int32 angle = number < 0 ? 360 + number % 360 : number % 360;
            Text = $@"{(angle <= 90 ? angle : angle <= 270 ? 180 - angle : angle - 360)}{EndString} ({(angle / 90) + 1})";
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (!e.Control) { return; }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-' || Name != "Wind"))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && (Text.StartsWith("-") || SelectionStart != 0))
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsControl(e.KeyChar) && e.KeyChar != '-' && Text.Replace("-", "").Length >= 3 &&
                SelectionLength == 0)
            {
                e.Handled = true;
                return;
            }

            if (SelectionStart == 0 && Text.StartsWith("-"))
            {
                e.Handled = true;
                return;
            }

            /*if (Char.IsNumber(e.KeyChar))
            {
                Int32 futureValue =
                    Int32.Parse(Text.Insert(SelectionStart, Char.IsNumber(e.KeyChar) ? $"{e.KeyChar}" : ""));
                if (Name == "Angle")
                {
                    Text = (futureValue % 360).ToString();
                }
                else if (futureValue > MaxValue)
                {
                    Text = MaxValue.ToString();
                    SelectionStart = Text.Length;
                }
                else if (futureValue < MinValue)
                {
                    Text = MinValue.ToString();
                    SelectionStart = Text.Length;
                }

                e.Handled = true;
                return;
            }*/

            if (Char.IsNumber(e.KeyChar))
            {
                switch (SelectionStart)
                {
                    case 2 when Text[0] == '-' && Text[1] == '0':
                        Text = $@"-{e.KeyChar}";
                        SelectionStart = 2;
                        e.Handled = true;
                        break;
                    case 1 when Text[0] == '0':
                        Text = $@"{e.KeyChar}";
                        SelectionStart = 1;
                        e.Handled = true;
                        break;
                }
            }
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
                Text = @"0";
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Label.Font = Font;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            UpdateLabelLocation();

            if (Regex.IsMatch(Text, "^-?\\d{1,3}.*\\(\\d\\)$"))
            {
                return;
            }

            if (Text.StartsWith("0") && Text.Length > 1)
            {
                Text = Text.Substring(1);
            }
            else if (Text != "" && Text[0] == '-' && Text.Substring(1).StartsWith("0") && Text.Length > 2)
            {
                Text = Text.Substring(1);
            }

            Int32 number = Int32.Parse(Text == "" || Text == @"-" ? "0" : Text);

            Value = number.ToString();
            switch (Name)
            {
                case "Power":
                    EventsAndGlobalsController.Power = number;
                    break;
                case "Angle":
                    EventsAndGlobalsController.Angle = number;
                    break;
                case "Wind":
                    EventsAndGlobalsController.Wind = number;
                    break;
                default:
                    break;
            }
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            UpdateLabelLocation();
        }

        private void UpdateLabelLocation()
        {
            Label.Location =
                new Point(
                    Size.Width / 2 + (Int32)Math.Floor(Font.SizeInPoints * Text.Length / (Name == "Wind" ? 2 : 2.1)),
                    0);
        }

        private void UpdateLabelSize()
        {
            Label.Size =
                new Size(
                    (Int32)(TextRenderer.MeasureText(Label.Text, Label.Font, Size, TextFormatFlags.Bottom).Width *
                            0.65), Size.Height);
        }

        private void OnEndStringChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "EndString")
            {
                return;
            }

            Label.Text = EndString;
            UpdateLabelSize();
        }

        private void OnDefaultValueChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "DefaultValue")
            {
                return;
            }

            if (!Focused)
            {
                OnLeave(EventArgs.Empty);
            }
            else
            {
                Value = DefaultValue.ToString();
            }
        }

        private void OnValueChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Value")
            {
                return;
            }
            if (Name == "Angle" && !Focused)
            {
                AngleToQuarter();
            }
            else
            {
                Text = Value;
            }
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