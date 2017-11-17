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
    /// Тип компании.
    /// </summary>
    [Table(nameof(CompanyType))]
    public class CompanyType
    {
        public CompanyType()
        {
            Id = Guid.NewGuid();

            Companies = new List<Company>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование типа.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Компании этого типа.
        /// </summary>
        public ICollection<Company> Companies { get; set; }

        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingType">Принимаемый тип компании.</param>
        public CompanyType CloneFrom(CompanyType transmittingType)
        {
            Name = transmittingType.Name;
            return this;
        }
    }
}
