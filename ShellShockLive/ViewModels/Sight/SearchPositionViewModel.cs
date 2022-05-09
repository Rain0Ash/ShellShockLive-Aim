// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Types;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Sight.Interfaces;
using ShellShockLive.ViewModels.Environment;

namespace ShellShockLive.ViewModels.Sight
{
    public class SearchPositionViewModel : SurfaceViewModel<ISearchPosition>
    {
        private SightViewModel? Model { get; }
        
        public virtual ISight Sight
        {
            get
            {
                return Model?.Sight ?? throw new NotInitializedException(null, nameof(Model));
            }
        }

        public ISearchPosition Search
        {
            get
            {
                return Sight.Search;
            }
        }

        public override ISearchPosition Surface
        {
            get
            {
                return Search;
            }
        }
        
        public override Byte Transparent
        {
            get
            {
                return Model?.Transparent ?? base.Transparent;
            }
        }

        public Boolean IsEmpty
        {
            get
            {
                return Equals(default, default);
            }
        }
        
        protected SearchPositionViewModel()
        {
        }

        public SearchPositionViewModel(SightViewModel model)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
        }

        public virtual void Set(Point point, Single radius)
        {
            Search.Center = point;
            Search.Radius = radius;
        }
        
        public virtual Boolean Equals(Point point)
        {
            return Search.Center == point;
        }

        public virtual Boolean Equals(Point point, Single radius)
        {
            return Search.Center == point && Math.Abs(Search.Radius - radius) < Single.Epsilon;
        }

        public virtual void Reset()
        {
            Set(Point.Empty, Search.Radius);
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

            Single radius = Search.Radius;
            graphics.FillCircle(Brushes.Yellow, Search.Center.X - radius, Search.Center.Y - radius, 2 * radius);
        }
    }
}