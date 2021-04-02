using ConsoleAdventureGame.model.items.Consumables;

namespace ConsoleAdventureGame.factory{
    /// <summary>
    /// Factory methods for the various items that can be found throughout the map. 
    /// </summary>
    public class ItemFactory{
        public static HealthPotions CreateHealthPotionsThree() => new HealthPotions(
            "Small Health Potion",  //Armor score
            "A bitter tasting health potion that restores a small bit of health", //Armor name
            3);   //Armor description
        public static HealthPotions CreateHealthPotionsSix() => new HealthPotions(
            "Medium Health Potion",  //Armor score
            "A rather tasty health potion that restores a moderate bit of health", //Armor name
            6
        );
        public static HealthPotions CreateHealthPotionsNine() => new HealthPotions(
            "Large Health Potion",  //Armor score
            "An absolutely delicious health potion that restores your health greatly", //Armor name
            9
        );
        
        public static StrengthPotion StrengthPotion() => new StrengthPotion(
            "Strength Potion",  //Armor score
            "A PCP infused tonic that makes one feel as if they could rip the arms off a goblin"
        );
        
        public static AgilityPotion AgilityPotion() => new AgilityPotion(
            "Agility Potion",
            "Gamer fuel allowing for a brief burst of speed that would put Usain Bolt to shame"
        );
    }
}