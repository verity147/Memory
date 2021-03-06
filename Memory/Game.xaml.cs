﻿using System;
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
using Windows.UI.Xaml.Media.Imaging;
using Memory.Models;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Memory
{
    public sealed partial class Game : Page
    {
        private readonly int cardCount = 18;
        private int turnedCardsCount = 0;
        private int solvedPairs = 0;
        private int attempts = 0;
        private Card[] turnedCards = { null, null };
        private Card card;
        private Button[] buttons = { null, null };
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
            int uniqueIdCounter = 0;
            for (int i = 1; i < cardCount + 1; i++)
            {
                string img = "Assets/card" + i.ToString() + "_s.png";
                for (int j = 0; j < 2; j++) //need one entry for each card of a pair
                {
                    Card card = new Card(uniqueIdCounter, i, img, false, false);
                    CardList.Add(card);
                    uniqueIdCounter++;
                }
            }
        }

        private void Card_Button(object sender, RoutedEventArgs e)
        {            
            if (turnedCardsCount >= 2)
            {
                return; //give player feedback to only turn two cards at once?
            }
            Button button = sender as Button;
            int clickedCardId = int.Parse(button.Name);
            card = CardList.Find(item => item.UniqueId == clickedCardId);

            if (!card.Turned)
            {
                TurnCardVisible(button, card);
                turnedCards.SetValue(card, turnedCardsCount);
                buttons.SetValue(button, turnedCardsCount);
                turnedCardsCount++;
            }

            if (turnedCardsCount == 2)
            {
                CompareCards();
            }
        }

        private async void CompareCards()
        {
            Frame contentFrame = Window.Current.Content as Frame;
            MainPage mainPage = contentFrame.Content as MainPage;
            if (turnedCards[0].UniqueId != turnedCards[1].UniqueId && turnedCards[0].PairId == turnedCards[1].PairId)
            {
                foreach (Button button in buttons)
                {
                    button.IsEnabled = false;
                    button.Opacity = 0;
                    Image face = button.FindName("Face") as Image;
                    face.Visibility = Visibility.Collapsed;
                }
                solvedPairs++;

                await ShowLargeImage();
                if (solvedPairs == cardCount)
                {
                    Frame frame = mainPage.FindName("GameFrame") as Frame;
                    frame.Navigate(typeof (Congratulations));
                    //play winning sound
                }
            }
            else
            {
                await Task.Delay(1750);
                for (int i = 0; i < buttons.Length; i++)
                {
                    TurnCardBack(buttons[i], turnedCards[i]);
                }
            }
            turnedCardsCount = 0;
            attempts++;
            mainPage.Attempts.Text = "Versuche: " + attempts.ToString();
        }

        private async Task ShowLargeImage()
        {
            Uri imgUri = new Uri("ms-appx:///Assets/card" + turnedCards[0].PairId.ToString() + "_l.png", UriKind.Absolute);
            LargeImage.Source = new BitmapImage(imgUri);
            LargeImage.Visibility = Visibility.Visible;
            await Task.Delay(1500);
            LargeImage.Visibility = Visibility.Collapsed;
        }

        private static void TurnCardVisible(Button button, Card card)
        {
            card.Turned = true;
            Image face = button.FindName("Face") as Image;
            face.Visibility = Visibility.Visible;
            Image back = button.FindName("Back") as Image;
            back.Visibility = Visibility.Collapsed;
        }

        private static void TurnCardBack(Button button, Card card)
        {
            card.Turned = false;
            Image face = button.FindName("Face") as Image;
            face.Visibility = Visibility.Collapsed;
            Image back = button.FindName("Back") as Image;
            back.Visibility = Visibility.Visible;
        }
    }
}
