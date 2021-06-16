using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DesignPatterns.UIElements
{
    public class CompositeControl : BaseControl
    {
        public override string ToString()
        {
            return $"group {_children.Count()}";
        }
    }
}
