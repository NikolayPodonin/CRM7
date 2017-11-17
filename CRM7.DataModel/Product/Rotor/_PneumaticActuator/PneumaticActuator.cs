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
    /// Пневмопривод.
    /// </summary>
    [Table(nameof(Rotor))]
    public class PneumaticActuator : Rotor
    {
        /// <summary>
        /// Свойство продукта
        /// </summary>
        public string PAProperty { get; set; }

        /// <summary>
        /// Модель пневмопривода.
        /// </summary>
        public new PneumaticActuatorModel Model
        {
            get
            {
                return (PneumaticActuatorModel)base.Model;
            }
            set
            {
                base.Model = value;
            }
        }
    }
}
