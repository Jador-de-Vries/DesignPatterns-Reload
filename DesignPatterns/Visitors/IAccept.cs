using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitors
{
    /// <summary>
    /// the interface for the visitor
    /// </summary>
    public interface IAccept
    {
        /// <summary>
        /// Accepts a visitor
        /// </summary>
        /// <param name="visitor">the Visitor in question</param>
        void Accept(IVisit visitor);
    }
}
