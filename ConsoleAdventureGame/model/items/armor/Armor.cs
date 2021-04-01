using ConsoleAdventureGame.model.creatures;
/*
 * Description: This class calculates the armor health and equips the creature with their armor
 */
namespace ConsoleAdventureGame.model.items.armor{
    public class Armor : AbstractArmor{
        private int ArmorScore;
        /// <summary>
        /// Determines the health of the armor 
        /// </summary>
        /// <param name="armorScore"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        public Armor(int armorScore, string name, string desc) : base(name, desc){
            ArmorScore = armorScore;
        }
        /// <summary>
        /// Will equip the creature with the armor
        /// </summary>
        /// <param name="creature"></param>
        public override void Use(AbstractCreature creature){
            Equip(creature);
        }
        /// <summary>
        /// Overrides the abstract method to return the armor score
        /// </summary>
        /// <returns></returns>
        public override int CalculateArmorScore(){
            return ArmorScore;
        }
    }
}