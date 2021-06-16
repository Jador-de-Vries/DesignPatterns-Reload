using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern_in_a_canvas
{
    interface IComponent
    {
        List<IComponent> Children { get; }

        string ToString();

        string Serialize(string indent);
    }
}
