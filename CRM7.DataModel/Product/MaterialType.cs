using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product
{
    /// <summary>
    /// Тип материала.
    /// </summary>
    [Table(nameof(MaterialType))]
    public class MaterialType
    {
        /// <summary>
        /// Создает новый экземпляр MaterialType.
        /// </summary>
        public MaterialType()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public MaterialType CloneFrom(MaterialType transmitting)
        {
            Name = transmitting.Name;
            return this;
        }
    }
}
