// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows;
using NetExtender.Types.Exceptions;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ShellShockLive.View.Render;

namespace ShellShockLive.ViewModels.Render
{
    public class RenderViewModel : ReactiveViewModelSingleton<RenderViewModel>
    {
        public static RenderManager Manager
        {
            get
            {
                return RenderManager.Instance;
            }
        }

        public RenderView? View { get; private set; }

        public void Start(Window window)
        {
            if (window is null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            if (View is not null)
            {
                throw new AlreadyInitializedException();
            }

            View = new RenderView(window);
            RenderManager.Instance.Start(View);
        }

        public void Render()
        {
            if (View is null)
            {
                throw new NotInitializedException(null, nameof(View));
            }
            
            RenderManager.Instance.Render(View);
        }
    }
}