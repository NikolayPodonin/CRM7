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
    /// Группа доступа.
    /// </summary>
    [Table(nameof(AccessGroup))]
    public class AccessGroup
    {
        public AccessGroup()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование группы.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Может ли видеть цены.
        /// </summary>
        public bool CanSeePrices { get; set; }

        /// <summary>
        /// Может ли видеть чужие документы.
        /// </summary>
        public bool CanSeeOthersDocs { get; set; }

        /// <summary>
        /// Может ли менять статус счетов.
        /// </summary>
        public bool CanChangeInvoicesStatus { get; set; }

        /// <summary>
        /// Может ли редактировать аккаунты пользователей.
        /// </summary>
        public bool CanChangeUserAccounts { get; set; }

        /// <summary>
        /// Может ли видеть компании, созданные другими пользователями.
        /// </summary>
        public bool CanSeeOthersCompanies { get; set; }

        /// <summary>
        /// Пользователи в группе.
        /// </summary>
        public ICollection<User> Users { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingGroup">Принимая группа доступа.</param>
        /// <returns>Группа доступа.</returns>
        public AccessGroup CloneFrom(AccessGroup transmittingGroup)
        {
            Name = transmittingGroup.Name;
            CanSeeOthersDocs = transmittingGroup.CanSeeOthersDocs;
            CanSeePrices = transmittingGroup.CanSeePrices;
            CanChangeInvoicesStatus = transmittingGroup.CanChangeInvoicesStatus;

            return this;
        }
    }
}
