using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hangman
{
    public partial class MainWindow : Window
    {
        UImanager ui;
        public MainWindow()
        {
            InitializeComponent();
            myGrid.Background = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/images/background.jpg")));
            ui = new UImanager(myGrid);
        }
    }
}
