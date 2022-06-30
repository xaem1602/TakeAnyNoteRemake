using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAnyNoteRemake
{
    public class Note
    {
        public string? text { get; set; }
        public DateTime date { get; set; }

        public Note(string? text, DateTime date)
        {
            this.text = text;
            this.date = date;
        }

        public override string ToString()
        {
            return this.date.ToShortDateString() + " " + this.date.ToShortTimeString() + "\n" + this.text;
        }
    }
}