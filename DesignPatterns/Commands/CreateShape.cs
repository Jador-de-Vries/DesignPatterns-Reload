using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatterns.Commands
{
    /// <summary>
    /// Commando voor het maken van een shape.
    /// </summary>
    class CreateShape : ICommand
    {
        private readonly Canvas _canvas;
        private readonly Type _shapeType;
        private readonly Point _startPoint;
        private readonly int _width, _height;
        private readonly BaseControl _shape;

        public CreateShape(Canvas canvas, Type shapeType, Point startPoint, int width, int height)
        {
            _shapeType = shapeType;
            _startPoint = startPoint;
            _width = width;
            _height = height;
            _canvas = canvas;
            _shape = _canvas.CreateShape(_shapeType, _startPoint, _width, _height);
        }

        public void Execute()
        {
            _canvas.Children.Add(_shape);
            Console.WriteLine($"[ACTION] Created shape {_shape.Content}");
        }

        public void Reverse()
        {
            _canvas.Children.Remove(_shape);
            Console.WriteLine($"[UNDO] Deleted shape {_shape.Content}");
        }
    }
}
