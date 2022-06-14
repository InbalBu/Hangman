using System;

namespace Hangman
{
    public class Words
    {
        string[] _wordList;
        public string[] wordList { get { return _wordList; } }
        public string wordEz { get { return wordList[rnd.Next(0, 3)]; } }
        public string wordHard { get { return wordList[rnd.Next(3, 6)]; } }

        static Random rnd = new Random();

        public Words()
        {
            _wordList = new string[6];
            wordList[0] = "DATA";
            wordList[1] = "ARRAY";
            wordList[2] = "LOOP";
            wordList[3] = "VARIABLES";
            wordList[4] = "COMPILATION";
            wordList[5] = "INTERFACES";
        }
    }
}
