using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

/*
 * Description: This class creates the Monster profile assigning them health, weapons, and armor. 
 */
namespace ConsoleAdventureGame.factory{
    public static class MonsterFactory{
        public static Random gen = new Random();

        /// <summary>
        /// Creates a goblin and puts them in a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static Monster CreateGoblin(Room room){
            return new Monster(5, new List<AbstractItem>(), room, ArmorFactory.CreateRags(), WeaponFactory.CreateClub(), "goblin", "a small, ugly humanoid with green skin.");
        }

        /// <summary>
        /// Creates an idle hobglobin and puts them in a room
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static Monster CreateHobgoblin(Room room) => CreateHobgoblin(room, CreatureState.IDLE);

        /// <summary>
        /// Creates a full hobglobin and assigns them a room and state
        /// </summary>
        /// <param name="room"></param>
        /// <param name="creatureState"></param>
        /// <returns></returns>
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