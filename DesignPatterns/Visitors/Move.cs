using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatterns.Visitors
{
    class Move : IVisit
    {
        Point _position;
        public Move(Point position)
        {
            _position = position;
        }
        public void Visit(BaseControl control)
        {
            Canvas.SetLeft(control, _position.X);
            Canvas.SetTop(control, _position.Y);
        }
    }
}
