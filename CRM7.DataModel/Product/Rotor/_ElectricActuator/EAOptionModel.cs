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
    /// Модель опции электропривода.
    /// </summary>
    [Table(nameof(RotorOptionModel))]
    public class EAOptionModel : RotorOptionModel
    {
        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public EAOptionModel CloneFrom(EAOptionModel transmitting)
        {
            base.CloneFrom(transmitting);
            return this;
        }
    }
}
