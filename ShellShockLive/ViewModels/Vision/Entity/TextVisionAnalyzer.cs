// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using NetExtender.Types.Comparers;
using NetExtender.Types.Culture;
using NetExtender.Types.Geometry;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.ViewModels.Settings;
using Tesseract;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class TextVisionAnalyzer<T> : ColorVisionAnalyzer<T>, IReadOnlyCollection<LocalizationIdentifier>
    {
        protected abstract override TextVisionTemplate Template { get; }
        protected virtual ImmutableSortedSet<LocalizationIdentifier> Identifiers { get; }

        public Int32 Count
        {
            get
            {
                return Identifiers.Count;
            }
        }

        protected TextVisionAnalyzer()
        {
            LocalizationComparer comparer = ShellShockLive.Settings.Instance.Comparer;
            Identifiers = ImmutableSortedSet.Create<LocalizationIdentifier>(comparer, CultureIdentifier.Invariant, CultureIdentifier.En, CultureIdentifier.Ru);
        }

        protected TesseractEngine? Engine()
        {
            return Engine(out _);
        }

        protected TesseractEngine? Engine(out LocalizationIdentifier identifier)
        {
            identifier = SettingsViewModel.Settings.Localization.Localization;
            return Engine(identifier);
        }

        protected TesseractEngine? Engine(LocalizationIdentifier identifier)
        {
            if (!Identifiers.Contains(identifier))
            {
                return null;
            }
            
            TesseractEngine? engine = Factory(identifier);

            if (engine is not null && Initialize(engine))
            {
                return engine;
            }

            engine?.Dispose();
            return null;
        }

        protected virtual TesseractEngine? Factory(LocalizationIdentifier identifier)
        {
            if (!Identifiers.Contains(identifier))
            {
                return null;
            }

            String? iso = identifier.ThreeLetterISOLanguageName?.ToLower();
            return iso is not null ? new TesseractEngine(@"./Files/Tesseract", iso, EngineMode.Default) : null;
        }

        protected virtual Boolean Initialize(TesseractEngine engine)
        {
            engine.SetVariable("language_model_penalty_non_freq_dict_word", "1");
            engine.SetVariable("language_model_penalty_non_dict_word", "1");
            return true;
        }

        protected virtual Bitmap? Text(Bitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            using Bitmap image = (Bitmap) bitmap.Clone();
            using DirectBitmap direct = image.Direct();
            return Text(direct);
        }

        protected virtual Bitmap? Text(DirectBitmap bitmap)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }
            
            foreach (DirectPoint point in bitmap)
            {
                if (Template.Foreground.In(point.Color))
                {
                    point.Color = Color.Black;
                    continue;
                }

                point.Color = Color.Transparent;
            }

            return TextBounds(bitmap, out Rectangle bounds) ? bitmap.Clone(bounds) : null;
        }

        protected virtual Boolean TextBounds(DirectBitmap bitmap, out Rectangle bounds)
        {
            if (bitmap is null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }
            
            Int32 left = -1;
            Int32 right = -1;
            foreach (DirectPoint point in bitmap.GetEnumerator(GeometryRotationType.Vertical))
            {
                if (point.Color.ToArgb() != Color.Black.ToArgb())
                {
                    continue;
                }
                
                if (left < 0)
                {
                    left = point.Point.X;
                }

                right = point.Point.X;
            }

            if (left < 0 || right < left)
            {
                bounds = default;
                return false;
            }

            const Int32 distance = 3;
            left = left >= distance ? left - distance : 0;
            right = right < bitmap.Width - distance ? right + distance : bitmap.Width;
            bounds = new Rectangle(left, 0, right - left, bitmap.Height);
            return true;
        }

        public ImmutableSortedSet<LocalizationIdentifier>.Enumerator GetEnumerator()
        {
            return Identifiers.GetEnumerator();
        }

        IEnumerator<LocalizationIdentifier> IEnumerable<LocalizationIdentifier>.GetEnumerator()
        {
            return ((IEnumerable<LocalizationIdentifier>) Identifiers).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<LocalizationIdentifier>) this).GetEnumerator();
        }
    }
}