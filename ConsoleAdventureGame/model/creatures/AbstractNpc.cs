using System.Collections.Generic;
using AdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures{
    public abstract class AbstractNpc : AbstractCreature{
        
        protected CreatureState State{ get; set; } = CreatureState.IDLE;
        protected NpcBehavior Behavior{ get; set; }
        protected Room Location{ get; set; }
        
        public AbstractNpc (int health, List<AbstractItem> inventory, Room location, AbstractArmor Armor): base(health, inventory, Armor){
            Location = location;
        }

        
        
        
        
    }
}