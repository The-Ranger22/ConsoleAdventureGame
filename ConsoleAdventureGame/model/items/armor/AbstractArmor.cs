using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.items.armor
{
    public abstract class AbstractArmor : AbstractItem, InfEquippable{
        public int ArmorHealth{ get; set; }

        public AbstractArmor(){
            name = "Test Armor";
            desc = "Armor made from the soft and supple flesh of younglings";
            ArmorHealth = 10;
        }

        public AbstractArmor(string name, string desc) : base(name, desc){
            name = "Test Armor";
            desc = "Armor made from the soft and supple flesh of younglings";
        }
    }
}