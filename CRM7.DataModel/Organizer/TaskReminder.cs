using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Organizer
{
    /// <summary>
    /// Напоминание о задании.
    /// </summary>
    [Table(nameof(TaskReminder))]
    public class TaskReminder
    {
        public TaskReminder()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            AlarmDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public virtual Task Task { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата напоминания.
        /// </summary>
        public DateTime AlarmDate { get; set; }

        /// <summary>
        /// Письмо отправлено.
        /// </summary>
        public bool EmailSended { get; set; }

        /// <summary>
        /// Пользователь оповещен.
        /// </summary>
        public bool UserNotified { get; set; }
    }
}
