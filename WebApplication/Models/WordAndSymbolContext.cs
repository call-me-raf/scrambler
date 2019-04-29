using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class WordAndSymbolContext:DbContext
    {
        public DbSet<Word> Words { get; set; }

        public DbSet<OldSymbol> OldSymbols { get; set; }
        public DbSet<NewSymbol> NewSymbols { get; set; }
    }
    public class SymbolInitializer : DropCreateDatabaseIfModelChanges<WordAndSymbolContext>
    {
        protected override void Seed(WordAndSymbolContext db)
        {
            string s = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            for (int i = 0; i < s.Length; i++)
            {
                int var = s.Length - 1;
                db.OldSymbols.Add(new OldSymbol { OSymbol = s.Substring(i, 1) });
                db.NewSymbols.Add(new NewSymbol { NSymbol = s.Substring(var - i, 1) });
            }
            base.Seed(db);
        }
    }
}