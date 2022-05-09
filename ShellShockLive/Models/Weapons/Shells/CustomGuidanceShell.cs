// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using ShellShockLive.Models.Physics.Guidances.Interfaces;

namespace ShellShockLive.Models.Weapons.Shells
{
    public class CustomGuidanceShell : GuidanceShell
    {
        public sealed override ShellType ShellType { get; }
        public sealed override IGuidance Guidance { get; }
        
        public CustomGuidanceShell(ShellType shell, IGuidance guidance)
        {
            ShellType = shell;
            Guidance = guidance ?? throw new ArgumentNullException(nameof(guidance));
        }
    }
}