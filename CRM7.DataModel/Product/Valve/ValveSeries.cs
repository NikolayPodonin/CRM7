using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Серия арматуры.
    /// </summary>
    [Table(nameof(ValveSeries))]
    public class ValveSeries
    {
        public ValveSeries()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя серии.
        /// </summary>
        public string Name { get; set; }
    }
}