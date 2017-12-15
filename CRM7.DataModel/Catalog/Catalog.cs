using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Catalog
{
    /// <summary>
    /// Каталог цен на продукцию.
    /// </summary>
    [Table(nameof(Catalog))]
    public class Catalog
    {
        public Catalog()
        {
            Id = Guid.NewGuid();
            Valves = new List<ValveInCatalog>();
            Rotors = new List<RotorInCatalog>();
            RotorOptions = new List<RotorOptionInCatalog>();
            SOFs = new List<SofInCatalog>();
            ManualProducts = new List<ManualProductInCatalog>();            
        }

        [Key]
        public Guid Id { get; set; }
        
        /// <summary>
        /// Название каталога.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание каталога.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список позиций трубопроводной арматуры.
        /// </summary>
        public virtual ICollection<ValveInCatalog> Valves { get; set; }

        /// <summary>
        /// Список позиций приводов.
        /// </summary>
        public virtual ICollection<RotorInCatalog> Rotors { get; set; }

        /// <summary>
        /// Список позиций опций привода.
        /// </summary>
        public virtual ICollection<RotorOptionInCatalog> RotorOptions { get; set; }

        /// <summary>
        /// Список позиций комплектов фланцев.
        /// </summary>
        public virtual ICollection<SofInCatalog> SOFs { get; set; }


        /// <summary>
        /// Список позиций комплектов фланцев.
        /// </summary>
        public virtual ICollection<ManualProductInCatalog> ManualProducts { get; set; }

        public List<IProductModel> GetAllModels()
        {
            List<IProductModel> allModels = new List<IProductModel>();
            foreach(var mod in Valves)
            {
                allModels.Add(mod.Model);
            }
            foreach (var mod in Rotors)
            {
                allModels.Add(mod.Model);
            }
            foreach (var mod in RotorOptions)
            {
                allModels.Add(mod.Model);
            }
            foreach (var mod in ManualProducts)
            {
                allModels.Add(mod.Model);
            }
            foreach (var mod in SOFs)
            {
                allModels.Add(mod.Model);
            }
            return allModels;
        }
    }
}
