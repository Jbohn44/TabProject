using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Models.Interfaces;

namespace TabIt.Models
{
    public class Bar : IBar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarId { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        public IProject Project { get; set; }
        public List<INote> Notes { get; set; }
        public Bar()
        {
        }
    }
}
