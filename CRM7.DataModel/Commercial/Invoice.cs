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
    /// Счет.
    /// </summary>
    [Table(nameof(Invoice))]
    public class Invoice
    {
        /// <summary>
        /// Платежный тип счета: полный; предварительный и окончательный.
        /// </summary>
        public enum PaymentTypes { Full, Advance, Final }

        public Invoice()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Номер счета по порядку.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата выставления.
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Уплаченная стоимость.
        /// </summary>
        public decimal PayedCost { get; set; }

        /// <summary>
        /// Себестоимость.
        /// </summary>
        public decimal SelfCost { get; set; }

        /// <summary>
        /// Произведена ли отгрузка.
        /// </summary>
        public bool Delivered { get; set; }

        /// <summary>
        /// Аннулирован ли.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Оплачен ли.
        /// </summary>
        public bool Payed { get; set; }

        /// <summary>
        /// Платежный тип счета: полный; предварительный и окончательный.
        /// </summary>
        public PaymentTypes PaymentType { get; set; }
        
        public Guid MakerId { get; set; }
        
        /// <summary>
        /// Создатель счета.
        /// </summary>
        public virtual Contact Maker { get; set; }

        public Guid MakerOrganizationId { get; set; }

        /// <summary>
        /// Компания-создатель счета.
        /// </summary>
        public virtual Facility MakerOrganization { get; set; }

        public Guid ContragentOrganizationId { get; set; }

        /// <summary>
        /// Компания-контрагент.
        /// </summary>
        public virtual Facility ContragentOrganization { get; set; }

        public Guid? SpecificationId { get; set; }

        /// <summary>
        /// Спецификация, по которой выставлен счет.
        /// </summary>
        public virtual Specification Specification { get; set; }

        public Guid? ProposalId { get; set; }

        /// <summary>
        /// Предложение, по которому выставлен счет.
        /// </summary>
        public virtual Proposal Proposal { get; set; }
        
        public Guid FileId { get; set; }

        /// <summary>
        /// Счет в виде документа.
        /// </summary>
        public virtual File File { get; set; }
    }
}
