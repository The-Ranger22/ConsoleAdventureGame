using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures{
    public class Monster : AbstractCreature{
        
        protected CreatureState State{ get; set; } = CreatureState.IDLE;
        public NpcBehavior Behavior{ get; set; }
        protected Room Location{ get; set; }
        
        public string Description{ get; set; }
        
        public Monster (int health, List<AbstractItem> inventory, Room location, AbstractArmor armor, AbstractWeapon weapon, string description): base(health, inventory, armor, weapon){
            Location = location;
            Behavior = NpcBehavior.WARY;
            Description = description;
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





    }
}