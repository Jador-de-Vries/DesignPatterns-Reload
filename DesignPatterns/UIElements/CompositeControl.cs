using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DesignPatterns.UIElements
{
    public class CompositeControl : BaseControl
    {
        System.Windows.Controls.Canvas _grid;

        // TODO: Zorgen dat deze composite control straks alle shapes bevat (maybe in een grid)
        // zodat deze niet meer apart bewogen kunnen worden
        public CompositeControl()
        {
            
        }

        public CompositeControl(List<BaseControl> selection)
        {
            _children.AddRange(selection);
            _grid = new System.Windows.Controls.Canvas();
            foreach(BaseControl c in _children)
            {
                _grid.Children.Add(c);
            }
            Content = _grid;
            
        }

        public override string ToString()
        {
            return $"group {_children.Count()}";
        }
    }
}
