using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman
{
    public class UImanager
    {
        Grid myGrid;
        TextBox[] txtChar;
        public TextBlock headLine;
        Buttons btn;
        Logic logic = new Logic();
        hangmanImage image = new hangmanImage();
        public UImanager(Grid myGrid1)
        {
            myGrid = myGrid1;
            btn = new Buttons(myGrid);
            btn.newGame = new Action(NewGame);
            btn.level = new Action(ChooseLevel);
            btn.Click = new Action<object, RoutedEventArgs>(ClickAllBtns);
            SetUpGame();
        }

        public void Head()
        {
            headLine = new TextBlock();
            headLine.Text = "Hangman Game";
            headLine.FontSize = 50;
            headLine.FontWeight = FontWeights.Bold;
            headLine.Width = 450;
            headLine.Height = 100;
            headLine.Foreground = new SolidColorBrush(Colors.DarkBlue);
            headLine.HorizontalAlignment = HorizontalAlignment.Center;
            headLine.VerticalAlignment = VerticalAlignment.Center;
            headLine.TextAlignment = TextAlignment.Center;
            Grid.SetColumnSpan(headLine, 14);
            Grid.SetRowSpan(headLine, 1);
            myGrid.Children.Add(headLine);
        }
        public void SetGridColandRow()
        {
            for (int i = 0; i <= 14; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(coldef);

            }
            for (int i = 0; i <= 5; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                myGrid.RowDefinitions.Add(rowdef);
            }
        }
        public void CreateStage()
        {
            txtChar = new TextBox[logic.tmp.Length];

            for (int i = 0; i < logic.tmp.Length; i++)
            {
                txtChar[i] = new TextBox();
                txtChar[i].Text = " ";
                txtChar[i].FontSize = 20;
                txtChar[i].Width = 80;
                txtChar[i].Height = 50;
                txtChar[i].HorizontalAlignment = HorizontalAlignment.Center;
                txtChar[i].VerticalAlignment = VerticalAlignment.Center;
                Grid.SetColumn(txtChar[i], i);
                Grid.SetRowSpan(txtChar[i], 5);
                myGrid.Children.Add(txtChar[i]);
            }
        }
        public void ChooseLevel()
        {
            logic.level = !logic.level;
            if (logic.level)
                btn.levelBtn.Content = "Change to Easy";
            else
            {
                btn.levelBtn.Content = "Change to Hard";
            }
            btn.levelBtn.Visibility = Visibility.Hidden;
            NewGame();
        }
        public void ChooseLevelBtn()
        {
            if (logic.lose)
            {
                btn.levelBtn.Visibility = Visibility.Visible;
                btn.DisableAllBtn();
            }
            else
            {
                btn.levelBtn.Visibility = Visibility.Hidden;
            }
        }
        public void NewGame()
        {
            for (int i = 0; i < logic.tmp.Length; i++)
            {
                txtChar[i].Text = " ";
                myGrid.Children.Remove(txtChar[i]);
            }
            logic.Level();
            CreateStage();
            btn.EnableBtn();
            logic.RestartVar();
            image.RestartCountImg();
        }
        public void SetUpGame()
        {
            Head();
            SetGridColandRow();
            CreateStage();
            image.CreateImage();
            myGrid.Children.Add(image.image);
        }
        private void ClickAllBtns(object arg1, RoutedEventArgs arg2)
        {
            Button btn = (Button)arg1;
            logic.letter = Convert.ToChar(btn.Content);
            InsertWord();
            ChooseLevelBtn();
        }
        private void InsertWord()
        {
            btn.DisableBtn(btn.btnChar[logic.ConvertChar()]);

            if (!logic.tmpCheck())
            {
                image.DisplayImg();
            }
            else
            {
                for (int i = 0; i < logic.tmp.Length; i++)
                {
                    if (logic.tmp[i].ToString() == logic.letter.ToString())
                    {
                        txtChar[i].Text = btn.btnChar[logic.ConvertChar()].Content.ToString();
                        logic.CheckCount();
                    }
                }
            }
        }
    }
}
