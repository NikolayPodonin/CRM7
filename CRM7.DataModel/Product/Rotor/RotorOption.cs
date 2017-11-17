using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Commercial;

namespace CRM7.DataModel.Product.Rotor
{
    /// <summary>
    /// Опция привода.
    /// </summary>
    [Table(nameof(RotorOption))]
    public class RotorOption : IProduct, IPriceable
    {
        /// <summary>
        /// Создает новый экземпляр RotorOption.
        /// </summary>
        public RotorOption()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        /// <summary>
        /// Модель опции привода.
        /// </summary>
        public virtual RotorOptionModel Model { get; set; }

        public Guid? StorageId { get; set; }

        /// <summary>
        /// Склад, на котором нахдится данная опция привода.
        /// </summary>
        public virtual Storage Storage { get; set; }

        #region IPriceable

        /// <summary>
        /// Прайс.
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
        /// Получить итоговую стоимость в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            return Price.GetValue(targetCurrency, currencyPairs);
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            return Price.GetValue(targetCurrency, currencyPair);
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            return Price.GetSelfCost(targetCurrency, currencyPairs);
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            return Price.GetSelfCost(targetCurrency, currencyPair);
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
        /// Опция привода в КП, для которой зарезервирована данная опция привода.
        /// </summary>
        public virtual RotorOptionInPosition ReservedBy { get; set; }
        
        public Guid? RotorId { get; set; }

        /// <summary>
        /// Привод, на который установлена данная опция.
        /// </summary>
        public virtual Rotor Rotor { get; set; }
    }
}
