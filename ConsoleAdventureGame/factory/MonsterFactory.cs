using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.factory{
    public static class MonsterFactory{
        public static Random gen = new Random();
        public static Monster CreateGoblin(Room room){
            return new Monster(5, new List<AbstractItem>(), room, ArmorFactory.CreateRags(), WeaponFactory.CreateClub(), "goblin", "a small, ugly humanoid with green skin.");
        }

        public static Monster CreateHobgoblin(Room room) => CreateHobgoblin(room, CreatureState.IDLE);

        public static Monster CreateHobgoblin(Room room, CreatureState creatureState) => new Monster(
            12,
            new List<AbstractItem>(),
            room,
            ArmorFactory.CreateLeather(),
            WeaponFactory.CreateAxe(),
            "hobgoblin",
            "the bigger, uglier cousin of the goblin.",
            creatureState
        );


    }
}