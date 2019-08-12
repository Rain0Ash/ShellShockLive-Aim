using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ruler.Weapons.Common
{
    public static class Weapons
    {
        private static Dictionary<String, Weapon> _weaponsDict = GetWeapons();

        public static List<Weapon> WeaponList = new List<Weapon>
        {
            //-
            new Weapon("Shot", 0, new Point(0, 0), Guidance.Parabola, Color.Gray),
            new Weapon("Big Shot", 0, new Point(0, 1), Guidance.Parabola, Color.Gray),
            new Weapon("Heavy Shot", 0, new Point(0, 2), Guidance.Parabola, Color.Gray),
            new Weapon("Massive Shot", 0, new Point(0, 3), Guidance.Parabola, Color.Gray),
            //-
            new Weapon("Three-Ball", 0, new Point(1, 0), Guidance.Parabola, Color.Gray),
            new Weapon("Five-Ball", 0, new Point(1, 1), Guidance.Parabola, Color.Gray),
            new Weapon("Eleven-Ball", 0, new Point(1, 2), Guidance.Parabola, Color.Gray),
            new Weapon("TwentyFive-Ball", 0, new Point(1, 3), Guidance.Parabola, Color.Gray),
            //-
            new Weapon("One-Bounce", 0, new Point(2, 0), Guidance.Parabola, Color.Purple),
            new Weapon("Three-Bounce", 0, new Point(2, 1), Guidance.Parabola, Color.Purple),
            new Weapon("Five-Bounce", 0, new Point(2, 2), Guidance.Parabola, Color.Purple),
            new Weapon("Seven-Bounce", 0, new Point(2, 3), Guidance.Parabola, Color.Purple),
            //-
            new Weapon("Digger", 0, new Point(3, 0), Guidance.Parabola, Color.Brown),
            new Weapon("Mega-Digger", 0, new Point(3, 1), Guidance.Parabola, Color.Brown),
            new Weapon("Excavation", 0, new Point(3, 2), Guidance.Parabola, Color.Brown),
            //-
            new Weapon("Grenade", 0, new Point(4, 0), Guidance.Parabola, Color.Green),
            new Weapon("Tri-Nade", 0, new Point(4, 1), Guidance.Parabola, Color.Green),
            new Weapon("Multi-Nade", 0, new Point(4, 2), Guidance.Parabola, Color.Green),
            new Weapon("Grenade Storm", 0, new Point(4, 3), Guidance.Parabola, Color.Green),
            //-
        };
        
        private static Dictionary<String, Weapon> GetWeapons()
        {
            Dictionary<String, Weapon> dict = new Dictionary<String, Weapon>();
            WeaponList.ForEach(weapon => dict.Add(weapon.Name, weapon));
            return dict;
        }

        public static Weapon GetWeapon(String weaponName)
        {
            _weaponsDict.TryGetValue(weaponName, out Weapon value);
            return value;
        }
        
    }
}