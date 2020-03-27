using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TabIt.Models;
using TabIt.Repository;

namespace TabIt.Views
{
    /// <summary>
    /// Interaction logic for BassProjectPage.xaml
    /// </summary>
    public partial class BassProjectPage : Page
    {
        public Project Project { get; set; }
        public List<BassTabSegment> BassTabSegments { get; set; }
        public BassProjectPage(Project project)
        {
            InitializeComponent();
            this.BassTabSegments = GetBassTabSegments(project.ProjectId);
            this.Project = project;

        }
        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            var bar = CreateBar();
            var b = new BarRepository().SaveBar(bar);
            var noteList = CreateNewNotes(b);
            var bSegment = new BassTabSegment(bar, noteList);
            bSegment.Height = 150;
            bSegment.Width = 150;
            BassTabSegments.Add(bSegment);
            bts.Items.Add(bSegment);

        }

        private List<Note> CreateNewNotes(Bar b)
        {
            var noteList = CreateNotes(b);
            return new NoteRepository().SaveNotes(noteList);
        }

        private List<BassTabSegment> GetBassTabSegments(int id)
        {
            var bl = new BarRepository().GetBars(id).ToList();
            var segments = new List<BassTabSegment>();
            if(bl.Count > 0)
            {
                foreach(var b in bl)
                {
                    var notes = new NoteRepository().GetNotes(b.BarId);
                    var bs = new BassTabSegment(b, notes);
                    bs.Height = 150;
                    bs.Width = 150;
                    segments.Add(bs);
                }
                foreach(var s in segments)
                {
                    this.bts.Items.Add(s);
                }
                return segments;
            }
            else
            {
                return segments;
            }
        }

        private List<Note> CreateNotes(Bar b)
        {
            var noteList = new List<Note>();
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "G1",
                Fret = G1.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "G2",
                Fret = G2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "G3",
                Fret = G3.Text

            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "G4",
                Fret = G4.Text

            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "D1",
                Fret = D1.Text

            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "D2",
                Fret = D2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "D3",
                Fret = D3.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "D4",
                Fret = D4.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "A1",
                Fret = A1.Text

            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "A2",
                Fret = A2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "A3",
                Fret = A3.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "A4",
                Fret = A4.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "E1",
                Fret = E1.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "E2",
                Fret = E2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "E3",
                Fret = E3.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "E4",
                Fret = E4.Text
            });

            return noteList;
        }
     

        public void Update_Page()
        {
            this.bts.Items.Clear();
            this.BassTabSegments = GetBassTabSegments(Project.ProjectId);
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow printWindow = new PrintWindow(this.Project);
            printWindow.Show();
        }

        private Bar CreateBar()
        {
            var bl = new BarRepository().GetBars(Project.ProjectId);
            var bar = new Bar();
            bar.ProjectId = Project.ProjectId;
            if(bl.Count == 0)
            {
                bar.PositionId = 1;
                return bar;
            }
            var sbl = bl.OrderBy(x => x.PositionId).ToList();
            var lastPostionId = sbl.Last().PositionId;
            bar.PositionId = lastPostionId + 1;

            return bar;
        }

   
    }

   
}
