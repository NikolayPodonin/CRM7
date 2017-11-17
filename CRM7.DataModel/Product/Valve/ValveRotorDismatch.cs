using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM7.DataModel.Product.Rotor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Соответствие между моделями приводов и моделями трубопроводной арматуры.
    /// </summary>
    [Table(nameof(ValveRotorDismatch))]
    public class ValveRotorDismatch
    {
        /// <summary>
        /// Создает новый экземпляр ValveRotorDismatch.
        /// </summary>
        public ValveRotorDismatch()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid RotorModelId { get; set; }

        /// <summary>
        /// Модель привода.
        /// </summary>
        public virtual RotorModel RotorModel { get; set; }

        public Guid ValveModelId { get; set; }

        /// <summary>
        /// Модель трубопроводной арматуры.
        /// </summary>
        public virtual ValveModel ValveModel { get; set; }
    }
}
