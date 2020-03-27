using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabIt.Models;

namespace TabIt.Repository
{
    public class ProjectRepository
    {
        public Project SaveProject(Project project)
        {
            using(var context = new Context())
            {
                if (project.ProjectId > 0)
                {
                    var p = context.Projects.FirstOrDefault(x => x.ProjectId == project.ProjectId);
                    p.ProjectName = project.ProjectName;
                    context.SaveChanges();
                    return p;
                }
                else
                {
                    context.Projects.Add(project);
                    context.SaveChanges();
                    return project;
                }
            }
        }

        public List<Project> GetProjects()
        {
            using(var context = new Context())
            {
                var pl = context.Projects.ToList();
                return pl;
            }
        }

        public Project GetProject(int id)
        {
            using(var context = new Context())
            {
                var p = context.Projects.FirstOrDefault(x => x.ProjectId == id);
                return p;
            }
        }

        public void DeleteProject(Project project)
        {
            List<Note> notes = new List<Note>();
            using(var context = new Context())
            {
                var p = context.Projects.FirstOrDefault(x => x.ProjectId == project.ProjectId);
                var bars = context.Bars.Where(x => x.ProjectId == project.ProjectId);
                foreach(var b in bars)
                {
                    var barNotes = context.Notes.Where(x => x.BarId == b.BarId).ToList();
                    foreach(var n in barNotes)
                    {
                        notes.Add(n);
                    }
                }

                foreach(var b in bars)
                {
                    context.Bars.Remove(b);
                }
                foreach(var n in notes)
                {
                    context.Notes.Remove(n);
                }
                context.Projects.Remove(p);
                context.SaveChanges();

            }
        }
    }
}
