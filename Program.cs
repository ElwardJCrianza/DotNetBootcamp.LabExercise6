using System;
using System.Collections.Generic;

namespace CSharp.LabExercise6
{
    class Word
    {
        public string word { get; set; }

        public bool WhiteSpaceValidator(string word)
        {
            if (word.Contains(" "))
            {
                return true;
            }
            return false;
        }
        public bool NumberValidator(string word)
        {
            string numbers = "1234567890";
            foreach (var item in numbers)
            {
                if (word.Contains(item)) return true;
            }
            return false;
        }
        public bool SpecialCharacterValidator(string word)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (word.Contains(item)) return true;
            }
            return false;
        }
    }

    class Scrabble: Word
    {
        public Dictionary<char, int> letterScores = new Dictionary<char, int>()
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1},{'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 1},
            {'B', 3}, {'C', 3}, {'M', 3},{'P', 3},
            {'F', 4}, {'H', 4},{'V', 4},{'W', 4},{'Y', 4},
            {'K', 5},
            {'J', 8},{'X', 8},
            {'Q', 10},{'Z', 10},
        };

        public int CalculateScore(string word)
        {
            int totalScore = 0;
            int letterScore = 0;
            foreach (char letter in word)
            {
                letterScores.TryGetValue(letter, out letterScore);
                totalScore += letterScore;
            }

            return totalScore;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scrabble Word Score Calculator!");
            var answer = "Y";
            bool valid = true;
            while (answer.Trim().ToUpper().Equals("Y") && valid == true)
            {
                Word word = new Word();
                Console.Write("Enter word: ");
                string enteredWord = Convert.ToString(Console.ReadLine());
                if (word.WhiteSpaceValidator(enteredWord))
                {
                    Console.WriteLine("Please enter a single word only!");
                    break;
                };
                if (word.NumberValidator(enteredWord))
                {
                    Console.WriteLine("Entered word contains numbers.");
                    break;
                };
                if (word.SpecialCharacterValidator(enteredWord))
                {
                    Console.WriteLine("Entered word contains special character.");
                    break;
                };
                Scrabble scrabble = new Scrabble();
                Console.WriteLine($"Total Score: {scrabble.CalculateScore(enteredWord.ToUpper())}");

                Console.Write("Do you want to continue(y/n)? ");
                answer = Console.ReadLine().ToUpper();
            }
        }
    }
}
