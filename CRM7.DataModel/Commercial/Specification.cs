using CRM7.DataModel.Commercial;
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
    /// Спецификация к договору.
    /// </summary>
    [Table(nameof(Specification))]
    public class Specification
    {
        public Specification()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Invoices = new List<Invoice>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер спецификации к одному договору.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Выставлено счетов на..
        /// </summary>
        public decimal Invoiced()
        {
            decimal invoiced = 0;
            foreach(Invoice inv in Invoices)
            {
                invoiced += inv.Cost;
            }
            return invoiced;
        }

        /// <summary>
        /// Заплачено по счетам..
        /// </summary>
        public decimal Payed()
        {
            decimal payed = 0;
            foreach (Invoice inv in Invoices)
            {
                payed += inv.PayedCost;
            }
            return payed;
        }

        /// <summary>
        /// Отгружено или нет.
        /// </summary>
        public bool Delivered { get; set; }

        public Guid ContractId { get; set; }
        
        /// <summary>
        /// Договор, к которому создана спецификация.
        /// </summary>
        public virtual Contract Contract { get; set; }

        public Guid ProposalId { get; set; }

        /// <summary>
        /// КП, по которому создана спецификация.
        /// </summary>
        public virtual Proposal Proposal { get; set; }

        /// <summary>
        /// Выставленные счета.
        /// </summary>
        public virtual ICollection<Invoice> Invoices { get; set; }

        public Guid? MakerOrganizationId { get; set; }

        /// <summary>
        /// Компания, которая выставляет спецификацию.
        /// </summary>
        public virtual Facility MakerOrganization { get; set; }

        public Guid MakerId { get; set; }

        /// <summary>
        /// Создатель спецификации.
        /// </summary>
        public virtual Contact Maker { get; set; }

        public Guid? ContragentOrganizationId { get; set; }

        /// <summary>
        /// Компания, которой выставляется спецификация.
        /// </summary>
        public virtual Facility ContragentOrganization { get; set; }

        public Guid? RecipientId { get; set; }

        /// <summary>
        /// Представитель компании-контрагента.
        /// </summary>
        public virtual Contact Recipient { get; set; }

        public Guid? FileId { get; set; }

        /// <summary>
        /// Спецификация в виде документа.
        /// </summary>
        public virtual File File { get; set; }
    }
}
