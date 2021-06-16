using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Commands
{
    class DeleteShape : ICommand
    {
        private readonly BaseControl _shape;
        private readonly Canvas _canvas;

        public DeleteShape(BaseControl shape, Canvas canvas)
        {
            _shape = shape;
            _canvas = canvas;
        }
        public void Execute()
        {
            Console.WriteLine($"[ACTION] Deleted shape {_shape.Content}");
            _canvas.Children.Remove(_shape);
        }

        public void Reverse()
        {
            Console.WriteLine($"[UNDO] Re-Created shape {_shape.Content}");
            _canvas.Children.Add(_shape);
        }
    }
}
