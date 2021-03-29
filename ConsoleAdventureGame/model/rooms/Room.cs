using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.rooms{
    public class Room{
        public int[] Adjacencies{ get; }
        public int Id{ get; }
        public string Description{ get; }
        public List<AbstractItem> Contents{ get; }
        public List<AbstractCreature> Creatures{ get; }

        public bool Visited{ get; }


        public Room(int id, int[] adjacencies){
            Id = id;
            Adjacencies = adjacencies;
            Description = "A cold, damp and frankly depressing room built out of uneven and poorly cut stone.";
            Contents = new List<AbstractItem>();
            Creatures = new List<AbstractCreature>();
            Visited = false;
        }
    }
}