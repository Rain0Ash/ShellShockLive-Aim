// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;
using System.Drawing;
using ShellShockLive.Models.Environment;
using ShellShockLive.Models.Environment.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.ViewModels.Environment
{
    public class EnvironmentViewModel : SurfaceViewModel
    {
        public override ISurface Surface { get; } = new EnvironmentInfo();
        private List<SurfaceViewModel> Environment { get; }
        
        public EnvironmentViewModel()
        {
            Environment = new List<SurfaceViewModel>(10);
        }

        public override void Draw(IGuidanceInfo guidance, Graphics graphics)
        {
            foreach (SurfaceViewModel surface in Environment)
            {
                surface.Draw(guidance, graphics);
            }
        }

        public void Add(SurfaceViewModel surface)
        {
            if (surface is null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            if (!surface.Interactive)
            {
                return;
            }

            Environment.Add(surface);
        }

        public void AddRange(IEnumerable<SurfaceViewModel> surfaces)
        {
            if (surfaces is null)
            {
                throw new ArgumentNullException(nameof(surfaces));
            }

            foreach (SurfaceViewModel surface in surfaces)
            {
                Add(surface);
            }
        }

        public void Remove(SurfaceViewModel surface)
        {
            if (surface is null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            Environment.Remove(surface);
        }

        public void Clear()
        {
            Environment.Clear();
        }
    }
}