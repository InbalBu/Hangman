using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Hangman
{
    public class hangmanImage
    {
        public Image imgBack = new Image();
        public Image image;
        private int count;
        public hangmanImage()
        {
            image = new Image();
            image.Source = (new BitmapImage(new Uri(@"pack://application:,,,/images/0.jpg")));
            image.Width = 400;
            image.Height = 350;
        }
        public void CreateImage()
        {
            Grid.SetColumn(image, 11);
            Grid.SetColumnSpan(image, 3);
            Grid.SetRow(image, 1);
            Grid.SetRowSpan(image, 3);
        }
        public void DisplayImg()
        {
            count++;
            image.Source = (new BitmapImage(new Uri($"pack://application:,,,/images/{count}.jpg")));
        }
        public void RestartCountImg()
        {
            count = 0;
            image.Source = (new BitmapImage(new Uri($"pack://application:,,,/images/{count}.jpg")));
        }
    }
}
