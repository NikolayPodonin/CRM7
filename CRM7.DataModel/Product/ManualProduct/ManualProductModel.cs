using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Management;
using CRM7.DataModel.OnlineStore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Product
{
    /// <summary>
    /// Модель продукта, добавленная вручную.
    /// </summary>
    [Table(nameof(ManualProductModel))]
    public class ManualProductModel : IProductModel
    {
        public ManualProductModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public virtual Company Manufacturer { get; set; }

        /// <summary>
        /// Длина, мм.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Высота, мм.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Масса, кг.
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Короткое описание.
        /// </summary>
        public string ShortDesignation { get; set; }

        /// <summary>
        /// Полное описание.
        /// </summary>
        public string FullDesignation { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string Unit { get; set; }

        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория продукта.
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Позиции модели арматуры в каталогах.
        /// </summary>
        public virtual ICollection<ManualProductInCatalog> ManualProductInCatalogs { get; set; }
    }
}
