using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Models;
using TabIt.Models.Interfaces;

namespace TabIt.Repository
{
    public class NoteRepository
    {
        public List<Note> SaveNotes(List<Note> notes)
        {
            using(var context = new Context())
            {
                foreach(var n in notes)
                {
                    context.Notes.Add(n);
                    context.SaveChanges();
                }
                return notes;
            }
        }

        public List<Note> GetNotes(int barId)
        {
            using(var context = new Context())
            {
                var n = context.Notes.Where(x => x.BarId == barId).ToList();
                return n;
            }
        }

      
    }
}
