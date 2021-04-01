using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;


/*
* Description: This creates an abstract armor class and allows armor to be an equipable item
*/
namespace ConsoleAdventureGame.model.items.armor
{
    public abstract class AbstractArmor : AbstractItem, InfEquippable{
        /// <summary>
        /// Default is no armor
        /// </summary>
        protected AbstractArmor(){
            
        }
        /// <summary>
        /// An abstract method for very basic armor creation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        public AbstractArmor(string name, string desc) : base(name, desc){
            name = "Test Armor";
            desc = "Armor made from the soft and supple flesh of younglings";
        }

        /// <summary>
        /// add the armor to the Monster or Human that is passed
        /// </summary>
        /// <param name="creature"></param>
        public void Equip(AbstractCreature creature){
            creature.Armor = this;
        }
        /// <summary>
        /// Abstract method for calculating the armor health score
        /// </summary>
        /// <returns></returns>
        public abstract int CalculateArmorScore();
    }
    
}