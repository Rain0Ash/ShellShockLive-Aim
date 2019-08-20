// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Ruler.Common.Forms
{
    public class AngleBox : ValueBox
    {
        public AngleBox()
        {
            AngleToQuarter();
        }
        
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            AngleToQuarter();
            Label.Visible = false;
        }
        
        private void AngleToQuarter()
        {
            Int32 number = Int32.Parse(Value == "" || Value == @"-" ? "0" : Value);
            Int32 angle = number < 0 ? 360 + number % 360 : number % 360;
            Text = $@"{(angle <= 90 ? angle : angle <= 270 ? 180 - angle : angle - 360)}{EndString} ({(angle / 90) + 1})";
        }

        protected override void OnValueChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Value")
            {
                return;
            }
            if (!Focused)
            {
                AngleToQuarter();
            }
            else
            {
                Text = Value;
            }
        }
        protected override void SetValue(Int32 value)
        {
            base.SetValue(value);            
            EventsAndGlobalsController.Angle = value;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (Regex.IsMatch(Text, "^-?\\d{1,3}.*\\(\\d\\)$"))
            {
                return;
            }
            base.OnTextChanged(e);
        }
    }
}