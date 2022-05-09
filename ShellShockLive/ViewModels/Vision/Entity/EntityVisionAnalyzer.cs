// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System.Drawing;
using System.Threading.Tasks;
using NetExtender.Types.Monads;
using NetExtender.Windows.Types;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    public abstract class EntityVisionAnalyzer<T>
    {
        public abstract Task<Maybe<T>> AnalyzeAsync(Rectangle screen, DirectBitmap bitmap, VisionBinding binding);
    }
}