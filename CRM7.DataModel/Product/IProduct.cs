using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Product
{
    /// <summary>
    /// Интерфейс физически существующего продукта.
    /// </summary>
    public interface IProduct : IPriceable
    {        
        Guid? StorageId { get; set; }

        /// <summary>
        /// Склад.
        /// </summary>
        Storage Storage { get; set; }
    }
}
