using DesignPatterns.UIElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitors
{
    /// <summary>
    /// Visitor interface, heeft definiëert methoden voor alle shapes
    /// </summary>
    public interface IVisit
    {
        /// <summary>
        /// Visitor methode voor een CompositeControl AKA group
        /// </summary>
        /// <param name="control">Groep die wordt meegegeven</param>
        void Visit(BaseControl control);

        ///// <summary>
        ///// Visitor methode voor een LeafControl AKA shape
        ///// </summary>
        ///// <param name="control">Shape die wordt meegegeven</param>
        //void VisitControl(LeafControl control);


    }
}
