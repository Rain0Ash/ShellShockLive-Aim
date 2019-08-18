// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.Collections.Generic;

namespace Ruler.Common
{
    public struct Parameters
    {
        internal Int32 Length;
        internal Int32 PointHeight;
        internal Double Gravity;
        internal Double Velocity;
        internal Double Radius;
        internal Double WindW;
        internal Int32 PortalRadius;
        internal Int32 BlackHoleRadius;

        public Parameters(Int32 length, Int32 pointHeight, Double gravity, Double velocity, Double radius, Double windW,
            Int32 portalRadius, Int32 blackHoleRadius)
        {
            Length = length;
            PointHeight = pointHeight;
            Gravity = gravity;
            Velocity = velocity;
            Radius = radius;
            WindW = windW;
            PortalRadius = portalRadius;
            BlackHoleRadius = blackHoleRadius;
        }
    }
    
    internal static class Parameter
    {
        private static readonly Dictionary<String, Parameters> ParametersDict = new Dictionary<String, Parameters>
        {
            {"1280x1024", new Parameters(220, 145, 9.8d, 1.272d, 19.9d, 1.0d/80.0d, 50, 50)},
            {"1366x768", new Parameters(236, 145, 9.8d, 1.317d, 20.0d, 1.0d/80.0d, 50, 50)},
            {"1600x1024", new Parameters(280, 145, 9.8d, 1.424d, 22.8d, 1.0d/80.0d, 50, 50)},
            {"1680x1050", new Parameters(300, 145, 9.8d, 1.46d, 26.0d, 1.0d/80.0d, 50, 50)},
            {"1920x1080", new Parameters(300, 165, 9.8d, 1.559d, 28.0d, 1.0d/80.0d, 50, 50)}, //can't check params
            {"2560x1440", new Parameters(350, 240, 9.8d, 1.8d, 37.0d, 1.0d/80.0d, 50, 50)} //can't check params
        };

        internal static Parameters GetParameters(String gameResolution = null)
        {
            return gameResolution != null && ParametersDict.ContainsKey(gameResolution) ? ParametersDict[gameResolution] : ParametersDict["1366x768"];
        }
        
    }
}