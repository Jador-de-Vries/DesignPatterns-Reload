using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DesignPatterns.UIElements
{
    class LeafControl : BaseControl
    {
        private readonly Shape _shape;
        public LeafControl(Shape shape)
        {
            Content = shape;
            _shape = shape;
            shape.Fill = Brushes.LightSteelBlue;
            shape.Stroke = Brushes.Black;
            shape.StrokeThickness = 1;
            shape.IsHitTestVisible = false;
            shape.Focusable = false;
        }

        public LeafControl(Shape shape, Brush fill)
        {
            Content = shape;
            shape.Fill = fill;
            shape.Stroke = Brushes.Black;
            shape.StrokeThickness = 1;
            shape.IsHitTestVisible = false;
            shape.Focusable = false;

        }

        public override string ToString()
        {
            string line = String.Empty;
            switch (_shape.ToString())
            {
                case "System.Windows.Shapes.Rectangle":
                    line += "rectangle ";
                    break;
                case "System.Windows.Shapes.Ellipse":
                    line += "ellipse ";
                    break;
                default: break;
            }
            line += $"{Canvas.GetLeft(this)} {Canvas.GetTop(this)} {Width} {Height}";
            return line;
        }
    }
}
