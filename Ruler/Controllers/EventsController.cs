// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Indieteur.GlobalHooks;
using SharpDX;
using SharpDX.Mathematics.Interop;

namespace Ruler.Common
{
    internal static partial class EventsAndGlobalsController
    {
        private static Int64 _lastRedraw = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        private const VirtualKeycodes ChangeWeaponMenuState = VirtualKeycodes.OEM_3;
        private const VirtualKeycodes ChangeSightPosition = VirtualKeycodes.E;
        private const VirtualKeycodes UpOffsetSightPosition = VirtualKeycodes.W;
        private const VirtualKeycodes LeftOffsetSightPosition = VirtualKeycodes.A;
        private const VirtualKeycodes DownOffsetSightPosition = VirtualKeycodes.S;
        private const VirtualKeycodes RightOffsetSightPosition = VirtualKeycodes.D;
        private const VirtualKeycodes IncreaseAngleOrWind = VirtualKeycodes.LeftArrow;
        private const VirtualKeycodes DecreaseAngleOrWind = VirtualKeycodes.RightArrow;
        private const VirtualKeycodes IncreasePower = VirtualKeycodes.UpArrow;
        private const VirtualKeycodes DecreasePower = VirtualKeycodes.DownArrow;

        private const Int32 OffsetPixelsByStep = 1;
        private const Int32 OffsetPixelsByStepWithShiftKey = 10;
        
        internal static void RecognizeInputAndThrowEvent(Object sender, GlobalKeyEventArgs e)
        {
            Boolean isNeedRedraw = false;
            isNeedRedraw = true;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (e.KeyCode)
            {
                case ChangeWeaponMenuState:
                    ChangedWeaponMenuState?.Invoke(sender, e);
                    isNeedRedraw = false;
                    break;
                case ChangeSightPosition:
                    if (!CheckLastRedrawTime(25))
                    {
                        return;
                    }
                    ChangedSightPosition?.Invoke(Utils.GetCursorPosition(RenderTargetSize));
                    break;
                case UpOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new RawVector2(0, e.Shift != ModifierKeySide.None ? -OffsetPixelsByStepWithShiftKey : -OffsetPixelsByStep));
                    break;
                case LeftOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new RawVector2(e.Shift != ModifierKeySide.None ? -OffsetPixelsByStepWithShiftKey : -OffsetPixelsByStep, 0));
                    break;
                case DownOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new RawVector2(0, e.Shift != ModifierKeySide.None ? OffsetPixelsByStepWithShiftKey : OffsetPixelsByStep));
                    break;
                case RightOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new RawVector2(e.Shift != ModifierKeySide.None ? OffsetPixelsByStepWithShiftKey : OffsetPixelsByStep, 0));
                    break;
                case IncreaseAngleOrWind:
                    if (e.Alt == ModifierKeySide.None)
                    {
                        Angle += e.Shift != ModifierKeySide.None ? 10 : 1;
                    }
                    else
                    {
                        Wind -= e.Shift != ModifierKeySide.None ? 10 : 1;
                    }
                    break;                
                case DecreaseAngleOrWind:
                    if (e.Alt == ModifierKeySide.None)
                    {
                        Angle -= e.Shift != ModifierKeySide.None ? 10 : 1;
                    }
                    else
                    {
                        Wind += e.Shift != ModifierKeySide.None ? 10 : 1;
                    }
                    break;                
                case IncreasePower:
                    Power += e.Shift != ModifierKeySide.None ? 10 : 1;
                    break;                
                case DecreasePower:
                    Power -= e.Shift != ModifierKeySide.None ? 10 : 1;
                    break;
                default:
                    e.Handled = false;
                    isNeedRedraw = false;
                    break;
            }
            
            if (!isNeedRedraw)
            {
                return;
            }
            NeedRedraw?.Invoke();
        }
        
        private static Boolean CheckLastRedrawTime(Int32 checkTime = 100)
        {
            Int64 now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            Boolean check = checkTime < now - _lastRedraw;
            if (check) _lastRedraw = now;
            return check;
        }
        
        private static Int32 VK(Key key)
        {
            return KeyInterop.VirtualKeyFromKey(key);
        }
    }
}