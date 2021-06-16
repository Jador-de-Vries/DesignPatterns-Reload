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

namespace CompositePattern_in_a_canvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Group _base = new Group();
        public MainWindow()
        {
            InitializeComponent();
            ShapeControl rectangle = new ShapeControl("rectangle", 10, 20, 100, 50);
            ShapeControl ellipse = new ShapeControl("ellipse", 10, 40, 20, 30);
            ShapeControl ellipseOutsideGroup = new ShapeControl("ellipse", 100, 64, 150, 320);
            Group rectlipse = new Group();
            _base.Children.Add(rectlipse);
            rectlipse.Children.Add(rectangle);
            rectlipse.Children.Add(ellipse);
            canvas.Children.Add(rectangle);
            canvas.Children.Add(ellipse);
            canvas.Children.Add(ellipseOutsideGroup);
            _base.Children.Add(ellipseOutsideGroup);

            Console.WriteLine(_base.Serialize());
        }
    }
}
