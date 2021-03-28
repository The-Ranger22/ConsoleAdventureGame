using System;
using System.Collections.Generic;
using AdventureGame.model.creatures;
using AdventureGame.model.items;

namespace AdventureGame.model.rooms
{
    public abstract class AbstractRoom
    {
        protected HashSet<AbstractCreature> occupants;
        protected HashSet<AbstractItem> items;
        protected static int roomCount = 0;
        private String id { get; }

        protected AbstractRoom()
        {
            this.id = "R" + roomCount++;
            this.occupants = new HashSet<AbstractCreature>();
            this.items = new HashSet<AbstractItem>();
        }

        
    }
}