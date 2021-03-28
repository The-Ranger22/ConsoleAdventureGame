using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.rooms
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