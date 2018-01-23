using CRM7.DataModel.Management;
using CRM7.DataModel.OnlineStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Product
{
    /// <summary>
    /// Интерфейс модели продукта.
    /// </summary>
    public interface IProductModel
    {        
        /// <summary>
        /// Производитель.
        /// </summary>
        Company Manufacturer { get; set; }

        /// <summary>
        /// Длина, мм.
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Высота, мм.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Масса, кг.
        /// </summary>
        double Mass { get; set; }

        /// <summary>
        /// Короткое описание.
        /// </summary>
        string ShortDesignation { get; set; }

        /// <summary>
        /// Полное описание.
        /// </summary>
        string FullDesignation { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        string Unit { get; set; }

        /// <summary>
        /// Категория продукта.
        /// </summary>
        ProductCategory Category { get; set; }
    }
}
