using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ConsoleAdventureGame.factory;
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
        static Player _player = new Player(20, new List<AbstractItem>(), ArmorFactory.CreateLeather(), WeaponFactory.CreateSword());
        static Dungeon _dungeon = new Dungeon();
        static Room _currentRoom = _dungeon.Rooms[0]; //player's initial spawn point
        static View view = new View();
        private static bool gameIsRunning = true;

        public void run(){
            //display opening message/title
            view.Output("AdventureGame v0.1");
            view.displayTitle();
            //main gameplay loop
            while (gameIsRunning){
                //display the information about the room
                //    - display room description
                //    - display creature(s) descriptions
                //    - display descriptions of the contents of the room
                describeRoom();
                //prompt user w/ menu options
                menu();
            }
        }
        
        
        private bool menu(){
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
                    case 0:{//quit
                        return false;
                    }
                }
            }

            return true;
        }

        private bool inspectMenu(){
            if (_currentRoom.Contents.Count < 1){
                view.Output("There is nothing to pick up.");
            }
            else{
                bool isInspecting = true;
                while (isInspecting){
                    int count = 0, input;
                    view.Output("What would you like to pick up?");
                    foreach (AbstractItem item in _currentRoom.Contents){
                        view.Output(String.Format("[{0}] : {1}", ++count, item.Name));
                    }

                    view.Output("Specify the number of the item you would like to pick up or enter 0 to return: ");
                    input = view.Input() - 1; //adjust user input to compensate for index offset
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
                view.Output("[0] : Return");
                view.Output("Specify the number of the item you would like to select.");
                int input = view.Input() - 1;
                if (input == -1){
                    return false;
                }

                if (input > -1 && input < _player.Inventory.Count){
                    AbstractItem item = _player.Inventory[input];
                    if (item is InfWieldable){
                        while (true){
                            view.Output(String.Format("What would you like to do with {0}?", item.Name));
                            //output the name of the weapon
                            view.Output(item.Name);
                            //output the description of the weapon
                            view.Output(item.Desc);
                            //list available actions that the user can perform on the weapon
                            view.Output(String.Format(format, 1, "Wield"));
                            view.Output(String.Format(format, 2, "Drop"));
                            view.Output(String.Format(format, 0, "Return"));
                            switch (view.Input()){
                                case 0:{
                                    //return to outer menu
                                    return false;
                                }
                                case 1:{
                                    //wield the weapon
                                    ((InfWieldable) item).Wield(_player); //set the player's weapon to the new one
                                    view.Output(String.Format("You are now wielding {0}.", item.Name));
                                    return true;
                                }
                                case 2:{
                                    //drop the weapon
                                    _currentRoom.Contents.Add(_player.DropItem(_player.Inventory.IndexOf(item)));
                                    //if the item dropped is the weapon the player is currently holding, set the player's current weapon to null
                                    if (_player.Weapon == item){
                                        _player.Weapon = null;
                                    }
                                    view.Output(String.Format("You drop {0}.", item.Name));
                                    return true;
                                }
                                default:{
                                    view.Output(String.Format("You want to do what with {0}?", item.Name));
                                    break;
                                }
                            }
                        }
                    }
                    else if (item is InfEquippable){
                        view.Output("NOT YET IMPLEMENTED");
                        //equip armor
                        //drop armor
                    }
                    else if (item is InfConsumable){
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

        private void describeRoom(){
            view.Output("You enter the room.");
            view.Output(_currentRoom.Description);
            //display all the creatures inside the room if there are any
            if (_currentRoom.Creatures.Count > 0){
                if (_currentRoom.Creatures.Count == 1){
                    view.Output("You see a ", false);
                    view.Output($"{_currentRoom.Creatures[0].Name}", false, ConsoleColor.Red);
                    view.Output(".");
                }
                else{
                    view.Output("You see ", false);
                    for (int i = 0; i < _currentRoom.Creatures.Count; i++){
                        if (i == _currentRoom.Creatures.Count - 1){
                            view.Output("and a ", false);
                            view.Output($"{_currentRoom.Creatures[i].Name}", false, ConsoleColor.Red);
                            view.Output(".");
                        }
                        else{
                            view.Output("a ", false);
                            view.Output($"{_currentRoom.Creatures[i].Name}", false, ConsoleColor.Red);
                            view.Output(", ");
                        }
                    }
                }
            }
            else{
                view.Output("There is no one here.");
            }
            //display all the items on the floor
            if (_currentRoom.Contents.Count > 0){
                if (_currentRoom.Contents.Count == 1){
                    view.Output($"You see a {_currentRoom.Contents[0].Name} lying on the floor.");
                }
                else{
                    view.Output("On the floor, you see ", false);
                    for (int i = 0; i < _currentRoom.Contents.Count; i++){
                        if (i == _currentRoom.Contents.Count - 1){
                            view.Output($"and a{_currentRoom.Contents[i].Name}.");
                        }
                        else{
                            view.Output($"a {_currentRoom.Contents[i].Name}, ", false);
                        }
                    }
                }
            }
            else{
                view.Output("There is nothing here.");
            }
        }
    }
}