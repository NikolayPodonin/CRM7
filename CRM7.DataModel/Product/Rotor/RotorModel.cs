using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Product.Valve;
using CRM7.DataModel.Management;
using CRM7.DataModel.Catalog.CatalogPosition;

namespace CRM7.DataModel.Product.Rotor
{
    /// <summary>
    /// Модель привода.
    /// </summary>
    [Table(nameof(RotorModel))]
    public class RotorModel : IProductModel
    {
        /// <summary>
        /// Создает новый экземпляр RotorModel.
        /// </summary>
        public RotorModel()
        {
            Id = Guid.NewGuid();
            OptionDismatches = new List<RotorOptionDismatch>();
            ValveDismatches = new List<ValveRotorDismatch>();
            RotorInCatalogs = new List<RotorInCatalog>();
        }

        [Key]
        public Guid Id { get; set; }


        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public virtual Company Manufacturer { get; set; }

        public Guid TypeId { get; set; }

        /// <summary>
        /// Тип ротора.
        /// </summary>
        public virtual RotorType Type { get; set; }

        /// <summary>
        /// Название.
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

        /// <summary>
        /// Список опций, которые подходят для данного привода.
        /// </summary>
        public virtual List<RotorOptionDismatch> OptionDismatches { get; set; }

        /// <summary>
        /// Список арматуры, для которой подходит данный привод.
        /// </summary>
        public virtual List<ValveRotorDismatch> ValveDismatches { get; set; }

        /// <summary>
        /// Позиции модели привода в каталогах.
        /// </summary>
        public virtual ICollection<RotorInCatalog> RotorInCatalogs { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public RotorModel CloneFrom(RotorModel transmitting)
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
