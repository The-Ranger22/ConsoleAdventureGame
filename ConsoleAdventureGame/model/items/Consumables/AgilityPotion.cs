using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    /// <summary>
    /// Concrete class for an agility potion, that adds to the players armor value to decrease the likelihood of a hit. 
    /// </summary>
    public class AgilityPotion : AbstractItem, InfConsumable{
        public AgilityPotion(string name, string desc) : base(name, desc){ }

        /// <summary>
        /// Use method sets the current creatures AgilityBoost boolean value to true, which adds points to the armor value calculation in the fight method for 1 turn. Also removes the item from the user's inventory.
        /// </summary>
        /// <param name="creature">The creature that will consume the potion. At this point that will only be the player, but could change in the future.</param>
        public override void Use(AbstractCreature creature){
            if (creature.Inventory.Contains(this)){
                creature.AgilityBoost = true;
                creature.Inventory.Remove(this);
            }
        }
    }
}