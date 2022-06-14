using System;
using System.Linq;
using System.Windows;

namespace Hangman
{
    public class Logic
    {
        public int count = 0;
        public int countCheck = 0;
        public bool level;
        public bool lose = false;
        public string tmp;
        public char letter;
        public bool chooseLevel;
        Words wordsClass = new Words();
        public Logic()
        {
            tmp = wordsClass.wordEz;
        }

        public void Level()
        {
            if (level == true)
            {
                tmp = wordsClass.wordHard;
            }
            else
            {
                tmp = wordsClass.wordEz;
            }
        }
        public bool WinOrLose()
        {
            if (count == 10)
            {
                MessageBox.Show("You Lose!");
                return lose = true;

            }
            else
            {
                if (tmp.Length == countCheck)
                {
                    MessageBox.Show("You Won!");
                    return lose = true;
                }
            }
            return lose = false;
        }
        public void CheckCount()
        {
            countCheck++;
            WinOrLose();
        }
        public void RestartVar()
        {
            count = 0;
            countCheck = 0;
        }
        public bool tmpCheck()
        {
            if (tmp.Contains(letter))
            {
                WinOrLose();
                return true;
            }
            else
            {
                count++;
                WinOrLose();
                return false;
            }
        }
        public int ConvertChar()
        {
            return Convert.ToInt32(letter - 65);
        }
    }
}
