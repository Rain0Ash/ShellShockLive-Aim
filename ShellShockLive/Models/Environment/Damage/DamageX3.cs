// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace ShellShockLive.Models.Environment.Damage
{
    public class DamageX3 : CircleSurface
    {
        public override SurfaceType Type
        {
            get
            {
                return SurfaceType.DamageX3;
            }
        }

        public override Boolean Interactive
        {
            get
            {
                return true;
            }
        }

        public override Object Clone()
        {
            return new DamageX3
            {
                Center = Center,
                Radius = Radius
            };
        }
    }
}