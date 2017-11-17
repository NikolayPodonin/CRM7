using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Product.Valve;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Арматура в позиции КП.
    /// </summary>
    [Table(nameof(ValveInPosition))]
    public class ValveInPosition : IProductInPosition
    {
        /// <summary>
        /// Создает новый экземпляр ValveInPosition.
        /// </summary>
        public ValveInPosition()
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
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости электропривода.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPairs);
            if (Rotor != null)
            {
                value += Rotor.GetCost(targetCurrency, currencyPairs);
                value += SOF.GetCost(targetCurrency, currencyPairs);
            }
            return value;
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости электропривода.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPair);
            if (Rotor != null)
            {
                value += Rotor.GetCost(targetCurrency, currencyPair);
                value += SOF.GetCost(targetCurrency, currencyPair);
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом себестоимости электропривода.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPairs);
            if (Rotor != null)
            {
                value += Rotor.GetSelfCost(targetCurrency, currencyPairs);
                value += SOF.GetSelfCost(targetCurrency, currencyPairs);
            }
            return value;
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте с учетом себестоимости электропривода.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            decimal value = Price.GetSelfCost(targetCurrency, currencyPair);
            if (Rotor != null)
            {
                value += Rotor.GetSelfCost(targetCurrency, currencyPair);
                value += SOF.GetSelfCost(targetCurrency, currencyPair);
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
        /// Коэффициеннт для вычисления себестоимости.
        /// </summary>
        public decimal SelfCostCoefficient { get; set; }

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

        public Guid ValveModelId { get; set; }

        /// <summary>
        /// Модель арматуры.
        /// </summary>
        public virtual ValveModel ValveModel { get; set; }
        
        /// <summary>
        /// Зарезервированная на складе арматура.
        /// </summary>
        public virtual Valve ReservedValve { get; set; }

        /// <summary>
        /// Привод, установленный на арматуру.
        /// </summary>
        public virtual RotorInPosition Rotor { get; set; }

        /// <summary>
        /// Комплект фланцев, установленный на арматуру.
        /// </summary>
        public virtual SofInPosition SOF { get; set; }
    }
}
