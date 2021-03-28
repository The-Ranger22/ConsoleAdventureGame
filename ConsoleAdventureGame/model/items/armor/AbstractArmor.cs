using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.items.armor
{
    public abstract class AbstractArmor : AbstractItem, InfEquippable{
        public int ArmorHealth{ get; set; } = 10;

        protected AbstractArmor(string name, string desc) : base(name, desc){
            name = "Test Armor";
            desc = "Armor made from the soft and supple flesh of younglings";
        }
    }
}