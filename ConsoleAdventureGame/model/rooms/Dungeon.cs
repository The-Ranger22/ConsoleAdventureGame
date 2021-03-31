using System.Collections.Generic;
using ConsoleAdventureGame.Factory;
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
            Rooms[0] = new Room(RoomCount++, new []{1});
            Rooms[1] = new Room(RoomCount++, new []{0, 2, 3});
            Rooms[2] = new Room(RoomCount++, new []{1});
            Rooms[3] = new Room(RoomCount++, new []{1, 4});
            Rooms[4] = new Room(RoomCount++, new []{3, 5});
            Rooms[5] = new Room(RoomCount++, new []{4, 6, 7});
            Rooms[6] = new Room(RoomCount++, new []{5});
            Rooms[7] = new Room(RoomCount++, new []{5});

            Rooms[2].Contents.Add(new MeleeWeapon(EnMeleeWeapons.DAGGER));
            Rooms[1].Contents.Add(new MeleeWeapon(DamageType.BLUNT, new DamageRoll(3, 4), "The Mighty Mack",
                "A four foot long mackerel ideal for bludgeoning someone to death with.", 1));
            Rooms[7].Contents.Add(new MeleeWeapon(EnMeleeWeapons.GREATSWORD));
            Rooms[2].Creatures.Add(MonsterFactory.CreateGoblin(Rooms[2]));
            

        }
        
        
    }
}