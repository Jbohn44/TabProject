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
    /// Interaction logic for GuitarProjectPage.xaml
    /// </summary>
    public partial class GuitarProjectPage : Page
    {
        public Project Project { get; set; }
        public List<GuitarTabSegment> GuitarTabSegments { get; set; } = new List<GuitarTabSegment>();
        public GuitarProjectPage(Project project)
        {
            InitializeComponent();
            this.GuitarTabSegments = GetGuitarTabSegments(project.ProjectId);
            Project = project;
        }

        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            var bar = new Bar();
            bar.ProjectId = this.Project.ProjectId;
            var b = new BarRepository().SaveBar(bar);
            var noteList = CreateNewNotes(b);
            var gSegment = new GuitarTabSegment(bar, noteList);
            gSegment.Height = 150;
            gSegment.Width = 100;
            GuitarTabSegments.Add(gSegment);
            bts.Items.Add(gSegment);

        }

        private List<Note> CreateNewNotes(Bar b)
        {
            var noteList = CreateNotes(b);
            return new NoteRepository().SaveNotes(noteList);
        }

        private List<GuitarTabSegment> GetGuitarTabSegments(int id)
        {
            var bl = new BarRepository().GetBars(id).ToList();
            var segments = new List<GuitarTabSegment>();
            if (bl.Count > 0)
            {
                foreach (var b in bl)
                {
                    var notes = new NoteRepository().GetNotes(b.BarId);
                    var gs = new GuitarTabSegment(b, notes);
                    gs.Height = 150;
                    gs.Width = 100;
                    segments.Add(gs);
                }
                foreach (var s in segments)
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
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "B1",
                Fret = B1.Text

            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "B2",
                Fret = B2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "B3",
                Fret = B3.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "B4",
                Fret = B4.Text
            });
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
                String = "Ee1",
                Fret = Ee1.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "Ee2",
                Fret = Ee2.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "Ee3",
                Fret = Ee3.Text
            });
            noteList.Add(new Note
            {
                BarId = b.BarId,
                String = "Ee4",
                Fret = Ee4.Text
            });

            return noteList;
        }


        public void Update_Page()
        {
            this.bts.Items.Clear();
            this.GuitarTabSegments = GetGuitarTabSegments(Project.ProjectId);
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            PrintWindow printWindow = new PrintWindow(this.Project);
            printWindow.Show();
        }
    }
}
