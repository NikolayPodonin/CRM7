using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Тип трубопроводной арматуры (запорного элемента).
    /// </summary>
    [Table(nameof(ValveType))]
    public class ValveType
    {
        /// <summary>
        /// Создает новый экземпляр ValveType.
        /// </summary>
        public ValveType()
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
        public ValveType CloneFrom(ValveType transmitting)
        {
            Name = transmitting.Name;
            return this;
        }
    }
}
