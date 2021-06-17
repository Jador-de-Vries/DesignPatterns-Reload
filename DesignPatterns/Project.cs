using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Project
    {
        /// <summary>
        /// Laatst opgeslagen pad van het project
        /// </summary>
        private string _projectPath = "";
        public string ProjectPath
        {
            get { return _projectPath; }
            set { _projectPath = value; }
        }

        private static Project _instance = null;
        private static readonly object padlock = new object();
        /// <summary>
        /// Constructor voor nieuwe projecten
        /// </summary>
        /// <param name="width">Lengte van het projectcanvas</param>
        /// <param name="height">Breedte van het projecanvas</param>
        private Project() { }

        public static Project Instance
        {
            get
            {
                lock(padlock)
                {
                    if (_instance == null)
                        _instance = new Project();
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Schrijft een string naar het pad Project._projectPath
        /// </summary>
        /// <param name="content">String die geschreven moet worden</param>
        public void WriteToDisk(string content)
        {
            File.WriteAllText(_projectPath, content);
        }
    }
}
