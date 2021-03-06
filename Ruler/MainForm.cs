// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common;
using Ruler.Common;
using Ruler.Common.Forms;
using Common_Localization = Common.Localization;

namespace Ruler
{
    internal sealed partial class MainForm : Form
    {
        private readonly Licence licence;
        private readonly Monitor monitor;
        private static RulerLocalization _localization = new RulerLocalization(Common_Localization.GetCurrentCulture());
        private readonly Boolean isDisguise;
        private System.Drawing.Rectangle resolution; 
        
        internal MainForm(Licence licence, Monitor monitor, String languageCode = null, Boolean isDisguise = false)
        {
            this.licence = licence;
            this.monitor = monitor;
            EventsAndGlobalsController.CurrentMonitor = monitor;
            _localization = new RulerLocalization(languageCode);
            this.isDisguise = isDisguise;
            resolution = monitor.Resolution;
            InitializeComponent();
        }
        
        internal static String GetLocalCultureCode()
        {
            return _localization.GetLocalCultureCode();
        }

            
        private static void ValueBoxOnTextChanged(ref ValueBox valueBox)
        {
            String text = new Regex("-[^0-9]{1,3}").Replace(valueBox.Text, String.Empty);
            Int32.TryParse(text, out Int32 value);

            if (valueBox.Name == "Angle" && value > valueBox.MaxValue)
            {
                valueBox.Text = (value % 360).ToString();
                valueBox.SelectionStart = valueBox.Text.Length;
            }
            
            else if (value > valueBox.MaxValue)
            {
                Int32 selection = valueBox.SelectionStart;
                valueBox.Text = valueBox.MaxValue.ToString();
                valueBox.SelectionStart = selection;
            }
            else if (value < -100)
            {
                valueBox.Text = @"0";
                valueBox.SelectionStart = 1;
            }
            else
            {
                Int32 selection = valueBox.SelectionStart;
                valueBox.Text = text;
                valueBox.SelectionStart = selection == 0 ? 0 : selection <= valueBox.Text.Length ? selection : valueBox.Text.Length;
            }
        }
    }
}