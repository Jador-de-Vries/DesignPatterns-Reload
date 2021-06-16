using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CompositePattern_in_a_canvas
{
    class ShapeControl : ContentControl, IComponent
    {
        private Shape _shape;
        private string _shapeType;

        public List<IComponent> Children { get => null; }
        public ShapeControl(string shapeType, int x, int y, int w, int h)
        {
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
            Width = w;
            Height = y;
            _shapeType = shapeType;
            SetShape(shapeType);
        }

        public void SetShape(string shapeType)
        {
            switch (shapeType)
            {
                case "rectangle":
                    _shape = new Rectangle()
                    {
                        Fill = Brushes.LightBlue
                    };
                    break;
                case "ellipse":
                    _shape = new Ellipse()
                    {
                        Fill = Brushes.IndianRed
                    };
                    break;
            }
            Content = _shape;
        }

        public override string ToString()
        {
            Console.WriteLine($"SHAPE {_shapeType} {Canvas.GetLeft(this)} {Canvas.GetTop(this)} {this.Width} {this.Height}");
            return $"{_shapeType} {Canvas.GetLeft(this)} {Canvas.GetTop(this)} {this.Width} {this.Height}";
        }

        public string Serialize(string indent)
        {
            return $"{indent}{this}\r\n";
        }
    }
}
