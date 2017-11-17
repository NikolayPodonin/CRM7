using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel.Localization
{
    /// <summary>
    /// Локализованные строки. //чуть позже перенесем в библиотеку tools
    /// </summary>
    public class LocalizedStrings
    {
        /// <summary>
        /// Валютная пара не подходит для преобразования необходимых валют.
        /// </summary>
        public string InvalidCurrencyPair = "Валютная пара не подходит для преобразования необходимых валют.";

        /// <summary>
        /// Отсутствует валютная пара для преобразования валют.
        /// </summary>
        public string NoCurrencyPair = "Отсутствует валютная пара для преобразования валют.";

        /// <summary>
        /// Тип модели не соответствует типу продукта.
        /// </summary>
        public string InvalidRotorModelType = "Тип модели не соответствует типу продукта.";
    }
}
