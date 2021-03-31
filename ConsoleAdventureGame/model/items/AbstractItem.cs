using System;
using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items
{
    public abstract class AbstractItem
    {
        
        private static int itemCount = 0;
        public readonly int id;
        public string Name{ get; set; }
        public string Desc{ get; set; }


        protected AbstractItem(){
            id = itemCount++;
            Name = "Item" + id;
            Desc = "nil";
        }

        protected AbstractItem(String name, String desc){
            id = itemCount++;
            this.Name = name;
            this.Desc = desc;
        }

        public abstract void Use(AbstractCreature creature);



    }
    
}