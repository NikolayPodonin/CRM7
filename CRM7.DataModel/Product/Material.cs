using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product
{
    /// <summary>
    /// Материал.
    /// </summary>
    [Table(nameof(Material))]
    public class Material
    {
        /// <summary>
        /// Создает новый экземпляр Material.
        /// </summary>
        public Material()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid TypeId { get; set; }

        /// <summary>
        /// Тип материала.
        /// </summary>
        public virtual MaterialType Type { get; set; }

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
        public Material CloneFrom(Material transmitting)
        {
            Name = transmitting.Name;
            return this;
        }
    }
}
