// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Windows.Forms;
using Ruler.Common;

namespace Ruler.Gui
{
    internal sealed class PageSwitcher : Label
    {
        internal event EventsAndGlobalsController.SwitchedState CurrentPageChanged;
        
        private readonly Button previousPageButton;
        private readonly Button nextPageButton;

        private static readonly Int32 MaxPage = 1 + Weapons.Common.Weapons.WeaponsArrayLength / (WeaponsPanel.MaxWeaponsInColumn - 1);
        private Int32 currentPage = 1;
        internal Int32 CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                if (value > MaxPage)
                {
                    currentPage = 1;
                }
                else if (value < 1)
                {
                    currentPage = MaxPage;
                }
                else
                {
                    currentPage = value;
                }

                CurrentPageChanged?.Invoke(currentPage);
            }
        }
        
        internal PageSwitcher()
        {
            
            TextAlign = ContentAlignment.MiddleLeft;
            Text = $@"{CurrentPage.ToString()}/{MaxPage}";
            Font = new Font(Font.Name, Font.Size + 6, FontStyle.Italic | FontStyle.Bold);
            CurrentPageChanged += page => Text = $@"{page.ToString()}/{MaxPage}";
            
            previousPageButton = new Button
            {
                ForeColor = ForeColor,
                BackColor = BackColor,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, BorderColor = BackColor},
                TextAlign = ContentAlignment.MiddleRight
            };
            nextPageButton = new Button
            {
                ForeColor = ForeColor,
                BackColor = BackColor,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0, BorderColor = BackColor},
                TextAlign = ContentAlignment.MiddleLeft
            };
            previousPageButton.Text = @"←";
            nextPageButton.Text = @"→";
            previousPageButton.Click += (sender, args) => CurrentPage -= 1;
            nextPageButton.Click += (sender, args) => CurrentPage += 1;
            
            Controls.Add(previousPageButton);
            Controls.Add(nextPageButton);
        }

        private void InitializeButtons()
        {
            if (previousPageButton == null || nextPageButton == null)
            {
                return;
            }

            previousPageButton.Size = new Size((Size.Width - Size.Height) / 2, Size.Height);
            nextPageButton.Size = new Size((Size.Width - Size.Height) / 2, Size.Height);
            previousPageButton.Location = new Point((Size.Width - Size.Height) / 2, 0);
            nextPageButton.Location = new Point(Size.Width-Size.Height, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InitializeButtons();
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            InitializeButtons();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (previousPageButton == null || nextPageButton == null)
            {
                return;
            }
            previousPageButton.BackColor = nextPageButton.BackColor = BackColor;
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (previousPageButton == null || nextPageButton == null)
            {
                return;
            }
            previousPageButton.ForeColor = nextPageButton.ForeColor = ForeColor;
        }
    }
}