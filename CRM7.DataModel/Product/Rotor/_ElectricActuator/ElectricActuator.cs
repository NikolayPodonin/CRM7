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
    /// Электропривод.
    /// </summary>
    [Table(nameof(Rotor))]
    public class ElectricActuator : Rotor
    {
        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string EAProperty { get; set; }

        /// <summary>
        /// Модель электропривода.
        /// </summary>
        public new ElectricActuatorModel Model
        {
            get
            {
                return (ElectricActuatorModel)base.Model;
            }
            set
            {
                base.Model = value;
            }
        }
    }
}
