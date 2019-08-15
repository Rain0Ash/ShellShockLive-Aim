using System;

namespace Ruler.Common
{
    public static class Utils
    {
        public static Double GetUpdateTimeForFPS(Int32 fps)
        {
            return fps * fps / 1000d;
        }

    }
}