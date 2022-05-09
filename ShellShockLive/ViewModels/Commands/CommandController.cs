// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using System.Threading.Tasks;
using NetExtender.Types.Exceptions;
using NetExtender.Types.Numerics;
using NetExtender.Utilities.IO;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using NetExtender.Utilities.UserInterface;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Weapons.Internal;
using ShellShockLive.View;
using ShellShockLive.ViewModels.Guidance;
using ShellShockLive.ViewModels.History;
using ShellShockLive.ViewModels.Physics;
using ShellShockLive.ViewModels.Render;
using ShellShockLive.ViewModels.Sight;
using ShellShockLive.ViewModels.Vision;
using ShellShockLive.ViewModels.Vision.Bindings;
using ShellShockLive.ViewModels.Weapons;

namespace ShellShockLive.ViewModels.Commands
{
    public class CommandController
    {
        public virtual ValueTask<Boolean> ChangeWeaponMenuState()
        {
            WeaponsViewModel.Instance.ShowPanel = !WeaponsViewModel.Instance.ShowPanel;
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> SetSightToPosition()
        {
            return SetSightToPosition(CursorUtilities.Position);
        }

        public virtual async ValueTask<Boolean> SetSightToPosition(Point position)
        {
            SightViewModel sight = RenderManager.Instance.Sight;

            if (sight.Sight.Center.Distance(position) >= 50)
            {
                await ResetSightGuidance().ConfigureAwait(false);
            }

            sight.Sight.Center = position;
            return true;
        }

        public virtual async ValueTask<Boolean> SetSightOfPlayer()
        {
            if (!VisionBinding.TryGetBinding(PhysicsViewModel.Instance.Binding, out VisionBinding? binding))
            {
                return false;
            }

            VisionResult result = await VisionViewModel.Instance.VisionAsync(VisionType.Player, binding).ConfigureAwait(false);
            return result.Player && await SetSightToPosition(result.Player.Value).ConfigureAwait(false);
        }

        public virtual async ValueTask<Boolean> SetInformationOfPlayer()
        {
            if (!VisionBinding.TryGetBinding(PhysicsViewModel.Instance.Binding, out VisionBinding? binding))
            {
                return false;
            }

            VisionResult result = await VisionViewModel.Instance.VisionAsync(VisionType.Light, binding).ConfigureAwait(false);

            if (!result)
            {
                return false;
            }

            if (result.Player)
            {
                await SetSightToPosition(result.Player.Value).ConfigureAwait(false);
            }
            
            if (result.Wind)
            {
                PhysicsViewModel.Instance.Wind = result.Wind.Value;
            }

            if (result.Weapon)
            {
                WeaponsViewModel.Instance.Weapon = result.Weapon.Value;
            }
            
            SightViewModel sight = RenderManager.Instance.Sight;
            Point position = sight.Search.Search.Center;

            Int32? count = GuidanceViewModel.Instance.Guidance?.Search.Count;
            GuidanceSearchInfo? search = count switch
            {
                1 => WeaponsViewModel.Instance.GuidanceInfo.Search(sight.Sight.Center, position, default),
                > 1 => WeaponsViewModel.Instance.GuidanceInfo.SearchAll(sight.Sight.Center, position, default),
                _ => null
            };

            if (search is null || !sight.Search.Equals(position))
            {
                return true;
            }
            
            sight.Search.Set(search.Position, search.Step.Epsilon);
            GuidanceViewModel.Instance.Set(search);
            return true;
        }

        public virtual ValueTask<Boolean> OffsetSightPositionToUp()
        {
            return OffsetSightPosition(PointOffset.Up, 1);
        }

        public virtual ValueTask<Boolean> LargeOffsetSightPositionToUp()
        {
            return OffsetSightPosition(PointOffset.Up, 10);
        }

        public virtual ValueTask<Boolean> OffsetSightPositionToLeft()
        {
            return OffsetSightPosition(PointOffset.Left, 1);
        }

        public virtual ValueTask<Boolean> LargeOffsetSightPositionToLeft()
        {
            return OffsetSightPosition(PointOffset.Left, 10);
        }

        public virtual ValueTask<Boolean> OffsetSightPositionToDown()
        {
            return OffsetSightPosition(PointOffset.Down, 1);
        }

        public virtual ValueTask<Boolean> LargeOffsetSightPositionToDown()
        {
            return OffsetSightPosition(PointOffset.Down, 10);
        }

        public virtual ValueTask<Boolean> OffsetSightPositionToRight()
        {
            return OffsetSightPosition(PointOffset.Right, 1);
        }

        public virtual ValueTask<Boolean> LargeOffsetSightPositionToRight()
        {
            return OffsetSightPosition(PointOffset.Right, 10);
        }

        public virtual ValueTask<Boolean> OffsetSightPosition(PointOffset offset, Int32 count)
        {
            SightViewModel sight = RenderManager.Instance.Sight;
            sight.Sight.Center = sight.Sight.Center.WithOffset(offset, count);
            
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> IncreaseAngle()
        {
            return ChangeAngle(1);
        }
        
        public virtual ValueTask<Boolean> LargeIncreaseAngle()
        {
            return ChangeAngle(10);
        }
        
        public virtual ValueTask<Boolean> DecreaseAngle()
        {
            return ChangeAngle(-1);
        }
        
        public virtual ValueTask<Boolean> LargeDecreaseAngle()
        {
            return ChangeAngle(-10);
        }
        
        public virtual async ValueTask<Boolean> ChangeAngle(Int16 count)
        {
            await ResetSightGuidance().ConfigureAwait(false);
            PhysicsViewModel.Instance.Angle -= count;
            return true;
        }
        
        public virtual ValueTask<Boolean> IncreaseWind()
        {
            return ChangeWind(1);
        }
        
        public virtual ValueTask<Boolean> LargeIncreaseWind()
        {
            return ChangeWind(10);
        }
        
        public virtual ValueTask<Boolean> DecreaseWind()
        {
            return ChangeWind(-1);
        }
        
        public virtual ValueTask<Boolean> LargeDecreaseWind()
        {
            return ChangeWind(-10);
        }
        
        public virtual ValueTask<Boolean> ChangeWind(Int16 count)
        {
            PhysicsViewModel.Instance.Wind += count;
            return ValueTaskUtilities.True;
        }
        
        public virtual ValueTask<Boolean> IncreasePower()
        {
            return ChangePower(1);
        }
        
        public virtual ValueTask<Boolean> LargeIncreasePower()
        {
            return ChangePower(10);
        }
        
        public virtual ValueTask<Boolean> DecreasePower()
        {
            return ChangePower(-1);
        }
        
        public virtual ValueTask<Boolean> LargeDecreasePower()
        {
            return ChangePower(-10);
        }
        
        public virtual async ValueTask<Boolean> ChangePower(Int16 count)
        {
            await ResetSightGuidance().ConfigureAwait(false);
            PhysicsViewModel.Instance.Power += count;
            return true;
        }

        public virtual ValueTask<Boolean> FindAllSightGuidance()
        {
            return SetSightGuidance(WeaponsViewModel.Instance.GuidanceInfo.SearchAll);
        }

        public virtual ValueTask<Boolean> FindSightGuidance()
        {
            return SetSightGuidance(WeaponsViewModel.Instance.GuidanceInfo.Search);
        }

        public virtual ValueTask<Boolean> SetSightGuidance(Func<Point, Point, EnvironmentInfo?, GuidanceSearchInfo> action)
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            
            SightViewModel sight = RenderManager.Instance.Sight;
            Point position = CursorUtilities.Position;
            GuidanceSearchInfo search = action(sight.Sight.Center, position, default);
            sight.Search.Set(search.Position, search.Step.Epsilon);
            GuidanceViewModel.Instance.Set(search);
            
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> ResetSightGuidance()
        {
            SightViewModel sight = RenderManager.Instance.Sight;
            sight.Search.Reset();
            GuidanceViewModel.Instance.Clear();
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> NextTrajectory()
        {
            PhysicsInfo? next = GuidanceViewModel.Instance.Next;

            if (next is not { } physics)
            {
                return ValueTaskUtilities.False;
            }
            
            GuidanceViewModel.Instance.Set(physics);
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> PreviousTrajectory()
        {
            PhysicsInfo? previous = GuidanceViewModel.Instance.Previous;
            
            if (previous is not { } physics)
            {
                return ValueTaskUtilities.False;
            }
            
            GuidanceViewModel.Instance.Set(physics);
            return ValueTaskUtilities.True;
        }
        
        public virtual ValueTask<Boolean> HighestTrajectory()
        {
            PhysicsInfo? next = GuidanceViewModel.Instance.Highest;

            if (next is not { } physics)
            {
                return ValueTaskUtilities.False;
            }
            
            GuidanceViewModel.Instance.Set(physics);
            return ValueTaskUtilities.True;
        }
        
        public virtual ValueTask<Boolean> MiddleTrajectory()
        {
            PhysicsInfo? next = GuidanceViewModel.Instance.Middle;

            if (next is not { } physics)
            {
                return ValueTaskUtilities.False;
            }
            
            GuidanceViewModel.Instance.Set(physics);
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> LowestTrajectory()
        {
            PhysicsInfo? previous = GuidanceViewModel.Instance.Lowest;
            
            if (previous is not { } physics)
            {
                return ValueTaskUtilities.False;
            }
            
            GuidanceViewModel.Instance.Set(physics);
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> ChangeGuidanceType()
        {
            WeaponsViewModel weapons = WeaponsViewModel.Instance;
            GuidanceType guidance = weapons.Weapon.GuidanceType;
            
            weapons.Weapon = guidance switch
            {
                GuidanceType.Parabola => DirectWeapon.Instance,
                GuidanceType.Direct => ParabolaWeapon.Instance,
                GuidanceType.Custom => ParabolaWeapon.Instance,
                _ => throw new EnumUndefinedOrNotSupportedException<GuidanceType>(guidance, nameof(weapons.Weapon.GuidanceType), null)
            };
            
            return ValueTaskUtilities.True;
        }

        public virtual ValueTask<Boolean> UndoAction()
        {
            return HistoryViewModel.Instance.Manager.Undo() ? ValueTaskUtilities.True : ValueTaskUtilities.False;
        }

        public virtual ValueTask<Boolean> RedoAction()
        {
            return HistoryViewModel.Instance.Manager.Redo() ? ValueTaskUtilities.True : ValueTaskUtilities.False;
        }

        public virtual async ValueTask<Boolean> MakeScreenshot()
        {
            if (await VisionViewModel.Instance.MakeScreenshot().ConfigureAwait(false) is not { } filename)
            {
                return false;
            }

            SoundPlayer.Default.Play(SoundStorage.GetSounds(SoundType.Screenshot).GetRandomOrDefault());
            $"Скриншот сохранен как: {filename}".ToConsole();
            return true;
        }
    }
}