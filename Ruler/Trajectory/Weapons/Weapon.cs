using System;
using System.Drawing;

namespace Ruler.Weapons
{
    public struct Weapon
    {
        public String Name;
        public AvGuidance GuidanceType;
        public Image Image;

        public Weapon(String weaponName, Image image = null)
        {
            Name = weaponName;
            GuidanceType = AvGuidance.Parabola;
            Image = image;
        }
        
        public Weapon(String weaponName, AvGuidance guidanceType, Image image = null)
        {
            Name = weaponName;
            GuidanceType = guidanceType;
            Image = image;
        }

        public override String ToString()
        {
            return Name;
        }
    }
}