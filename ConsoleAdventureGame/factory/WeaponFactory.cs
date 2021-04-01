using ConsoleAdventureGame.model.items.weapon;
/*
 * Description: This class creates the weapons by assigning them an enum 
 */
namespace ConsoleAdventureGame.factory{
    public class WeaponFactory{
        public static MeleeWeapon CreateSword() => new MeleeWeapon(EnMeleeWeapons.SWORD);
        public static MeleeWeapon CreateAxe() => new MeleeWeapon(EnMeleeWeapons.AXE);
        public static MeleeWeapon CreateMace() => new MeleeWeapon(EnMeleeWeapons.MACE);
        public static MeleeWeapon CreateClub() => new MeleeWeapon(EnMeleeWeapons.CLUB);
        public static MeleeWeapon CreateGreatsword() => new MeleeWeapon(EnMeleeWeapons.GREATSWORD);
        public static MeleeWeapon CreateSpear() => new MeleeWeapon(EnMeleeWeapons.SPEAR);
        public static MeleeWeapon CreateDagger() => new MeleeWeapon(EnMeleeWeapons.DAGGER);
    }
}