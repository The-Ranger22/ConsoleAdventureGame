using System.Collections.Generic;
using ConsoleAdventureGame.model.items;
using ConsoleAdventureGame.model.rooms;

namespace ConsoleAdventureGame.model.creatures
{
    public class Player : AbstractCreature
    {
        public Player(int health, List<AbstractItem> inventory, AbstractRoom location) {
            //health = 100
            //location 
        }
        protected override bool move(Directions direction) {
            throw new System.NotImplementedException();
        }

        protected override void fight(AbstractCreature opponent) {
            throw new System.NotImplementedException();
        }
        

        protected override void pickUp(AbstractItem item) {
            throw new System.NotImplementedException();
        }
        
    }
}