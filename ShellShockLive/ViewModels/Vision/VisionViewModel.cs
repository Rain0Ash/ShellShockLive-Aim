// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using NetExtender.Types.Attributes;
using NetExtender.Types.Events;
using NetExtender.Types.Timers;
using NetExtender.Types.Timers.Interfaces;
using NetExtender.Utilities.IO;
using NetExtender.Utilities.Types;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.ViewModels.Commands;
using ShellShockLive.ViewModels.Render;
using ShellShockLive.ViewModels.Vision.Bindings;

namespace ShellShockLive.ViewModels.Vision
{
    [StaticInitializerRequired]
    public class VisionViewModel : ReactiveViewModelSingleton<VisionViewModel>
    {
        static VisionViewModel()
        {
            Instance.Start();
        }
        
        public VisionController Vision { get; }
        public CommandController Command { get; }
        
        private ITimer Timer { get; }

        [Reactive]
        public Boolean Auto { get; private set; }
        
        private Boolean InTick { get; set; }

        public VisionViewModel()
            : this(null, null)
        {
        }

        public VisionViewModel(VisionController? vision, CommandController? command)
        {
            Vision = vision ?? new VisionController();
            Command = command ?? new CommandController();
            Timer = new TimerWrapper(ShellShockLive.Settings.Constants.Scanning.Start);
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

        protected virtual async ValueTask TickAsync(DateTime signal)
        {
            if (Auto)
            {
                Boolean result = await Command.SetInformationOfPlayer().ConfigureAwait(false);
                if (result)
                {
                    RenderViewModel.Instance.Render();
                }
            }

            Int32 value = ShellShockLive.Settings.Instance.Scanning.Value;
            if (value <= ShellShockLive.Settings.Constants.Scanning.Minimum)
            {
                Auto = false;
                Timer.Interval = Time.Second.Half;
                return;
            }

            Auto = true;
            Timer.Interval = TimeSpan.FromMilliseconds(value);
        }
        
        public virtual async ValueTask<VisionResult> VisionAsync(VisionType type, VisionBinding binding)
        {
            try
            {
                return await Vision.VisionAsync(type, binding).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                exception.ToConsole();
                return default;
            }
        }

        public virtual async ValueTask<VisionResult> VisionAsync(VisionType type, Rectangle screen, Bitmap screenshot, VisionBinding binding)
        {
            try
            {
                return await Vision.VisionAsync(type, screen, screenshot, binding).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                exception.ToConsole();
                return default;
            }
        }

        public virtual ValueTask<String?> MakeScreenshot()
        {
            if (!DirectoryUtilities.TryCreateDirectory("Analysis"))
            {
                return StringUtilities.ValueNull;
            }

            using Bitmap? screenshot = Vision.MakeScreenshot(out _);
            if (screenshot is null)
            {
                return StringUtilities.ValueNull;
            }

            try
            {
                String filename = $"Screenshot {DateTime.Now:dd.MM hh.mm.ss}.png";
                screenshot.Save(Path.Combine("Analysis", filename));
                return ValueTask.FromResult<String?>(filename);
            }
            catch (Exception)
            {
                return StringUtilities.ValueNull;
            }
        }
    }
}