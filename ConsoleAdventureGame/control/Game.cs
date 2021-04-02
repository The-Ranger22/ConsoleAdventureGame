using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using ConsoleAdventureGame.factory;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;
using ConsoleAdventureGame.view;

namespace ConsoleAdventureGame.control{
    /// <summary>
    /// Responsible for driving the game.
    /// </summary>
    public class Game{
        private static Player _player = new Player(20, new List<AbstractItem>(), ArmorFactory.CreateLeather(),
            WeaponFactory.CreateSword());

        private static Dungeon _dungeon = new Dungeon();
        private static Room _currentRoom = _dungeon.Rooms[0]; //player's initial spawn point
        private static int _previousRoomId = _currentRoom.Id;
        private static View view = new View();
        private static bool gameIsRunning = true;
        private static bool inCombat = false;
        private static GameState _gameState = GameState.RUNNING;
        private static SoundPlayer _soundPlayer; 

        public void run(){
            playBackgroundMusic();
            //display opening message/title
            view.FormattedOutput("&dmaAdventureGame &grnv0.2");
            view.displayTitle();
            view.FormattedOutput("&redOver-engineered is the &grnname of the &dylgame!");

            //main gameplay loop
            while (gameIsRunning){
                //display the information about the room
                //    - display room description
                //    - display creature(s) descriptions
                //    - display descriptions of the contents of the room
                describeRoom();
                //check if combat is going to occur w/ any creature inside the room
                if (!combat()){
                    //prompt user w/ menu options
                    menu();
                    //after the user has taken their action, go through all the rooms and have all monsters act upon their behavior
                    monstersTurn();
                }


                if (_gameState != GameState.RUNNING){
                    gameIsRunning = false;
                }
            }

            switch (_gameState){
                case GameState.DEFEAT:{
                    view.FormattedOutput("&magDefeat! The &redgoblin &redhordes have bested you!");
                    break;
                }
                case GameState.VICTORY:{
                    break;
                }
            }
        }

        private void playBackgroundMusic(){
            try{
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                _soundPlayer = new SoundPlayer(@"nahhan.wav");
                _soundPlayer.PlayLooping();
            }
            catch (FileNotFoundException e){
                Console.WriteLine(e);
            }
            
        }

        private void menu(){
            bool actionTaken = false;

            while (!actionTaken){
                view.FormattedOutput("What would you like to do?");
                view.FormattedOutput("[1] : Inspect room");
                view.FormattedOutput("[2] : Move");
                view.FormattedOutput("[3] : Inventory");
                view.FormattedOutput("[4] : Take a hostile action");
                view.FormattedOutput("[0] : Quit");
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
                    case 4:{
                        actionTaken = fightMenu();
                        break;
                    }
                    case 0:{
                        //quit the game
                        _gameState = GameState.DEFEAT;
                        return;
                    }
                }
            }
        }

        private bool inspectMenu(){
            if (_currentRoom.Contents.Count < 1){
                view.FormattedOutput("There is nothing to pick up.");
            }
            else{
                bool isInspecting = true;
                while (isInspecting){
                    int count = 0, input;
                    view.FormattedOutput("What would you like to pick up?");
                    foreach (AbstractItem item in _currentRoom.Contents){
                        view.FormattedOutput($"[{++count}] : {item.Name}");
                    }

                    view.FormattedOutput(
                        "Specify the number of the item you would like to pick up or enter 0 to return: ");
                    input = view.Input() - 1; //adjust user input to compensate for index offset
                    if (input == -1){
                        return false;
                    }

                    if (input >= 0 && input < _currentRoom.Contents.Count){
                        if (_player.PickUp(_currentRoom.Contents[input])){
                            view.FormattedOutput($"You picked up &blu{_currentRoom.Contents[input].Name}");
                            _currentRoom.Contents.RemoveAt(input);
                            return true;
                        }

                        view.FormattedOutput(
                            "You've &dylcarrying to much! You'll need to part ways with something you hoarder.");
                        isInspecting = false;
                    }
                    else{
                        view.FormattedOutput("What item are you talking about?");
                    }
                }
            }


            return false;
        }

        private bool moveMenu(){
            while (true){
                view.FormattedOutput("Where would you like to go?");
                for (int i = 0; i < _currentRoom.Adjacencies.Length; i++){
                    view.FormattedOutput(String.Format("[{0}] : Room {1}", i + 1, _currentRoom.Adjacencies[i]));
                }

                view.FormattedOutput("Specify the number of the room you would like to go to. Enter 0 to return.");
                int input = view.Input() - 1;
                if (input == -1){
                    return false;
                }

                if (input > -1 && input < _currentRoom.Adjacencies.Length){
                    view.FormattedOutput($"You head to room &dyl{_currentRoom.Adjacencies[input]}");
                    _previousRoomId = _currentRoom.Id;
                    _currentRoom = _dungeon.Rooms[_currentRoom.Adjacencies[input]];
                    return true;
                }
                else{
                    view.FormattedOutput("Well, you're not getting there from here.");
                }

                Console.Clear();
            }
        }

        private bool inventoryMenu(){
            while (true){
                view.FormattedOutput("Manage your inventory.");
                string format = "[{0}] : {1}";
                for (int i = 0; i < _player.Inventory.Count; i++){
                    view.FormattedOutput(String.Format(format, i + 1, _player.Inventory[i].Name));
                }

                view.FormattedOutput("[0] : Return");
                view.FormattedOutput("Specify the number of the item you would like to select.");
                int input = view.Input() - 1;
                if (input == -1){
                    return false;
                }

                if (input > -1 && input < _player.Inventory.Count){
                    AbstractItem item = _player.Inventory[input];
                    if (item is InfWieldable){
                        while (true){
                            view.FormattedOutput($"What would you like to do with &blu{item.Name}?");
                            //output the name of the weapon and its description
                            view.FormattedOutput($"&blu{item.Name}. {item.Desc}");
                            //list available actions that the user can perform on the weapon
                            view.FormattedOutput(string.Format(format, 1, "Wield"));
                            view.FormattedOutput(string.Format(format, 2, "Drop"));
                            view.FormattedOutput(string.Format(format, 0, "Return"));
                            switch (view.Input()){
                                case 0:{
                                    //return to outer menu
                                    return false;
                                }
                                case 1:{
                                    //wield the weapon
                                    ((InfWieldable) item).Wield(_player); //set the player's weapon to the new one
                                    view.FormattedOutput($"You are now wielding &blu{item.Name}.");
                                    return true;
                                }
                                case 2:{
                                    //drop the weapon
                                    _currentRoom.Contents.Add(_player.DropItem(_player.Inventory.IndexOf(item)));
                                    //if the item dropped is the weapon the player is currently holding, set the player's current weapon to null
                                    if (_player.Weapon == item){
                                        _player.Weapon = null;
                                    }

                                    view.FormattedOutput($"You drop &blu{item.Name}.");
                                    return true;
                                }
                                default:{
                                    view.FormattedOutput($"You want to do what with &blu{item.Name}?");
                                    break;
                                }
                            }
                        }
                    }
                    else if (item is InfEquippable){
                        while (true){
                            view.FormattedOutput($"What would you like to do with &blu{item.Name}?");
                            // Output item name and description
                            view.FormattedOutput($"&blu{item.Name}. {item.Desc}");

                            view.FormattedOutput(string.Format(format, 1, "Equip"));
                            view.FormattedOutput(string.Format(format, 2, "Drop"));
                            view.FormattedOutput(string.Format(format, 0, "Return"));

                            switch (view.Input()){
                                case 0:{
                                    //return to outer menu
                                    return false;
                                }
                                case 1:{
                                    ((InfEquippable) item).Equip(_player); // Equip the armor to the player
                                    view.FormattedOutput($"You are now wearing &blu{item.Name}.");
                                    return true;
                                }
                                case 2:{
                                    _currentRoom.Contents.Add(_player.DropItem(_player.Inventory.IndexOf(item)));
                                    //if the item dropped is the weapon the player is currently holding, set the player's current weapon to null
                                    if (_player.Weapon == item){
                                        _player.Weapon = null;
                                    }

                                    view.FormattedOutput($"You drop &blu{item.Name}.");
                                    return true;
                                }
                                default:{
                                    view.FormattedOutput($"You want to do what with &blu{item.Name}?");
                                    break;
                                }
                            }
                        }
                    }
                    else if (item is InfConsumable){
                        while (true){
                            view.FormattedOutput($"What would you like to do with &blu{item.Name}?");
                            // Output item name and description
                            view.FormattedOutput($"&blu{item.Name}. {item.Desc}");

                            view.FormattedOutput(string.Format(format, 1, "Use"));
                            view.FormattedOutput(string.Format(format, 2, "Drop"));
                            view.FormattedOutput(string.Format(format, 0, "Return"));

                            switch (view.Input()){
                                case 0:{
                                    //return to outer menu
                                    return false;
                                }
                                case 1:{
                                    item.Use(_player); // Player use's the item
                                    view.FormattedOutput($"You use &blu{item.Name}.");
                                    return true;
                                }
                                case 2:{
                                    _currentRoom.Contents.Add(_player.DropItem(_player.Inventory.IndexOf(item)));
                                    //if the item dropped is the weapon the player is currently holding, set the player's current weapon to null
                                    if (_player.Weapon == item){
                                        _player.Weapon = null;
                                    }

                                    view.FormattedOutput($"You drop {item.Name}.");
                                    return true;
                                }
                                default:{
                                    view.FormattedOutput(String.Format("You want to do what with {0}?", item.Name));
                                    break;
                                }
                            }
                        }
                    }
                    else{
                        view.FormattedOutput("You have... &drdw &dgnh &dbla &dylt?");
                    }
                }
                else{
                    view.FormattedOutput("You're rather imaginative, aren't you?");
                }
            }
        }

        private bool combatMenu(){
            if (_currentRoom.Creatures.Count > 0 && _currentRoom.ContainsAliveCreatures()){
                bool actionTaken = false;
                while (!actionTaken){
                    view.FormattedOutput("What would you like to do?");
                    view.FormattedOutput("[1] : Fight");
                    view.FormattedOutput("[2] : Inventory");
                    view.FormattedOutput("[3] : &dylEscape");

                    switch (view.Input()){
                        case 1:{
                            //choose an enemy to fight
                            actionTaken = fightMenu();
                            break;
                        }
                        case 2:{
                            //manage inventory
                            actionTaken = inventoryMenu();
                            break;
                        }
                        case 3:{
                            //Escape !!! -> only available if there are monsters in the combat state in the room
                            if (inCombat){
                                Random random = new Random();

                                if (random.Next() % 2 == 0){
                                    //50% chance to escape
                                    inCombat = false;
                                    moveMenu();
                                }
                            }

                            break;
                        }
                    }
                }
            }
            else{
                view.FormattedOutput("There is no one to fight!");
                return false;
            }

            return false;
        }

        private bool fightMenu(){
            while (true){
                view.FormattedOutput("Who would you like to attack?");
                for (int i = 0; i < _currentRoom.Creatures.Count; i++){
                    if (_currentRoom.Creatures[i] is Monster monster){
                        switch (monster.State){
                            case CreatureState.IDLE:
                            case CreatureState.HUNTING:{
                                view.FormattedOutput(
                                    $"[{i + 1}] : A &mag{monster.Behavior.ToString().ToLower()} &red{monster.Name}. They are standing &grnidle.");
                                break;
                            }
                            case CreatureState.COMBAT:{
                                view.FormattedOutput(
                                    $"[{i + 1}] : A &mag{monster.Behavior.ToString().ToLower()} &red{monster.Name}. They are &ylwengaging you in &redcombat!");
                                break;
                            }
                            default: break;
                        }
                    }
                    else{
                        view.FormattedOutput($"[{i + 1}] : A &drd{_currentRoom.Creatures[i]}.");
                    }
                }

                view.FormattedOutput("[0] : Return");

                int adjustedInput = view.Input() - 1;
                if (adjustedInput == -1){
                    return false;
                }

                //if user input is within the bounds of the room's creatures list, fight a creature
                if (adjustedInput >= 0 && adjustedInput < _currentRoom.Creatures.Count){
                    if (_currentRoom.Creatures[adjustedInput] is Monster monster){
                        view.FormattedOutput(
                            $"You swing your &blu{_player.Weapon.Name} &ylw{_player.Weapon.AttacksPerTurn} time(s). &ylw{_player.Fight(monster)} of your blows connect with the &red{monster.Name}!");
                        if (monster.IsAlive()){
                            monster.Behavior = NpcBehavior.ANGRY;
                            monster.State = CreatureState.COMBAT;
                        }

                        return true;
                    }
                }
                else{
                    view.FormattedOutput("Ah, the most dangerous of &redfoes. Nothing.");
                }
            }
        }

        private void describeRoom(){
            if (_currentRoom.Id == _previousRoomId){
                view.FormattedOutput($"You are in room &dyl{_currentRoom.Id}.");
            }
            else{
                view.FormattedOutput("You enter the room.");
                _previousRoomId = _currentRoom.Id;
            }

            view.FormattedOutput(_currentRoom.Description);
            //display all the items on the floor
            if (_currentRoom.Contents.Count > 0){
                if (_currentRoom.Contents.Count == 1){
                    view.FormattedOutput($"You see a {_currentRoom.Contents[0].Name} lying on the floor.");
                }
                else{
                    StringBuilder outputString = new StringBuilder();
                    outputString.Append("On the floor, you see ");

                    for (int i = 0; i < _currentRoom.Contents.Count; i++){
                        if (i == _currentRoom.Contents.Count - 1){
                            outputString.Append($"and a &blu{_currentRoom.Contents[i].Name}.");
                        }
                        else{
                            outputString.Append($"a &blu{_currentRoom.Contents[i].Name}, ");
                        }
                    }

                    view.FormattedOutput(outputString.ToString());
                }
            }
            else{
                view.FormattedOutput("There is nothing here.");
            }

            //display all the creatures inside the room if there are any
            if (_currentRoom.Creatures.Count > 0){
                if (_currentRoom.Creatures.Count == 1){
                    if (_currentRoom.Creatures[0] is Monster monster){
                        view.FormattedOutput(
                            $"You see a &red{monster.Name}. They are {((monster.IsAlive()) ? $"&mag{monster.Behavior.ToString().ToLower()}" : $"&dgy{monster.State.ToString().ToLower()}")}.");
                    }
                    else{
                        view.FormattedOutput($"You see a &ylw{_currentRoom.Creatures[0].Name}");
                    }
                }
                else{
                    StringBuilder outputString = new StringBuilder();
                    outputString.Append("You see a ");

                    foreach (AbstractCreature creature in _currentRoom.Creatures){
                        if (creature is Monster monster){
                            outputString.Append(
                                $"{(monster.IsAlive() ? $"&mag{monster.Behavior.ToString().ToLower()}" : $"&dgy{monster.State.ToString().ToLower()}")} &red{monster.Name}");
                            if (creature == _currentRoom.Creatures[_currentRoom.Creatures.Count - 2]){
                                //if the current creature is the second to last creature, append 'and a '
                                outputString.Append(" and a ");
                            }
                            else if (creature != _currentRoom.Creatures[_currentRoom.Creatures.Count - 1]){
                                //if the current creature is not the last creature, append a comma
                                outputString.Append(", ");
                            }
                        }
                    }

                    view.FormattedOutput(outputString.ToString());
                }
            }
            else{
                view.FormattedOutput("There is no one here.");
            }
        }

        private void monstersTurn(){
            Queue<Monster> turnOrder = new Queue<Monster>();
            foreach (Room room in _dungeon.Rooms){
                foreach (AbstractCreature creature in room.Creatures){
                    if (creature is Monster monster){
                        turnOrder.Enqueue(monster);
                    }
                }
            }

            while (turnOrder.Count > 0){
                turnOrder.Dequeue().Act();
            }
        }

        private bool combat(){
            bool combatHasOccured = false;
            //Combat is now commencing
            inCombat = true; //TODO: make local variable
            //check if room is populated
            if (_currentRoom.Creatures.Count > 0 && _currentRoom.ContainsAliveCombatants()){
                combatHasOccured = true;
                Queue<Monster> turnOrder = new Queue<Monster>();
                //Enqueue all monsters down to tussle
                foreach (AbstractCreature abstractCreature in _currentRoom.Creatures){
                    if (abstractCreature is Monster monster && monster.Behavior > NpcBehavior.NEUTRAL &&
                        monster.State != CreatureState.DEAD){
                        //set the state of the creature to combat
                        monster.State = CreatureState.COMBAT;
                        turnOrder.Enqueue(monster);
                    }
                }

                while (turnOrder.Count > 0 && _player.IsAlive()){
                    //prompt player to pick an action
                    //TODO: Prompt player to pick a combat action
                    inCombat =
                        combatMenu(); //depending on the action taken by the player inside the combat menu, they may remain in combat or escape it (true if they remain, false if they escape)

                    view.FormattedOutput($"Player: &grn{_player.Health}");

                    if (!turnOrder.Peek().IsAlive()){
                        view.FormattedOutput($"The &red{turnOrder.Peek().Name} is dead.");
                        turnOrder.Dequeue(); //remove the dead from the turn order because they are dead
                    }

                    Queue<Monster> tempQueue = new Queue<Monster>();
                    while (turnOrder.Count > 0){
                        Monster monster = turnOrder.Dequeue();
                        view.FormattedOutput(
                            $"The vicious &red{monster.Name} swings his &red{monster.Weapon.Name} &ylw{monster.Weapon.AttacksPerTurn} time(s). &ylw{monster.Fight(_player)} of his blows connect with you!");
                        tempQueue.Enqueue(monster);
                    }

                    //TODO: DISPLAY ENEMY COMBAT
                    turnOrder = tempQueue;
                    //TODO: Check for monsters that were not initially aggressive and add them to the queue
                    foreach (AbstractCreature creature in _currentRoom.Creatures){
                        if (!turnOrder.Contains(creature) && creature.IsAlive()){
                            if (creature is Monster monster && monster.State == CreatureState.COMBAT){
                                turnOrder.Enqueue(monster);
                            }
                        }
                    }
                }
            }

            inCombat = false; //combat has ended
            return combatHasOccured;
        }
    }
}