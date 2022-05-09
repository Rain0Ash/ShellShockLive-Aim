// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection;
using NetExtender.Localization.Properties.Interfaces;
using NetExtender.Localization.Property.Localization.Initializers;
using NetExtender.Types.Exceptions;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;

namespace ShellShockLive.ViewModels.Weapons
{
    public partial class WeaponsLocalization : LocalizationAutoInitializerSingleton<WeaponsLocalization>
    {
        protected ImmutableDictionary<IWeapon, IReadOnlyLocalizationProperty> Weapons { get; }

        public WeaponsLocalization()
        {
            Dictionary<IWeapon, IReadOnlyLocalizationProperty> weapons = new Dictionary<IWeapon, IReadOnlyLocalizationProperty>();
            IReadOnlyList<IWeapon> stack = WeaponsStack.Instance;

            for (Int32 i = 0; i < stack.Count; i++)
            {
                IWeapon weapon = stack[i];
                
                if (!Store.TryGetKeyValuePairByIndex(i + 1, out KeyValuePair<ILocalizationPropertyInfo, PropertyInfo> pair))
                {
                    throw new InvalidInitializationException($"Can't get store values at index '{i}'.");
                }

                (ILocalizationPropertyInfo info, PropertyInfo property) = pair;

                if (property.Name != weapon.Title)
                {
                    throw new InvalidInitializationException($"Property '{property.Name}' not equals weapon '{weapon.Title}' at index '{i}'.");
                }

                if (info is not IReadOnlyLocalizationProperty result)
                {
                    throw new InvalidCastException($"Can't cast '{info.GetType().Name}' to '{nameof(IReadOnlyLocalizationProperty)}' for weapon '{weapon.Title}' at index '{i}'.");
                }
                
                weapons.Add(weapon, result);
            }
            
            Weapons = weapons.ToImmutableDictionary();
        }

        public IReadOnlyLocalizationProperty? Get(IWeapon weapon)
        {
            if (weapon is null)
            {
                throw new ArgumentNullException(nameof(weapon));
            }

            return Weapons.TryGetValue(weapon, out IReadOnlyLocalizationProperty? result) ? result : null;
        }
    }
}