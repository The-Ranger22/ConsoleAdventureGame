namespace ConsoleAdventureGame.model.items.weapon{
    public class MeleeWeapon : AbstractWeapon{
        
        public MeleeWeapon(){
            _damageType = weapon.DamageType.SLASHING;
            _damageRoll = new DamageRoll(1, 6);
            bonusDmg = 0;
            name = "Simple sword";
            desc = "A sword of unremarkable make and design, forged from bronze.";
        }

        public MeleeWeapon(DamageType damageType, DamageRoll damageRoll, string name, string desc, int modifier){
            _damageType = damageType;
            _damageRoll = damageRoll;
            this.name = name;
            this.desc = desc;
            bonusDmg = modifier;
        }

        public MeleeWeapon(EnMeleeWeapons weaponType){
            switch (weaponType){
                case EnMeleeWeapons.AXE:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(1, 6);
                    name = "Axe";
                    desc =
                        "A short-handled axe wrought from dirty iron with a cutting smile the breadth of a man's spread hand. Suitable for splitting skulls.";
                    break;
                }
                case EnMeleeWeapons.SWORD:{
                    AttacksPerTurn = 2;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(1, 6);
                    name = "Sword";
                    desc =
                        "A sword forged of iron, twice the length of a man's forearm. Ideal for cutting threads.";
                    break;
                }
                case EnMeleeWeapons.DAGGER:{
                    AttacksPerTurn = 3;
                    _damageType = weapon.DamageType.PIERCING;
                    _damageRoll = new DamageRoll(1, 4);
                    name = "Dagger";
                    desc =
                        "A dagger exuding trouble.";
                    break;
                }
                case EnMeleeWeapons.SPEAR:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.PIERCING;
                    _damageRoll = new DamageRoll(1, 6);
                    name = "Spear";
                    desc =
                        "A short spear two-thirds the length of a man, capped with a jagged, bronze spearhead.";
                    break;
                }
                case EnMeleeWeapons.MACE:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.BLUNT;
                    _damageRoll = new DamageRoll(1, 6);
                    name = "Mace";
                    desc =
                        "An ugly, forged lump of iron decorated with brutal spikes of iron affixed atop a simple shaft of oak.";
                    break;
                }
                case EnMeleeWeapons.GREATSWORD:{
                    AttacksPerTurn = 1;
                    _damageType = weapon.DamageType.SLASHING;
                    _damageRoll = new DamageRoll(2, 6);
                    name = "Greatsword";
                    desc =
                        "A finely wrought greatsword, forged from iron and tempered by blood split on untold battlefields.";
                    break;
                }
                default: break;
            }
            bonusDmg = 0;
        }

        public override int CalculateDamage(){
            return _damageRoll.roll(bonusDmg);
        }


        public override void Use(){
            throw new System.NotImplementedException();
        }
    }
}