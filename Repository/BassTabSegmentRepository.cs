using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TabIt.Interfaces;
using TabIt.Views;

namespace TabIt.Repository
{
    public class BassTabSegmentRepository
    {
        public IList<BassTabSegment> getSegments(int projectId)
        {
            var bl = new BarRepository().GetBars(projectId).ToList();
            var segments = new List<BassTabSegment>();
            if (bl.Count > 0)
            {
                foreach (var b in bl)
                {
                    var notes = new NoteRepository().GetNotes(b.BarId);
                    var bs = new BassTabSegment(b, notes);
                    bs.Height = 150;
                    bs.Width = 150;
                    bs.removePanel.Visibility = Visibility.Hidden;
                    bs.positionIdBox.Visibility = Visibility.Hidden;
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
