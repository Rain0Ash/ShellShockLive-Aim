// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Physics.Guidances;
using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Weapons.Shells.Interfaces;

namespace ShellShockLive.Models.Weapons
{
    public class CustomWeapon : Weapon
    {
        public sealed override String Title { get; }
        public sealed override Byte Level { get; }
        public sealed override IShell Shell { get; }
        public sealed override IGuidance Guidance { get; }
        
        public CustomWeapon(String title, IGuidanceShell shell)
            : this(title, 0, shell)
        {
        }
        
        public CustomWeapon(String title, Byte level, IGuidanceShell shell)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Level = level;
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
            Guidance = shell.Guidance ?? throw new ArgumentNullException(nameof(shell.Guidance));
        }

        public CustomWeapon(String title, IShell shell, GuidanceType guidance)
            : this(title, 0, shell, guidance)
        {
        }

        public CustomWeapon(String title, IShell shell, IGuidance guidance)
            : this(title, 0, shell, guidance)
        {
        }

        public CustomWeapon(String title, Byte level, IShell shell, GuidanceType guidance)
            : this(title, level, shell, (Guidance) guidance)
        {
        }

        public CustomWeapon(String title, Byte level, IShell shell, IGuidance guidance)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Level = level;
            Shell = shell ?? throw new ArgumentNullException(nameof(shell));
            Guidance = guidance ?? throw new ArgumentNullException(nameof(guidance));
        }
    }
}