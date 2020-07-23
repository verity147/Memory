using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = "cardback_s.png";

        public bool Turned { get; set; } = false;
        public bool Solved { get; set; } = false; //use this to hide solved pairs when set to true

        public Card(int id, string imagePath, bool turned, bool solved)
        {
            Id = id;
            ImagePath = imagePath;
            Turned = turned;
            Solved = solved;
        }
    }

}

