using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Commands
{
    class LoadProject : ICommand
    {
        private string path;
        public LoadProject(string path)
        {
            this.path = path;
        }
        public void Execute()
        {

        }

        public void Reverse()
        {
            // Leeg, je kan geen LoadFile reversen.
        }
    }
}
