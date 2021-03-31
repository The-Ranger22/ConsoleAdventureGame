using System.Collections.Generic;
using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.items.armor;
using ConsoleAdventureGame.model.items.weapon;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.Factory{
    public class MonsterFactory{
        
        public static Monster CreateGoblin(Room room){
            return new Monster(5, new List<AbstractItem>(), room, new SimpleArmor(), new MeleeWeapon(EnMeleeWeapons.CLUB), "goblin", "a small, ugly humanoid with green skin.");
        }
    }
}