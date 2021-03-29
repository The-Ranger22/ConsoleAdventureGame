using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;
using ConsoleAdventureGame.view;

namespace ConsoleAdventureGame.control{
    /// <summary>
    /// Responsible for driving the game.
    /// </summary>
    public class Game{
        static Player _player = new Player(20, new List<AbstractItem>(), new SimpleArmor(), new MeleeWeapon());
        static Dungeon _dungeon = new Dungeon();
        static Room _currentRoom = _dungeon.Rooms[1];
        static View view = new View();
        private static bool gameIsRunning = true;

        public void run(){
            //display opening message/title
            view.Output("AdventureGame v0.1");

            //prompt player to inspect their inventory


            //int i = 0x2500;



            //main gameplay loop
            while (gameIsRunning){
                string room_description = "";
                //display the information about the room
                //    - display room description
                room_description += _currentRoom.Description;

                //    - display creature(s) descriptions


                //    - display descriptions of the contents of the room
                view.Output(room_description);

                
                //prompt user w/ menu options
                menu();
            }
        }

        public int menu(){
            bool actionTaken = false;

            while (!actionTaken){
                view.Output("What would you like to do?");
                view.Output("[1] : Inspect room");
                view.Output("[2] : Move");
                view.Output("[3] : Inventory");
                switch (view.Input()){
                    case 1:{
                        //inspect menu
                        actionTaken = inspectMenu();
                        break;
                    }
                    case 2:{
                        //move menu
                        actionTaken = moveMenu();
                        break;
                    }
                    case 3:{
                        //inventory menu
                        actionTaken = inventoryMenu();
                        break;
                    }
                    case 0:{
                        break;
                    } //quit
                    default: break;
                }
            }

            return -1;
        }

        private bool inspectMenu(){
            if (_currentRoom.Contents.Count < 1){
                view.Output("There is nothing to pick up.");
            } else{
                bool isInspecting = true;
                while (isInspecting){
                    int count = 0, input;
                    view.Output("What would you like to pick up?");
                    foreach (AbstractItem item in _currentRoom.Contents){
                        view.Output(String.Format("|{0} : {1}|", ++count, item.Name));
                    }

                    view.Output("Specify the number of the item you would like to pick up or enter 0 to return: ");
                    input = view.Input() - 1;//adjust user input to compensate for index offset
                    if (input == -1){
                        return false;
                    }
                    if (input >= 0 && input < count){
                        if (_player.PickUp(_currentRoom.Contents[input])){
                            view.Output($"You picked up {_currentRoom.Contents[input].Name}");
                            _currentRoom.Contents.RemoveAt(input);
                            return true;
                        }
                        view.Output("You've carrying to much! You'll need to part ways with something you hoarder.");
                        isInspecting = false;
                    }
                    else{
                        view.Output("What item are you talking about?");
                    }
                }
            }

            
            return false;
        }

        private bool moveMenu(){
            
            while (true){
                view.Output("Where would you like to go?");
                for (int i = 0; i < _currentRoom.Adjacencies.Length; i++){
                    view.Output(String.Format("[{0}] : Room {1}", i + 1, _currentRoom.Adjacencies[i]));
                }
                view.Output("Specify the number of the room you would like to go to. Enter 0 to return.");
                int input = view.Input() - 1;
                if (input == -1){
                    return false;
                }

                if (input > -1 && input < _currentRoom.Adjacencies.Length){
                    view.Output(String.Format("You head to room {0}", _currentRoom.Adjacencies[input]));
                    _currentRoom = _dungeon.Rooms[_currentRoom.Adjacencies[input]];
                    return true;
                }
                else{
                    view.Output("Well, you're not getting there from here.");
                }
                Console.Clear();
            }
        }

        private bool inventoryMenu(){
            
            while (true){
                view.Output("Manage your inventory.");
                string format = "[{0}] : {1}";
                for (int i = 0; i < _player.Inventory.Count; i++){
                    view.Output(String.Format(format, i + 1, _player.Inventory[i].Name));
                }
                view.Output("Specify the number of the item you would like to select.");
                int input = view.Input() - 1;
                if (input == -1){
                    return false;
                }
                if (input > -1 && input < _player.Inventory.Count){
                    AbstractItem item = _player.Inventory[input];
                    if (item is InfWieldable){
                        Console.WriteLine("YEeET");
                        //wield weapon
                        //drop weapon
                    } else if (item is InfEquippable){
                        //equip armor
                        //drop armor
                    } else if (item is InfConsumable){
                        //use item
                        //drop item
                    }
                    else{
                        view.Output("You have... what?");
                    }
                }
                else{
                    view.Output("You're rather imaginative, aren't you?");
                }
                //Console.Clear();
            }
        }
    }
}