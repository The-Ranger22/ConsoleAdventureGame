using System;

namespace ConsoleAdventureGame.model.items
{
    public abstract class AbstractItem
    {
        //TODO: Add container data field
        private static int itemCount = 0;
        public readonly int id;
        protected String name { get; set; }
        protected String desc { get; set; }


        protected AbstractItem(){
            id = itemCount++;
            name = "Item" + id;
            desc = "nil";
        }

        protected AbstractItem(String name, String desc){
            id = itemCount++;
            this.name = name;
            this.desc = desc;
        }

        public abstract void use();



    }
    
}