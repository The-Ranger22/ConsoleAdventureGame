using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    public class AgilityPotion : AbstractItem, InfConsumable{
        public AgilityPotion(string name, string desc) : base(name, desc){ }

        public override void Use(AbstractCreature creature){
            creature.AgilityBoost = true;
        }
    }
}