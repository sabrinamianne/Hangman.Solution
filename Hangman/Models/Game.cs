using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Game
  {
    private string[] _allWords = {"elephant", "giraffe", "monkey", "panda", "kangaroo", "dolphin", "horse"};
    // private char[] _letter;
    private string _wordToFind;
    private char[] _display;
    private static List<Game> _allGames = new List<Game>{};
    private int _lives= 6;


    public Game()
    {
      _wordToFind = SelectWord();
      _display = new char[_wordToFind.Length];
      for(int i = 0; i < _wordToFind.Length; i++)
      {
        _display[i] = '*';
      }
      _allGames.Add(this);

    }

    public static Game GetCurrentGame()
    {
      return _allGames[0];
    }

    public static void ClearAll()
    {
      _allGames.Clear();
    }

    public string GetDisplay()
    {
      return string.Join("", _display);
    }

    public int GetLives()
    {
      return _lives;
    }

    public string GetWordToFind()
    {
      return _wordToFind;
    }

    private string SelectWord()
    {
      Random random = new Random();
      int wordIndex = random.Next(0, _allWords.Length);
      return _allWords[wordIndex];
    }

    public void CheckGuess(char guessLetter)
    {
      if (_wordToFind.Contains(guessLetter))
      {
        for(int i = 0; i<_wordToFind.Length; i++)
        {
          if(_wordToFind[i] == guessLetter)
          {
            _display[i] = guessLetter;
          }
        }
      }
      else
      {
        _lives -= 1;
      }
    }
  }
}
