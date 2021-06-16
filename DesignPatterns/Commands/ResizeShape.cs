using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace DesignPatterns.Commands
{
    class ResizeShape : ICommand
    {
        private readonly BaseControl _shape;
        private readonly Point _oldPosition, _newPosition;
        private readonly double _oldWidth, _oldHeight, _newWidth, _newHeight;

        public ResizeShape(BaseControl shape, Point oldPosition, Point newPosition, double oldWidth, double oldHeight, double newWidth, double newHeight)
        {
            _shape = shape;
            _oldPosition = oldPosition;
            _newPosition = newPosition;
            _oldWidth = oldWidth;
            _oldHeight = oldHeight;
            _newWidth = newWidth;
            _newHeight = newHeight;
        }
        public void Execute()
        {
            Canvas.SetLeft(_shape, _newPosition.X);
            Canvas.SetTop(_shape, _newPosition.Y);
            _shape.Width = _newWidth;
            _shape.Height = _newHeight;
            Console.WriteLine($"[ACTION] Shape resized. new Dimensions: ({_newPosition}), new Width: {_newWidth}, new Height: {_newHeight}");
        }

        public void Reverse()
        {
            Canvas.SetLeft(_shape, _oldPosition.X);
            Canvas.SetTop(_shape, _oldPosition.Y);
            _shape.Width = _oldWidth;
            _shape.Height = _oldHeight;
            Console.WriteLine("[UNDO] Shape un-resized.");
        }
    }
}
