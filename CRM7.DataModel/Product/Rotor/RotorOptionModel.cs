using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Management;
using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.OnlineStore;

namespace CRM7.DataModel.Product.Rotor
{
    /// <summary>
    /// Модель опции привода.
    /// </summary>
    [Table(nameof(RotorOptionModel))]
    public class RotorOptionModel : IProductModel
    {
        /// <summary>
        /// Создает новый экземпляр RotorOptionModel.
        /// </summary>
        public RotorOptionModel()
        {
            Id = Guid.NewGuid();
            RotorDismatches = new List<RotorOptionDismatch>();
            RotorOptionInCatalogs = new List<RotorOptionInCatalog>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public virtual Company Manufacturer { get; set; }

        /// <summary>
        /// Свойство модели
        /// </summary>
        public string Name { get; set; }

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
        /// Список приводов, которым подходит данная опция.
        /// </summary>
        public virtual ICollection<RotorOptionDismatch> RotorDismatches { get; set; }

        /// <summary>
        /// Позиции модели опций привода в каталогах.
        /// </summary>
        public virtual ICollection<RotorOptionInCatalog> RotorOptionInCatalogs { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public RotorOptionModel CloneFrom(RotorOptionModel transmitting)
        {
            Name = transmitting.Name;
            Length = transmitting.Length;
            Height = transmitting.Height;
            Mass = transmitting.Mass;
            ShortDesignation = transmitting.ShortDesignation;
            FullDesignation = transmitting.FullDesignation;
            Unit = transmitting.Unit;
            return this;
        }
    }
}
