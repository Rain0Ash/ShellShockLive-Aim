// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using NetExtender.Utilities.UserInterface;
using NetExtender.WindowsPresentation.Utilities.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.View.WeaponPanel
{
    public partial class WeaponPanel
    {
        public static readonly DependencyProperty WeaponProperty = DependencyPropertyUtilities.Register(nameof(Weapon), false);
        public static readonly DependencyProperty CurrentPageProperty = DependencyPropertyUtilities.Register(nameof(CurrentPage), (Byte) 1, false);
        public static readonly DependencyProperty TotalPagesProperty = DependencyPropertyUtilities.Register(nameof(TotalPages), (Byte) 1, false);
        public static readonly DependencyProperty ShowPanelProperty = DependencyPropertyUtilities.Register(nameof(ShowPanel));

        [Bindable(true)]
        public IWeapon Weapon
        {
            get
            {
                return (IWeapon) GetValue(WeaponProperty);
            }
            set
            {
                SetValue(WeaponProperty, value);
            }
        }
        
        [Bindable(true)]
        public Byte CurrentPage
        {
            get
            {
                return (Byte) GetValue(CurrentPageProperty);
            }
            private set
            {
                SetValue(CurrentPageProperty, value.ToRange(1, TotalPages, true));
            }
        }
        
        [Bindable(true)]
        public Byte TotalPages
        {
            get
            {
                return (Byte) GetValue(TotalPagesProperty);
            }
            private set
            {
                SetValue(TotalPagesProperty, value);
            }
        }
        
        [Bindable(true)]
        public Boolean ShowPanel
        {
            get
            {
                return (Boolean) GetValue(ShowPanelProperty);
            }
            set
            {
                SetValue(ShowPanelProperty, value);
            }
        }

        private const Int32 Size = 20;
        private List<WeaponStack> Weapons { get; }
        public ObservableCollection<WeaponStack> Stacks { get; } = new ObservableCollection<WeaponStack>();
        
        public WeaponPanel()
        {
            InitializeComponent();
            Weapons = new List<WeaponStack>(WeaponsStack.Instance);
            Stacks.AddRange(Weapons.Take(Size));
            TotalPages = (Byte) Math.Ceiling(Weapons.Count / (Double) Size);
        }

        private void PreviousButtonClick(Object sender, RoutedEventArgs args)
        {
            CurrentPage--;
        }

        private void NextButtonClick(Object sender, RoutedEventArgs args)
        {
            CurrentPage++;
        }

        private void CurrentWeaponButtonClick(Object sender, RoutedEventArgs args)
        {
            WeaponsViewModel.Instance.Reset();
        }

        private static Regex SearchRegex { get; } = new Regex(@"^\=[0-9]{1,3}$|^[0-9a-zA-Zа-яА-Я\- ]+$", RegexOptions.Compiled);
        private static Regex LevelSearchRegex { get; } = new Regex(@"^\=[0-9]{1,3}$", RegexOptions.Compiled);

        private static ImmutableDictionary<String, String> SearchReplacer { get; } = new Dictionary<String, String>(StringComparer.InvariantCultureIgnoreCase)
        {
            ["=С"] = "=101", // Соло
            ["=О"] = "=101", // Одиночная
            ["=SO"] = "=101", // Solo
            ["=SI"] = "=101", // Single
            
            ["=A"] = "=102", // Achievement
            ["=Д"] = "=102", // Достижение
            
            ["=S"] = "=103", // Store
            ["=М"] = "=103" // Магазин
        }.ToImmutableDictionary();
        
        private void SearchBoxTextChanged(Object sender, TextChangedEventArgs args)
        {
            if (sender is not TextBox search)
            {
                return;
            }

            String text = search.Text;
            if (String.IsNullOrEmpty(text))
            {
                SetStacks(WeaponsStack.Instance);
                return;
            }

            if (SearchReplacer.TryGetValue(text, out String? replace))
            {
                text = replace;
            }

            const StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
            
            if (!text.StartsWith("=") && SearchRegex.IsMatch(text))
            {
                Boolean Find(IWeapon weapon)
                {
                    String? current = WeaponsLocalization.Instance.Get(weapon)?.Current;

                    if (String.IsNullOrEmpty(current))
                    {
                        return false;
                    }
                    
                    return text.Length >= 3 ? current.Contains(text, comparison) : current.StartsWith(text, comparison);
                }

                SetWeapons(WeaponsStack.Instance.AsWeapons().Where(Find));
                return;
            }

            if (LevelSearchRegex.IsMatch(text) && Byte.TryParse(text[1..], out Byte level))
            {
                SetStacks(WeaponsStack.Instance.AsStacks().Where(stack => stack.Level == level));
            }
        }

        private void SetStacks(IEnumerable<WeaponStack> stacks)
        {
            if (stacks is null)
            {
                throw new ArgumentNullException(nameof(stacks));
            }
            
            Weapons.Clear();
            Weapons.AddRange(stacks);
            TotalPages = (Byte) Math.Ceiling(Weapons.Count / (Double) Size);
            Update();
        }

        private void SetWeapons(IEnumerable<IWeapon> weapons)
        {
            if (weapons is null)
            {
                throw new ArgumentNullException(nameof(weapons));
            }

            IWeapon[] array = new IWeapon[4];
            SetStacks(weapons.Chunk(array).Select(count => new WeaponStack(count >= array.Length ? array : array.Slice(0, count).ToArray())));
        }

        private void Update()
        {
            Stacks.Clear();
            Stacks.AddRange(Weapons.Skip(Size * (CurrentPage - 1)).Take(Size));
            Update(Weapon);
        }

        private void Update(IWeapon? weapon)
        {
            foreach (WeaponPanelStack stack in WeaponGrid.GetChildrens<WeaponPanelStack>())
            {
                stack.Update(weapon);
            }
        }

        private static void WeaponChanged(DependencyObject sender)
        {
            IWeapon weapon = (IWeapon) sender.GetValue(WeaponProperty);

            if (sender is not WeaponPanel panel)
            {
                return;
            }

            panel.Update(weapon);
        }

        private static void CurrentPageChanged(DependencyObject sender)
        {
            if (sender is not WeaponPanel panel)
            {
                return;
            }
            
            panel.Update();
        }

        private static void TotalPagesChanged(DependencyObject sender)
        {
            Byte current = (Byte) sender.GetValue(CurrentPageProperty);
            Byte total = (Byte) sender.GetValue(TotalPagesProperty);

            current = current >= total ? total : (Byte) 1;
            sender.SetValue(CurrentPageProperty, current);
            CurrentPageChanged(sender);
        }
    }
}