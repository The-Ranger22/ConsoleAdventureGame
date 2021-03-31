using ConsoleAdventureGame.model.items.armor;

namespace ConsoleAdventureGame.factory{
    public class ArmorFactory{
        public static Armor CreateRags() => new Armor();
        public static Armor CreateLeather() => new Armor();
    }
}