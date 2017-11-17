using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Management;
using CRM7.DataModel.Files;

namespace CRM7.DataModel.Commercial
{
    /// <summary>
    /// Коммерческое предложение.
    /// </summary>
    [Table(nameof(Proposal))]
    public class Proposal : IPriceable
    {
        /// <summary>
        /// Создает новый экземпляр Proposal.
        /// </summary>
        public Proposal()
        {
            Id = Guid.NewGuid();
            Positions = new List<ProposalPosition>();
            Date = DateTime.Now;
            AdditionallyCost = new List<CPOption>();
        }

        [Key]
        public Guid Id { get; set; }

        public Guid MakerOrganizationId { get; set; }

        /// <summary>
        /// Компания, выставляющая предложение.
        /// </summary>
        public virtual Facility MakerOrganization { get; set; }

        public Guid MakerId { get; set; }

        /// <summary>
        /// Создатель предложения.
        /// </summary>
        public virtual Contact Maker { get; set; }

        public Guid SigningPersonId { get; set; }

        /// <summary>
        /// Подписывающее лицо.
        /// </summary>
        public virtual Contact SigningPerson { get; set; }

        public Guid? ContragentOrganizationId { get; set; }

        /// <summary>
        /// Компания, которой выставляется предложение.
        /// </summary>
        public virtual Facility ContragentOrganization { get; set; }

        public Guid? RecipientId { get; set; }

        /// <summary>
        /// Представитель компании-контрагента.
        /// </summary>
        public virtual Contact Recipient { get; set; }
        
        /// <summary>
        /// Номер исходящего письма (КП).
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Дата создания КП.
        /// </summary>        
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Условия поставки.
        /// </summary>
        public string Inventory { get; set; }
        
        /// <summary>
        /// Условия оплаты.
        /// </summary>
        public string Payment { get; set; }
        
        /// <summary>
        /// Условия гарантии.
        /// </summary>
        public string Guarantee { get; set; }
        
        /// <summary>
        /// Условия доставки.
        /// </summary>
        public string Transport { get; set; }
        
        /// <summary>
        /// Срок поставки.
        /// </summary>
        public string DeliveryPeriod { get; set; }
        
        /// <summary>
        /// Способ поставки.
        /// </summary>
        public string DeliveryWay { get; set; }

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

        /// <summary>
        /// Игнорировать скидку и наценку для целевых прайсов.
        /// </summary>
        public bool IgnoreDM { get; set; }

        /// <summary>
        /// Стоимость доставки (расплывается по позициям пропорционально их стоимости).
        /// </summary>        
        public decimal DeliveryCost { get; set; }

        /// <summary>
        /// Стоимость ДМ(хз что это) (расплывается по позициям пропорционально их стоимости).
        /// </summary>
        public decimal DMCost { get; set; }

        /// <summary>
        /// Коеффициент (умножается на DMCost).
        /// </summary>
        public decimal DMCoef { get; set; }

        /// <summary>
        /// Дополнительные расходы (расплываются по позициям пропорционально их стоимости).
        /// </summary>
        public virtual ICollection<CPOption> AdditionallyCost { get; set; }

        #endregion

        /// <summary>
        /// Отображать исполнителя при выводе КП в Word.
        /// </summary>
        public bool DisplayMaker { get; set; }

        /// <summary>
        /// Список позиций в предложении.
        /// </summary>
        public virtual ICollection<ProposalPosition> Positions { get; set; }
        
        /// <summary>
        /// Спецификация.
        /// </summary>
        public virtual Specification Specification { get; set; }

        /// <summary>
        /// Выставленные счета.
        /// </summary>
        public virtual ICollection<Invoice> Invoices { get; set; }

        public Guid FileId { get; set; }

        public virtual File File { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmittingProposal">Принимаемая компания.</param>
        /// <returns></returns>
        public Proposal CloneFrom(Proposal transmittingProposal)
        {
            Number = transmittingProposal.Number;
            Date = transmittingProposal.Date;
            Inventory = transmittingProposal.Inventory;
            Payment = transmittingProposal.Payment;
            Guarantee = transmittingProposal.Guarantee;
            Transport = transmittingProposal.Transport;
            DeliveryPeriod = transmittingProposal.DeliveryPeriod;
            DeliveryWay = transmittingProposal.DeliveryWay;
            BaseValue = transmittingProposal.BaseValue;
            Currency = transmittingProposal.Currency;
            Coefficient = transmittingProposal.Coefficient;
            SelfCostCoefficient = transmittingProposal.SelfCostCoefficient;
            Diskount = transmittingProposal.Diskount;
            Markup = transmittingProposal.Markup;
            IgnoreDM = transmittingProposal.IgnoreDM;
            DeliveryCost = transmittingProposal.DeliveryCost;
            DMCost = transmittingProposal.DMCost;
            DMCoef = transmittingProposal.DMCoef;
            DisplayMaker = transmittingProposal.DisplayMaker;

            return this;
        }
    }
}
