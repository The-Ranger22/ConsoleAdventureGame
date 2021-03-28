using System;
using System.Reflection;

namespace ConsoleAdventureGame.view{
    public class View{
        
        public void output(String message){
            Console.WriteLine(message);
        }

        public int input(){
            String input = Console.ReadLine();
            bool isInt = false;
            while (!isInt){
                try{
                    Int32.Parse(input);
                    isInt = true;
                } catch {
                    output("Please enter an integer per the previous prompt!");
                    input = Console.ReadLine();
                }
            }
            return Int32.Parse(input);
        }
    }
}