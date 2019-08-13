using System;

namespace Ruler.Common
{
    internal class EventController
    {
        internal static event EventHandler ChangeWeaponMenuState;

        internal EventController()
        {
        }

        internal void RecognizeAndThrowEvent(Object sender, GlobalKeyboardHookEventArgs e)
        {
            Boolean isNeedRedraw = false;
            if (e.KeyboardData.VirtualCode == 0x65 && e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                ChangeWeaponMenuState?.Invoke(sender, e);
            }
        }
    }
}