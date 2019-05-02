using Microsoft.AspNetCore.Mvc;
using Hangman.Models;

namespace Hangman.Controllers
{
  public class GamesController : Controller
  {
    [HttpGet("/index")]
    public ActionResult Index()
    {
      return View(Game.GetCurrentGame());
    }

    [HttpPost("/game/new")]
    public ActionResult Create()
    {
      Game.ClearAll();
      Game newGame = new Game();
      return RedirectToAction("Index");
    }

    [HttpPost("/game/newguess")]
    public ActionResult Create(char newguess)
    {
      Game newGame = Game.GetCurrentGame();
      char userLetter = newguess;
      newGame.CheckGuess(userLetter);
      return RedirectToAction("Index");
    }




  }
}
