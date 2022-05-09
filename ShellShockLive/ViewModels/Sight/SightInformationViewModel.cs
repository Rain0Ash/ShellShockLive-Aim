// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Globalization;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Environment;

namespace ShellShockLive.ViewModels.Sight
{
    public class SightInformationViewModel : SurfaceViewModel<ISightInformation>
    {
        protected SightViewModel? Model { get; }

        public virtual ISight Sight
        {
            get
            {
                return Model?.Sight ?? throw new NotInitializedException(null, nameof(Model));
            }
        }

        public ISightInformation Information
        {
            get
            {
                return Sight.Information;
            }
        }

        public override ISightInformation Surface
        {
            get
            {
                return Information;
            }
        }

        public override Byte Transparent
        {
            get
            {
                return Model is not null ? (Byte) Math.Clamp(Model.Transparent * 3, Byte.MinValue, Byte.MaxValue) : base.Transparent;
            }
        }
        
        protected SightInformationViewModel()
        {
        }

        public SightInformationViewModel(SightViewModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public override void Draw(IGuidanceInfo guidance, Graphics graphics)
        {
            if (guidance is null)
            {
                throw new ArgumentNullException(nameof(guidance));
            }

            if (graphics is null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            using Font font = new Font(FontFamily.GenericSansSerif, 20f, FontStyle.Regular, GraphicsUnit.Pixel, 204);
            using Brush anglebrush = new SolidBrush(Adapt(Color.LimeGreen));
            using Brush windbrush = new SolidBrush(Adapt(Color.DarkCyan));
            using Brush powerbrush = new SolidBrush(Adapt(Color.Red));
            
            DrawableString angle = new DrawableString(Information.Physics.Degree.ToString(CultureInfo.InvariantCulture)+"°", anglebrush, font);
            DrawableString wind = new DrawableString(Information.Physics.Wind.ToString(CultureInfo.InvariantCulture)+"M", windbrush, font);
            DrawableString power = new DrawableString(Information.Physics.Power.ToString(CultureInfo.InvariantCulture)+"%", powerbrush, font);
            DrawableString separator = new DrawableString("/", Brushes.Azure, font);

            Point center = Sight.Center;
            PointF down = new PointF(center.X, center.Y + Sight.Radius);
            
            graphics.DrawString(center, ContentAlignment.BottomCenter, power, separator, angle, separator, wind);
            graphics.DrawString(down, ContentAlignment.BottomCenter, power, separator, angle, separator, wind);
        }
    }
}