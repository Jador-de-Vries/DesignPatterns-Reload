using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Project : CompositeControl
    {
        /// <summary>
        /// Laatst opgeslagen pad van het project
        /// </summary>
        private string projectPath = "";

        /// <summary>
        /// Lengte en hoogte van het canvas
        /// </summary>
        private int width, height;

        /// <summary>
        /// String array van de content in het project
        /// Wordt gebruikt voor het saven en loaden
        /// </summary>
        private List<string> contents;

        /// <summary>
        /// Constructor voor nieuwe projecten
        /// </summary>
        /// <param name="width">Lengte van het projectcanvas</param>
        /// <param name="height">Breedte van het projecanvas</param>
        public Project(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Constructor voor al bestaande projecten
        /// </summary>
        /// <param name="width">Lengte van het projectcanvas</param>
        /// <param name="height">Breedte van het projectcanvas</param>
        /// <param name="contents">String array van de contents die in het projectcanvas moeten staan</param>
        public Project(int width, int height, List<string> contents) : this(width, height)
        {
            this.contents = contents;
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public string ProjectPath
        {
            get { return projectPath; }
            set { projectPath = value; }
        }

        public List<string> Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        public void SetProjectContents(List<string> content)
        {
            this.Contents = content;
        }

        public void WriteToDisk()
        {
            File.WriteAllLines(ProjectPath, Contents);
        }

        public void PutToCanvas()
        {

        }
    }
}
