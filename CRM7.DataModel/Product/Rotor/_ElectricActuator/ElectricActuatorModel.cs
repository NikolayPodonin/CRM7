using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product.Rotor
{
    /// <summary>
    /// Модель электропривода.
    /// </summary>
    [Table(nameof(RotorModel))]
    public class ElectricActuatorModel : RotorModel
    {
        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public ElectricActuatorModel CloneFrom(ElectricActuatorModel transmitting)
        {
            base.CloneFrom(transmitting);
            return this;
        }
    }
}
