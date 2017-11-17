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
    /// Привод.
    /// </summary>
    [Table(nameof(Rotor))]
    public class Rotor : IProduct, IPriceable
    {
        /// <summary>
        /// Создает новый экземпляр Rotor.
        /// </summary>
        public Rotor()
        {
            Id = Guid.NewGuid();
            RotorOptions = new List<RotorOption>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid ModelId { get; set; }

        /// <summary>
        /// Модель привода.
        /// </summary>
        [NotMapped]
        RotorModel _Model;
        
        /// <summary>
        /// Модель привода.
        /// </summary>
        public virtual RotorModel Model
        {
            get
            {
                return _Model;
            }
            set
            {                
                if (this is ElectricActuator && value is ElectricActuatorModel) _Model = value;
                else if (this is PneumaticActuator && value is PneumaticActuatorModel) _Model = value;
                else if (this is ManualGear && value is ManualGearModel) _Model = value;
                else if (this is Rotor && value is RotorModel) _Model = value;
                else throw new InvalidCastException(Localization.LocalizationManager.LocalizedStrings.InvalidRotorModelType);
            }
        }

        public string Number { get; set; }

        public Guid? StorageId { get; set; }

        /// <summary>
        /// Склад, на котором находится привод.
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
        /// Получить итоговую стоимость в указанной валюте с учетом стоимости опций.
        /// </summary>
        /// <param name="targetCurrency">Целевая валюта.</param>
        /// <param name="currencyPairs">Валютные пары, содержащие котировки для преобразования валют.</param>
        public decimal GetCost(Currency targetCurrency, CurrencyPair[] currencyPairs)
        {
            decimal value = Price.GetValue(targetCurrency, currencyPairs);
            foreach (var op in RotorOptions)
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
        /// Привод в КП, для которого зарезервирован привод.
        /// </summary>
        public virtual RotorInPosition ReservedBy { get; set; }
        
        /// <summary>
        /// Арматура, на которую установлен привод.
        /// </summary>
        public virtual Valve.Valve Valve { get; set; }

        /// <summary>
        /// Опции привода.
        /// </summary>
        public virtual ICollection<RotorOption> RotorOptions { get; set; }
    }
}
