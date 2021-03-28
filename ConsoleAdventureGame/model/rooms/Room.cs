using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.rooms{
    public class Room{
        public int[] Adjacencies{ get; }
        public int Id{ get; }
        public LinkedList<AbstractItem> Contents{ get; }
        public LinkedList<AbstractCreature> Creatures{ get; }

        public Room(int id, int[] adjacencies){
            this.Id = id;
            this.Adjacencies = adjacencies;
        }
        
        

        public void randomizeContents(){
                
        }
    }
}