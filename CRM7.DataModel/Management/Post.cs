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
    /// Должность.
    /// </summary>
    [Table(nameof(Post))]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование должности.
        /// </summary>
        public string Name { get; set; }

        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Работник на должности.
        /// </summary>
        public virtual Contact Employee { get; set; }
        
        public Guid FacilityId { get; set; }

        /// <summary>
        /// Компания.
        /// </summary>
        public virtual Facility Facility { get; set; }
        
        public bool IsDirector { get; set; }

        /// <summary>
        /// Возможность подписывать документы.
        /// </summary>
        public bool CanSigning { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingPost">Принимая должность.</param>
        /// <returns></returns>
        public Post CloneFrom(Post transmittingPost)
        {
            Name = transmittingPost.Name;
            IsDirector = transmittingPost.IsDirector;
            CanSigning = transmittingPost.CanSigning;

            return this;
        }
    }
}
