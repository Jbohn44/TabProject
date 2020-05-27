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
using TabIt.Views;

namespace TabIt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> projectNames { get; set; }
        private Project project { get; set; }
        private int ProjectTypeId { get; set; }
        public MainWindow()
        {
                InitializeComponent();
                this.projectNames = new List<string>();
            this.project = new Project();
        }

        public string SubmitButton { get; private set; }

        private void MenuItem_Click_New_Bass(object sender, RoutedEventArgs e)
        {
            this.ProjectHandler();
            this.ProjectTypeId = 0;
            
        }

       

        private void MenuItem_Click_New_Guitar(object sender, RoutedEventArgs e)
        {
            this.ProjectHandler();
            this.ProjectTypeId = 1;
        }

        private void MenuItem_Click_Open_Saved(object sender, RoutedEventArgs e)
        {
            HideProjectMenu();
            this.exitButton.Visibility = Visibility.Visible;
            ListView lv = new ListView();
            lv.Name = "ProjectListView";
            this.RegisterName(lv.Name, lv);
            lv.Background = Brushes.Transparent;
            lv.Width = 230;
            var projects = new ProjectRepository().GetProjects();

            // TODO: seperate guitar and bass projects in here
            foreach(var p in projects)
            {
                Button projectButton = new Button
                {
                    Height = 40,
                    Width = 218,
                    Name = "ProjectButton" + p.ProjectId.ToString(),
                    Content = p.ProjectName,
                    Background = (Brush)new BrushConverter().ConvertFrom("#FF3D3F48"),
                    BorderBrush = Brushes.Transparent,
                    Foreground = Brushes.White
                };
                this.RegisterName(projectButton.Name, projectButton);
                this.projectNames.Add(projectButton.Name);
                projectButton.Tag = p.ProjectId;
                projectButton.Click += ProjectButton_Click;
                lv.Items.Add(projectButton);
            }
            Grid.SetRow(lv, 5);
            Grid.SetColumnSpan(lv, 4);
            Grid.SetRowSpan(lv, 25);
            this.ProjectMenu.Children.Add(lv);

        }

        private void ProjectButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveListView();
            this.projectNames = new List<string>();
            var id = Convert.ToInt32(((Button)sender).Tag);
            project = new ProjectRepository().GetProject(id);

            if (project.ProjectTypeId == 0)
            {
                OpenBassProject(project);
            }
            if (project.ProjectTypeId == 1)
            {
                OpenGuitarProject(project);
            }
        }

        private void RemoveListView()
        {
            foreach (var n in projectNames)
            {
                this.UnregisterName(n);
            }
            var lv = (ListView)this.FindName("ProjectListView");
            this.ProjectMenu.Children.Remove(lv);
            this.UnregisterName(lv.Name);
        }

        private void OpenBassProject(Project p)
        {
            this.exitButton.Visibility = Visibility.Visible;
            BassProjectPage bassProjectPage = new BassProjectPage(p);
            ProjectFrame.Navigate(bassProjectPage);
            ShowProjectSidPanel(p);
        }

        private void OpenGuitarProject(Project p)
        {
            this.exitButton.Visibility = Visibility.Visible;
            GuitarProjectPage guitarProjectPage = new GuitarProjectPage(p);
            ProjectFrame.Navigate(guitarProjectPage);
            ShowProjectSidPanel(p);
        }

    

       

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)this.FindName("ProjectTextBox");
            if (tb.Text != "")
            {
                string pName = tb.Text;
                var project = new Models.Project
                {
                    ProjectName = pName,
                    ProjectTypeId = this.ProjectTypeId
                };
                ProjectRepository projectRepository = new ProjectRepository();
                var p = projectRepository.SaveProject(project);
                this.project = p;
                if(p.ProjectTypeId == 0)
                {
                    this.OpenBassProject(p);
                }
                if(p.ProjectTypeId == 1)
                {
                    this.OpenGuitarProject(p);
                }
                this.HideStuff();
            }
        }

        

        private void ShowProjectSidPanel(Project p)
        {
            TextBlock projectHeaderText = new TextBlock
            {
                Text = $"{p.ProjectName}",
                Margin = new Thickness(20),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Name = "ProjectHeaderText",
                TextAlignment = TextAlignment.Center,
                Foreground = Brushes.White
            };
            this.RegisterName(projectHeaderText.Name, projectHeaderText);

            Button editButton = new Button
            {
                Margin = new Thickness(20),
                Height = 30,
                Width = 150,
                Name = "ProjectEditButton",
                Content = "Edit",
                BorderBrush = Brushes.Transparent,
                Background = (Brush)new BrushConverter().ConvertFrom("#FF3D3F48"),
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Brushes.White

            };
            this.RegisterName(editButton.Name, editButton);
            editButton.Click += EditButton_Click;

            StackPanel stack = new StackPanel
            {
                Name = "SideNavStackPanel"
            };
            this.RegisterName(stack.Name, stack);
            stack.Children.Add(projectHeaderText);
            stack.Children.Add(editButton);
            Grid.SetColumn(stack, 0);
            Grid.SetColumnSpan(stack, 4);
            Grid.SetRow(stack, 5);
            Grid.SetRowSpan(stack, 20);
            this.ProjectMenu.Children.Add(stack);

        }

       

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.exitButton.Visibility = Visibility.Hidden;
            RemoveProjectSideNav();
            Button deleteButton = new Button
            {
                Name = "deleteButton",
                Width = 200,
                Height = 50,
                Background = (Brush)new BrushConverter().ConvertFrom("#FF3D3F48"),
                BorderBrush = Brushes.Transparent,
                Content = "DELETE",
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Foreground = Brushes.White

            };
            this.RegisterName(deleteButton.Name, deleteButton);
            deleteButton.Click += DeleteButton_Click;
            StackPanel stack = new StackPanel
            {
                Name = "EditStackPanel"
            };
            this.RegisterName(stack.Name, stack);
            stack.Children.Add(deleteButton);
            Grid.SetColumn(stack, 0);
            Grid.SetColumnSpan(stack, 4);
            Grid.SetRow(stack, 5);
            Grid.SetRowSpan(stack, 20);
            this.ProjectMenu.Children.Add(stack);


        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "ARE YOU SURE YOU WANT TO DELETE?";
            string caption = "dooomsssdayyyy buttonnnn";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    new ProjectRepository().DeleteProject(project);
                    RevertProjectMenu();
                    StackPanel stack = (StackPanel)FindName("EditStackPanel");
                    Button deleteButton = (Button)FindName("deleteButton");

                    this.ProjectMenu.Children.Remove(stack);
                    this.UnregisterName(stack.Name);
                    this.UnregisterName(deleteButton.Name);
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

      

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Are you sure you want to exit";
            string caption = "EXIT";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (FindName("SideNavStackPanel") != null)
                    {
                        RemoveProjectSideNav();
                    }
                    if (FindName("ProjectListView") != null)
                    {
                        RemoveListView();
                        this.projectNames = new List<string>();
                    }
                    if(FindName("SubmitStackPanel") != null)
                    {
                        this.HideStuff();
                    }
                    RevertProjectMenu();
                    this.exitButton.Visibility = Visibility.Hidden;
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }
        }

        private void RevertProjectMenu()
        {
            this.ProjectMenu.Children.Add(this.NewBassProject);
            this.ProjectMenu.Children.Add(this.NewGuitarProject);
            this.ProjectMenu.Children.Add(this.OpenSavedProjec);
            this.ClearFrame();
        }

        private void HideProjectMenu()
        {
            this.ProjectMenu.Children.Remove(this.NewBassProject);
            this.ProjectMenu.Children.Remove(this.NewGuitarProject);
            this.ProjectMenu.Children.Remove(this.OpenSavedProjec);

        }
        private void ClearFrame()
        {
            this.ProjectFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            this.ProjectFrame.NavigationService.RemoveBackEntry();
            this.ProjectFrame.Content = null;
        }

        private void RemoveProjectSideNav()
        {
            TextBlock block = (TextBlock)this.FindName("ProjectHeaderText");
            Button editButton = (Button)this.FindName("ProjectEditButton");
            StackPanel s = (StackPanel)this.FindName("SideNavStackPanel");
            this.ProjectMenu.Children.Remove(s);
            this.ProjectMenu.Children.Remove(block);
            this.ProjectMenu.Children.Remove(editButton);
            this.UnregisterName(block.Name);
            this.UnregisterName(editButton.Name);
            this.UnregisterName(s.Name);
        }

        private void HideStuff()
        {
            TextBox tb = (TextBox)this.FindName("ProjectTextBox");
            TextBlock block = (TextBlock)this.FindName("ProjectTextBlock");
            Button button = (Button)this.FindName("ProjectSubmitButton");
            StackPanel s = (StackPanel)this.FindName("SubmitStackPanel");
            this.ProjectMenu.Children.Remove(s);
            this.ProjectMenu.Children.Remove(tb);
            this.ProjectMenu.Children.Remove(block);
            this.ProjectMenu.Children.Remove(button);
            this.UnregisterName(tb.Name);
            this.UnregisterName(block.Name);
            this.UnregisterName(button.Name);
            this.UnregisterName(s.Name);


        }

        private void ProjectHandler()
        {
            this.HideProjectMenu();
            TextBlock projectText = new TextBlock
            {
                Text = "Create New Project",
                Margin = new Thickness(20),
                FontSize = 18,
                TextWrapping = TextWrapping.Wrap,
                Name = "ProjectTextBlock",
                Width = 200,
                Height = 50,
                Visibility = Visibility.Visible,
                TextAlignment = TextAlignment.Center,
                Foreground = Brushes.White
            };
            this.RegisterName(projectText.Name, projectText);

            TextBox textBox = new TextBox()
            {
                Height = 30,
                Width = 200,
                Margin = new Thickness(20),
                FontSize = 18,
                Name = "ProjectTextBox"
            };
            this.RegisterName(textBox.Name, textBox);
            Button submitButton = new Button
            {
                Margin = new Thickness(20),
                Height = 30,
                Width = 200,
                Name = "ProjectSubmitButton",
                Content = "Submit",
                Foreground = Brushes.White,
                BorderBrush = Brushes.Transparent,
                Background = (Brush)new BrushConverter().ConvertFrom("#FF3D3F48")

            };
            this.RegisterName(submitButton.Name, submitButton);
            submitButton.Click += SubmitButton_Click;

            StackPanel s = new StackPanel();
            s.Name = "SubmitStackPanel";
            this.RegisterName(s.Name, s);
            s.Children.Add(projectText);
            s.Children.Add(textBox);
            s.Children.Add(submitButton);
            Grid.SetColumn(s, 0);
            Grid.SetColumnSpan(s, 4);
            Grid.SetRow(s, 2);
            Grid.SetRowSpan(s, 20);
            this.ProjectMenu.Children.Add(s);
            this.exitButton.Visibility = Visibility.Visible;
        }
    }
}
