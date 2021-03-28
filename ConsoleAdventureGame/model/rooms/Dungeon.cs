using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;

namespace ConsoleAdventureGame.model.rooms{
    public class Dungeon{
        private static int roomCount = 0;
        private Room[] _rooms;
        
        Dungeon(){
            prefabA();
        }

        private void prefabA(){
            _rooms = new Room[8];
            _rooms[0] = new Room(roomCount++, new []{1});
            _rooms[1] = new Room(roomCount++, new []{0, 2, 3});
            _rooms[2] = new Room(roomCount++, new []{1});
            _rooms[3] = new Room(roomCount++, new []{1, 4});
            _rooms[4] = new Room(roomCount++, new []{3, 5});
            _rooms[5] = new Room(roomCount++, new []{4, 6, 7});
            _rooms[6] = new Room(roomCount++, new []{5});
            _rooms[7] = new Room(roomCount++, new []{5});
        }
        
        
    }
}