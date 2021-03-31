using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.armor{
    public class Armor : AbstractArmor{

        public Armor() : base("Armor", "A suit of Armor"){
            
        }

        public Armor(EnArmors armorType){
            
        }

        public Armor(string name, string desc) : base(name, desc){
            
        }
        
        
        public override void Use(AbstractCreature creature){
            Equip(creature);
        }

        public override int CalculateArmorScore(){
            throw new System.NotImplementedException();
        }
    }
}