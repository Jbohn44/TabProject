using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Models.Interfaces;

namespace TabIt.Models
{
    public class Note : INote
    {
        public int NoteId { get; set; }
        public int BarId { get; set; }
        public string String { get; set; }
        public string Fret { get; set; }
    }
}
