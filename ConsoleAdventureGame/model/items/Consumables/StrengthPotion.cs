using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    /// <summary>
    /// Concrete class for a strength potion, which acts by increasing the players weapons number of attacks by 1. 
    /// </summary>
    public class StrengthPotion : AbstractItem, InfConsumable{
        public StrengthPotion(string name, string desc) : base(name, desc){
            
        }

        /// <summary>
        /// Use method sets the boolean value StrengthBoost to true.
        /// </summary>
        /// <param name="creature">The creature to receive the boost, which will only be the player for now.</param>
        public override void Use(AbstractCreature creature){
            if (creature.Inventory.Contains(this)){
                creature.StrengthBoost = true;
                creature.Inventory.Remove(this);
            }
            
        }
    }
}