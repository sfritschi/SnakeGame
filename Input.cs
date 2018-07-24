using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class Input
    {
        // Load list of available keys
        private static Hashtable KeyTable = new Hashtable();

        // Perform a check to see if a particular button is pressed
        public static bool KeyPressed(Keys key)
        {
            if (KeyTable[key] == null)
            {
                return false;
            }
            return (bool)KeyTable[key];
        }

        // Detect if a key is pressed
        public static void ChangeState(Keys key, bool state)
        {
            KeyTable[key] = state;
        }
    }
}
