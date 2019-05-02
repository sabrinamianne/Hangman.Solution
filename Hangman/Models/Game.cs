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
    private List<char> _lettersInput = new List<char>{};
    private int _lives= 6;
    private string _errorMessage = "";


    public Game()
    {
      _wordToFind = SelectWord();
      _display = new char[_wordToFind.Length];
      for(int i = 0; i < _wordToFind.Length; i++)
      {
        _display[i] = '_';
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

    public string GetListLetterInput()
    {
      return string.Join(" ",_lettersInput );
    }


    public int GetLives()
    {
      return _lives;
    }

    public string GetWordToFind()
    {
      return _wordToFind;
    }

    public string GetErrorMessage()
    {
      return _errorMessage;
    }

    private string SelectWord()
    {
      Random random = new Random();
      int wordIndex = random.Next(0, _allWords.Length);
      return _allWords[wordIndex];
    }

    public bool CheckForError(char guessLetter)
    {
      if (guessLetter == '\0')
        {
          _errorMessage = "Please, enter a letter.";
          return true;
        }
      else if(_lettersInput.Contains(guessLetter))
      {
        _errorMessage = "You already guessed that letter!";
        return true;
      }
      else
      {
        return false;
      }
    }

    public void CheckGuess(char guessLetter)
    {
      if (CheckForError(guessLetter))
      {
        return;
      }
      if (_wordToFind.Contains(guessLetter))
      {
          _lettersInput.Add(guessLetter);
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
        _lettersInput.Add(guessLetter);
      }
      _errorMessage = "";
    }
  }
}
