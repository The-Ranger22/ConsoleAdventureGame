using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.Consumables{
    public class Potions : AbstractItem, InfConsumable {
        
        protected int PotionValue{ get; set; }
        
        public Potions(string name, string desc, int potionValue) : base(name, desc){
            PotionValue = potionValue;
        }

        public override void Use(AbstractCreature creature){
            // Creatures health cannot exceed his starting health, so use MaxHealth if the potion exceeds that value. 
            int newHealth = creature.Health += PotionValue;
            creature.Health = (newHealth > creature.MaxHealth) ? creature.MaxHealth : newHealth;
        }
    }
}