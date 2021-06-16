using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Commands
{
    class MergeToGroup : ICommand
    {
        private readonly List<BaseShape> _selection;
        private readonly BaseShape _parent;
        public MergeToGroup(List<BaseShape> selection, BaseShape parent)
        {
            _selection = selection;
            _parent = parent;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
