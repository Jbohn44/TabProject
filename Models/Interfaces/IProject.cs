using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabIt.Models.Interfaces
{
    public interface IProject
    {
        int ProjectId { get; set; }
        int ProjectTypeId { get; set; }
        string ProjectName { get; set; }
        ICollection<IBar> Bars { get; set; }
    }
}
