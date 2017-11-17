using CRM7.DataModel.Organizer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CRM7.DataModel.Management
{
    /// <summary>
    /// Пользователь системы.
    /// </summary>
    [Table(nameof(User))]
    public class User
    {
        public User() : base()
        {
            Id = Guid.NewGuid();
            ReceivedTasks = new List<Task>();
            AssignedTasks = new List<Task>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid AccessId { get; set; }

        /// <summary>
        /// Группа доступа.
        /// </summary>
        public AccessGroup Access { get; set; }

        public Guid ContactId { get; set; }

        /// <summary>
        /// Данные пользователя.
        /// </summary>
        public Contact Contact { get; set; }

        /// <summary>
        /// Хэш пароля.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Полученные задания.
        /// </summary>
        public virtual ICollection<Task> ReceivedTasks { get; set; }
        
        /// <summary>
        /// Назначенные задания.
        /// </summary>
        public virtual ICollection<Task> AssignedTasks { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingUser">Принимый пользователь.</param>
        /// <returns>Пользователь.</returns>
        public User CloneFrom(User transmittingUser)
        {
            PasswordHash = transmittingUser.PasswordHash;

            return this;
        }
    }
}
