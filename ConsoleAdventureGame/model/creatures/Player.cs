using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;

namespace ConsoleAdventureGame.model.creatures
{
    /// <summary>
    /// Class representing the user of the program. Everything but the inventory limit is inherited from AbstractCreature.
    /// Contains methods for adding and dropping items from the inventory as well as taking damage.
    /// </summary>
    public class Player : AbstractCreature{
        private const int INVENTORY_LIMIT = 7;


        public Player(int health, List<AbstractItem> inventory, AbstractArmor armor, AbstractWeapon weapon) : base(
            health, inventory, armor, weapon){
            
        }

        /// <summary>
        /// Adds and item to the user's inventory provided that space is available.
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>True if the item was successfully added, false otherwise</returns>
        public bool PickUp(AbstractItem item){
            if (Inventory.Count < INVENTORY_LIMIT){
                Inventory.Add(item);
                return true;
            } else {
                return false;
            }
        }
        
        /// <summary>
        /// Remove's an item from the user's inventory
        /// </summary>
        /// <param name="indexOfItem">The index of the item to be removed</param>
        /// <returns>The item that was removed.</returns>
        public AbstractItem DropItem(int indexOfItem){
            AbstractItem item = Inventory[indexOfItem];
            Inventory.Remove(item);
            return item;
        }

        /// <summary>
        /// Removes damage taken during a turn of combat from the user's health
        /// </summary>
        /// <param name="damage">The integer value representing the damage taken</param>
        protected override void TakeDamage(int damage){
            Health -= damage;
        }
    }
}