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
    public class Project : IProject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public int ProjectTypeId { get; set; }
        public string ProjectName { get; set; }
        public ICollection<IBar> Bars { get; set; }
    }
}
