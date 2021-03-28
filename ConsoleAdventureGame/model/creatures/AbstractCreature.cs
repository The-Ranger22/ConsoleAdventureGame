using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures
{
    public abstract class AbstractCreature {
        protected int health{ get; set; }
        protected AbstractWeapon weapon{ get; set; }
        protected List<AbstractItem> inventory{ get; set; } = new List<AbstractItem>(10);
        
        public AbstractCreature(int health, List<AbstractItem> inventory){
            this.health = health;
            this.inventory = inventory;
            this.weapon = new MeleeWeapon();
        }

        protected void fight(AbstractCreature opponent) {
            while (opponent.health > 0) {
                //for (int i = 0; i < weapon.)
            }
        }
        

        public void takeDamage(int damage) {
            health -= damage;
        }


    }

}