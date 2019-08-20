// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Windows.Forms;
using Ruler.Common;
using SharpDX.Direct2D1;
using SharpDX.Mathematics.Interop;

namespace Ruler
{
    public class Manager : IDisposable
    {
        private RenderTarget drawer;
        private Sight sight;
        private Trajectory trajectory;

        public Manager(ref RenderTarget renderTarget)
        {
            drawer = renderTarget;
            
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            RawVector2 initializeCoord = new RawVector2(drawer.Size.Width / 2f, drawer.Size.Height / 2f);
            
            sight = new Sight(initializeCoord, EventsAndGlobalsController.Parameters.Length, ref drawer);
            trajectory = new Trajectory(initializeCoord, ref drawer);
        }

        public void PrepareNextFrame()
        {
            sight.Draw();
            trajectory.Draw();
        }

        public void Dispose()
        {
        }
    }
}