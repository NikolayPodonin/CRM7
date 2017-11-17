using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.DataModel
{
    /// <summary>
    /// Валютная пара.
    /// </summary>
    public struct CurrencyPair
    {
        /// <summary>
        /// Базовая валюта.
        /// </summary>
        public Currency BaseCurrency { get; set; }

        /// <summary>
        /// Котируемая валюта.
        /// </summary>
        public Currency QuotedCurrency { get; set; }

        /// <summary>
        /// Курс (отношение стоимости базовой валюты к котируемой).
        /// </summary>
        public decimal Rate { get; set; }
    }
}
