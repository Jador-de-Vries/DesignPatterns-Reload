using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DesignPatterns;

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
            _shape.Accept(new Visitors.Move(_end));
            Console.WriteLine($"[ACTION] Set shape to: ({_end})");
        }

        public void Reverse()
        {
            _shape.Accept(new Visitors.Move(_start));
            Console.WriteLine($"[UNDO] Set shape back to: ({_start})");
        }
    }
}
