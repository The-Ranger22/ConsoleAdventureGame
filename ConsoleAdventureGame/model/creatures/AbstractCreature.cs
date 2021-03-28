using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures
{
    public abstract class AbstractCreature {
        protected int health{ get; set; }
        private int actionPoints{ get; set; }
        private int level{ get; set; }
        private int experience{ get; set; }
        private bool wounded{ get; set; }
        private List<AbstractItem> inventory{ get; } = new List<AbstractItem>(10);
        private AbstractRoom location{ get; set; }
        public CreatureState state{ get; } = CreatureState.IDLE;

        protected class stats {

        }

        protected abstract bool move(Directions direction);
        //update location

        protected abstract void fight(AbstractCreature opponent);

        protected void dropItem(AbstractItem item) {
            //remove item from inventory. 
            //something like location.addContents(item) or some shit. 
        }

        protected abstract void pickUp(AbstractItem item);



        public void takeDamage(int damage) {
            health -= damage;
        }


    }

}