using System;
using System.IO;
using System.Linq;

using System.Reflection;

namespace ConsoleAdventureGame.view{
    public class View{
        public void Output(string message, bool newline = true, ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black){
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            
            if (newline){
                Console.WriteLine(message);
            }
            else{
                Console.Write(message);
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
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

        public void displayTitle(){
            /*
             * How the pattern works:
             * -1 : blank space
             * 0 : block
             */
            
            
            char block = IBM437Symbol.getChar(IBM437Symbol.BLOCK.FULL);
            int[,] displayPattern = new int[6, 45];
            int[] row0pattern = {2, 3, 4};
            int[] row1pattern = {1, 2, 3, 4, 5, 9, 11, 13, 16, 17, 20, 23, 25, 26, 27, 29, 31, 33, 34, 35, 36, 39, 40};
            int[] row2pattern = {1, 5, 9, 11, 13, 15, 18, 20, 21, 23, 26, 29, 31, 33, 36, 38, 41};
            int[] row3pattern = {1, 2, 3, 4, 5, 8, 9, 11, 13, 15, 16, 17, 20, 22, 23, 26, 29, 31, 33, 34, 35, 38, 39, 40};
            int[] row4pattern = {1, 5, 7, 9, 11, 13, 15, 20, 23, 26, 29, 31, 33, 35, 38};
            int[] row5pattern = {1, 5, 8, 9, 12, 16, 17, 20, 23, 26, 29, 30, 31, 33, 36, 39, 40};
            for (int i = 0; i < displayPattern.GetLength(0); i++){
                for (int j = 0; j < displayPattern.GetLength(1); j++){
                    switch (i){
                        case 0 :{
                            
                            if (row0pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                        case 1 :{
                            if (row1pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                        case 2 :{
                            if (row2pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                        case 3 :{
                            if (row3pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                        case 4 :{
                            if (row4pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                        case 5 :{
                            if (row5pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }
                            break;
                        }
                    }
                }
            }

            
            
            
            for (int i = 0; i < displayPattern.GetLength(0); i++){
                for (int j = 0; j < displayPattern.GetLength(1); j++){
                    switch (displayPattern[i, j]){
                        case -1:{
                            Output(" ", false);
                            break;
                        }
                        case 0:{
                            Output(block.ToString(), false);
                            break;
                        }
                    }
                }
                Console.WriteLine();
            }
            
            

        }
    }
}