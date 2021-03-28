using System;
using System.Reflection;

namespace ConsoleAdventureGame.view{
    public class View{
        
        public void Output(String message){
            Console.WriteLine(message);
        }

        public int Input(){
            String input = Console.ReadLine();
            bool isInt = false;
            while (!isInt){
                try{
                    Int32.Parse(input);
                    isInt = true;
                } catch {
                    Output("Please enter an integer per the previous prompt!");
                    input = Console.ReadLine();
                }
            }
            return Int32.Parse(input);
        }
    }
}