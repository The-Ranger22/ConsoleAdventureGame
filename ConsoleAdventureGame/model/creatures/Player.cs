using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.creatures
{
    public class Player : AbstractCreature{
        public Player(int health, List<AbstractItem> inventory, AbstractArmor armor) : base(health, inventory, armor){ }


        public bool PickUp(AbstractItem item){
            if (Inventory.Count < 10){
                Inventory.Add(item);
                return true;
            } else {
                return false;
            }
        }

        public AbstractItem DropItem(int indexOfItem){
            AbstractItem item = Inventory[indexOfItem];
            return item;
        }





    }
}