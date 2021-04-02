namespace ConsoleAdventureGame.view{
    /// <summary>
    /// Provides a means to get special characters present in the IBM437 code page
    /// </summary>
    public static class IBM437Symbol{
        /// <summary>
        /// Given a BLOCK constant, returns the character equivalent
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public static char getChar(BLOCK block){
            return (char) block;
        }

        /// <summary>
        /// BLOCK contains the hexadecimal values of all the block symbols present in the IBM437 code page.
        /// </summary>
        public enum BLOCK{
            UPPER_HALF = 0x2580,
            LOWER_HALF = 0x2584,
            FULL = 0x2588,
            LEFT_HALF = 0x258C,
            RIGHT_HALF = 0x2590,
            LIGHT_SHADE = 0x2591,
            MED_SHADE = 0x2592,
            DARK_SHADE = 0x2593
        }
    }
}