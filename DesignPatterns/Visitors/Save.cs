using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitors
{
    class Save : IVisit
    {
        public void Visit(BaseControl control)
        {
            Project.Instance.WriteToDisk(control.Serialize());
        }
    }
}
