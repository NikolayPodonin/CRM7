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
    /// Ручной редуктор.
    /// </summary>
    [Table(nameof(Rotor))]
    public class ManualGear : Rotor
    {
        /// <summary>
        /// Свойство продукта
        /// </summary>
        public string MGProperty { get; set; }

        /// <summary>
        /// Модель ручного редуктора.
        /// </summary>
        public new ManualGearModel Model
        {
            get
            {
                return (ManualGearModel)base.Model;
            }
            set
            {
                base.Model = value;
            }
        }
    }
}
