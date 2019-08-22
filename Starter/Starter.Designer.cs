// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Properties;
using Common;
using Ruler.Properties;
using Starter.Localization;

namespace Ruler.Starter
{
    partial class Starter
    {
        StarterLocalization localization = new StarterLocalization();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.LanguageImagedComboBox = new ImagedComboBox();
            this.ScreenLabel = new System.Windows.Forms.Label();
            this.ScreenImagedComboBox = new ImagedComboBox();            
            this.AboutButton = new Button();
            this.GameResolutionLabel = new System.Windows.Forms.Label();
            this.GameResolutionImagedComboBox = new ImagedComboBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.LicenceID = new System.Windows.Forms.MaskedTextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.LicenceKey = new System.Windows.Forms.MaskedTextBox();
            this.IsDisguiseRuler = new System.Windows.Forms.CheckBox();
            this.NotSaveSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.NotDisplayAnymoreCheckBox = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(10, 5);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(55, 13);
            // 
            // LanguageComboBox
            // 
            this.LanguageImagedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LanguageImagedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageImagedComboBox.FormattingEnabled = true;
            this.LanguageImagedComboBox.Location = new System.Drawing.Point(10, 20);
            this.LanguageImagedComboBox.Name = "LanguageImagedComboBox";
            this.LanguageImagedComboBox.Size = new System.Drawing.Size(100, 21);
            this.LanguageImagedComboBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            this.LanguageImagedComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageImagedComboBox_ChangeStarterLanguage);
            // 
            // ScreenLabel
            // 
            this.ScreenLabel.AutoSize = true;
            this.ScreenLabel.Location = new System.Drawing.Point(130, 5);
            this.ScreenLabel.Name = "ScreenLabel";
            this.ScreenLabel.Size = new System.Drawing.Size(55, 13);
            // 
            // ScreenComboBox
            // 
            this.ScreenImagedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ScreenImagedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScreenImagedComboBox.FormattingEnabled = true;
            this.ScreenImagedComboBox.Location = new System.Drawing.Point(130, 20);
            this.ScreenImagedComboBox.Name = "ScreenImagedComboBox";
            this.ScreenImagedComboBox.Size = new System.Drawing.Size(130, 21);
            this.ScreenImagedComboBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(265, 11);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(30, 30);
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Image = new Bitmap(SystemIcons.Information.ToBitmap(), new Size(20, 20));
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // 
            // GameResolutionLabel
            // 
            this.GameResolutionLabel.AutoSize = true;
            this.GameResolutionLabel.Location = new System.Drawing.Point(130, 45);
            this.GameResolutionLabel.Name = "GameResolutionLabel";
            this.GameResolutionLabel.Size = new System.Drawing.Size(55, 13);
            // 
            // GameResolutionComboBox
            // 
            this.GameResolutionImagedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GameResolutionImagedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameResolutionImagedComboBox.FormattingEnabled = true;
            this.GameResolutionImagedComboBox.Location = new System.Drawing.Point(130, 60);
            this.GameResolutionImagedComboBox.Name = "GameResolutionImagedComboBox";
            this.GameResolutionImagedComboBox.Size = new System.Drawing.Size(130, 21);
            this.GameResolutionImagedComboBox.DropDownClosed += new System.EventHandler(this.ComboBox_DropDownClosed);
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(10, 85);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(59, 13);
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(130, 85);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(66, 13);
            // 
            // LicenceID
            // 
            this.LicenceID.Location = new System.Drawing.Point(10, 100);
            this.LicenceID.Name = "LicenceID";
            this.LicenceID.Size = new System.Drawing.Size(100, 20);
            this.LicenceID.Multiline = false;
            this.LicenceID.PromptChar = ' ';
            this.LicenceID.HidePromptOnLeave = true;
            this.LicenceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //this.LicenceID.TextChanged += new System.EventHandler(this.LicenceID_TextChanged);
            // 
            // LicenceKey
            // 
            this.LicenceKey.AsciiOnly = true;
            this.LicenceKey.Location = new System.Drawing.Point(130, 100);
            this.LicenceKey.Name = "LicenceKey";
            this.LicenceKey.Size = new System.Drawing.Size(160, 20);
            this.LicenceKey.Multiline = false;
            this.LicenceKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IsDisguiseRuler
            // 
            this.IsDisguiseRuler.AutoSize = true;
            this.IsDisguiseRuler.Location = new System.Drawing.Point(10, 140);
            this.IsDisguiseRuler.Name = "IsDisguiseRuler";
            this.IsDisguiseRuler.Size = new System.Drawing.Size(107, 17);
            this.IsDisguiseRuler.UseVisualStyleBackColor = true;
            // 
            // NotDisplayCheckBox
            // 
            this.NotDisplayAnymoreCheckBox.AutoSize = true;
            this.NotDisplayAnymoreCheckBox.Location = new System.Drawing.Point(145, 140);
            this.NotDisplayAnymoreCheckBox.Name = "NotDisplayAnymoreCheckBox";
            this.NotDisplayAnymoreCheckBox.Size = new System.Drawing.Size(136, 17);
            this.NotDisplayAnymoreCheckBox.UseVisualStyleBackColor = true;            
            // 
            // NotSaveSettingsCheckBox
            // 
            this.NotSaveSettingsCheckBox.AutoSize = true;
            this.NotSaveSettingsCheckBox.Location = new System.Drawing.Point(145, 125);
            this.NotSaveSettingsCheckBox.Name = "NotSaveSettingsCheckBox";
            this.NotSaveSettingsCheckBox.Size = new System.Drawing.Size(136, 17);
            this.NotSaveSettingsCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 160);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(280, 35);
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Starter
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.ScreenLabel);
            this.Controls.Add(this.GameResolutionLabel);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.LicenceKey);
            this.Controls.Add(this.NotDisplayAnymoreCheckBox);
            this.Controls.Add(this.LicenceID);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LanguageImagedComboBox);
            this.Controls.Add(this.NotSaveSettingsCheckBox);
            this.Controls.Add(this.IsDisguiseRuler);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.ScreenImagedComboBox);
            this.Controls.Add(this.GameResolutionImagedComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Icon = Resources.icon;
            this.Visible = false;
            this.Load += new System.EventHandler(this.Starter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LanguageLabel;
        private ImagedComboBox LanguageImagedComboBox;
        private Label ScreenLabel;
        private ImagedComboBox ScreenImagedComboBox;
        private Button AboutButton;
        private Label GameResolutionLabel;
        private ImagedComboBox GameResolutionImagedComboBox;
        private Label IDLabel;
        private MaskedTextBox LicenceID;
        private Label KeyLabel;
        private MaskedTextBox LicenceKey;
        private CheckBox IsDisguiseRuler;
        private CheckBox NotSaveSettingsCheckBox;
        private CheckBox NotDisplayAnymoreCheckBox;
        private Button StartButton;
    }
}