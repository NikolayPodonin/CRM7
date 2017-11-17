using CRM7.DataModel.Files;
using CRM7.DataModel.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Договор.
    /// </summary>
    [Table(nameof(Contract))]
    public class Contract
    {
        public Contract()
        {
            Id = Guid.NewGuid();
            Specifications = new List<Specification>();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now.AddYears(1);
        }

        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Номер договора.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата вступления в силу.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Дата окончания.
        /// </summary>
        public DateTime EndDate { get; set; }

        public Guid ContragentOrganizationId { get; set; }

        /// <summary>
        /// Компания-контрагент.
        /// </summary>
        public virtual Facility ContragentOrganization { get; set; }

        public Guid MakerOrganizationId { get; set; }

        /// <summary>
        /// Компания-создатель.
        /// </summary>
        public virtual Facility MakerOrganization { get; set; }

        public Guid MakerId { get; set; }

        /// <summary>
        /// Создатель.
        /// </summary>
        public virtual Contact Maker { get; set; }

        public Guid? RecipientId { get; set; }

        /// <summary>
        /// Получатель.
        /// </summary>
        public virtual Contact Recipient { get; set; }

        /// <summary>
        /// Спецификации.
        /// </summary>
        public virtual ICollection<Specification> Specifications { get; set; }
        
        public Guid? FileId { get; set; }

        /// <summary>
        /// Контракт в виде документа.
        /// </summary>
        public virtual File File { get; set; }
    }
}
