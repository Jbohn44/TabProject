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
    /// Interaction logic for GuitarTabSegment.xaml
    /// </summary>
    public partial class GuitarTabSegment : UserControl
    {
        private int BarId { get; set; }
        private int ProjectId { get; set; }
        public int PositionId { get; set; }

        private string _e1 { get; set; }
        private string _e2 { get; set; }
        private string _e3 { get; set; }
        private string _e4 { get; set; }
        private string _b1 { get; set; }
        private string _b2 { get; set; }
        private string _b3 { get; set; }
        private string _b4 { get; set; }
        private string _g1 { get; set; }
        private string _g2 { get; set; }
        private string _g3 { get; set; }
        private string _g4 { get; set; }
        private string _d1 { get; set; }
        private string _d2 { get; set; }
        private string _d3 { get; set; }
        private string _d4 { get; set; }
        private string _a1 { get; set; }
        private string _a2 { get; set; }
        private string _a3 { get; set; }
        private string _a4 { get; set; }
        private string _ee1 { get; set; }
        private string _ee2 { get; set; }
        private string _ee3 { get; set; }
        private string _ee4 { get; set; }

        public GuitarTabSegment() { }
        public GuitarTabSegment(Bar bar, List<Note> notes)
        {
            InitializeComponent();
            this.BarId = bar.BarId;
            this.ProjectId = bar.ProjectId;
            this.PositionId = bar.PositionId;
            SetPrivateNotes(bar, notes);
            SetNotes();
            this.SetPositionId();


        }

        private void SetPrivateNotes(Bar bar, List<Note> notes)
        {
            foreach (var n in notes)
            {
                if (n.String == "E1")
                {
                    this._e1 = n.Fret;
                }

                if (n.String == "E2")
                {
                    this._e2 = n.Fret;

                }

                if (n.String == "E3")
                {
                    this._e3 = n.Fret;
                }

                if (n.String == "E4")
                {
                    this._e4 = n.Fret;
                }

                if (n.String == "B1")
                {
                    this._b1 = n.Fret;
                }

                if (n.String == "B2")
                {
                    this._b2 = n.Fret;
                }

                if (n.String == "B3")
                {
                    this._b3 = n.Fret;
                }

                if (n.String == "B4")
                {
                    this._b4 = n.Fret;
                }
                if (n.String == "G1")
                {
                    this._g1 = n.Fret;
                }

                if (n.String == "G2")
                {
                    this._g2 = n.Fret;

                }

                if (n.String == "G3")
                {
                    this._g3 = n.Fret;
                }

                if (n.String == "G4")
                {
                    this._g4 = n.Fret;
                }

                if (n.String == "D1")
                {
                    this._d1 = n.Fret;
                }

                if (n.String == "D2")
                {
                    this._d2 = n.Fret;
                }

                if (n.String == "D3")
                {
                    this._d3 = n.Fret;
                }

                if (n.String == "D4")
                {
                    this._d4 = n.Fret;
                }

                if (n.String == "A1")
                {
                    this._a1 = n.Fret;
                }

                if (n.String == "A2")
                {
                    this._a2 = n.Fret;
                }

                if (n.String == "A3")
                {
                    this._a3 = n.Fret;
                }

                if (n.String == "A4")
                {
                    this._a4 = n.Fret;
                }

                if (n.String == "Ee1")
                {
                    this._ee1 = n.Fret;
                }

                if (n.String == "Ee2")
                {
                    this._ee2 = n.Fret;
                }

                if (n.String == "Ee3")
                {
                    this._ee3 = n.Fret;
                }

                if (n.String == "Ee4")
                {
                    this._ee4 = n.Fret;
                }

            }
        }
        private void SetNotes()
        {
            this.E1.Text = this._e1;
            this.E2.Text = this._e2;
            this.E3.Text = this._e3;
            this.E4.Text = this._e4;
            this.B1.Text = this._b1;
            this.B2.Text = this._b2;
            this.B3.Text = this._b3;
            this.B4.Text = this._b4;
            this.G1.Text = this._g1;
            this.G2.Text = this._g2;
            this.G3.Text = this._g3;
            this.G4.Text = this._g4;
            this.D1.Text = this._d1;
            this.D2.Text = this._d2;
            this.D3.Text = this._d3;
            this.D4.Text = this._d4;
            this.A1.Text = this._a1;
            this.A2.Text = this._a2;
            this.A3.Text = this._a3;
            this.A4.Text = this._a4;
            this.Ee1.Text = this._ee1;
            this.Ee2.Text = this._ee2;
            this.Ee3.Text = this._ee3;
            this.Ee4.Text = this._ee4;

        }

        private void SetPositionId()
        {
            this.positionIdBox.Text = this.PositionId.ToString();
        }


        private void removePanel_Click(object sender, RoutedEventArgs e)
        {
            //this is where the remove panel code needs to notify the bass tab page to call repo and remove segment, then update ui
            new BarRepository().Delete(BarId);
            var listBox = (ListBox)this.Parent;
            var grid = (Grid)listBox.Parent;
            var page = (GuitarProjectPage)grid.Parent;
            page.Update_Page();
        }
    }
}
