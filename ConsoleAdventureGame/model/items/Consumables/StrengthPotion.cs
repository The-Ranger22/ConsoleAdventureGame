using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    public class StrengthPotion : AbstractItem, InfConsumable{
        public StrengthPotion(string name, string desc) : base(name, desc){
            
        }

        public override void Use(AbstractCreature creature){
            creature.StrengthBoost = true;
        }
    }
}