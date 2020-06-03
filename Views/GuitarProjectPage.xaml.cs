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
            this.GuitarTabSegments = new GuitarTabSegmentRepository().getSegments(project.ProjectId).ToList();
            Project = project;
            addSegmentsToBts(GuitarTabSegments);
        }

        private void AddNotes_Click(object sender, RoutedEventArgs e)
        {
            var bar = CreateBar();
            var b = new BarRepository().SaveBar(bar);
            var noteList = CreateNewNotes(b);
            var gSegment = new GuitarTabSegment(bar, noteList);
            gSegment.Height = 200;
            gSegment.Width = 200;
            GuitarTabSegments.Add(gSegment);
            bts.Items.Add(gSegment);

        }

        private List<Note> CreateNewNotes(Bar b)
        {
            var noteList = CreateNotes(b);
            return new NoteRepository().SaveNotes(noteList);
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
            this.GuitarTabSegments = new GuitarTabSegmentRepository().getSegments(Project.ProjectId).ToList();
            addSegmentsToBts(GuitarTabSegments);
        }

        private void addSegmentsToBts(List<GuitarTabSegment> guitarTabSegments)
        {
            foreach (var item in guitarTabSegments)
            {
                this.bts.Items.Add(item);
            }
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
