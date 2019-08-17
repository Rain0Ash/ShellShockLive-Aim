// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Indieteur.GlobalHooks;

namespace Ruler.Common
{
    internal class KeyboardController : IDisposable
    {
        private static Int64 _lastKeyInput = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
        private GlobalKeyHook globalKeyHook;
        public void SetupKeyboardHooks()
        {
            if (globalKeyHook != null)
            {
                return;
            }

            globalKeyHook = new GlobalKeyHook();
            globalKeyHook.OnKeyDown += OnKeyPressed;
            globalKeyHook.OnKeyPressed += OnKeyPressed;
        }

        private void OnKeyPressed(Object sender, GlobalKeyEventArgs e)
        {
            Int64 now = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            if (now - _lastKeyInput < 25)
            {
                return;
            }
            _lastKeyInput = now;
            EventsAndGlobalsController.RecognizeInputAndThrowEvent(sender, e);
        }

        public void Dispose()
        {
            globalKeyHook?.Dispose();
        }
    }
}