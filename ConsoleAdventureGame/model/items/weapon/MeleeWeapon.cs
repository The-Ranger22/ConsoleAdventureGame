using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.weapon{
    public class MeleeWeapon : AbstractWeapon{
        
        public MeleeWeapon(){
            _damageType = weapon.DamageType.SLASHING;
            _damageRoll = new DamageRoll(1, 6);
            bonusDmg = 0;
            Name = "Simple sword";
            Desc = "A sword of unremarkable make and design, forged from bronze.";
        }

        public MeleeWeapon(DamageType damageType, DamageRoll damageRoll, string name, string desc, int modifier, int attacksPerTurn){
            _damageType = damageType;
            _damageRoll = damageRoll;
            this.Name = name;
            this.Desc = desc;
            bonusDmg = modifier;
            AttacksPerTurn = attacksPerTurn;
        }
        public MeleeWeapon(EnMeleeWeapons weaponType){
            switch (weaponType){
                case EnMeleeWeapons.AXE:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(1, 8);
                    Name = "Axe";
                    Desc =
                        "A short-handled axe wrought from dirty iron with a cutting smile the breadth of a man's spread hand. Suitable for splitting skulls.";
                    break;
                }
                case EnMeleeWeapons.SWORD:{
                    AttacksPerTurn = 2;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(1, 6);
                    Name = "Sword";
                    Desc =
                        "A sword forged of iron, twice the length of a man's forearm. Ideal for cutting threads.";
                    break;
                }
                case EnMeleeWeapons.DAGGER:{
                    AttacksPerTurn = 3;
                    _damageType = weapon.DamageType.PIERCING;
                    _damageRoll = new DamageRoll(1, 4);
                    Name = "Dagger";
                    Desc =
                        "A dagger exuding trouble.";
                    break;
                }
                case EnMeleeWeapons.SPEAR:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.PIERCING;
                    _damageRoll = new DamageRoll(1, 6);
                    Name = "Spear";
                    Desc =
                        "A short spear two-thirds the length of a man, capped with a jagged, bronze spearhead.";
                    break;
                }
                case EnMeleeWeapons.MACE:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.BLUNT;
                    _damageRoll = new DamageRoll(1, 6);
                    Name = "Mace";
                    Desc =
                        "An ugly, forged lump of iron decorated with brutal spikes of iron affixed atop a simple shaft of oak.";
                    break;
                }
                case EnMeleeWeapons.GREATSWORD:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(2, 6);
                    Name = "Greatsword";
                    Desc =
                        "A finely wrought greatsword, forged from iron and tempered by blood split on untold battlefields.";
                    break;
                }
                case EnMeleeWeapons.CLUB:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.BLUNT;
                    _damageRoll = new DamageRoll(1, 4);
                    Name = "Club";
                    Desc = "A crude club fashioned from wood.";
                    break;
                }
            }
            bonusDmg = 0;
        }

        public override int CalculateDamage(){
            return _damageRoll.roll(bonusDmg);
        }


        public override void Use(AbstractCreature creature){
            Wield(creature);
        }
    }
}