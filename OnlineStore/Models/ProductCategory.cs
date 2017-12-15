using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class ProductCategory
    {
        public Guid UserId { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("CSS-иконка")]
        public string IconCssProperty { get; set; }
    }
}