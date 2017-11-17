using CRM7.DataModel.Commercial;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Management
{
    /// <summary>
    /// Производственный объект или отдел.
    /// </summary>
    [Table(nameof(Facility))]
    public class Facility
    {
        public Facility()
        {
            Id = Guid.NewGuid();
            Posts = new List<Post>();
            ExternalProposals = new List<Proposal>();
            InternalProposals = new List<Proposal>();
            ExternalSpecifications = new List<Specification>();
            InternalSpecifications = new List<Specification>();
            ExternalContracts = new List<Contract>();
            InternalContracts = new List<Contract>();
            ExternalInvoices = new List<Invoice>();
            InternalInvoices = new List<Invoice>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Короткое название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Полное название.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public string PostAddress { get; set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Факс.
        /// </summary>
        public string FAX { get; set; }

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Сайт.
        /// </summary>
        public string Web { get; set; }

        public Guid? ParentObjectId { get; set; }

        /// <summary>
        /// Компания.
        /// </summary>
        public virtual Facility ParentObject { get; set; }

        /// <summary>
        /// Список сотрудников отдела.
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }

        /// <summary>
        /// Список объектов отдела.
        /// </summary>
        public virtual ICollection<Facility> Facilities { get; set; }

        /// <summary>
        /// Работники отдела.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Contact> Employees
        {
            get
            {
                return Posts.Select(i => i.Employee).ToList();
            }
        }

        /// <summary>
        /// Подписывающие лица отдела.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Contact> Signers
        {
            get
            {
                return Posts.Where(i => i.CanSigning).Select(i => i.Employee).ToList();
            }
        }


        /// <summary>
        /// Исходящие коммерческие предложения.
        /// </summary>
        public virtual ICollection<Proposal> ExternalProposals { get; set; }

        /// <summary>
        /// Входящие коммерческие предложения.
        /// </summary>
        public virtual ICollection<Proposal> InternalProposals { get; set; }
        
        /// <summary>
        /// Исходящие спецификации.
        /// </summary>
        public virtual ICollection<Specification> ExternalSpecifications { get; set; }

        /// <summary>
        /// Входящие спецификации.
        /// </summary>
        public virtual ICollection<Specification> InternalSpecifications { get; set; }

        /// <summary>
        /// Исходящие договоры.
        /// </summary>
        public virtual ICollection<Contract> ExternalContracts { get; set; }

        /// <summary>
        /// Входящие договоры.
        /// </summary>
        public virtual ICollection<Contract> InternalContracts { get; set; }

        /// <summary>
        /// Исходящие счета.
        /// </summary>
        public virtual ICollection<Invoice> ExternalInvoices { get; set; }

        /// <summary>
        /// Входящие счета.
        /// </summary>
        public virtual ICollection<Invoice> InternalInvoices { get; set; }

        /// <summary>
        /// Получить все исходящие КП, включая КП дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Proposal> GetExternalProposalsIncludeChildren()
        {
            List<Proposal> allProposals = ExternalProposals.ToList();
            foreach (Facility obj in Facilities)
            {
                allProposals.AddRange(obj.GetExternalProposalsIncludeChildren());
            }
            return allProposals;
        }

        /// <summary>
        /// Получить все входящие КП, включая КП дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Proposal> GetInternalProposalsIncludeChildren()
        {
            List<Proposal> allProposals = InternalProposals.ToList();
            foreach (Facility obj in Facilities)
            {
                allProposals.AddRange(obj.GetInternalProposalsIncludeChildren());
            }
            return allProposals;
        }

        /// <summary>
        /// Получить все исходящие спецификации, включая спецификации дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Specification> GetExternalSpecificationsIncludeChildren()
        {
            List<Specification> allSpecifications = ExternalSpecifications.ToList();
            foreach (Facility obj in Facilities)
            {
                allSpecifications.AddRange(obj.GetExternalSpecificationsIncludeChildren());
            }
            return allSpecifications;
        }

        /// <summary>
        /// Получить все входящие спецификации, включая спецификации дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Specification> GetInternalSpecificationsIncludeChildren()
        {
            List<Specification> allSpecifications = InternalSpecifications.ToList();
            foreach (Facility obj in Facilities)
            {
                allSpecifications.AddRange(obj.GetInternalSpecificationsIncludeChildren());
            }
            return allSpecifications;
        }

        /// <summary>
        /// Получить все исходящие договоры, включая договоры дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Contract> GetExternalContractsIncludeChildren()
        {
            List<Contract> allContracts = ExternalContracts.ToList();
            foreach (Facility obj in Facilities)
            {
                allContracts.AddRange(obj.GetExternalContractsIncludeChildren());
            }
            return allContracts;
        }

        /// <summary>
        /// Получить все входящие договоры, включая договоры дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Contract> GetInternalContractsIncludeChildren()
        {
            List<Contract> allContracts = InternalContracts.ToList();
            foreach (Facility obj in Facilities)
            {
                allContracts.AddRange(obj.GetInternalContractsIncludeChildren());
            }
            return allContracts;
        }

        /// <summary>
        /// Получить все исходящие счета, включая счета дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetExternalInvoicesIncludeChildren()
        {
            List<Invoice> allInvoices = ExternalInvoices.ToList();
            foreach (Facility obj in Facilities)
            {
                allInvoices.AddRange(obj.GetExternalInvoicesIncludeChildren());
            }
            return allInvoices;
        }

        /// <summary>
        /// Получить все входящие счета, включая счета дочерних элементов.
        /// </summary>
        /// <returns></returns>
        public List<Invoice> GetInternalInvoicesIncludeChildren()
        {
            List<Invoice> allInvoices = InternalInvoices.ToList();
            foreach (Facility obj in Facilities)
            {
                allInvoices.AddRange(obj.GetInternalInvoicesIncludeChildren());
            }
            return allInvoices;
        }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingObject">Принимый объект организации.</param>
        /// <returns></returns>
        public Facility CloneFrom(Facility transmittingObject)
        {
            Name = transmittingObject.Name;
            FullName = transmittingObject.FullName;
            PostAddress = transmittingObject.PostAddress;
            Phone = transmittingObject.Phone;
            FAX = transmittingObject.FAX;
            Email = transmittingObject.Email;
            Web = transmittingObject.Web;

            return this;
        }
    }
}
