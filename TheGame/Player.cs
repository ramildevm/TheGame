using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HighScore { get; set; }
        public Player() { }
        public Player(string name, string highScore)
        {
            Name = name; HighScore = highScore;
        }
    }
}
