using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

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
                        opponent.TakeDamage((Weapon != null) ? Weapon.CalculateDamage() : new DamageRoll(1, 4).roll()); //roll damage. 
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

        private void TakeDamage(int damage){
            Health -= damage;
        }
    }
}