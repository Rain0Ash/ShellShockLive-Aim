// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Types.Exceptions;
using NetExtender.Types.HotKeys.Events;
using NetExtender.Utilities.UserInterface;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;

namespace ShellShockLive.ViewModels.Events
{
    public class EventControllerViewModel : ReactiveViewModel<ShellShockLiveWindow>
    {
        public EventController Controller { get; }
        public Boolean IsRegister { get; private set; }

        public EventControllerViewModel()
            : this(null)
        {
        }

        public EventControllerViewModel(EventController? controller)
        {
            Controller = controller ?? new EventController();
        }

        public void Register()
        {
            if (IsRegister)
            {
                throw new AlreadyInitializedException(null, nameof(EventControllerViewModel));
            }
            
            Window.HotKey += Handler;
            Window.RegisterHotKey(Controller.HotKeys);
            IsRegister = true;
        }

        private void Handler(Object? sender, HotKeyEventArgs args)
        {
            if (args.Handled)
            {
                return;
            }
            
            Controller.HandleAsync(args.Value).ConfigureAwait(true).GetAwaiter().GetResult();
        }
    }
}