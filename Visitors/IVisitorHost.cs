using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabacchiFinale.Visitors
{
    public interface IVisitorHost
    {
        void Accept(IVisitor visitor);
    }
}
