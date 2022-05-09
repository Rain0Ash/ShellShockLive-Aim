// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Threading.Tasks;
using NetExtender.Types.Attributes;
using NetExtender.Types.Events;
using NetExtender.Types.Timers;
using NetExtender.Types.Timers.Interfaces;
using NetExtender.Utilities.Types;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.ViewModels.Game;
using ShellShockLive.ViewModels.Physics;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    [StaticInitializerRequired]
    public class GameViewModel : ReactiveViewModelSingleton<GameViewModel>
    {
        static GameViewModel()
        {
            Instance.Start();
        }
        
        public GameController Game { get; }
        private ITimer Timer { get; }

        [Reactive]
        public IntPtr Window { get; private set; }
        private Boolean InTick { get; set; }

        public GameViewModel()
            : this(null)
        {
        }

        public GameViewModel(GameController? game)
        {
            Game = game ?? new GameController();
            Timer = new TimerWrapper(Time.Second.Half);
            Timer.Tick += Tick;
        }

        protected virtual void Start()
        {
            Timer.Start();
        }

        public static void Initialize()
        {
        }

        private async void Tick(Object? sender, TimeEventArgs args)
        {
            if (InTick)
            {
                return;
            }
            
            InTick = true;
            await TickAsync(args.SignalTime).ConfigureAwait(false);
            InTick = false;
        }

        protected virtual ValueTask TickAsync(DateTime signal)
        {
            if (VisionBinding.TryGetBinding(PhysicsViewModel.Instance.Binding, out VisionBinding? binding))
            {
                IntPtr window = Game.Window(binding, out Boolean outbound);
                Window = !outbound ? window : IntPtr.Zero;
                return ValueTask.CompletedTask;
            }

            Window = IntPtr.Zero;
            return ValueTask.CompletedTask;
        }
    }
}