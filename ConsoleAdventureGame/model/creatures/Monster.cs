using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures{
    public class Monster : AbstractCreature{
        
        public CreatureState State{ get; set; } = CreatureState.IDLE;
        public NpcBehavior Behavior{ get; set; }
        protected Room Location{ get; set; }
        
        public string Description{ get; set; }
        
        public Monster (int health, List<AbstractItem> inventory, Room location, AbstractArmor armor, AbstractWeapon weapon, string name, string description): base(health, inventory, armor, weapon){
            Location = location;
            Behavior = NpcBehavior.WARY;
            Description = description;
            Name = name;
        }

        public Monster(int health, List<AbstractItem> inventory, Room location, AbstractArmor armor,
            AbstractWeapon weapon, string name, string description, CreatureState state) : base(health, inventory,
            armor, weapon){
            Location = location;
            Behavior = NpcBehavior.WARY;
            State = state;
            Description = description;
            Name = name;
        }

        public void IncreaseAggression(){
            switch (Behavior){
                case NpcBehavior.FEARFUL:{
                    Behavior = NpcBehavior.WARY;
                    break;
                }
                case NpcBehavior.WARY:{
                    Behavior = NpcBehavior.WARY;
                    break;
                }
                case NpcBehavior.NEUTRAL:{
                    Behavior = NpcBehavior.WARY;
                    break;
                }
                case NpcBehavior.ANGRY:{
                    Behavior = NpcBehavior.WARY;
                    break;
                }
                case NpcBehavior.BESERK:{
                    break;
                }
                default: break;
            }
        }

        public void Act(){
            switch (State){
                case CreatureState.HUNTING:{
                    Random gen = new Random();
                    if ((gen.Next(100) + 1) > 25 ){
                        Location.Creatures.Remove(this); //Creature leaves their current location

                        Location = Location.ContainingDungeon.Rooms[
                            Location.Adjacencies[gen.Next(Location.Adjacencies.Length)]]; //creatures picks where to travel
                        
                        Location.Creatures.Add(this); //creature enters the new location
                    }
                    break;
                }
            }
        }





    }
}