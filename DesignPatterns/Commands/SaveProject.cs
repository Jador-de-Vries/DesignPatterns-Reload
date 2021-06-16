/**
 * @author Jador de Vries
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Commands
{
    /// <summary>
    /// Commandoklasse om het project naar een bestand te "printen"
    /// </summary>
    class SaveProject : ICommand
    {
        private readonly Project project;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="project">De projectdata</param>
        public SaveProject(Project project)
        {
            this.project = project;
        }

        /// <summary>
        /// Voert de Project.WriteToDisk functie uit.
        /// </summary>
        public void Execute()
        {
            project.WriteToDisk();
        }

        /// <summary>
        /// Actie is niet reversable, method toch nodig om ICommand volledig te implementeren.
        /// </summary>
        public void Reverse()
        {
            // Actie is niet reversable
        }
    }
}
