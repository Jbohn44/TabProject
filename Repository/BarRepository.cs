using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Models;

namespace TabIt.Repository
{
    public class BarRepository
    {
        public Bar SaveBar(Bar bar)
        {
            using(var context = new Context())
            {
                context.Bars.Add(bar);
                context.SaveChanges();
                return bar;
            }
        }

        public List<Bar> GetBars(int projectId)
        {
            using(var context = new Context())
            {
                var bs = context.Bars.Where(x => x.ProjectId == projectId).ToList();
                return bs;
            }
        }

        public void Delete(int barid)
        {
            using(var context = new Context())
            {
                var bar = context.Bars.FirstOrDefault(x => x.BarId == barid);
                var notes = context.Notes.Where(x => x.BarId == barid).ToList();
                foreach(var n in notes)
                {
                    context.Notes.Remove(n);
                }
                context.Bars.Remove(bar);
                context.SaveChanges();

            }
        }
    }
}
