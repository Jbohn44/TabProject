using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabIt.Models.Interfaces
{
    public interface IBar
    {
        int BarId { get; set; }
        int PositionId { get; set; }
        List<INote> Notes { get; set; }
        IProject Project { get; set; }
    }
}
