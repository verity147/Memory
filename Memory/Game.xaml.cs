using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Memory.Models;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory
{
    public sealed partial class Game : Page
    {
        private readonly int cardCount = 18;
        private readonly string cardBack = "Assets/cardback_s.png";
        public List<Card> CardList { get; set; } = new List<Card>();

        public Game()
        {
            WriteCardList();
            ShuffleCardList();
            this.InitializeComponent();
        }

        private void ShuffleCardList()
        {
            Random random = new Random();
            CardList = CardList.OrderBy(item => random.Next()).ToList();
        }

        public void WriteCardList()
        {
            for (int i = 1; i < cardCount + 1; i++)
            {
                string img = "Assets/card" + i.ToString() + "_s.png";
                Card card = new Card(i, img, false, false);
                for (int j = 0; j < 2; j++) //need one entry for each card of a pair
                {
                    CardList.Add(card);
                }
            }
        }

        private void Card_Click(object sender, ItemClickEventArgs e)
        {
            Card clickedCard = e.ClickedItem as Card;
            //clickedCard.ImagePath = "Assets/card" + (clickedCard.Id).ToString() + "_s.png";
            clickedCard.Turned = !clickedCard.Turned;
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var thing = e.AddedItems;
        }
    }
}
