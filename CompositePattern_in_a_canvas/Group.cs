using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern_in_a_canvas
{
    class Group : IComponent
    {
        private List<IComponent> _children = new List<IComponent>();
        public List<IComponent> Children => _children;
        public override string ToString()
        {
            return $"Group {_children.Count()}";
        }

        public string Serialize(string indent = "")
        {
            string s = $"{indent}{this}\r\n";
            if(indent == "                    ") return s;
            indent += "  ";
            foreach(IComponent child in _children)
            {
               s += child.Serialize(indent);
            }
            return s;
        }
    }
}
