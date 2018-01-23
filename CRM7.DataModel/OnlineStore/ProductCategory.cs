using CRM7.DataModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.OnlineStore
{
    /// <summary>
    /// Категория продуктов.
    /// </summary>
    public class ProductCategory
    {
        public ProductCategory()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("CSS-иконка")]
        public string IconCssProperty { get; set; }

        /// <summary>
        /// Продукты категории.
        /// </summary>
        public virtual List<IProductModel> Products { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public ProductCategory CloneFrom(ProductCategory transmitting)
        {
            Name = transmitting.Name;
            IconCssProperty = transmitting.IconCssProperty;
            return this;
        }
    }
}
