using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabIt.Models.Interfaces
{
    public interface INote
    {
        int NoteId { get; set; }
        int BarId { get; set; }
        string String { get; set; }
        string Fret { get; set; }
    }
}
