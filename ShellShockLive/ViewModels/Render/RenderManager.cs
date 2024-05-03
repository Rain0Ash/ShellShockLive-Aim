// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.View.Render;
using ShellShockLive.ViewModels.Environment;
using ShellShockLive.ViewModels.Sight;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.ViewModels.Render
{
    public sealed class RenderManager : ReactiveViewModel<ShellShockLiveWindow>
    {
        private static Lazy<RenderManager> Internal { get; } = new Lazy<RenderManager>(() => new RenderManager(), true);

        public static RenderManager Instance
        {
            get
            {
                return Internal.Value;
            }
        }

        public static RenderViewModel Model
        {
            get
            {
                return RenderViewModel.Instance;
            }
        }
        
        public SightViewModel Sight { get; } = new SightViewModel();
        public EnvironmentViewModel Environment { get; } = new EnvironmentViewModel();

        public Boolean IsRender
        {
            get
            {
                return ShellShockLive.Settings.Instance.Interface.Value.HasFlag(InterfaceType.Render);
            }
        }

        public void Start(RenderView view)
        {
            if (view is null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            view.Show();
            Window.BringToForeground();
        }

        public void Render(RenderView view)
        {
            if (view is null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            view.Invalidate();
        }

        public void NextFrame(Graphics graphics)
        {
            if (graphics is null)
            {
                throw new ArgumentNullException(nameof(graphics));
            }

            if (!IsRender)
            {
                return;
            }
            
            IGuidanceInfo guidance = WeaponsViewModel.Instance.GuidanceInfo;
            Environment.Draw(guidance, graphics);
            Sight.Draw(guidance, graphics);
        }
    }
}