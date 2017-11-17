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
    /// Отчет за день.
    /// </summary>
    [Table(nameof(DayReport))]
    public class DayReport
    {
        public DayReport()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Проведенные встречи.
        /// </summary>
        public string BodyMeetings { get; set; }

        /// <summary>
        /// Совершенные звонки.
        /// </summary>
        public string BodyCalls { get; set; }

        /// <summary>
        /// Работа в офисе или на складе.
        /// </summary>
        public string BodyOffice { get; set; }

        public Guid UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
    }
}
