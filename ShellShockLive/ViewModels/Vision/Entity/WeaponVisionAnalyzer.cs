// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NetExtender.Localization.Common.Interfaces;
using NetExtender.Types.Culture;
using NetExtender.Types.Monads;
using NetExtender.Utilities.IO;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.Models.Weapons.Interfaces;
using ShellShockLive.Models.Weapons.Stacks;
using ShellShockLive.Utilities.ViewModels.Vision;
using ShellShockLive.ViewModels.Vision.Bindings;
using ShellShockLive.ViewModels.Weapons;
using Tesseract;

namespace ShellShockLive.ViewModels.Vision
{
    public class WeaponVisionAnalyzer : TextVisionAnalyzer<IWeapon>
    {
        protected static ImmutableDictionary<String, IWeapon> Weapons { get; }

        static WeaponVisionAnalyzer()
        {
            Dictionary<String, IWeapon> weapons = new Dictionary<String, IWeapon>(StringComparer.OrdinalIgnoreCase);

            foreach (IWeapon weapon in WeaponsStack.Instance.AsWeapons())
            {
                ILocalizationString? value = WeaponsLocalization.Instance.Get(weapon)?.Value;

                if (value is null)
                {
                    continue;
                }

                foreach (String title in value.Values.Values())
                {
                    weapons.TryAdd(title, weapon);
                }
            }
            
            Dictionary<String, String> replace = new Dictionary<String, String>
            {
                ["Ко6ра"] = WeaponsLocalization.Instance.Cobra[CultureIdentifier.Ru] ?? String.Empty,
                ["Мини"] = WeaponsLocalization.Instance.MiniV[CultureIdentifier.Ru] ?? String.Empty,
                ["Макси"] = WeaponsLocalization.Instance.FlyingV[CultureIdentifier.Ru] ?? String.Empty,
                ["Uzl"] = WeaponsLocalization.Instance.Uzi[CultureIdentifier.En] ?? String.Empty
            };

            foreach ((String title, String actual) in replace)
            {
                weapons.TryAdd(title, weapons[actual]);
            }

            Weapons = weapons.ToImmutableDictionary(StringComparer.OrdinalIgnoreCase);
        }
        
        protected override WeaponVisionTemplate Template { get; }
        protected Regex Replacer { get; } = new Regex(@"[\-\\\\|\/\n\r]+$|", RegexOptions.Compiled);

        public WeaponVisionAnalyzer()
            : this(null)
        {
        }

        public WeaponVisionAnalyzer(WeaponVisionTemplate? template)
        {
            Template = template ?? new WeaponVisionTemplate();
        }
        
        // ReSharper disable once CognitiveComplexity
        public override async Task<Maybe<IWeapon>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            if (binding is null)
            {
                throw new ArgumentNullException(nameof(binding));
            }
            
            using Bitmap image = bitmap.Clone(binding.Weapon.Title);
            using Bitmap? analyze = Text(image);

            String? main = null;
            LocalizationIdentifier current = default;
            foreach (LocalizationIdentifier identifier in this.Where(identifier => current != identifier))
            {
                using (TesseractEngine? engine = identifier == LocalizationIdentifier.Invariant ? Engine(out current) : Engine(identifier))
                {
                    if (engine is not null && analyze is not null)
                    {
                        (String? text, IWeapon? weapon) = await AnalyzeAsync(engine, analyze).ConfigureAwait(false);

                        if (weapon is not null)
                        {
                            return new Maybe<IWeapon>(weapon);
                        }
                    
                        main ??= text;
                    }
                }

                using (TesseractEngine? engine = identifier == LocalizationIdentifier.Invariant ? Engine(current) : Engine(identifier))
                {
                    if (engine is null)
                    {
                        continue;
                    }

                    (String? _, IWeapon? weapon) = await AnalyzeAsync(engine, image).ConfigureAwait(false);

                    if (weapon is not null)
                    {
                        return new Maybe<IWeapon>(weapon);
                    }
                }
            }
            
            if (!ShellShockLive.Settings.Instance.DebugAnalysis.Value)
            {
                return default;
            }

            String filename = $"Analysis/WeaponAnalysis.{(!String.IsNullOrEmpty(main) ? PathUtilities.RemoveIllegalCharacters(main) : DateTime.UtcNow.ToString("dd.MM.yy hh.mm.ss"))}.png";

            if (!File.Exists(filename))
            {
                (analyze ?? image).Save(filename);
            }

            return default;
        }

        protected virtual async ValueTask<(String? Text, IWeapon? Weapon)> AnalyzeAsync(TesseractEngine engine, Bitmap image)
        {
            using Page page = await engine.ProcessAsync(image, PageSegMode.SingleLine).ConfigureAwait(false);
            String text = page.GetText().Trim();

            if (String.IsNullOrEmpty(text))
            {
                return (null, null);
            }

            IWeapon? weapon;
            text = Replacer.Replace(text, String.Empty);

            if (!text.EndsWith("..."))
            {
                return Weapons.TryGetValue(text, out weapon) ? (text, weapon) : (text, null);
            }

            text = Replacer.Replace(text[..^3], String.Empty);

            if (Weapons.TryGetValue(text, out weapon))
            {
                return (text, weapon);
            }

            if (Weapons.Keys.FirstOrDefault(pair => pair.StartsWith(text)) is { } title)
            {
                text = title;
            }

            return Weapons.TryGetValue(text, out weapon) ? (text, weapon) : (text, null);
        }
    }
}