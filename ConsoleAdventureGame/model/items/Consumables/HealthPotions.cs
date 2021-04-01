using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    /// <summary>
    /// Concrete class for a health potion, that when consumed replenishes some of the player's health, not to exceed their starting health. 
    /// </summary>
    public class HealthPotions : AbstractItem, InfConsumable {
        
        public int PotionValue{ get; set; }

        public HealthPotions(string name, string desc, int potionValue) : base(name, desc){
            PotionValue = potionValue;
        }

        /// <summary>
        /// Increase the players health by the value of the potion. If that exceeds the MaxHealth, then set the user's health to max health. 
        /// </summary>
        /// <param name="creature">The creature using the potion</param>
        public override void Use(AbstractCreature creature){
            if (creature.Inventory.Contains(this)){
                int newHealth = creature.Health += PotionValue;
                creature.Health = (newHealth > creature.MaxHealth) ? creature.MaxHealth : newHealth; // Creatures health cannot exceed his starting health, so use MaxHealth if the potion exceeds that value. 
                creature.Inventory.Remove(this);
            }
        }
    }
}