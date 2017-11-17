using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Commercial;
using CRM7.DataModel.Product.Rotor;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Трубопроводная арматура.
    /// </summary>
    [Table(nameof(Valve))]
    public class Valve : IProduct, IPriceable
    {
        /// <summary>
        /// Создает новый экземпляр Valve.
        /// </summary>
        public Valve()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        /// <summary>
        /// Модель арматуры.
        /// </summary>
        public virtual ValveModel Model { get; set; }

        public string Number { get; set; }

        public Guid? StorageId { get; set; }

        /// <summary>
        /// Склад, на котором находится данная арматура.
        /// </summary>
        public virtual Storage Storage { get; set; }

        #region IPriceable

        /// <summary>
        /// Прайс (не учитывает опции и ЭП).
        /// </summary>
        [NotMapped]
        public Price Price
        {
            get
            {
                return new Price()
                {
                    BaseValue = BaseValue,
                    Currency = Currency,
                    Coefficient = Coefficient,
                    Diskount = Diskount,
                    Markup = Markup
                };
            }
            set
            {
                BaseValue = value.BaseValue;
                Currency = value.Currency;
                Coefficient = value.Coefficient;
                Diskount = value.Diskount;
                Markup = value.Markup;
            }
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости электропривода и опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPairs);
            if (Rotor != null)
            {
                value += Rotor.GetCost(targetCurrency, currencyPairs);
            }
            if(Model.CanBeClassA == true)
            {
                value += Price.GetValue(targetCurrency, currencyPairs) * 0.1m;
            }
            return value;
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости электропривода и опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPair);
            if (Rotor != null)
            {
                value += Rotor.GetCost(targetCurrency, currencyPair);
            }
            if (Model.CanBeClassA == true)
            {
                value += Price.GetValue(targetCurrency, currencyPair) * 0.1m;
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом стоимости электропривода и опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPairs);
            if (Rotor != null)
            {
                value += Rotor.GetSelfCost(targetCurrency, currencyPairs);
            }
            if (Model.CanBeClassA == true)
            {
                if (ClassA)
                {
                    value += Price.GetSelfCost(targetCurrency, currencyPairs) * 0.1m;
                }
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом стоимости электропривода и опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPair);
            if (Rotor != null)
            {
                value += Rotor.GetSelfCost(targetCurrency, currencyPair);
            }
            if (Model.CanBeClassA == true)
            {
                if (ClassA)
                {
                    value += Price.GetSelfCost(targetCurrency, currencyPair) * 0.1m;
                }
            }
            return value;
        }

        /// <summary>
        /// Базовая стоимость.
        /// </summary>
        public decimal BaseValue { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Базовый коэффициеннт.
        /// </summary>
        public decimal Coefficient { get; set; }

        /// <summary>
        /// Коэффициеннт для вычисления себестоимости.
        /// </summary>
        public decimal SelfCostCoefficient { get; set; }

        /// <summary>
        /// Скидка, %.
        /// </summary>
        public decimal Diskount { get; set; }

        /// <summary>
        /// Наценка, %.
        /// </summary>
        public decimal Markup { get; set; }

        #endregion
        
        /// <summary>
        /// Позиция КП, для которой зарезервированна арматура.
        /// </summary>
        public virtual ValveInPosition ReservedBy { get; set; }

        /// <summary>
        /// Привод, установленный на арматуру.
        /// </summary>
        public virtual Rotor.Rotor Rotor { get; set; }

        /// <summary>
        /// Комплект фланцев, установленный на арматуру
        /// </summary>
        public virtual SOF.SOF SOF { get; set; }

        /// <summary>
        /// Класс герметичности А - дополнительная опция
        /// </summary>
        public bool ClassA { get; set; }        
    }
}
