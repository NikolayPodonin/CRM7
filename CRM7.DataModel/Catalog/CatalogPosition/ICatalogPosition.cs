using CRM7.DataModel.Files;
using CRM7.DataModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Catalog.CatalogPosition
{
    public interface ICatalogPosition : IPriceable
    {
        Guid? ImageId { get; set; }

        File Image { get; set; }
    }
}
