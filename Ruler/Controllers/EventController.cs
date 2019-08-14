// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Ruler.Common
{
    internal class EventController
    {
        internal static event EventHandler ChangeWeaponMenuState;
        internal static event EventHandler NeedRedraw;

        internal void RecognizeAndThrowEvent(Object sender, GlobalKeyboardHookEventArgs e)
        {
            Boolean isNeedRedraw = false;
            if (e.KeyboardData.VirtualCode == 0x65 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                ChangeWeaponMenuState?.Invoke(sender, e);
            }

            if (isNeedRedraw)
            {
                NeedRedraw?.Invoke(sender, e);
            }
        }
    }
}