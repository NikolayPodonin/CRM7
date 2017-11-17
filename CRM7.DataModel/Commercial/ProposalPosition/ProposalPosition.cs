using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Product;
using CRM7.DataModel.Commercial;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Позиция коммерческого предложения, содержащая продукты.
    /// </summary>
    [Table(nameof(ProposalPosition))]
    public class ProposalPosition
    {
        /// <summary>
        /// Создает новый экземпляр ProposalPosition.
        /// </summary>
        public ProposalPosition()
        {
            Id = Guid.NewGuid();
            RotorOptions = new List<RotorOptionInPosition>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ProposalId { get; set; }

        /// <summary>
        /// Коммерческое предложение.
        /// </summary>
        public virtual Proposal Proposal { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Номер позиции.
        /// </summary>
        public int PositionNumber { get; set; }

        /// <summary>
        /// Короткое описание. ПРОТОТИП
        /// </summary>
        [NotMapped]
        public string ShortDesignation
        {
            get
            {
                string designation = "";
                if (Valve != null) designation += Valve.ValveModel.ShortDesignation;
                if (Rotor != null) designation += Rotor.RotorModel.ShortDesignation;
                if (RotorOptions != null)
                {
                    foreach (var ro in RotorOptions)
                    {
                        designation += ro.RotorOptionModel.ShortDesignation;
                    }
                }
                if (SOF != null) designation += SOF.SofModel.ShortDesignation;
                if (ManualProduct != null) designation += ManualProduct.ManualProductModel.ShortDesignation;
                return designation;
            }
        }

        /// <summary>
        /// Полное описание. ПРОТОТИП
        /// </summary>
        [NotMapped]
        public string FullDesignation
        {
            get
            {
                string designation = "";
                if (Valve != null) designation += Valve.ValveModel.FullDesignation;
                if (Rotor != null) designation += Rotor.RotorModel.FullDesignation;
                if (RotorOptions != null)
                {
                    foreach (var ro in RotorOptions)
                    {
                        designation += ro.RotorOptionModel.FullDesignation;
                    }
                }
                if (SOF != null) designation += SOF.SofModel.FullDesignation;
                if (ManualProduct != null) designation += ManualProduct.ManualProductModel.FullDesignation;
                return designation;
            }
        }

        /// <summary>
        /// Стоимость позиции в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal cost = 0;
            foreach (IProductInPosition product in Products)
            {
                cost += product.Price.GetValue(targetCurrency, currencyPair);
            }
            return cost;
        }

        /// <summary>
        /// Стоимость позиции в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal cost = 0;
            foreach (IProductInPosition product in Products)
            {
                cost += product.Price.GetValue(targetCurrency, currencyPairs);
            }
            return cost;
        }
        
        /// <summary>
        /// Опция привода.
        /// </summary>
        public virtual ICollection<RotorOptionInPosition> RotorOptions { get; set; }

        /// <summary>
        /// Привод.
        /// </summary>
        public virtual RotorInPosition Rotor { get; set; }

        /// <summary>
        /// Запорная арматура.
        /// </summary>
        public virtual ValveInPosition Valve { get; set; }

        /// <summary>
        /// Комплект фланцев.
        /// </summary>
        public virtual SofInPosition SOF { get; set; }

        /// <summary>
        /// Продукт, добавленный вручную.
        /// </summary>
        public virtual ManualProductInPosition ManualProduct { get; set; }

        /// <summary>
        /// Список продуктов в позиции.
        /// </summary>
        [NotMapped]
        public List<IProductInPosition> Products
        {
            get
            {
                var products = new List<IProductInPosition>();
                if (Valve != null) products.Add(Valve);
                if (Rotor != null) products.Add(Rotor);
                if (RotorOptions != null) products.AddRange(RotorOptions);
                if (SOF != null) products.Add(SOF);
                if (ManualProduct != null) products.Add(ManualProduct);
                return products;
            }
        }
    }
}
