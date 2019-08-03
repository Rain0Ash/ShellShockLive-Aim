// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Ruler.Forms;
using Hash = Common.Hash;

namespace Ruler.Starter
{
    public partial class Starter : Form
    {


        public Starter()
        {
            InitializeComponent();
        }

        private void Starter_Load(Object sender, EventArgs e)
        {
            CenterToScreen();
            LicenceID.Focus();

            List<DropDownItem> languages = new List<DropDownItem>();
            foreach (String iso2 in new StarterLocalization().GetCultures())
            {
                CountryData.EnglishNameByIso2.TryGetValue(iso2.ToUpper(), out String value);
                if (value == null)
                {
                    continue;
                }

                DropDownItem item = new DropDownItem(value);
                Image image = (Image)new LanguageFlags().GetFlag(iso2);
                if (image != null)
                    item.Image = image;
                languages.Add(item);
            }
            LanguageComboBox.DataSource = languages;

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
            localization.UpdateLocalization(CountryData.EnglishNameByIso2.FirstOrDefault(x => x.Value == LanguageComboBox.Text).Key.ToLower());
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

            String isValidKeyID = Hash.Sha256(LicenceID.Text + "@" + LicenceKey.Text);

            if (!Licence.ValidHash.Contains(isValidKeyID))
            {
                await invalidMessage(localization.InvalidKeyID);
                return;
            }

            Hide();
            Form ruler = new Ruler(CountryData.EnglishNameByIso2.FirstOrDefault(x => x.Value == LanguageComboBox.Text).Key.ToLower(),
                IsDisguiseRuler.Checked, isValidKeyID != Licence.ValidHash[0]);
            ruler.Closed += (s, args) => this.Close();
            ruler.Show();
        }
    }
}
