// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using NetExtender.Types.Monads;
using NetExtender.Utilities.Types;
using NetExtender.Windows.Types;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    public class GameVisionAnalyzer : ColorVisionAnalyzer<Boolean>
    {
        protected override GameVisionTemplate Template { get; }
        
        public GameVisionAnalyzer()
            : this(null)
        {
        }
        
        public GameVisionAnalyzer(GameVisionTemplate? template)
        {
            Template = template ?? new GameVisionTemplate();
        }

        public override async Task<Maybe<Boolean>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding)
        {
            return await Template.Background.PointsInAsync(bitmap.GetEnumerator(binding.Fuel.Image), query => query.Skip(Template.Background.Limit).Any()).ConfigureAwait(false);
        }
    }
}