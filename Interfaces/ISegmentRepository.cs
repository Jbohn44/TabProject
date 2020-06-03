using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Views;

namespace TabIt.Interfaces
{
    public interface ISegmentRepository
    {
        IList<BassTabSegment> getSegments(int projectId);
    }
}
