﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Добавленный расход.
    /// </summary>
    [Table(nameof(CPOption))]
    public class CPOption
    {
        public CPOption()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

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
        /// Стоимость.
        /// </summary>
        public decimal Cost { get; set; }

        public Guid? ProposalId { get; set; }

        /// <summary>
        /// КП, для которого добавлен этот пункт расхода.
        /// </summary>
        public virtual Proposal Proposal { get; set; }
    }
}
