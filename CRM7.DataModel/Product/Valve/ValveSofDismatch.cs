using CRM7.DataModel.Product.SOF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Соответствие между моделями КОФ и моделями трубопроводной арматуры.
    /// </summary>
    [Table(nameof(ValveSofDismatch))]
    public class ValveSofDismatch
    {
        /// <summary>
        /// Создает новый экземпляр ValveSofDismatch.
        /// </summary>
        public ValveSofDismatch()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid SofModelId { get; set; }

        /// <summary>
        /// Модель КоФ.
        /// </summary>
        public virtual SofModel SofModel { get; set; }

        public Guid ValveModelId { get; set; }

        /// <summary>
        /// Модель трубопроводной арматуры.
        /// </summary>
        public virtual ValveModel ValveModel { get; set; }
    }
}
