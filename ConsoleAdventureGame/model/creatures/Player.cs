using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures
{
    public class Player : AbstractCreature{
        public Player(int health, List<AbstractItem> inventory) : base(health, inventory){ }


        public bool pickUp(AbstractItem item){
            if (inventory.Count < 10){
                inventory.Add(item);
                return true;
            } else {
                return false;
            }
        }

        public AbstractItem dropItem(int indexOfItem){
            AbstractItem item = inventory[indexOfItem];
            return item;
        }





    }
}