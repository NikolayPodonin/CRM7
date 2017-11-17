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
    /// Опция привода в позиции КП.
    /// </summary>
    [Table(nameof(RotorOptionInPosition))]
    public class RotorOptionInPosition : IProductInPosition
    {
        /// <summary>
        /// Создает новый экземпляр RotorOptionInPosition.
        /// </summary>
        public RotorOptionInPosition()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid? PositionId { get; set; }

        /// <summary>
        /// Позиция КП, которой принадлежит опция.
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

        public Guid RotorOptionModelId { get; set; }

        /// <summary>
        /// Модель опции.
        /// </summary>
        public virtual RotorOptionModel RotorOptionModel { get; set; }

        /// <summary>
        /// Зарезервированная на складе опция.
        /// </summary>
        public virtual RotorOption ReservedRotorOption { get; set; }

        public Guid? RotorId { get; set; }

        /// <summary>
        /// Привод, на который установлена опция.
        /// </summary>
        public virtual RotorInPosition Rotor { get; set; }
    }
}
