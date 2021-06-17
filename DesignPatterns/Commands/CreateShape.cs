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
        private readonly ShapeType _shapeType;
        private readonly Point _startPoint;
        private readonly int _width, _height;
        private readonly BaseControl _shape;

        public CreateShape(ShapeType shapeType, Point startPoint, int width, int height)
        {
            _shapeType = shapeType;
            _startPoint = startPoint;
            _width = width;
            _height = height;
            _shape = MainWindow.mainWindow.canvas.CreateShape(_shapeType, _startPoint, _width, _height);
        }

        public void Execute()
        {
            _shape.Draw();
            Console.WriteLine($"[ACTION] Created shape {_shape.Content}");
        }

        public void Reverse()
        {
            _shape.Dispose();
            Console.WriteLine($"[UNDO] Deleted shape {_shape.Content}");
        }
    }
}
