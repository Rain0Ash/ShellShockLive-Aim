// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Environment.Rebound.Interfaces;

namespace ShellShockLive.ViewModels.Environment.Rebound
{
    public abstract class ReboundViewModel<T> : SurfaceViewModel<T> where T : class, ISurface, IRebound
    {
    }
}