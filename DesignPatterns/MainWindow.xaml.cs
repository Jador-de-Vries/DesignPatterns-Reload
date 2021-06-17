using Microsoft.Win32;
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

using DesignPatterns.Commands;
using DesignPatterns.UIElements;

namespace DesignPatterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Project project;
        public static MainWindow mainWindow;

        public MainWindow()
        {
            InitializeComponent();
            project = new Project(800, 600);
            mainWindow = this;
            canvas.Width = project.Width;
            canvas.Height = project.Height;
        }

        private void Menu_Shapes_Rectangle_Click(object sender, RoutedEventArgs e)
        {
            canvas.CursorMode = CursorState.Creator;
            canvas.DrawingShape = ShapeType.Rectangle;
        }
        private void Menu_Shapes_Circle_Click(object sender, RoutedEventArgs e)
        {
            canvas.CursorMode = CursorState.Creator;
            canvas.DrawingShape = ShapeType.Ellipse;
        }

        private void Menu_File_SaveProject_Click(object sender, RoutedEventArgs e)
        {
            if (project.ProjectPath == String.Empty || project.ProjectPath == null)
            {
                Menu_File_SaveProjectAs_Click(sender, e);
            }
            else
            {
                //project.Contents = canvas.SerializeCanvas();
                canvas.Invoker.ExecuteCommand(new SaveProject());
            }
        }

        private void Menu_File_SaveProjectAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "LePaint file (*.lepaint)|*.lepaint",
                RestoreDirectory = true
            };
            if (sfd.ShowDialog() == true)
            {
                Console.WriteLine(sfd.FileName);
                project.ProjectPath = sfd.FileName;
                Menu_File_SaveProject_Click(sender, e);
            }
        }

        private void Menu_File_LoadProject_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "LePaint file (*.lepaint)|*.lepaint"
            };
            if (ofd.ShowDialog() == true)
            {
                canvas.Children.Clear();
                canvas.Invoker.ClearUndoCommands();
                // Project newProject = Project.Load(ofd.FileName);
                // InitializeProject(newProject);
            }
        }

        private void Menu_Edit_Undo_Click(object sender, RoutedEventArgs e)
        {
            canvas.Invoker.UndoCommand();
        }

        private void Menu_Shapes_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (FocusManager.GetFocusedElement(canvas) is BaseControl shape)
            {
                Console.WriteLine(shape);
                canvas.Invoker.ExecuteCommand(new DeleteShape(shape, canvas));
            }
        }

        private void Menu_Edit_Redo_Click(object sender, RoutedEventArgs e)
        {
            canvas.Invoker.RedoCommand();
        }

        private void CanvasWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HistoryWindow historyWindow = new HistoryWindow
            {
                ShowInTaskbar = false,
                Owner = this
            };
            historyWindow.Show();
        }

        private void MergeSelection_Click(object sender, RoutedEventArgs e)
        {
            canvas.Invoker.ExecuteCommand(new MergeToGroup(canvas.Selection));
        }

        private void ShowGroup_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
