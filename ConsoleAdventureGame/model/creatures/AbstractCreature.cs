using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

/*
 * Class Description: Abstract class representing common properties and behaviors of Creatures. Main functionality exists in the fight() method, where
 * recursive calls continue until either the player or the NPC creature are dead. While some properties are used by the player exclusively, they were included to facilitate later enhancements to game.
 */

namespace ConsoleAdventureGame.model.creatures{
    public abstract class AbstractCreature{

        private static int creaturesCreated = 0;
        public readonly string Id;
        public int Health{ get; set; }

        public readonly int MaxHealth;  //Player's health cannot exceed the starting value after taking a health potion.
        public string Name{ get; set; }
        public AbstractWeapon Weapon{ get; set; }
        public List<AbstractItem> Inventory{ get; set; }

        public AbstractArmor Armor{ get; set; }

        public bool StrengthBoost{ get; set; } // Set to true when the player consumes a strength potion
        public bool AgilityBoost{ get; set; }  // Set to true when the player consumes an agility potion

        public AbstractCreature(int health, List<AbstractItem> inventory, AbstractArmor armor, AbstractWeapon weapon){
            Id = String.Format("CR{0}", creaturesCreated++);
            Health = health;
            MaxHealth = health;
            Inventory = inventory;
            Weapon = weapon;
            Armor = armor;

            Inventory.Add(Weapon);
            Inventory.Add(Armor);
        }
        
        /// <summary>
        /// Determine if the creature is still alive
        /// </summary>
        /// <returns>True if the creatures health is greater than zero</returns>
        public bool IsAlive(){
            return Health > 0;
        }

        /// <summary>
        /// First attacks per turn and defense score are calculated based on the weapon's number of strikes + strength bonus and the Armor's Score + agility bonus respectively.
        /// As an NPC creature at this point cannot consume potions, those values will always default to the Armor and Weapons natural values during calculation.
        /// At the end of the fight, Strength Boost and Agility boost are reset
        /// to false, as a potion will only last one fight.
        /// </summary>
        /// <param name="opponent">The creature that will take damage in this iteration of the fight</param>
        /// <returns>an int representing the number of successful hits</returns>
        
        public int Fight(AbstractCreature opponent){
            int hits = 0;
            Random gen = new Random();
            // Should not effect non-player characters as their StrengthBoost and AgilityBoost should always be false.  
            int actualAttacksPerTurn = StrengthBoost ? Weapon.AttacksPerTurn + 1 : Weapon.AttacksPerTurn;
            int defenseScore = AgilityBoost
                ? opponent.Armor.CalculateArmorScore() + 3
                : opponent.Armor.CalculateArmorScore();
            for (int i = 0; i < actualAttacksPerTurn; i++){
                if ((gen.Next(20) + 1) > defenseScore){
                    hits++;
                    //roll to hit
                    opponent.TakeDamage((Weapon != null)
                        ? Weapon.CalculateDamage()
                        : new DamageRoll(1, 4).roll()); // if hit successful, roll damage. 
                }
            }
            // At the end of fight's recursive calls, reset players values to false, as potions only should last one fight. 
            StrengthBoost = false;
            AgilityBoost = false;
            return hits;
        }

        /**
         * Removes the damage taken from the current creatures health. 
         */
        protected abstract void TakeDamage(int damage);
    }
}