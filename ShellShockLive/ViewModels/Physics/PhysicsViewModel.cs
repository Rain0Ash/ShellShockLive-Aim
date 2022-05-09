// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Windows;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Bindings.Interfaces;
using ShellShockLive.Models.Physics.Bindings.Internal;

namespace ShellShockLive.ViewModels.Physics
{
    public class PhysicsViewModel : ReactiveViewModelSingleton<PhysicsViewModel>
    {
        [Reactive]
        public IPhysicsBinding Binding { get; set; } = PhysicsBinding1366x768.Instance;

        private Int16 _angle;
        public Int16 Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _angle, ToDegree(value));
            }
        }

        private Int16 _wind;
        public Int16 Wind
        {
            get
            {
                return _wind;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _wind, ToWind(value));
            }
        }
        
        private Int16 _power;
        public Int16 Power
        {
            get
            {
                return _power;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _power, ToPower(value));
            }
        }

        [Reactive]
        public Rectangle Resolution { get; set; } = MonitorUtilities.GetPrimaryMonitor().Resolution;

        public PhysicsInfo Physics
        {
            get
            {
                return new PhysicsInfo(Binding, Angle, Wind, Power, Resolution);
            }
            set
            {
                Binding = value.Binding;
                Angle = value.Angle;
                Wind = value.Wind;
                Power = value.Power;
                Resolution = value.Resolution;
                this.RaisePropertyChanged();
            }
        }

        public PhysicsViewModel()
        {
            Angle = Binding.Angle;
            Wind = Binding.Wind;
            Power = Binding.Power;
        }

        public Int16 ToDegree(Int16 value)
        {
            value %= Binding.Angle.Maximum;
            return value >= Binding.Angle.Minimum ? value : unchecked((Int16) (Binding.Angle.Maximum - Math.Abs(value)));
        }
        
        public Int16 ToWind(Int16 value)
        {
            return value.ToRange(Binding.Wind.Minimum, Binding.Wind.Maximum);
        }
        
        public Int16 ToPower(Int16 value)
        {
            return value.ToRange(Binding.Power.Minimum, Binding.Power.Maximum);
        }
    }
}