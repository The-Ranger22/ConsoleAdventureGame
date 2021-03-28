using System.Collections.Generic;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures{
    public abstract class AbstractNpc : AbstractCreature{
        
        protected CreatureState state{ get; set; } = CreatureState.IDLE;
        protected NpcBehavior behavior{ get; set; }
        
        public AbstractNpc (int health, List<AbstractItem> inventory): base(health, inventory) {
            
        }

        
        
        
        
    }
}