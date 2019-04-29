using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string OldWord { get; set; }
        public string NewWord { get; set; }
        public DateTime dateTime { get; set; }
    }
}