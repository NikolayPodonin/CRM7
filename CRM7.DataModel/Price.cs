using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM7.DataModel.Localization;

namespace CRM7.DataModel
{
    /// <summary>
    /// Валюта.
    /// </summary>
    public enum Currency { EUR, RUR }

    /// <summary>
    /// Прайс.
    /// </summary>
    public class Price
    {
        /// <summary>
        /// Создает новый экземпляр Price.
        /// </summary>
        public Price()
        {
            Coefficient = 1;
            Diskount = 0;
            Markup = 0;
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
        /// Скидка, %.
        /// </summary>
        public decimal Diskount { get; set; }

        /// <summary>
        /// Наценка, %.
        /// </summary>
        public decimal Markup { get; set; }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом коэффициента, скидки и наценки.
        /// При этом, если целевая валюта отличается от валюты прайса, передаваемая валютная пара должна содержать валюту прайса и целевую валюту в качестве базовой и котируемой или наоборот.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютная пара.</param>
        public decimal GetValue(Currency targetCurrency, CurrencyPair currencyPair)
        {
            if (targetCurrency == Currency)
            {
                return GetValue();
            }
            else if (currencyPair.BaseCurrency == Currency && currencyPair.QuotedCurrency == targetCurrency)
            {
                return Math.Round(CalculateDiskountAndMarkup(BaseValue * currencyPair.Rate * Coefficient), 2);
            }
            else if (currencyPair.QuotedCurrency == Currency && currencyPair.BaseCurrency == targetCurrency)
            {
                return Math.Round(CalculateDiskountAndMarkup(BaseValue / currencyPair.Rate * Coefficient), 2);
            }
            else
            {
                throw new ArgumentException(LocalizationManager.LocalizedStrings.InvalidCurrencyPair);
            }                
        }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом коэффициента, скидки и наценки.
        /// При этом, если целевая валюта отличается от валюты прайса, одна из передаваемых валютных пар должна содержать валюту прайса и целевую валюту в качестве базовой и котируемой или наоборот.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютная пара.</param>
        public decimal GetValue(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            foreach (var currencyPair in currencyPairs)
            {
                if (targetCurrency == Currency)
                {
                    return GetValue();
                }
                else if (currencyPair.BaseCurrency == Currency && currencyPair.QuotedCurrency == targetCurrency)
                {
                    return Math.Round(CalculateDiskountAndMarkup(BaseValue * currencyPair.Rate * Coefficient), 2);
                }
                else if (currencyPair.QuotedCurrency == Currency && currencyPair.BaseCurrency == targetCurrency)
                {
                    return Math.Round(CalculateDiskountAndMarkup(BaseValue / currencyPair.Rate * Coefficient), 2);
                }
            }
            throw new ArgumentException(LocalizationManager.LocalizedStrings.NoCurrencyPair);
        }

        /// <summary>
        /// Получить итоговую стоимость в валюте прайса.
        /// </summary>
        public decimal GetValue()
        {
            return Math.Round(CalculateDiskountAndMarkup(BaseValue * Coefficient), 2);
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте.
        /// При этом, если целевая валюта отличается от валюты прайса, передаваемая валютная пара должна содержать валюту прайса и целевую валюту в качестве базовой и котируемой или наоборот.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютная пара.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair)
        {
            if (targetCurrency == Currency)
            {
                return GetSelfCost();
            }
            else if (currencyPair.BaseCurrency == Currency && currencyPair.QuotedCurrency == targetCurrency)
            {
                return Math.Round(BaseValue * currencyPair.Rate, 2);
            }
            else if (currencyPair.QuotedCurrency == Currency && currencyPair.BaseCurrency == targetCurrency)
            {
                return Math.Round(BaseValue / currencyPair.Rate, 2);
            }
            else
            {
                throw new ArgumentException(LocalizationManager.LocalizedStrings.InvalidCurrencyPair);
            }
        }

        /// <summary>
        /// Получить себестоимость в указанной валюте.
        /// При этом, если целевая валюта отличается от валюты прайса, одна из передаваемых валютных пар должна содержать валюту прайса и целевую валюту в качестве базовой и котируемой или наоборот.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютная пара.</param>
        public decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            foreach (var currencyPair in currencyPairs)
            {
                if (targetCurrency == Currency)
                {
                    return GetSelfCost();
                }
                if (currencyPair.BaseCurrency == Currency && currencyPair.QuotedCurrency == targetCurrency)
                {
                    return Math.Round(BaseValue * currencyPair.Rate, 2);
                }
                else if (currencyPair.QuotedCurrency == Currency && currencyPair.BaseCurrency == targetCurrency)
                {
                    return Math.Round(BaseValue / currencyPair.Rate, 2);
                }
            }
            throw new ArgumentException(LocalizationManager.LocalizedStrings.NoCurrencyPair);
        }

        /// <summary>
        /// Получить себестоимость в валюте прайса.
        /// </summary>
        public decimal GetSelfCost()
        {
            return Math.Round(BaseValue, 2);
        }

        /// <summary>
        /// Применить скидку и наценку.
        /// </summary>
        /// <param name="value">Исходная стоимость.</param>
        private decimal CalculateDiskountAndMarkup(decimal value)
        {
            return value * (1 - Diskount / 100) * (1 + Markup / 100);
        }
    }
}
