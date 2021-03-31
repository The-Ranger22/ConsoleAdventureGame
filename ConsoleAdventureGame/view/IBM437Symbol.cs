namespace ConsoleAdventureGame.view{
    public class IBM437Symbol{
        
        
        
        public static char getChar(BLOCK block){
            return (char) block;
        }

        public static char getChar(BOX box){
            return (char) box;
        }

        public enum BOX{
            LT_HOR = 0x2500,
            LT_HOR_UP = 0x2534,
            LT_HOR_DOWN = 0x252C,
            LT_VER = 0x2502,
            LT_VER_LEFT = 0x2524,
            LT_VER_RIGHT = 0x251C,
            LT_CROSS = 0x253C,
            LT_COR_NE = 0x2510,
            LT_COR_NW = 0x250C,
            LT_COR_SE = 0x2518,
            LT_COR_SW = 0x2514,
            HVY_HOR = 0x2550,
            HVY_HOR_UP = 0x2569,
            HVY_HOR_DOWN = 0x2566,
            HVY_VER = 0x2551,
            HVY_VER_LEFT = 0x2563,
            HVY_VER_RIGHT = 0x2560,
            HVY_CROSS = 0x256C,
            HVY_COR_NE = 0x2557,
            HVY_COR_NW = 0x2554,
            HVY_COR_SE = 0x255D,
            HVY_COR_SW = 0x255A
        }
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
        
        public enum MATH{
            UNION = 0x2229
        }
        
    }
}