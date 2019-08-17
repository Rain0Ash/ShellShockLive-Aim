// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Input;
using Common;
using Ruler.Weapons;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler.Common
{
    internal static partial class EventsAndGlobalsController
    {
        #region Events And Delegates
        
        #region Delegates

        internal delegate void EmptyHandler();
        internal delegate void SwitchedState(String name);
        internal delegate void ChangedPositionHandler(RawVector2 newCoord);
        internal delegate void ChangedParameterHandler(Int32 parameter);
        internal delegate void ChangedWeaponHandler(Weapon weapon);
        #endregion
        
        #region Events
        internal static event EmptyHandler NeedRedraw;
        internal static event EventHandler ChangedWeaponMenuState;
        internal static event ChangedPositionHandler ChangedSightPosition;
        internal static event ChangedWeaponHandler ChangedWeapon;
        internal static event ChangedParameterHandler ChangedPower;
        internal static event ChangedParameterHandler ChangedAngle;
        internal static event ChangedParameterHandler ChangedWind;
        #endregion
        
        #endregion

        #region Globals

        internal static Parameters Parameters;
        internal static RawVector2 RenderTargetSize;
        
        private static Monitor _monitor;
        internal static Monitor CurrentMonitor
        {
            get
            {
                return _monitor;
            }
            set
            {
                _monitor = value;
            }
        }

        private static Weapon _weapon;

        internal static Weapon Weapon
        {
            get
            {
                return _weapon;
            }
            set
            {
                _weapon = value;
                ChangedWeapon?.Invoke(_weapon);
                NeedRedraw?.Invoke();
            }
        }
        
        private static Int32 _power = 100;
        internal static Int32 Power
        {
            get
            {
                return _power;
            }
            set
            {
                _power = (Int32) Utils.LimitToRange(value, 0, 100);
                ChangedPower?.Invoke(_power);
                NeedRedraw?.Invoke();
            }
        }

        private static Int32 _angle = 90;
        internal static Int32 Angle
        {
            get
            {
                return _angle;
            }
            set
            {
                _angle = value;
                ChangedAngle?.Invoke(_angle);
                NeedRedraw?.Invoke();
            }
        }        
        
        private static Int32 _wind;
        internal static Int32 Wind
        {
            get
            {
                return _wind;
            }
            set
            {
                _wind = (Int32) Utils.LimitToRange(value, -100, 100);
                ChangedWind?.Invoke(_wind);
                NeedRedraw?.Invoke();
            }
        }

        #endregion
    }
}