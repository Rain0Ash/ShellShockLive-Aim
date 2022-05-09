// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using ShellShockLive.Models.Weapons.Internal;

namespace ShellShockLive.Models.Weapons.Stacks.Internal
{
    public sealed class PinpointWeaponStack : InternalWeaponStack<PinpointWeaponStack>
    {
        public PinpointWeaponStack()
            : base(PinpointWeapon.Instance, NeedlesWeapon.Instance, PinsandNeedlesWeapon.Instance)
        {
        }
    }
}