using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel
{
    public interface IPriceable
    {
        /// <summary>
        /// Прайс без учета дочерних продуктов.
        /// </summary>
        Price Price { get; set; }

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом дочерних продуктов.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs);

        /// <summary>
        /// Получить итоговую стоимость в указанной валюте с учетом дочерних продуктов.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютнае пара, содержащая котировку для преобразования валют.</param>
        decimal GetCost(Currency targetCurrency, CurrencyPair currencyPair);

        /// <summary>
        /// Себестоимость с учетом дочерних продуктов, в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPair">Валютная пара, содержащая котировку для преобразования валют.</param>
        /// <returns>Себестоимость.</returns>
        decimal GetSelfCost(Currency targetCurrency, CurrencyPair currencyPair);

        /// <summary>
        /// Себестоимость с учетом дочерних продуктов, в указанной валюте.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары.</param>
        /// <returns>Себестоимость.</returns>
        decimal GetSelfCost(Currency targetCurrency, CurrencyPair[] currencyPairs);

        /// <summary>
        /// Базовая стоимость.
        /// </summary>
        decimal BaseValue { get; set; }

        /// <summary>
        /// Валюта.
        /// </summary>
        Currency Currency { get; set; }

        /// <summary>
        /// Базовый коэффициеннт.
        /// </summary>
        decimal Coefficient { get; set; }

        /// <summary>
        /// Коэффициент для вычисления себестоимости.
        /// </summary>
        decimal SelfCostCoefficient { get; set; }

        /// <summary>
        /// Скидка, %.
        /// </summary>
        decimal Diskount { get; set; }

        /// <summary>
        /// Наценка, %.
        /// </summary>
        decimal Markup { get; set; }
    }
}
