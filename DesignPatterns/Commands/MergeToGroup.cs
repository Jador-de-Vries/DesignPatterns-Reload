using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DesignPatterns.Commands
{
    class MergeToGroup : ICommand
    {
        private readonly List<BaseControl> _selection;
        private CompositeControl _group;
        public MergeToGroup(List<BaseControl> selection)
        {
            _selection = selection;
        }

        public void Execute()
        {
            //Remove items from selection from canvas
            foreach (BaseControl item in _selection)
            {
                MainWindow.mainWindow.canvas.Group.Remove(item);
                MainWindow.mainWindow.canvas.Children.Remove(item);
            }

            int x = _selection.OrderBy(c => c.X).First().X;
            int y = _selection.OrderBy(c => c.Y).First().Y;
            BaseControl lastX = _selection.OrderBy(c => c.X).Last();
            BaseControl lastY = _selection.OrderBy(c => c.Y).Last();
            int w = (int)(lastX.X - x + lastX.Width);
            int h = (int)(lastY.Y - y + lastY.Height);

            CompositeControl _group = MainWindow.mainWindow.canvas.CreateShape(ShapeType.Group, new System.Windows.Point(x, y), w, h) as CompositeControl;

            MainWindow.mainWindow.canvas.Children.Add(_group);
        }

        public void Reverse()
        {
            MainWindow.mainWindow.canvas.Children.Remove(_group);
            MainWindow.mainWindow.canvas.Group.Remove(_group);
            foreach (BaseControl item in _selection)
            {
                MainWindow.mainWindow.canvas.Group.Add(item);
            }
        }
    }
}
