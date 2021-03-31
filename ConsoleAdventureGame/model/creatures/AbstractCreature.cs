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
        public int Health{ get; set; }

        public readonly int MaxHealth; 
        public string Name{ get; set; }
        public AbstractWeapon Weapon{ get; set; }
        public List<AbstractItem> Inventory{ get; set; }

        public AbstractArmor Armor{ get; set; }
        
        public bool StrengthBoost{ get; set; }
        public bool AgilityBoost { get; set; }

        public AbstractCreature(int health, List<AbstractItem> inventory, AbstractArmor armor, AbstractWeapon weapon){
            Health = health;
            MaxHealth = health;
            Inventory = inventory;
            Weapon = weapon;
            Armor = armor;

            Inventory.Add(Weapon);
            Inventory.Add(Armor);
        }

        /**
         * Params: An Abstract Creature, either the Player or an NPC. 
         * First attacks per turn and defense score are calculated based on the weapon's number of strikes + strength bonus and the Armor's Score + agility bonus respectively.
         * As an NPC creature at this point cannot consume potions, those values will always default to the Armor and Weapons natural values during calculation.
         * At the end of the fight, Strength Boost and Agility boost are reset
         * to false, as a potion will only last one fight. 
         */
        protected void Fight(AbstractCreature opponent){
            Random gen = new Random();
            // Should not effect non-player characters. Calculate bonus value based on presence of strength or agility boost. 
            int actualAttacksPerTurn = StrengthBoost ? Weapon.AttacksPerTurn + 1 : Weapon.AttacksPerTurn;
            int defenseScore = AgilityBoost
                ? opponent.Armor.CalculateArmorScore() + 3
                : opponent.Armor.CalculateArmorScore();
            if (Health > 0){ //if the player is still alive, attack
                for (int i = 0; i < actualAttacksPerTurn; i++){
                    if ((gen.Next(20) + 1) > defenseScore){ //roll to hit
                        opponent.TakeDamage((Weapon != null) ? Weapon.CalculateDamage() : new DamageRoll(1, 4).roll()); // if hit successful, roll damage. 
                    }
                }
                if (opponent.Health > 0){
                    opponent.Fight(this);
                }
            }
            // At the end of fight's recursive calls, reset players values to false, as potions only should last one fight. 
            StrengthBoost = false;
            AgilityBoost = false;
        }

        /**
         * Removes the damage taken from the current creatures health. 
         */
        private void TakeDamage(int damage){
            Health -= damage;
        }
    }
}