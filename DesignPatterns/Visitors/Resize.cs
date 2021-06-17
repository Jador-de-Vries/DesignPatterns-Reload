using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatterns.Visitors
{
    class Resize : IVisit
    {
        Point _newPosition;
        double _newWidth, _newHeight;

        public Resize(double newWidth, double newHeight, Point newPosition)
        {
            _newWidth = newWidth;
            _newHeight = newHeight;
            _newPosition = newPosition;
        }

        public void Visit(BaseControl control)
        {
            Canvas.SetLeft(control, _newPosition.X);
            Canvas.SetTop(control, _newPosition.Y);
            control.Width = _newWidth;
            control.Height = _newHeight;
        }
    }
}
