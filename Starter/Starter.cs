// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Starter.Localization;

namespace Ruler.Starter
{
    public partial class Starter : Form
    {


        public Starter()
        {
            Process starter = Process.GetCurrentProcess();
            InitializeComponent();
        }
        private void Starter_Load(Object sender, EventArgs e)
        {
            CenterToScreen();
            LicenceID.Focus();
            LanguageComboBox.DataSource = new StarterLocalization().GetCultures()
                .Select(culture => new DropDownItem(culture.CultureName) { Image = culture.CultureImage }).ToList();

            LanguageComboBox_ChangeStarterLanguage(sender, e);
        }

        private void LicenceID_TextChanged(Object sender, EventArgs e)
        {
            String text = new Regex("[^0-9a-zA-Z']").Replace(LicenceID.Text, String.Empty);

            if (text.Length > Licence.MaxIDLength)
            {
                Int32 selection = LicenceID.SelectionStart;
                LicenceID.Text = text.Remove(selection-(text.Length - Licence.MaxIDLength), text.Length - Licence.MaxIDLength);
                LicenceID.SelectionStart = selection- (text.Length - Licence.MaxIDLength);
            }
            else
            {
                Int32 selection = LicenceID.SelectionStart;
                LicenceID.Text = text;
                LicenceID.SelectionStart = selection;
            }
            
        }
        private void LanguageComboBox_ChangeStarterLanguage(Object sender, EventArgs e)
        {
            localization.UpdateLocalization(new Localization.Culture(null, LanguageComboBox.Text).CultureCode);
            Text = localization.StarterTitle;
            LanguageLabel.Text = localization.LanguageLabel;
            IDLabel.Text = localization.IDLabel;
            KeyLabel.Text = localization.KeyLabel;
            IsDisguiseRuler.Text = localization.DisguiseCheckBox;
            NotDisplayCheckBox.Text = localization.NotDisplayAnymoreCheckBox;
            StartButton.Text = localization.StartButton;
        }

        private void LanguageComboBox_DropDownClosed(Object sender, EventArgs e)
        {
            LanguageLabel.Focus();
        }

        private async void StartButton_Click(Object sender, EventArgs e)
        {
            async Task invalidMessage(String message)
            {
                String text = StartButton.Text;
                StartButton.BackColor = Color.LightPink;
                StartButton.ForeColor = Color.Black;
                StartButton.Font = new Font(StartButton.Font, FontStyle.Bold);
                StartButton.Text = message;
                StartButton.Enabled = false;
                LanguageComboBox.Enabled = false;
                await Task.Delay(1500);
                StartButton.BackColor = DefaultBackColor;
                StartButton.ForeColor = DefaultForeColor;
                StartButton.Font = new Font(StartButton.Font, FontStyle.Regular);
                StartButton.Text = text;
                StartButton.Enabled = true;
                LanguageComboBox.Enabled = true;
            }

            
            if (LicenceID.Text.Length == 0)
            {
                LicenceID.Focus();
                await invalidMessage(localization.IDLabel);
                return;
            }
            if (!LicenceKey.MaskFull)
            {
                LicenceKey.Focus();
                String key = new Regex("[^0-9A-Z- ']").Replace(LicenceKey.Text, String.Empty).TrimEnd(' ', '-');
                Int32 selStart = key.TakeWhile(c => c == ' ' || c == '-').Count();
                Int32 keyLength = key.Length - selStart;
                LicenceKey.SelectionStart = selStart;
                LicenceKey.SelectionLength = keyLength;
                await invalidMessage(localization.KeyLabel);
                return;
            }


            Licence licence = new Licence(LicenceID.Text, LicenceKey.Text);
            if (!licence.IsValid())
            {
                await invalidMessage(localization.InvalidKeyID);
                return;
            }

            Hide();
            Form ruler = new Ruler(licence, CountryData.EnglishNameByIso2.FirstOrDefault(x => x.Value == LanguageComboBox.Text).Key.ToLower(),
                IsDisguiseRuler.Checked);
            ruler.Closed += (s, args) => this.Close();
            ruler.Show();
        }
    }
}
