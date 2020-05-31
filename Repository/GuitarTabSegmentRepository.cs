using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TabIt.Views;

namespace TabIt.Repository
{
    public class GuitarTabSegmentRepository
    {
        public IList<GuitarTabSegment> getSegments(int projectId)
        {
            var bl = new BarRepository().GetBars(projectId).ToList();
            var segments = new List<GuitarTabSegment>();
            if (bl.Count > 0)
            {
                foreach (var b in bl)
                {
                    var notes = new NoteRepository().GetNotes(b.BarId);
                    var bs = new GuitarTabSegment(b, notes);
                    bs.Height = 200;
                    bs.Width = 200;
                    segments.Add(bs);
                }

                return segments;
            }
            else
            {
                return segments;
            }
        }
    }
}
