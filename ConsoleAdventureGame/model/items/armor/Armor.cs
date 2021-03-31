using ConsoleAdventureGame.model.creatures;

namespace ConsoleAdventureGame.model.items.armor{
    public class Armor : AbstractArmor{
        private int ArmorScore;
        public Armor(int armorScore, string name, string desc) : base(name, desc){
            ArmorScore = armorScore;
        }
        public override void Use(AbstractCreature creature){
            Equip(creature);
        }

        public override int CalculateArmorScore(){
            return ArmorScore;
        }
    }
}