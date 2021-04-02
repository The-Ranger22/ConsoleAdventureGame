using System;
using System.Collections.Generic;
using ConsoleAdventureGame.factory;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;

namespace ConsoleAdventureGame.model.rooms{
    public class Dungeon{
        private static Random _gen;
        public static int RoomCount{ get; private set; } = 0;
        public Room[] Rooms{ get; private set; }

        public Dungeon(){
            _gen = new Random();
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
            //Add monsters
            Monster miniBoss = MonsterFactory.CreateHobgoblin(Rooms[4]);
            miniBoss.Weapon = WeaponFactory.CreateAxe();
            miniBoss.Armor = ArmorFactory.CreateChainmail();
            miniBoss.Behavior = NpcBehavior.ANGRY;
            miniBoss.Inventory.Add(ItemFactory.StrengthPotion());
            Rooms[4].Creatures.Add(miniBoss);
            int randPos = _gen.Next(7) + 1;
            Monster wanderer = MonsterFactory.CreateGoblin(Rooms[randPos]); //randomly place the wanderer in the dungeon, barring where the player starts
            wanderer.Inventory.Add(ItemFactory.AgilityPotion());
            wanderer.Behavior = NpcBehavior.ANGRY;
            wanderer.State = CreatureState.HUNTING;
            wanderer.Weapon = WeaponFactory.CreateDagger();
            wanderer.Inventory.Add(wanderer.Weapon);
            Rooms[randPos].Creatures.Add(wanderer);
            Monster boss = MonsterFactory.CreateHobgoblin(Rooms[7]);
            boss.Name = "Grimbo";
            boss.Armor = ArmorFactory.CreateChainmail();
            boss.Weapon = WeaponFactory.CreateGreatsword();
            boss.Behavior = NpcBehavior.ANGRY;
            Rooms[7].Creatures.Add(boss);
            Rooms[2].Creatures.Add(MonsterFactory.CreateGoblin(Rooms[2]));
            //Add items
            Rooms[6].Contents.Add(ArmorFactory.CreatePlate());
            MeleeWeapon thunderHammer = new MeleeWeapon(
                DamageType.PIERCING, 
                new DamageRoll(4, 6),
                "40mm BOFORS Autocannon",
                "Employed by multiple european militaries, the BOFORS is used as the main implement of destruction for multiple types of Infantry Fighting Vehicles.",
                1,
                100);

            Rooms[6].Contents.Add(thunderHammer);
            Rooms[2].Contents.Add(ItemFactory.CreateHealthPotionsSix());
            Rooms[1].Contents.Add(ArmorFactory.CreateRags());
            Rooms[5].Contents.Add(ItemFactory.CreateHealthPotionsNine());
            Rooms[0].Contents.Add(WeaponFactory.CreateMace());
            Rooms[0].Contents.Add(ItemFactory.CreateHealthPotionsSix());
            Rooms[3].Contents.Add(WeaponFactory.CreateSpear());
            
            
            


        }
        
        
    }
}