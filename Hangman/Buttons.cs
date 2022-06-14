using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman
{
    public class Buttons
    {
        public Button[] btnChar;
        public Button restartBtn;
        public Button levelBtn;
        public Button btn;
        public Grid myGrid;
        public Action newGame { get; set; }
        public Action level { get; set; }
        public Action<object, RoutedEventArgs> Click { get; set; }

        public Buttons(Grid myGrid1)
        {
            myGrid = myGrid1;
            btnChar = new Button[26];
            AddBtn();
        }
        public Button CreateBtn(int height, int width, string content, int row, int col, int font, RoutedEventHandler e)
        {
            btn = new Button();
            btn.Content = content;
            btn.Height = height;
            btn.Width = width;
            btn.FontSize = font;
            btn.Foreground = new SolidColorBrush(Colors.White);
            btn.Background = new SolidColorBrush(Colors.DarkBlue);
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(btn, col);
            Grid.SetRow(btn, row);
            myGrid.Children.Add(btn);
            btn.Click += e;
            return btn;
        }
        public void AddBtn()
        {
            CreateBtn(50, 80, "Restart", 0, 0, 20, RestartBtn);
            levelBtn = CreateBtn(50, 80, "Change to Hard", 0, 2, 10, LevelBtn);
            levelBtn.Visibility = Visibility.Hidden;
            for (int i = 0; i < 14; i++)
            {
                btnChar[i] = CreateBtn(50, 80, Convert.ToChar(i + 65).ToString(), 4, i, 20, BtnChar);

            }
            for (int i = 0; i < 12; i++)
            {
                btnChar[i + 14] = CreateBtn(50, 80, Convert.ToChar(i + 79).ToString(), 5, i, 20, BtnChar);
            }
        }
        private void BtnChar(object sender, RoutedEventArgs e)
        {
            Click(sender, e);
        }
        private void LevelBtn(object sender, RoutedEventArgs e)
        {
            level();
        }
        private void RestartBtn(object sender, RoutedEventArgs e)
        {
            newGame();
        }
        public void EnableBtn()
        {
            for (int i = 0; i < 14; i++)
            {
                btnChar[i].IsEnabled = true;
            }
            for (int i = 14; i < 26; i++)
            {
                btnChar[i].IsEnabled = true;
            }
        }
        public void DisableBtn(Button button)
        {
            button.IsEnabled = false;
        }
        public void DisableAllBtn()
        {
            for (int i = 0; i < 26; i++)
            {
                btnChar[i].IsEnabled = false;
            }
        }


    }
}
