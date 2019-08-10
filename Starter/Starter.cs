// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Ruler.Properties;
using Ruler.Starter.Registry;
using Settings = Common.Settings;

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
            LanguageImagedComboBox.DataSource = Localization.GetCultures()
                .Select(culture => new DropDownItem(culture.CultureName) { Image = culture.CultureImage }).ToList();
            
            ScreenImagedComboBox.DataSource = Monitors.GetMonitors()
                .Select(screen => new DropDownItem($"{(screen.Name.Length > 0 ? screen.Name[screen.Name.Length-1] : 'U')} {screen.Resolution.Width.ToString()}x{screen.Resolution.Height.ToString()} [{screen.Frequency.ToString()}]"){Image = Resources.monitor}).ToList();

            LicenceID.MaxLength = Licence.MaxIDLength;
            LicenceKey.MaxLength = Licence.MaxKeyLength;
            LicenceID.Mask = $@"A{String.Concat(Enumerable.Repeat("a", Licence.MaxIDLength - 1))}";
            LicenceKey.Mask = $@"{String.Concat(Enumerable.Repeat($@"{String.Concat(Enumerable.Repeat("A", Licence.MaxKeyCharInCell))}-", Licence.MaxKeyCells))}".TrimEnd('-');
            
            RegistrySettings registrySettings = Registry.Registry.GetRegistry();
            if (registrySettings.DontUseRegistry || !Licence.Sha256(Settings.Version).Equals(registrySettings.BuildDateTimeHash, StringComparison.OrdinalIgnoreCase))
                registrySettings = Registry.Registry.GetRegistry(true);

            Int32 getLanguageIndex()
            {
                for (Int32 i = 0; i < LanguageImagedComboBox.Items.Count; i++)
                {
                    if (String.Equals((LanguageImagedComboBox.Items[i] as DropDownItem)?.Value, 
                        new Localization.Culture(registrySettings.LanguageCode).CultureName,
                        StringComparison.CurrentCultureIgnoreCase))
                    {
                        return i;
                    }
                }
                return 0;
            }
            
            LicenceID.Text = registrySettings.ID;
            LicenceKey.Text = registrySettings.Key;
            LanguageImagedComboBox.SelectedIndex = getLanguageIndex();
            ScreenImagedComboBox.SelectedIndex = registrySettings.MonitorID < ScreenImagedComboBox.Items.Count ? registrySettings.MonitorID : 0;
            IsDisguiseRuler.Checked = registrySettings.IsDisguise;
            NotSaveSettingsCheckBox.Checked = registrySettings.DontUseRegistry;
            NotDisplayAnymoreCheckBox.Checked = registrySettings.DontShowAnymore;

            LicenceID.Focus();

            LanguageImagedComboBox_ChangeStarterLanguage(sender, e);
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
        private void LanguageImagedComboBox_ChangeStarterLanguage(Object sender, EventArgs e)
        {
            localization.UpdateLocalization(new Localization.Culture(null, LanguageImagedComboBox.Text).CultureCode);
            Text = localization.StarterTitle;
            LanguageLabel.Text = localization.LanguageLabel;
            ScreenLabel.Text = localization.ScreenLabel;
            IDLabel.Text = localization.IDLabel;
            KeyLabel.Text = localization.KeyLabel;
            IsDisguiseRuler.Text = localization.DisguiseCheckBox;
            NotSaveSettingsCheckBox.Text = localization.NotSaveSettings;
            NotDisplayAnymoreCheckBox.Text = localization.NotDisplayAnymoreCheckBox;
            StartButton.Text = localization.StartButton;
        }

        private void ComboBox_DropDownClosed(Object sender, EventArgs e)
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
                LanguageImagedComboBox.Enabled = false;
                await Task.Delay(1500);
                StartButton.BackColor = DefaultBackColor;
                StartButton.ForeColor = DefaultForeColor;
                StartButton.Font = new Font(StartButton.Font, FontStyle.Regular);
                StartButton.Text = text;
                StartButton.Enabled = true;
                LanguageImagedComboBox.Enabled = true;
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
                LicenceID.Focus();
                await invalidMessage(localization.InvalidKeyID);
                return;
            }

            try
            {
                String languageCode = CountryData.EnglishNameByIso2.FirstOrDefault(x => x.Value == LanguageImagedComboBox.Text).Key.ToLower();
                
                if (!NotSaveSettingsCheckBox.Checked)
                {
                    Registry.Registry.SetRegistry(new RegistrySettings(LicenceID.Text, LicenceKey.Text, languageCode, ScreenImagedComboBox.SelectedIndex,
                        IsDisguiseRuler.Checked, NotSaveSettingsCheckBox.Checked, NotDisplayAnymoreCheckBox.Checked));
                }
                else
                {
                    Registry.Registry.RemoveRegistry();
                }

                Hide();
                Form ruler = new Ruler(licence, Monitors.GetMonitors()[ScreenImagedComboBox.SelectedIndex],
                    languageCode,
                    IsDisguiseRuler.Checked);
                ruler.Closed += (s, args) => Close();
                ruler.Show();
                Dispose();
            }
            catch (ObjectDisposedException)
            {
                Close();
                Application.Exit();
            }
        }
    }
}
