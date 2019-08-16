// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Ruler.Common
{
    internal class KeyboardController : IDisposable
    {
        private GlobalKeyboardHook globalKeyboardHook;
        private static Int64 lastKeyInput = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        
        public void SetupKeyboardHooks()
        {
            globalKeyboardHook = new GlobalKeyboardHook();
            globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(Object sender, GlobalKeyboardHookEventArgs e)
        {
            //Debug.WriteLine(e.KeyboardData.VirtualCode);
            Int64 now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            if (now - lastKeyInput < 50)
            {
                return;
            }
            lastKeyInput = now;
            EventController.RecognizeInputAndThrowEvent(sender, e);



            /*if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkSnapshot)
                return;
            
             seems, not needed in the life.
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
                e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
            {
                MessageBox.Show("Alt + Print Screen");
                e.Handled = true;
            }
            //else

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                MessageBox.Show("Print Screen");
                e.Handled = true;
            }*/
        }

        public void Dispose()
        {
            globalKeyboardHook?.Dispose();
        }
    }
}