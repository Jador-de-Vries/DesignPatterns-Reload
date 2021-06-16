using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns
{
    public interface ICommand
    {
        /// <summary>
        /// Methode voor het uitvoeren van een commando.
        /// </summary>
        void Execute();

        /// <summary>
        /// Methode voor het ongedaan maken van een commando.
        /// </summary>
        void Reverse();
    }
}