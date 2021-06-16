using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DesignPatterns.UIElements
{
    public abstract class BaseControl : ContentControl
    {
        protected readonly List<BaseControl> _children = new List<BaseControl>();

        public List<BaseControl> Children => _children;


        public void Add(BaseControl component)
        {
            _children.Add(component);
        }

        public void Remove(BaseControl component)
        {
            _children.Remove(component);
        }

        public void Draw()
        {
            MainWindow.mainWindow.canvas.Children.Add(this);
        }

        public void Dispose()
        {
            MainWindow.mainWindow.canvas.Children.Remove(this);
        }

        public BaseControl GetChild(int noOfChild)
        {
            return _children[noOfChild];
        }

        public void Display(string indent = "", bool top = true)
        {
            if (top)
            {
                if (_children.Count > 1)
                {
                    Console.WriteLine($"Group {_children.Count}");
                }
            }
            indent += "  ";
            foreach(var child in _children)
            {
                if (child.Children.Count <= 0)
                {
                    Console.WriteLine($"{indent}{child}");
                }
                else
                {
                    Console.WriteLine($"{indent}{child}");
                    Console.WriteLine($"{indent}Group {child.Children.Count}");
                    child.Display(indent, false);
                }
            }
        }

    }
}
