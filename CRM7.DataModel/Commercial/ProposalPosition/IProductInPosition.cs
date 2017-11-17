using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Commercial
{
    public interface IProductInPosition : IPriceable
    {
        ProposalPosition Position { get; set; }
    }
}
