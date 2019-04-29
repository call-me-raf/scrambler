using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        WordAndSymbolContext db = new WordAndSymbolContext();
        [HttpPost]
        public ActionResult Reverse(string Word)
        {
                string NewWord = "";
                for (int i = 0; i < Word.Length; i++)
                {
                    var idd = db.OldSymbols.Select(x => new { x.Id, x.OSymbol }).FirstOrDefault(x => x.OSymbol == Word.Substring(i, 1));
                    var newidd = db.NewSymbols.Select(x => new { x.Id, x.NSymbol }).FirstOrDefault(x => x.Id == idd.Id);
                    NewWord = NewWord + newidd.NSymbol;
                }
                ViewBag.NewWord = NewWord;

                using (var db = new WordAndSymbolContext())
                {
                    var word = new Word();
                    word.OldWord = Word;
                    word.NewWord = NewWord;
                    word.dateTime = DateTime.Now;
                    db.Words.Add(word);
                    db.SaveChanges();
                    db.Dispose();
                }
                var WordsList = db.Words;
                ViewBag.WordsList = WordsList;
                return View();
        }
    }
}