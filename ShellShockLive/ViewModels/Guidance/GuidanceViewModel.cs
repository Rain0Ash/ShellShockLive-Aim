// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using NetExtender.Types.Exceptions;
using NetExtender.Utilities.Numerics;
using NetExtender.Utilities.Types;
using NetExtender.WindowsPresentation.ReactiveUI.Types.Models;
using ReactiveUI.Fody.Helpers;
using ShellShockLive.Models.Physics;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.ViewModels.Physics;

namespace ShellShockLive.ViewModels.Guidance
{
    public class GuidanceViewModel : ReactiveViewModelSingleton<GuidanceViewModel>
    {
        [Reactive]
        public GuidanceSearchInfo? Guidance { get; private set; }
        
        public Int32 Index
        {
            get
            {
                return Guidance is not null && Guidance.Count > 0 ? Guidance.IndexOf(PhysicsViewModel.Instance.Physics) : -1;
            }
        }

        public PhysicsInfo? Next
        {
            get
            {
                if (Guidance is null || Guidance.Count <= 0)
                {
                    return default;
                }

                Int32 index = Index;
                PhysicsInfo physics = Guidance[++index % Guidance.Count];
                return physics;
            }
        }

        public PhysicsInfo? Previous
        {
            get
            {
                if (Guidance is null || Guidance.Count <= 0)
                {
                    return default;
                }

                Int32 index = Index;
                return index <= 0 ? Guidance[^1] : Guidance[--index];
            }
        }

        public PhysicsInfo? Highest
        {
            get
            {
                if (Guidance is null || Guidance.Count <= 0)
                {
                    return default;
                }

                return Guidance.Highest;
            }
        }

        public PhysicsInfo? Middle
        {
            get
            {
                if (Guidance is null || Guidance.Count <= 0)
                {
                    return default;
                }

                return Guidance.Middle;
            }
        }

        public PhysicsInfo? Lowest
        {
            get
            {
                if (Guidance is null || Guidance.Count <= 0)
                {
                    return default;
                }

                return Guidance.Lowest;
            }
        }

        public void Set(Int32 index)
        {
            if (Guidance is null)
            {
                return;
            }

            Set(Guidance[index]);
        }

        public void Set(PhysicsInfo physics)
        {
            PhysicsViewModel.Instance.Physics = physics;
        }

        public PhysicsInfo Set(GuidanceSearchInfo? guidance)
        {
            GuidanceSearchInfo? previous = Guidance;
            Guidance = guidance;

            PhysicsInfo current = PhysicsViewModel.Instance.Physics;
            if (Guidance is null || Guidance.Count <= 0)
            {
                return current;
            }

            Int32 index = Index;
            Int32 count = previous?.Count ?? 0;
            PhysicsInfo physics = count <= 0 || index == 0 ? Guidance.Highest : index >= 0 && index == Guidance.Count - 1 ? Guidance.Lowest : Nearest(current) ?? Guidance.Highest;
            
            Set(physics);
            return physics;
        }

        public PhysicsInfo? Nearest(PhysicsInfo physics)
        {
            if (Guidance is null || Guidance.Count <= 0)
            {
                return default;
            }

            if (Guidance.Search.Contains(physics))
            {
                return physics;
            }

            (PhysicsInfo lower, PhysicsInfo higher) = Guidance.Search.Nearest(physics, out MathPositionType position);

            return position switch
            {
                MathPositionType.None => default,
                MathPositionType.Left => lower,
                MathPositionType.Right => higher,
                MathPositionType.Both => higher,
                _ => throw new EnumUndefinedOrNotSupportedException<MathPositionType>(position)
            };
        }

        public void Clear()
        {
            Guidance = null;
        }
    }
}