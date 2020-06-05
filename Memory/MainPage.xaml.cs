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
using Windows.UI.Xaml.Navigation;
using Memory.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Memory
{
    public sealed partial class MainPage : Page
    {
        private Game game;
        public MainPage()
        {
            game = (Game)FindName("Game");
            this.InitializeComponent();
            game.InitializeGame();
            game.InitializeComponent();
            GameFrame.Navigate(typeof(Game));
        }


        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Header.Text = "Hello World";
        }
    }
}
