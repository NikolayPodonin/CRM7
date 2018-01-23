using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Management;
using CRM7.DataModel.OnlineStore;
using CRM7.DataModel.Product.Valve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Product.SOF
{
    /// <summary>
    /// Модель фланцев.
    /// </summary>
    [Table(nameof(SofModel))]
    public class SofModel : IProductModel
    {
        public SofModel()
        {
            Id = Guid.NewGuid();
            ValveDismatches = new List<ValveSofDismatch>();
            SofInCatalogs = new List<SofInCatalog>();
        }

        [Key]
        public Guid Id { get; set; }

        #region IProductModel

        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public Company Manufacturer { get; set; }

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

        #endregion

        /// <summary>
        /// Список арматуры, на которую можно поставить эти фланцы
        /// </summary>
        public virtual ICollection<ValveSofDismatch> ValveDismatches { get; set; }

        /// <summary>
        /// Позиции модели фланцев в каталогах.
        /// </summary>
        public virtual ICollection<SofInCatalog> SofInCatalogs { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        public Guid CategoryId { get; set; }

        /// <summary>
        /// Категория продукта.
        /// </summary>
        public virtual ProductCategory Category { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public SofModel CloneFrom(SofModel transmitting)
        {
            Name = transmitting.Name;
            return this;
        }
    }
}
