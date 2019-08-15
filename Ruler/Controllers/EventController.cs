// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Input;

namespace Ruler.Common
{
    internal class EventController
    {
        internal static event EventHandler ChangeWeaponMenuState;
        internal static event EventHandler NeedRedraw;

        internal static void RecognizeInputAndThrowEvent(Object sender, GlobalKeyboardHookEventArgs e)
        {
            Boolean isNeedRedraw = false;
            Int32 vkCode = e.KeyboardData.VirtualCode;
            if (vkCode == VK(Key.NumPad5) && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                ChangeWeaponMenuState?.Invoke(sender, e);
                isNeedRedraw = true;
                e.Handled = true;
            }

            if (isNeedRedraw)
            {
                NeedRedraw?.Invoke(sender, e);
            }
        }

        private static Int32 VK(Key key)
        {
            return KeyInterop.VirtualKeyFromKey(key);
        }
    }
}