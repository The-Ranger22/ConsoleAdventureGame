using ConsoleAdventureGame.model.items.armor;

namespace ConsoleAdventureGame.factory{
    public static class ArmorFactory{
        public static Armor CreateRags() => new Armor(
            6,
            "Rags",
            "A patchwork set of armor comprised of scraps of leather and ragged cloth.");
        public static Armor CreateLeather() => new Armor(
            10,
            "Leather Armor",
            "A set of worn studded leather armor."
            );
        public static Armor CreateChainmail() => new Armor(
            14,
            "Chainmail Armor",
            "A set of chainmail armor complete with a gambeson overcoat, making it the perfect excursion wear for fighting the french."
            );
        public static Armor CreatePlate() => new Armor(
            17,
            "Plate Armor",
            "A set of plate armor, forged from steel and quenched in the blood of virgins. We don't ask where the blood came from, we only ask if its been properly christened."
            );
    }
}