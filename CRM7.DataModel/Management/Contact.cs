using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Commercial;

namespace CRM7.DataModel.Management
{
    /// <summary>
    /// Контакт.
    /// </summary>
    [Table(nameof(Contact))]
    public class Contact
    {
        /// <summary>
        /// Создает новый экземпляр Contact.
        /// </summary>
        public Contact()
        {
            Id = Guid.NewGuid();

            MakedProposals = new List<Proposal>();
            SignedProposals = new List<Proposal>();
            TakedProposals = new List<Proposal>();
            
            MakedSpecifications = new List<Specification>();
            TakedSpecifications = new List<Specification>();

            MakedContracts = new List<Contract>();
            TakedContracts = new List<Contract>();

            MakedInvoices = new List<Invoice>();
            
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер мобильного телефона.
        /// </summary>
        public string MobilePhone { get; set; }
        
        /// <summary>
        /// Созданные коммерческие предложения.
        /// </summary>
        public virtual ICollection<Proposal> MakedProposals { get; set; }

        /// <summary>
        /// Подписанные коммерческие предложения.
        /// </summary>
        public virtual ICollection<Proposal> SignedProposals { get; set; }

        /// <summary>
        /// Полученные коммерческие предложения.
        /// </summary>
        public virtual ICollection<Proposal> TakedProposals { get; set; }

        /// <summary>
        /// Созданные спецификации.
        /// </summary>
        public virtual ICollection<Specification> MakedSpecifications { get; set; }

        /// <summary>
        /// Полученные спецификации.
        /// </summary>
        public virtual ICollection<Specification> TakedSpecifications { get; set; }

        /// <summary>
        /// Созданные счета.
        /// </summary>
        public virtual ICollection<Invoice> MakedInvoices { get; set; }

        /// <summary>
        /// Созданные договоры.
        /// </summary>
        public virtual ICollection<Contract> MakedContracts { get; set; }

        /// <summary>
        /// Полученные договоры.
        /// </summary>
        public virtual ICollection<Contract> TakedContracts { get; set; }

        /// <summary>
        /// Компании, с которыми работает этот человек.
        /// </summary>
        public virtual ICollection<Company> SupervisedCompanies { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public virtual Post Post { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}. {2}.", LastName, FirstName.Substring(0, 1), MiddleName.Substring(0, 1));
            }
        }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingСontact">Принимаемый контакт.</param>
        public Contact CloneFrom(Contact transmittingСontact)
        {
            FirstName = transmittingСontact.FirstName;
            MiddleName = transmittingСontact.MiddleName;
            LastName = transmittingСontact.LastName;
            MobilePhone = transmittingСontact.MobilePhone;
            Email = transmittingСontact.Email;
            return this;
        }
    }
}
