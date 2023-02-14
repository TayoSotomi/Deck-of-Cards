using Deck_Of_Cards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deck_Of_Cards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DeckOfCards()
        {

            DeckModel result =DeckDAL.GetDeckModel(5);

            if(result.remaining == 0)
            {
                DeckDAL.ShuffleDeck();
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult DeckOfCards(string card0, string card1, string card2, string card3, string card4)
        {
            int newcards = 5;
            if (card0 != null && card0 != "")
            {
                newcards--;
            }
            if (card1 != null && card1 != "")
            {
                newcards--;
            }
            if (card2 != null && card2 != "")
            {
                newcards--;
            }
            if (card3 != null && card3 != "")
            {
                newcards--;
            }
            if (card4 != null && card4 != "")
            {
                newcards--;
            }

            DeckModel result = DeckDAL.GetDeckModel(newcards);

            if (card0 != null && card0 != "")
            {
                result.cards.Add(new Card() { image = card0 });
            }
            if (card1 != null && card1 != "")
            {
                result.cards.Add(new Card() { image = card1 });
            }
            if (card2 != null && card2 != "")
            {
                result.cards.Add(new Card() { image = card2});
            }
            if (card3 != null && card3 != "")
            {
                result.cards.Add(new Card() { image = card3 });
            }
            if (card4 != null && card4 != "")
            {
                result.cards.Add(new Card() { image = card4 });
            }

            if (result.remaining == null)
            {
                DeckDAL.ShuffleDeck();
            }
            return View(result);

        }

        public IActionResult Shuffle()
        {

            DeckDAL.ShuffleDeck();
            
            return RedirectToAction("Cards");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}