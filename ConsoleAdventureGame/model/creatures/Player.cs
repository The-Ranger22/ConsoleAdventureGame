using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;

namespace ConsoleAdventureGame.model.creatures
{
    public class Player : AbstractCreature{
        private const int INVENTORY_LIMIT = 5;


        public Player(int health, List<AbstractItem> inventory, AbstractArmor armor, AbstractWeapon weapon) : base(
            health, inventory, armor, weapon){
            
        }


        public bool PickUp(AbstractItem item){
            if (Inventory.Count < INVENTORY_LIMIT){
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