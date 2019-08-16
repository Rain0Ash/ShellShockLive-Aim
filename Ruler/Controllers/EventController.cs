// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace Ruler.Common
{
    internal class EventController
    {
        internal static event EventHandler NeedRedraw;
        internal static event EventHandler ChangeWeaponMenuState;

        internal static event EventHandler ChangeSightPosition;

        private static Int64 _lastRedraw = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        internal static void RecognizeInputAndThrowEvent(Object sender, GlobalKeyboardHookEventArgs e)
        {
            Boolean isNeedRedraw = false;
            Int32 vkCode = e.KeyboardData.VirtualCode;
            if (vkCode == VK(Key.NumPad5) && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                ChangeWeaponMenuState?.Invoke(sender, e);
                e.Handled = true;
            }

            if (vkCode == VK(Key.E) && e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfCtrldown)
            {
                e.Handled = true;
                Int64 now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
                if (now - _lastRedraw < 25)
                {
                    return;
                }
                
                _lastRedraw = now;
                ChangeSightPosition?.Invoke(sender, e);
                isNeedRedraw = true;
            }
            
            if (!isNeedRedraw)
            {
                return;
            }
            NeedRedraw?.Invoke(sender, e);
        }

        private static Int32 VK(Key key)
        {
            return KeyInterop.VirtualKeyFromKey(key);
        }
    }
}