using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;
//Test
/*
 * Class Description: Class representing properties and behaviors of Monsters. Extends the abstract creature class and gives the moster an agression
 * rating and ability to act and take damage.
 */
namespace ConsoleAdventureGame.model.creatures{
    public class Monster : AbstractCreature{
        
        public CreatureState State{ get; set; } = CreatureState.IDLE;
        public NpcBehavior Behavior{ get; set; }
        protected Room Location{ get; set; }
        
        public string Description{ get; set; }
        
        /// <summary>
        /// Initializes a monster without a state but with health, inventory, location, armor, weapons, and location
        /// </summary>
        /// <param name="health"></param>
        /// <param name="inventory"></param>
        /// <param name="location"></param>
        /// <param name="armor"></param>
        /// <param name="weapon"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Monster (int health, List<AbstractItem> inventory, Room location, AbstractArmor armor, AbstractWeapon weapon, string name, string description): base(health, inventory, armor, weapon){
            Location = location;
            Behavior = NpcBehavior.WARY;
            Description = description;
            Name = name;
        }
        /// <summary>
        /// Initializes Monster to also have a state and health, inventory, armor, weapons and location.
        /// </summary>
        /// <param name="health"></param>
        /// <param name="inventory"></param>
        /// <param name="location"></param>
        /// <param name="armor"></param>
        /// <param name="weapon"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="state"></param>
        public Monster(int health, List<AbstractItem> inventory, Room location, AbstractArmor armor,
            AbstractWeapon weapon, string name, string description, CreatureState state) : base(health, inventory,
            armor, weapon){
            Location = location;
            Behavior = NpcBehavior.WARY;
            State = state;
            Description = description;
            Name = name;
        }
        /// <summary>
        /// This method takes no parameters but increases the agression level of the monster by 1 level
        /// lowest agression to highest: fearful, wary, neutral, angry, & beserk
        /// </summary>
        public void IncreaseAggression(){
            switch (Behavior){
                case NpcBehavior.FEARFUL:{
                    Behavior = NpcBehavior.WARY;
                    break;
                }
                case NpcBehavior.WARY:{
                    Behavior = NpcBehavior.NEUTRAL;
                    break;
                }
                case NpcBehavior.NEUTRAL:{
                    Behavior = NpcBehavior.ANGRY;
                    break;
                }
                case NpcBehavior.ANGRY:{
                    Behavior = NpcBehavior.BESERK;
                    break;
                }
                case NpcBehavior.BESERK:{
                    break;
                }
                default: break;
            }
        }
        /// <summary>
        /// This method allows the Monster to actively hunt out the play by moving to a new room of their choosing
        /// </summary>
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

        /// <summary>
        /// This method decreases the health of the Monster by the damage amount passed
        /// </summary>
        /// <param name="damage"></param>
        protected override void TakeDamage(int damage){
            Health -= damage;
            if (Health <= 0 && State != CreatureState.DEAD){
                State = CreatureState.DEAD;
                Location.Contents.AddRange(Inventory); //upon death, add contents of the inventory to their current location
            }
            //if the monster has been hit but is still alive, it will remain in combat and stay angry
            else if (IsAlive()){
                State = CreatureState.COMBAT;
                Behavior = NpcBehavior.ANGRY;
            }
        }
    }
}