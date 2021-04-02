using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;


 /*
  * Class Description: Handles the input and output from and to the command line. Also contains the initial ADVENTURE display as well as the color constants for the command line.
  */

namespace ConsoleAdventureGame.view{
    public class View{
        /*
         * The following constants are string codes used to color the output of strings prefixed with one of the codes listed below 
         */
        private const string CC_BLUE = "&blu";
        private const string CC_RED = "&red";
        private const string CC_CYAN = "&cyn";
        private const string CC_GRAY = "&gry";
        private const string CC_GREEN = "&grn";
        private const string CC_MAGENTA = "&mag";
        private const string CC_YELLOW = "&ylw";
        private const string CC_DARK_BLUE = "&dbl";
        private const string CC_DARK_RED = "&drd";
        private const string CC_DARK_CYAN = "&dcy";
        private const string CC_DARK_GRAY = "&dgy";
        private const string CC_DARK_GREEN = "&dgn";
        private const string CC_DARK_MAGENTA = "&dma";
        private const string CC_DARK_YELLOW = "&dyl";

        /// <summary>
        /// A generic output method for outputting text to the console. Provides the ability to add colors and a newline if desired. 
        /// </summary>
        /// <param name="message"> the string message to be output</param>
        /// <param name="newline"> true if a newline is desired after the message</param>
        /// <param name="foreground"> color value for the text</param>
        /// <param name="background"> color value for the background of the message</param>
        public void Output(string message, bool newline = true, ConsoleColor foreground = ConsoleColor.White,
            ConsoleColor background = ConsoleColor.Black){
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
        
        /// <summary>
        /// Method for receiving integer input from the user. No strings from the user are required for the game at this time
        /// </summary>
        /// <returns>The user given integer</returns>
        public int Input(){
            String input = Console.ReadLine();
            bool isInt = false;
            while (!isInt){
                try{
                    Int32.Parse(input);
                    isInt = true;
                }
                catch{
                    Output("Please enter an integer per the previous prompt!", foreground: ConsoleColor.Magenta);
                    input = Console.ReadLine();
                }
            }

            return Int32.Parse(input);
        }

        /// <summary>
        /// Outputs the given message with and accepts custom formatting with the use of color
        /// </summary>
        /// <param name="message">The string to be output</param>
        /// <param name="newline">True if a newline after the message is desired</param>
        public void FormattedOutput(string message, bool newline = true){
            if (message != null){
                string[] messages = message.Split(' ');
                foreach (string msg in messages){
                    if ((!msg.Equals("")) && msg[0] == '&'){ //if the current message isn't null and the first character is an '&', output the message w/ color
                        Output(msg.Substring(4), false, determineColor(msg));
                    }
                    else{ //else display normally
                        Output(msg, false);
                    }
                    //if last message in messages, end with newline. Otherwise, output a space
                    if(!msg.Equals(messages[messages.Length - 1])){
                        Output(" ", false);
                    }
                    else if(newline){
                        Output("");
                    }

                    
                }
            }
        }
        //Displays ADVENTURE in IBM437 block characters. Why yes, I do hate myself. - Levi
        public void displayTitle(){
            /*
             * the int arrays rowXpattern (X = 0->5) are used to detail the output pattern for the "Adventure" title.
             */
            char block = IBM437Symbol.getChar(IBM437Symbol.BLOCK.FULL); //get the full block character
            int[,] displayPattern = new int[6, 45];
            int[] row0pattern = {2, 3, 4}; 
            int[] row1pattern = {1, 2, 3, 4, 5, 9, 11, 13, 16, 17, 20, 23, 25, 26, 27, 29, 31, 33, 34, 35, 36, 39, 40};
            int[] row2pattern = {1, 5, 9, 11, 13, 15, 18, 20, 21, 23, 26, 29, 31, 33, 36, 38, 41};
            int[] row3pattern =
                {1, 2, 3, 4, 5, 8, 9, 11, 13, 15, 16, 17, 20, 22, 23, 26, 29, 31, 33, 34, 35, 38, 39, 40};
            int[] row4pattern = {1, 5, 7, 9, 11, 13, 15, 20, 23, 26, 29, 31, 33, 35, 38};
            int[] row5pattern = {1, 5, 8, 9, 12, 16, 17, 20, 23, 26, 29, 30, 31, 33, 36, 39, 40};
            for (int i = 0; i < displayPattern.GetLength(0); i++){
                for (int j = 0; j < displayPattern.GetLength(1); j++){
                    switch (i){
                        case 0:{
                            if (row0pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }

                            break;
                        }
                        case 1:{
                            if (row1pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }

                            break;
                        }
                        case 2:{
                            if (row2pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }

                            break;
                        }
                        case 3:{
                            if (row3pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }

                            break;
                        }
                        case 4:{
                            if (row4pattern.Contains(j)){
                                displayPattern[i, j] = 0;
                            }
                            else{
                                displayPattern[i, j] = -1;
                            }

                            break;
                        }
                        case 5:{
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
        //given a color code string (I.e. a string beginning with one of the CC_XXX constants), this function returns the appropriate ConsoleColor equivalent
        private ConsoleColor determineColor(string msg){
            /*
             * Colors are denoted by &xxx in a string
             * Color codes:
             * Blue        => &blu => CC_BLUE
             * Red         => &red => CC_RED
             * Cyan        => &cyn => CC_CYAN
             * Gray        => &gry => CC_GRAY
             * Green       => &grn => CC_GREEN
             * Magenta     => &mag => CC_MAGENTA
             * Yellow      => &ylw => CC_YELLOW
             * DarkBlue    => &dbl => CC_DARK_BLUE
             * DarkRed     => &drd => CC_DARK_RED
             * DarkCyan    => &dcy => CC_DARK_CYAN
             * DarkGray    => &dgy => CC_DARK_GRAY
             * DarkGreen   => &dgn => CC_DARK_GREEN
             * DarkMagenta => &dma => CC_DARK_MAGENTA
             * DarkYellow  => &dyl => CC_DARK_YELLOW
             */
            ConsoleColor displayColor;
            switch (msg.Substring(0, 4)){
                case CC_RED:{
                    displayColor = ConsoleColor.Red;
                    break;
                }
                case CC_BLUE:{
                    displayColor = ConsoleColor.Blue;
                    break;
                }
                case CC_CYAN:{
                    displayColor = ConsoleColor.Cyan;
                    break;
                }
                case CC_GRAY:{
                    displayColor = ConsoleColor.Gray;
                    break;
                }
                case CC_GREEN:{
                    displayColor = ConsoleColor.Green;
                    break;
                }
                case CC_MAGENTA:{
                    displayColor = ConsoleColor.Magenta;
                    break;
                }
                case CC_YELLOW:{
                    displayColor = ConsoleColor.Yellow;
                    break;
                }
                case CC_DARK_BLUE:{
                    displayColor = ConsoleColor.DarkBlue;
                    break;
                }
                case CC_DARK_RED:{
                    displayColor = ConsoleColor.DarkRed;
                    break;
                }
                case CC_DARK_CYAN:{
                    displayColor = ConsoleColor.DarkCyan;
                    break;
                }
                case CC_DARK_GRAY:{
                    displayColor = ConsoleColor.DarkGray;
                    break;
                }
                case CC_DARK_GREEN:{
                    displayColor = ConsoleColor.DarkGreen;
                    break;
                }
                case CC_DARK_MAGENTA:{
                    displayColor = ConsoleColor.DarkMagenta;
                    break;
                }
                case CC_DARK_YELLOW:{
                    displayColor = ConsoleColor.DarkYellow;
                    break;
                }
                default:{
                    displayColor = ConsoleColor.White;
                    break;
                }
            }
            return displayColor;
        }

        
    }
}