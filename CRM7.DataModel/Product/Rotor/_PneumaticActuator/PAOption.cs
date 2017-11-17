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
    /// Опция пневмопривода.
    /// </summary>
    [Table(nameof(RotorOption))]
    public class PAOption : RotorOption
    {
        /// <summary>
        /// Свойство опции
        /// </summary>
        public string PAOptionProperty { get; set; }

        /// <summary>
        /// Модель опции пенвмопривода.
        /// </summary>
        public new PAOptionModel Model
        {
            get
            {
                return (PAOptionModel)base.Model;
            }
            set
            {
                base.Model = value;
            }
        }
    }
}
