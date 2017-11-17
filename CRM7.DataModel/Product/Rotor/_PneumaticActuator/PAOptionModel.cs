using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product.Rotor
{
    /// <summary>
    /// Модель опции пневмопривода.
    /// </summary>
    [Table(nameof(RotorOptionModel))]
    public class PAOptionModel : RotorOptionModel
    {
        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public PAOptionModel CloneFrom(PAOptionModel transmitting)
        {
            base.CloneFrom(transmitting);
            return this;
        }
    }
}
