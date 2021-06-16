using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatterns.Commands
{
    class MoveShape : ICommand
    {
        private readonly BaseControl _shape;
        private readonly Point _start, _end;

        public MoveShape(BaseControl shape, Point start, Point end)
        {
            _shape = shape;
            _start = start;
            _end = end;
        }
        public void Execute()
        {
            Canvas.SetLeft(_shape, _end.X);
            Canvas.SetTop(_shape, _end.Y);
            Console.WriteLine($"[ACTION] Set shape to: ({_end})");
        }

        public void Reverse()
        {
            Canvas.SetLeft(_shape, _start.X);
            Canvas.SetTop(_shape, _start.Y);
            Console.WriteLine($"[UNDO] Set shape back to: ({_start})");
        }
    }
}
