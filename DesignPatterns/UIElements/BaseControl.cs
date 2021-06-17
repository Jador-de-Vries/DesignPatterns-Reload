using DesignPatterns.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace DesignPatterns.UIElements
{
    public abstract class BaseControl : ContentControl, IAccept
    {
        protected readonly List<BaseControl> _children = new List<BaseControl>();

        public List<BaseControl> Children => _children;

        public int X { get { return (int)Canvas.GetLeft(this); } }
        public int Y { get { return (int)Canvas.GetTop(this); } }
        
        
        public void Add(BaseControl component)
        {
            _children.Add(component);
        }

        public void Remove(BaseControl component)
        {
            _children.Remove(component);
        }

        public void Draw()
        {
            MainWindow.mainWindow.canvas.Children.Add(this);
        }

        public void Dispose()
        {
            MainWindow.mainWindow.canvas.Children.Remove(this);
        }

        public BaseControl GetChild(int noOfChild)
        {
            return _children[noOfChild];
        }

        /// <summary>
        /// Recursieve method voor het serialiseren van de groepenstructuur
        /// </summary>
        /// <param name="indent">Defaults naar 0× spaties, voegt twee spaties toe elke keer als de methode zichzelf heeft geroepen.</param>
        /// <returns>
        /// Group 2
        ///   rectangle...
        ///   rectangle...
        /// </returns>
        public string Serialize(string indent = "")
        {
            string s = $"{indent}{this}\r\n";
            if (indent == "                                        ") return s; // Als er 20 indents zijn is de recursie waarschijnlijk infinite, return s om een stackoverflow te voorkomen
            indent += "  ";
            foreach(BaseControl c in _children)
            {
                s += c.Serialize(indent);
            }
            return s;
        }

        public void Accept(IVisit visitor)
        {
            visitor.Visit(this);
        }

    }
}
