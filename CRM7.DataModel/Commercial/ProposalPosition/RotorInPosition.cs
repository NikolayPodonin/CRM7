using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Product.Rotor;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Привод в позиции КП.
    /// </summary>
    [Table(nameof(RotorInPosition))]
    public class RotorInPosition : IProductInPosition
    {
        /// <summary>
        /// Создает новый экземпляр RotorInPosition.
        /// </summary>
        public RotorInPosition()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Позиция КП.
        /// </summary>
        public virtual ProposalPosition Position { get; set; }

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
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPairs);
            foreach(var op in RotorOptions)
            {
                value += op.GetCost(targetCurrency, currencyPairs);
            }
            return value;
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPair);
            foreach (var op in RotorOptions)
            {
                value += op.GetCost(targetCurrency, currencyPair);
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом себестоимости опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPairs);
            foreach (var op in RotorOptions)
            {
                value += op.GetSelfCost(targetCurrency, currencyPairs);
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом себестоимости опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPair);
            foreach (var op in RotorOptions)
            {
                value += op.GetSelfCost(targetCurrency, currencyPair);
            }
            return value;
        }

        /// <summary>
        /// Коэффициеннт для вычисления себестоимости.
        /// </summary>
        public decimal SelfCostCoefficient { get; set; }

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
        /// Скидка, %.
        /// </summary>
        public decimal Diskount { get; set; }

        /// <summary>
        /// Наценка, %.
        /// </summary>
        public decimal Markup { get; set; }

        #endregion

        public Guid RotorModelId { get; set; }

        /// <summary>
        /// Модель привода.
        /// </summary>
        public virtual RotorModel RotorModel { get; set; }
        
        /// <summary>
        /// Арматура, на которую установлен привод.
        /// </summary>
        public virtual ValveInPosition Valve { get; set; }

        /// <summary>
        /// Зарезервированный на складе привод.
        /// </summary>
        public virtual Rotor ReservedRotor { get; set; }

        /// <summary>
        /// Опции привода.
        /// </summary>
        public virtual ICollection<RotorOptionInPosition> RotorOptions { get; set; }
    }
}
