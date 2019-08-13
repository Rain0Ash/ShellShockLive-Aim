using System;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace Ruler.Common
{
    internal class KeyboardController : IDisposable
    {
        private EventController eventController;
        private GlobalKeyboardHook globalKeyboardHook;

        public KeyboardController()
        {
            eventController = new EventController();
        }
        public void SetupKeyboardHooks()
        {
            globalKeyboardHook = new GlobalKeyboardHook();
            globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(Object sender, GlobalKeyboardHookEventArgs e)
        {
            //Debug.WriteLine(e.KeyboardData.VirtualCode);

            eventController.RecognizeAndThrowEvent(sender, e);



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