using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Commands
{
    public class CommandInvoker
    {
        private readonly Stack<ICommand> commands = new Stack<ICommand>();
        public Stack<ICommand> Commands => commands;

        private readonly Stack<ICommand> undoCommands = new Stack<ICommand>();
        public void ExecuteCommand(ICommand command)
        {
            if (!(command is SaveProject))
            {
                commands.Push(command);
            }
            command.Execute();
            if (undoCommands.Count != 0)
                undoCommands.Clear();
        }

        public void UndoCommand()
        {
            if (commands.Count == 0) return;

            var pop = commands.Pop();
            pop.Reverse();
            undoCommands.Push(pop);
        }

        public void RedoCommand()
        {
            if (undoCommands.Count == 0) return;

            var pop = undoCommands.Pop();
            pop.Execute();
            commands.Push(pop);
        }

        public void ClearUndoCommands()
        {
            undoCommands.Clear();
        }
    }
}