using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.Valve;
using CRM7.DataModel.Product;
using CRM7.DataModel.Product.SOF;
using CRM7.DataModel.Management;

namespace CRM7.DataModel
{
    /// <summary>
    /// Склад.
    /// </summary>
    [Table(nameof(Storage))]
    public class Storage
    {
        /// <summary>
        /// Создает новый экземпляр Storage.
        /// </summary>
        public Storage()
        {
            Id = Guid.NewGuid();
            Valves = new List<Valve>();
            Rotors = new List<Rotor>();
            RotorOptions = new List<RotorOption>();
            SOFs = new List<SOF>();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        public Guid OwnerId { get; set; }

        /// <summary>
        /// Владелец.
        /// </summary>
        public virtual Company Owner { get; set; }

        /// <summary>
        /// Список трубопроводной арматуры.
        /// </summary>
        public virtual ICollection<Valve> Valves { get; set; }

        /// <summary>
        /// Список приводов.
        /// </summary>
        public virtual ICollection<Rotor> Rotors { get; set; }

        /// <summary>
        /// Список опций привода.
        /// </summary>
        public virtual ICollection<RotorOption> RotorOptions { get; set; }

        /// <summary>
        /// Комплект фланцев.
        /// </summary>
        public virtual ICollection<SOF> SOFs { get; set; }

        /// <summary>
        /// Список разного рода продуктов.
        /// </summary>
        public virtual ICollection<ManualProduct> ManualProducts { get; set; }

        /// <summary>
        /// Список всех продуктов.
        /// </summary>
        [NotMapped]
        public ICollection<IProduct> Products 
        { 
            get
            {
                var products = new List<IProduct>();
                products.AddRange(Valves);
                products.AddRange(Rotors);
                products.AddRange(RotorOptions);
                products.AddRange(SOFs);
                return products;
            }
        }

        public Storage Clone()
        {
            return (Storage)this.MemberwiseClone();
        }
    }
}
