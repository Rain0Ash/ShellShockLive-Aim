// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Input;
using Indieteur.GlobalHooks;

namespace Ruler.Common
{
    internal static partial class EventsAndGlobalsController
    {
        private static Int64 _lastRedraw = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        private const VirtualKeycodes ChangeWeaponMenuState = VirtualKeycodes.OEM_3;
        private const VirtualKeycodes ChangeSightPosition = VirtualKeycodes.E;

            internal static void RecognizeInputAndThrowEvent(Object sender, GlobalKeyEventArgs e)
        {
            Boolean isNeedRedraw = false;
            if (e.Control == ModifierKeySide.None)
            {
                return;
            }

            e.Handled = true;
            switch (e.KeyCode)
            {
                case ChangeWeaponMenuState:
                    ChangedWeaponMenuState?.Invoke(sender, e);
                    break;
                case ChangeSightPosition:
                {
                    if (!CheckLastRedrawTime(50))
                    {
                        return;
                    }
                    ChangedSightPosition?.Invoke(Utils.GetCursorPosition(RenderTargetSize));
                    isNeedRedraw = true;
                    break;
                }
                
                default:
                    e.Handled = false;
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