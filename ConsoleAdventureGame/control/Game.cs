using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.rooms;
using ConsoleAdventureGame.view;

namespace ConsoleAdventureGame.control
{
    /// <summary>
    /// Responsible for driving the game.
    /// </summary>
    public class Game{
        static Player _player = new Player(20, new List<AbstractItem>(), new SimpleArmor());
        static Dungeon _dungeon = new Dungeon();
        static Room _currentRoom = _dungeon.Rooms[0];
        static View view = new View();
        private static bool gameIsRunning = true;
        public void run(){
            //display opening message/title
            view.Output("AdventureGame v0.1");
            //prompt player to inspect their inventory
            
            
            
            //main gameplay loop
            while (gameIsRunning){
                //display the information about the room
                //    - display room description
                //    - display creature(s) descriptions
                //    - display descriptions of the contents of the room
                
                
                
                //prompt user w/ menu options
                
                
            }
        }
        
    }
}