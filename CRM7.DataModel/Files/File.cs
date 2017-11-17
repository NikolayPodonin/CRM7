using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Files
{
    /// <summary>
    /// Документ.
    /// </summary>
    [Table(nameof(File))]
    public class File
    {
        public File()
        {
            Id = Guid.NewGuid();
        }
        
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер.
        /// </summary>
        public double Size { get; set; }

        /// <summary>
        /// Файл в виде массива байт.
        /// </summary>
        public byte[] Data { get; set; }
    }
}
