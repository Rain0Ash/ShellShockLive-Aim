// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Weapons.Internal
{
    public sealed class DirectWeapon : GuidanceInternalWeapon<DirectWeapon>
    {
        public override IGuidanceShell Shell
        {
            get
            {
                return Shells.Shell.Direct;
            }
        }
    }
}