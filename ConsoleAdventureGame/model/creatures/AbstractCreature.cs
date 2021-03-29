using System;
using System.Collections.Generic;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures
{
    public abstract class AbstractCreature {
        private int Health{ get; set; }
        protected AbstractWeapon Weapon{ get; set; }
        protected List<AbstractItem> Inventory{ get; set; }
        
        protected AbstractArmor Armor{ get; set;}
        
        public AbstractCreature(int health, List<AbstractItem> inventory, AbstractArmor armor, AbstractWeapon weapon){
            Health = health;
            Inventory = inventory;
            Weapon = weapon;
            Armor = armor;
        }

        protected void Fight(AbstractCreature opponent) {
            Random gen = new Random();
            int damage = Weapon.CalculateDamage();
            while (opponent.Health > 0 && Health > 0) {
                for (int i = 0; i < Weapon.AttacksPerTurn; i++){
                    int attackRoll = gen.Next(20);
                    if (attackRoll > opponent.Armor.ArmorHealth){
                        opponent.TakeDamage(damage);
                    }
                }
                if (opponent.Health > 0){
                    opponent.Fight(this);
                }
            }
        }
        private void TakeDamage(int damage) {
            Health -= damage;
        }


    }

}