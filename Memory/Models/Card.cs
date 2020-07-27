using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Models
{
    public class Card
    {
        public int UniqueId { get; set; } //absolutely unique Id
        public int PairId { get; set; } //represents the image to identify pairings

        public string ImagePath { get; set; } = "cardback_s.png";

        public bool Turned { get; set; } = false;
        public bool Solved { get; set; } = false; //use this to hide solved pairs when set to true

        public Card(int uniqueId, int pairId, string imagePath, bool turned, bool solved)
        {
            UniqueId = uniqueId;
            PairId = pairId;
            ImagePath = imagePath;
            Turned = turned;
            Solved = solved;
        }
    }

}

