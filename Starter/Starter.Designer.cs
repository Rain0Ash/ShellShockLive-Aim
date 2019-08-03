// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;
using Ruler.Forms;

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
            this.IsDisguiseRuler = new System.Windows.Forms.CheckBox();
            this.LanguageComboBox = new ImagedComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.LicenceID = new System.Windows.Forms.TextBox();
            this.NotDisplayCheckBox = new System.Windows.Forms.CheckBox();
            this.LicenceKey = new System.Windows.Forms.MaskedTextBox();
            this.LanguageLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IsDisguiseRuler
            // 
            this.IsDisguiseRuler.AutoSize = true;
            this.IsDisguiseRuler.Location = new System.Drawing.Point(10, 100);
            this.IsDisguiseRuler.Name = "IsDisguiseRuler";
            this.IsDisguiseRuler.Size = new System.Drawing.Size(107, 17);
            this.IsDisguiseRuler.TabIndex = 5;
            this.IsDisguiseRuler.Text = "Disguise the ruler";
            this.IsDisguiseRuler.UseVisualStyleBackColor = true;
            // 
            // LanguageComboBox
            // 
            this.LanguageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageComboBox.FormattingEnabled = true;
            this.LanguageComboBox.Location = new System.Drawing.Point(10, 26);
            this.LanguageComboBox.Name = "LanguageComboBox";
            this.LanguageComboBox.Size = new System.Drawing.Size(110, 21);
            this.LanguageComboBox.TabIndex = 1;
            this.LanguageComboBox.DropDownClosed += new System.EventHandler(this.LanguageComboBox_DropDownClosed);
            this.LanguageComboBox.SelectedIndexChanged += new System.EventHandler(this.LanguageComboBox_ChangeStarterLanguage);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(10, 120);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(265, 35);
            this.StartButton.TabIndex = 7;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LicenceID
            // 
            this.LicenceID.Location = new System.Drawing.Point(10, 65);
            this.LicenceID.Name = "LicenceID";
            this.LicenceID.Size = new System.Drawing.Size(90, 20);
            this.LicenceID.Multiline = false;
            this.LicenceID.TabIndex = 3;
            this.LicenceID.Text = "PREMIUM";
            this.LicenceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LicenceID.TextChanged += new System.EventHandler(this.LicenceID_TextChanged);
            // 
            // NotDisplayCheckBox
            // 
            this.NotDisplayCheckBox.AutoSize = true;
            this.NotDisplayCheckBox.Location = new System.Drawing.Point(130, 100);
            this.NotDisplayCheckBox.Name = "NotDisplayCheckBox";
            this.NotDisplayCheckBox.Size = new System.Drawing.Size(136, 17);
            this.NotDisplayCheckBox.TabIndex = 6;
            this.NotDisplayCheckBox.Text = "Do not display anymore";
            this.NotDisplayCheckBox.UseVisualStyleBackColor = true;
            // 
            // LicenceKey
            // 
            this.LicenceKey.AsciiOnly = true;
            this.LicenceKey.Location = new System.Drawing.Point(105, 65);
            this.LicenceKey.Mask = ">AAAA-AAAA-AAAA-AAAA-AAAA";
            this.LicenceKey.Name = "LicenceKey";
            this.LicenceKey.Size = new System.Drawing.Size(170, 20);
            this.LicenceKey.Multiline = false;
            this.LicenceKey.TabIndex = 4;
            this.LicenceKey.Text = "FREEFREEFREEFREEFREE";
            this.LicenceKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LanguageLabel
            // 
            this.LanguageLabel.AutoSize = true;
            this.LanguageLabel.Location = new System.Drawing.Point(10, 11);
            this.LanguageLabel.Name = "LanguageLabel";
            this.LanguageLabel.Size = new System.Drawing.Size(55, 13);
            this.LanguageLabel.TabIndex = 0;
            this.LanguageLabel.Text = "Language";
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(10, 50);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(59, 13);
            this.IDLabel.TabIndex = 2;
            this.IDLabel.Text = "Licence ID";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(105, 50);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(66, 13);
            this.KeyLabel.TabIndex = 4;
            this.KeyLabel.Text = "Licence Key";
            // 
            // Starter
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 162);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.LanguageLabel);
            this.Controls.Add(this.LicenceKey);
            this.Controls.Add(this.NotDisplayCheckBox);
            this.Controls.Add(this.LicenceID);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LanguageComboBox);
            this.Controls.Add(this.IsDisguiseRuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::Ruler.Properties.Resources.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Starter";
            this.Text = "Ruler";
            this.Load += new System.EventHandler(this.Starter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox IsDisguiseRuler;
        private ImagedComboBox LanguageComboBox;
        private Button StartButton;
        private TextBox LicenceID;
        private CheckBox NotDisplayCheckBox;
        private MaskedTextBox LicenceKey;
        private Label LanguageLabel;
        private Label IDLabel;
        private Label KeyLabel;
    }
}