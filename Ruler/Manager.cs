// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Drawing;
using Ruler.Common;

namespace Ruler
{
    public class Manager : IDisposable
    {
        private Sight sight;
        private Trajectory trajectory;

        public Manager()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            Point initializeCoord = new Point(EventsAndGlobalsController.CurrentMonitor.Resolution.Width / 2, EventsAndGlobalsController.CurrentMonitor.Resolution.Height / 2);
            
            sight = new Sight(initializeCoord, EventsAndGlobalsController.Parameters.Length);
            trajectory = new Trajectory(initializeCoord);
        }

        public void NextFrame(Graphics graphics)
        {
            sight.Draw(ref graphics);
            trajectory.Draw(ref graphics);
        }

        public void Dispose()
        {
        }
    }
}