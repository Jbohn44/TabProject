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
using System.Windows.Shapes;
using System.Windows.Xps;
using TabIt.Models;
using TabIt.Repository;
using TabIt.Views;
using PdfSharp;
using PdfSharp.Pdf;

namespace TabIt
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        private Project Project { get; set; }
        private List<BassTabSegment> BassTabSegments { get; set; }
        public PrintWindow(Project project)
        {
            InitializeComponent();
            this.Project = project;
            getSegments(project);
            setHeader();
            
        }

        private void getSegments(Project project)
        {
            switch (project.ProjectTypeId)
            {
                case 0:
                    BassTabSegments = new BassTabSegmentRepository().getSegments(project.ProjectId).ToList();
                    addSegmentsToListBox(BassTabSegments);
                    break;
                case 1:
                    
                    break;
            }
        }

        private void addSegmentsToListBox(List<BassTabSegment> segments)
        {
            for(var i = 0; i < segments.Count; i++)
            {
               
            }
        }
        private void setHeader()
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            doc.AddPage();
            doc.Save("test.pdf");
        }
    }
}
