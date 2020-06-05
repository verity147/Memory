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
        private int cardCount = 18;
        public List<Card> CardList { get; set; }


        //public Game()
        //{
        //    this.InitializeComponent();
        //}

        public void InitializeGame()
        {
            for (int i = 0; i < cardCount; i++)
            {
                string img = "Assets/card" + (i + 1).ToString() + "_s.png";
                Card card = new Card(i, img, false, false);
                for (int j = 0; j < 2; j++) //need one entry for each card of a pair
                {
                    CardList.Add(card);
                }
            }
        }
    }
}
