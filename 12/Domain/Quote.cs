using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiIdId { get; set; }
    }
}
