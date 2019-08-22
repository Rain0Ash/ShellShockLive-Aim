// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Ruler.Common
{
    internal static partial class EventsAndGlobalsController
    {
        [Flags]
        private enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WinKey = 8
        }
        private struct Action
        {
            internal readonly Char Key;
            internal readonly KeyModifier KeyModifier;
            internal Action(Keys key, KeyModifier keyModifier)
            {
                Key = (Char)key;
                KeyModifier = keyModifier;
            }
        }

        private enum ActionsEnum
        {
            ChangeWeaponMenuState,
            ChangeWeaponMenuStateShift,
            ChangeSightPosition,
            ChangeSightPositionShift,
            UpOffsetSightPosition,
            UpOffsetSightPositionShift,
            LeftOffsetSightPosition,
            LeftOffsetSightPositionShift,
            DownOffsetSightPosition,
            DownOffsetSightPositionShift,
            RightOffsetSightPosition,
            RightOffsetSightPositionShift,
            IncreaseAngle,
            IncreaseAngleShift,
            DecreaseAngle,
            DecreaseAngleShift,
            IncreaseWind,
            IncreaseWindShift,
            DecreaseWind,
            DecreaseWindShift,
            IncreasePower,
            IncreasePowerShift,
            DecreasePower,
            DecreasePowerShift
        }

        private static readonly Action[] Actions = new[]
        {
            new Action(Keys.Oem3, KeyModifier.Ctrl),
            new Action(Keys.Oem3, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.E, KeyModifier.Ctrl),
            new Action(Keys.E, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.W, KeyModifier.Ctrl),
            new Action(Keys.W, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.A, KeyModifier.Ctrl),
            new Action(Keys.A, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.S, KeyModifier.Ctrl),
            new Action(Keys.S, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.D, KeyModifier.Ctrl),
            new Action(Keys.D, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.Right, KeyModifier.Ctrl),
            new Action(Keys.Right, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.Left, KeyModifier.Ctrl),
            new Action(Keys.Left, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.Right, KeyModifier.Ctrl | KeyModifier.Alt),
            new Action(Keys.Right, KeyModifier.Ctrl | KeyModifier.Alt | KeyModifier.Shift),
            new Action(Keys.Left, KeyModifier.Ctrl | KeyModifier.Alt),
            new Action(Keys.Left, KeyModifier.Ctrl | KeyModifier.Alt | KeyModifier.Shift),
            new Action(Keys.Up, KeyModifier.Ctrl),
            new Action(Keys.Up, KeyModifier.Ctrl | KeyModifier.Shift),
            new Action(Keys.Down, KeyModifier.Ctrl),
            new Action(Keys.Down, KeyModifier.Ctrl | KeyModifier.Shift),
        };

        private const Int32 OffsetPixelsByStep = 1;
        private const Int32 OffsetPixelsByStepWithShiftKey = 10;
        private const Int32 OffsetValueByStep = 1;
        private const Int32 OffsetValueByStepWithShiftKey = 10;

        [DllImport("user32.dll")]
        private static extern Boolean RegisterHotKey(IntPtr hWnd, Int32 id, Int32 fsModifiers, Int32 vlc);
        
        internal static void RegisterHotKeys(IntPtr handle)
        {
            for (Int32 actionID = 0; actionID < Actions.Length; actionID++)
            {
                Action action = Actions[actionID];
                RegisterHotKey(handle, actionID, (Int32)action.KeyModifier, action.Key);
            }
        }
        
        internal static Boolean RecognizeInputAndThrowEvent(ref Message m)
        {
            ActionsEnum action = (ActionsEnum) m.WParam.ToInt32();
            Boolean isNeedRedraw = true;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (action)
            {
                case ActionsEnum.ChangeWeaponMenuState:
                case ActionsEnum.ChangeWeaponMenuStateShift:
                    ChangedWeaponMenuState?.Invoke();
                    isNeedRedraw = false;
                    break;
                case ActionsEnum.ChangeSightPosition:
                case ActionsEnum.ChangeSightPositionShift:
                    ChangedSightPosition?.Invoke(Utils.GetCursorPosition());
                    break;
                case ActionsEnum.UpOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new Point(0, -OffsetPixelsByStep));
                    break;
                case ActionsEnum.UpOffsetSightPositionShift:
                    OffsetSightPosition?.Invoke(new Point(0, -OffsetPixelsByStepWithShiftKey));
                    break;
                case ActionsEnum.LeftOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new Point(-OffsetPixelsByStep, 0));
                    break;
                case ActionsEnum.LeftOffsetSightPositionShift:
                    OffsetSightPosition?.Invoke(new Point(-OffsetPixelsByStepWithShiftKey, 0));
                    break;
                case ActionsEnum.DownOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new Point(0, OffsetPixelsByStep));
                    break;
                case ActionsEnum.DownOffsetSightPositionShift:
                    OffsetSightPosition?.Invoke(new Point(0, OffsetPixelsByStepWithShiftKey));
                    break;
                case ActionsEnum.RightOffsetSightPosition:
                    OffsetSightPosition?.Invoke(new Point(OffsetPixelsByStep, 0));
                    break;
                case ActionsEnum.RightOffsetSightPositionShift:
                    OffsetSightPosition?.Invoke(new Point(OffsetPixelsByStepWithShiftKey, 0));
                    break;
                case ActionsEnum.IncreaseAngle:
                    Angle -= OffsetValueByStep;
                    break;
                case ActionsEnum.IncreaseAngleShift:
                    Angle -= OffsetValueByStepWithShiftKey;
                    break;
                case ActionsEnum.DecreaseAngle:
                    Angle += OffsetValueByStep;
                    break;                
                case ActionsEnum.DecreaseAngleShift:
                    Angle += OffsetValueByStepWithShiftKey;
                    break;
                case ActionsEnum.IncreaseWind:
                    Wind += OffsetValueByStep;
                    break;
                case ActionsEnum.IncreaseWindShift:
                    Wind += OffsetValueByStepWithShiftKey;
                    break;
                case ActionsEnum.DecreaseWind:
                    Wind -= OffsetValueByStep;
                    break;                
                case ActionsEnum.DecreaseWindShift:
                    Wind -= OffsetValueByStepWithShiftKey;
                    break;
                case ActionsEnum.IncreasePower:
                    Power += OffsetValueByStep;
                    break;
                case ActionsEnum.IncreasePowerShift:
                    Power += OffsetValueByStepWithShiftKey;
                    break;
                case ActionsEnum.DecreasePower:
                    Power -= OffsetValueByStep;
                    break;                
                case ActionsEnum.DecreasePowerShift:
                    Power -= OffsetValueByStepWithShiftKey;
                    break;
            }

            return isNeedRedraw;
        }
        
    }
}