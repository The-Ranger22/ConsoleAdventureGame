using System.Collections.Generic;
using ConsoleAdventureGame.factory;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;

namespace ConsoleAdventureGame.model.rooms{
    public class Dungeon{
        public static int RoomCount{ get; private set; } = 0;
        public Room[] Rooms{ get; private set; }

        public Dungeon(){
            prefabA();
        }

        private void prefabA(){
            Rooms = new Room[8];
            Rooms[0] = new Room(RoomCount++, new []{1}, this);
            
            Rooms[1] = new Room(RoomCount++, new []{0, 2, 3}, this);
            Rooms[2] = new Room(RoomCount++, new []{1}, this);
            Rooms[3] = new Room(RoomCount++, new []{1, 4}, this);
            Rooms[4] = new Room(RoomCount++, new []{3, 5}, this);
            Rooms[5] = new Room(RoomCount++, new []{4, 6, 7}, this);
            Rooms[6] = new Room(RoomCount++, new []{5}, this);
            Rooms[7] = new Room(RoomCount++, new []{5}, this);
            
            
            
            Monster monster = MonsterFactory.CreateGoblin(Rooms[1]);
            monster.Behavior = NpcBehavior.ANGRY;
            Rooms[1].Creatures.Add(monster);


        }
        
        
    }
}