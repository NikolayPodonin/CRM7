using CRM7.DataModel.OnlineStore;
using CRM7.DataModel.Catalog.CatalogPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class UniversalViewModel
    {
        public List<ProductCategory> Categories { get; set; }
        public List<ICatalogPosition> Products { get; set; }
    }
}