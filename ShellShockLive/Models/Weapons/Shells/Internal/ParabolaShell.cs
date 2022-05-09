// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Physics.Guidances.Interfaces;
using ShellShockLive.Models.Physics.Guidances.Internal;
using ShellShockLive.Models.Weapons.Shells;

namespace ShellShockLive.Models.Shells.Internal
{
    public sealed class ParabolaShell : InternalGuidanceShell<ParabolaShell>
    {
        public override ShellType ShellType
        {
            get
            {
                return ShellType.All;
            }
        }

        public override IGuidance Guidance
        {
            get
            {
                return ParabolaGuidance.Instance;
            }
        }
    }
}