using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Directions
    {
        UP, LEFT, DOWN, RIGHT
    };
    class Settings
    {
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int Speed { get; set; }
        public static int Score { get; set; }
        public static int Points { get; set; }
        public static bool GameOver { get; set; }
        public static Directions Direction { get; set; }

        public Settings()
        {
            Score = 0;
            Width = 16;
            Height = 16;
            Speed = 10;
            Points = 10;
            GameOver = false;
            Direction = Directions.DOWN;
        }
    }
}
