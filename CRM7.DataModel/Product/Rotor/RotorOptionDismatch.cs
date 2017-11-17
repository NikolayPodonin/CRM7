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
    /// Соответствие между моделями приводов и моделями опций.
    /// </summary>
    [Table(nameof(RotorOptionDismatch))]
    public class RotorOptionDismatch
    {
        /// <summary>
        /// Создает новый экземпляр RotorOptionDismatch.
        /// </summary>
        public RotorOptionDismatch()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid RotorModelId { get; set; }

        /// <summary>
        /// модель привода.
        /// </summary>
        public virtual RotorModel RotorModel { get; set; }

        public Guid RotorOptionModelId { get; set; }

        /// <summary>
        /// Модель опции привода.
        /// </summary>
        public virtual RotorOptionModel RotorOptionModel { get; set; }
    }
}
