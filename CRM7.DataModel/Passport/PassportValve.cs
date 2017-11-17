using CRM7.DataModel.Files;
using CRM7.DataModel.Product.Valve;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Passport
{
    /// <summary>
    /// Пасспорт на арматуру.
    /// </summary>
    [Table(nameof(Passport))]
    public class PassportValve
    {
        public PassportValve()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid ValveId { get; set; }

        /// <summary>
        /// Арматура, на которую изготавливается пасспорт.
        /// </summary>
        public virtual Valve Valve { get; set; }
        
        public Guid FileId { get; set; }

        /// <summary>
        /// Паспорт в виде документа.
        /// </summary>
        public virtual File File { get; set; }
    }
}
