using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.items.armor
{
    public abstract class AbstractArmor : AbstractItem, InfEquippable{




        protected AbstractArmor(){
            
        }

        public AbstractArmor(string name, string desc) : base(name, desc){
            name = "Test Armor";
            desc = "Armor made from the soft and supple flesh of younglings";
        }

        public void Equip(AbstractCreature creature){
            creature.Armor = this;
        }

        public abstract int CalculateArmorScore();
    }
    
}