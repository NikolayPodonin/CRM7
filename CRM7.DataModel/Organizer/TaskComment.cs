using CRM7.DataModel.Management;
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
    /// Комментарий к задаче.
    /// </summary>
    [Table(nameof(TaskComment))]
    public class TaskComment
    {
        public TaskComment()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid TaskId { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public virtual Task Task { get; set; }

        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь, оставивший комментарий.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Текст.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Дата созданий.
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
