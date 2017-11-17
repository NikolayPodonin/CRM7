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
    /// Опция электропривода.
    /// </summary>
    [Table(nameof(RotorOption))]
    public class EAOption : RotorOption
    {
        /// <summary>
        /// Свойство продукта
        /// </summary>
        public string EAOptionProperty { get; set; }

        /// <summary>
        /// Модель опции электропривода.
        /// </summary>
        public new EAOptionModel Model
        {
            get
            {
                return (EAOptionModel)base.Model;
            }
            set
            {
                base.Model = value;
            }
        }
    }
}
