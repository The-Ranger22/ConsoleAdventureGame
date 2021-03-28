
using System;

namespace ConsoleAdventureGame.model.items.weapon{
    public class DamageRoll{
        private Random gen;
        private int diceCount;
        private int numOfSides;
        

        public DamageRoll(){
            gen = new Random();
            diceCount = 1;
            numOfSides = 6;
        }

        public DamageRoll(int diceCount, int numOfSides){
            gen = new Random();
            this.diceCount = diceCount;
            this.numOfSides = numOfSides;
        }

        public int roll(){
            return roll(0);
        }

        public int roll(int bonusDmg){
            return diceCount * (gen.Next(diceCount) + 1) + bonusDmg;
        }
    }
}