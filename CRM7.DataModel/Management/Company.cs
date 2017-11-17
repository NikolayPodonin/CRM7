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
    /// Компания.
    /// </summary>
    [Table(nameof(Facility))]
    public class Company : Facility
    {
        /// <summary>
        /// Создает новый экземпляр Company.
        /// </summary>
        public Company() : base()
        {

        }

        /// <summary>
        /// ИНН.
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// КПП.
        /// </summary>
        public string KPP { get; set; }

        /// <summary>
        /// Юридический адресс.
        /// </summary>
        public string JurAddress { get; set; }

        /// <summary>
        /// Банковский счет.
        /// </summary>
        public string BankAccount { get; set; }

        /// <summary>
        /// Корреспондентский счет.
        /// </summary>
        public string CorrespAccount { get; set; }

        /// <summary>
        /// БИК.
        /// </summary>
        public string BIK { get; set; }

        /// <summary>
        /// Банк.
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// ОГРН.
        /// </summary>
        public string OGRN { get; set; }

        /// <summary>
        /// ОКПО.
        /// </summary>
        public string OKPO { get; set; }

        /// <summary>
        /// ОКАТО.
        /// </summary>
        public string OKATO { get; set; }

        /// <summary>
        /// ОКТМО.
        /// </summary>
        public string OKTMO { get; set; }

        /// <summary>
        /// ОКВЕД.
        /// </summary>
        public string OKVED { get; set; }

        /// <summary>
        /// ОКОГУ.
        /// </summary>
        public string OKOGU { get; set; }

        /// <summary>
        /// ОКОПФ.
        /// </summary>
        public string OKOPF { get; set; }

        /// <summary>
        /// ОКФС.
        /// </summary>
        public string OKFS { get; set; }

        public Guid? TypeId { get; set; }

        /// <summary>
        /// Тип компании.
        /// </summary>
        public virtual CompanyType Type { get; set; }

        public Guid SupervisorId { get; set; }

        /// <summary>
        /// Человек, курирующий работу с этой компанией.
        /// </summary>
        public Contact Supervisor { get; set; }
        
        /// <summary>
        /// Директор.
        /// </summary>
        [NotMapped]
        public Contact Director
        {
            get
            {
                Post director = Posts.SingleOrDefault(i => i.IsDirector);
                return director != null ? director.Employee : null;
            }
        }
        

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingCompany">Принимаемая компания.</param>
        /// <returns></returns>
        public Company CloneFrom(Company transmittingCompany)
        {
            Name = transmittingCompany.Name;
            FullName = transmittingCompany.FullName;
            INN = transmittingCompany.INN;
            KPP = transmittingCompany.KPP;
            JurAddress = transmittingCompany.JurAddress;
            PostAddress = transmittingCompany.PostAddress;
            Phone = transmittingCompany.Phone;
            FAX = transmittingCompany.FAX;
            Email = transmittingCompany.Email;
            Web = transmittingCompany.Web;
            BankAccount = transmittingCompany.BankAccount;
            CorrespAccount = transmittingCompany.CorrespAccount;
            BIK = transmittingCompany.BIK;
            Bank = transmittingCompany.Bank;
            OGRN = transmittingCompany.OGRN;
            OKPO = transmittingCompany.OKPO;
            OKATO = transmittingCompany.OKATO;
            OKTMO = transmittingCompany.OKTMO;
            OKVED = transmittingCompany.OKVED;
            OKOGU = transmittingCompany.OKOGU;
            OKOPF = transmittingCompany.OKOPF;
            OKFS = transmittingCompany.OKFS;

            return this;       
        }
    }
}
