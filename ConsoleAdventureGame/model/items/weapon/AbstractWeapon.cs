using System;
using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.weapon
{
    /**
     * 
     */
    public abstract class AbstractWeapon : AbstractItem, InfWieldable{
        protected DamageType _damageType { get; set; }
        protected DamageRoll _damageRoll { get; set; }
        protected int bonusDmg { get; set; }
        public int AttacksPerTurn{ get; set; }

        protected AbstractWeapon() : base("Weapon", "A weapon"){
            _damageRoll = new DamageRoll();
            _damageType = weapon.DamageType.SLASHING;
        }

        protected AbstractWeapon(DamageRoll damageRoll, DamageType damageType) : base("Weapon", "A weapon"){
            _damageRoll = damageRoll;
            _damageType = damageType;
        }

        protected AbstractWeapon(String name, String description, DamageRoll damageRoll, DamageType damageType) : base(name, description){
            _damageRoll = damageRoll;
            _damageType = damageType;
        }

        public DamageType DamageType(){
            return _damageType;
        }

        public DamageRoll DamageRoll(){
            return _damageRoll;
        }

        public void Wield(AbstractCreature creature){
            creature.Weapon = this;
        }

        

        public abstract int CalculateDamage();

        public int CalculateDamage(int bonus){
            return CalculateDamage() + bonus;
        }
    }
}