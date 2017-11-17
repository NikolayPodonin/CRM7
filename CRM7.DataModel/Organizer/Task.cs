using CRM7.DataModel.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CRM7.DataModel.Organizer
{
    /// <summary>
    /// Задача.
    /// </summary>
    [Table(nameof(Task))]
    public class Task
    {
        public Task()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public Guid OrdererId { get; set; }

        /// <summary>
        /// Поручитель.
        /// </summary>
        public virtual User Orderer { get; set; }

        public Guid ExecutorId { get; set; }

        /// <summary>
        /// Исполнитель.
        /// </summary>
        public virtual User Executor { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата выполнения.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Верменной период для автоматического переноса даты выполнения задания.
        /// </summary>
        public TimeSpan AutomaticProlongExpDate { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Подробности.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Задание выполнено.
        /// </summary>
        public bool Executed { get; set; }

        /// <summary>
        /// Поручитель оповещен.
        /// </summary>
        public bool OrdererNotified { get; set; }

        /// <summary>
        /// Исполнитель оповещен.
        /// </summary>
        public bool ExecutorNotified { get; set; }

        /// <summary>
        /// Добавлен комментарий.
        /// </summary>
        public bool CommentAdded { get; set; }

        /// <summary>
        /// Дата выполнения изменена.
        /// </summary>
        public bool ExpirationDateChanged { get; set; }

        /// <summary>
        /// Комментарии.
        /// </summary>
        public virtual ICollection<TaskComment> Comments { get; set; }

        /// <summary>
        /// Напоминания.
        /// </summary>
        public virtual ICollection<TaskReminder> Reminders { get; set; }

        public Guid? ParentTaskId { get; set; }

        /// <summary>
        /// Родительская задача.
        /// </summary>
        public virtual Task ParentTask { get; set; }

        /// <summary>
        /// Дочерние задачи.
        /// </summary>
        public virtual ICollection<Task> ChildTasks { get; set; }
    }
}
