using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.rooms{
    public class Dungeon{
        public static int RoomCount{ get; private set; } = 0;
        public Room[] Rooms{ get; private set; }

        Dungeon(){
            prefabA();
        }

        private void prefabA(){
            Rooms = new Room[8];
            Rooms[0] = new Room(RoomCount++, new []{1});
            Rooms[1] = new Room(RoomCount++, new []{0, 2, 3});
            Rooms[2] = new Room(RoomCount++, new []{1});
            Rooms[3] = new Room(RoomCount++, new []{1, 4});
            Rooms[4] = new Room(RoomCount++, new []{3, 5});
            Rooms[5] = new Room(RoomCount++, new []{4, 6, 7});
            Rooms[6] = new Room(RoomCount++, new []{5});
            Rooms[7] = new Room(RoomCount++, new []{5});
        }
        
        
    }
}