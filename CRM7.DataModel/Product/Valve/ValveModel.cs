using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRM7.DataModel.Management;
using CRM7.DataModel.Catalog.CatalogPosition;

namespace CRM7.DataModel.Product.Valve
{
    /// <summary>
    /// Модель трубопроводной арматуры.
    /// </summary>
    [Table(nameof(ValveModel))]
    public class ValveModel : IProductModel
    {
        /// <summary>
        /// Создает новый экземпляр ValveModel.
        /// </summary>
        public ValveModel()
        {
            Id = Guid.NewGuid();
            RotorDismatches = new List<ValveRotorDismatch>();
            SofDismatches = new List<ValveSofDismatch>();
            ValveInCatalogs = new List<ValveInCatalog>();
        }
     
        [Key]
        public Guid Id { get; set; }
        
        public Guid ManufacturerId { get; set; }

        /// <summary>
        /// Производитель.
        /// </summary>
        public virtual Company Manufacturer { get; set; }

        public Guid TypeId { get; set; }

        /// <summary>
        /// Тип арматуры (тип запорого элемента).
        /// </summary>
        public virtual ValveType Type { get; set; }

        public Guid SeriesId { get; set; }

        /// <summary>
        /// Серия.
        /// </summary>
        public virtual ValveSeries Series { get; set; }

        public Guid ConnectionId { get; set; }

        /// <summary>
        /// Тип присоединения.
        /// </summary>
        public virtual ValveConnection Connection { get; set; }

        public Guid EnvironmentId { get; set; }

        /// <summary>
        /// Рабочая среда.
        /// </summary>
        public virtual Environment Environment { get; set; }

        public Guid ConsolidationId { get; set; }

        /// <summary>
        /// Тип уплотнения.
        /// </summary>
        public virtual Consolidation Consolidation { get; set; }

        /// <summary>
        /// Запорный (можно перекрывать поток среды).
        /// </summary>
        public bool ShutOff { get; set; }

        /// <summary>
        /// Регулирующий (можно регулировать поток среды).
        /// </summary>
        public bool Controlling { get; set; }
        
        /// <summary>
        /// Может быть А класса.
        /// </summary>
        public bool CanBeClassA { get; set; }

        /// <summary>
        /// Может иметь температурное расширение.
        /// </summary>
        public bool CanHaveTemperatureExtantion { get; set; }

        /// <summary>
        /// Имеет температурное расширение.
        /// </summary>        
        bool _haveTemperatureExtantion;

        /// <summary>
        /// Имеет температурное расширение.
        /// </summary>
        [NotMapped]
        public bool HaveTemperatureExtantion
        {
            get
            {
                if (CanHaveTemperatureExtantion)
                {
                    return _haveTemperatureExtantion;
                }
                return false;
            }
            set
            {
                if (CanHaveTemperatureExtantion)
                {
                    _haveTemperatureExtantion = value;
                }
                _haveTemperatureExtantion = false;
            }
        }

        /// <summary>
        /// Минимальная температура рабочей среды, °С.
        /// </summary>
        public int MinTemperatureInside { get; set; }

        /// <summary>
        /// Максимальная температура рабочей среды, °С.
        /// </summary>
        public int MaxTemperatureInside { get; set; }

        /// <summary>
        /// Минимальная температура внешней среды, °С.
        /// </summary>
        public int MinTemperatureOutside { get; set; }

        /// <summary>
        /// Максимальная температура внешней среды, °С.
        /// </summary>
        public int MaxTemperatureOutside { get; set; }

        /// <summary>
        /// Назначение.
        /// </summary>
        public string Purpose { get; set; }

        #region materials

        public Guid? BodyMaterialId { get; set; }

        /// <summary>
        /// Материал корпуса.
        /// </summary>
        public virtual Material BodyMaterial { get; set; }

        public Guid? CloseElementMaterialId { get; set; }

        /// <summary>
        /// Материал запорного элемента.
        /// </summary>
        public virtual Material CloseElementMaterial { get; set; }

        public Guid? RodMaterialId { get; set; }

        /// <summary>
        /// Материал штока.
        /// </summary>
        public virtual Material RodMaterial { get; set; }

        public Guid? InsideConsolidationMaterialId { get; set; }
        
        /// <summary>
        /// Материал уплотнения запорного элемента.
        /// </summary>
        public virtual Material InsideConsolidationMaterial { get; set; }

        public Guid? RodConsolidationMaterialId { get; set; }
        
        /// <summary>
        /// Матириал уплотнения штока.
        /// </summary>
        public virtual Material RodConsolidationMaterial { get; set; }

        #endregion

        /// <summary>
        /// Номинальный диаметр, мм.
        /// </summary>
        public int NominalDN { get; set; }

        /// <summary>
        /// Диаметр прохода, мм.
        /// </summary>
        public int CanalDN { get; set; }

        /// <summary>
        /// Диаметр в виде строки.
        /// </summary>
        public string DN { get; set; }

        /// <summary>
        /// Максимальное давление среды, бар.
        /// </summary>
        public double PN { get; set; }

        /// <summary>
        /// Максимальный перепад давлений, бар.
        /// </summary>
        public int DeltaP { get; set; }

        /// <summary>
        /// Длина, мм.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Высота, мм.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Масса, кг.
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Высота корпуса, без ручного рычага и выступающей части штока, мм.
        /// </summary>
        public int BodyHeight { get; set; }

        /// <summary>
        /// Масса корпуса без ручного рычага, кг.
        /// </summary>
        public double BodyMass { get; set; }

        /// <summary>
        /// Пропускная способность, м^3/ч.
        /// </summary>
        public int Kv { get; set; }
        
        /// <summary>
        /// Рабочий момент, Нм.
        /// </summary>
        public int Torque { get; set; }

        /// <summary>
        /// Короткое описание.
        /// </summary>
        public string ShortDesignation
        {
            get
            {
                return Series.Name + ", DN " + DN + ", PN " + PN + ", " + Consolidation.Name + ", ";
            }
            private set { }
        }

        /// <summary>
        /// Полное описание.
        /// </summary>
        public string FullDesignation { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Список приводов, которые подходят для этой арматуры.
        /// </summary>
        public virtual ICollection<ValveRotorDismatch> RotorDismatches { get; set; }

        /// <summary>
        /// Список фланцев, которые подходят для этой арматуры
        /// </summary>
        public virtual ICollection<ValveSofDismatch> SofDismatches { get; set; }

        /// <summary>
        /// Позиции модели арматуры в каталогах.
        /// </summary>
        public virtual ICollection<ValveInCatalog> ValveInCatalogs { get; set; }

        /// <summary>
        /// Метод, присваивающий полям объекта значения полей принимаемого объекта. 
        /// Касается только полей, не участвующих в связях модели данных.
        /// </summary>
        /// <param name="transmitting">Принимаемый объект.</param>
        /// <returns></returns>
        public ValveModel CloneFrom(ValveModel transmitting)
        {
            ShutOff = transmitting.ShutOff;
            Controlling = transmitting.Controlling;
            CanBeClassA = transmitting.CanBeClassA;
            CanHaveTemperatureExtantion = transmitting.CanHaveTemperatureExtantion;
            _haveTemperatureExtantion = transmitting._haveTemperatureExtantion;
            MinTemperatureInside = transmitting.MinTemperatureInside;
            MaxTemperatureInside = transmitting.MaxTemperatureInside;
            MinTemperatureOutside = transmitting.MinTemperatureOutside;
            MaxTemperatureOutside = transmitting.MaxTemperatureOutside;
            Purpose = transmitting.Purpose;
            NominalDN = transmitting.NominalDN;
            CanalDN = transmitting.CanalDN;
            DN = transmitting.DN;
            PN = transmitting.PN;
            DeltaP = transmitting.DeltaP;
            Length = transmitting.Length;
            Height = transmitting.Height;
            Mass = transmitting.Mass;
            BodyHeight = transmitting.BodyHeight;
            BodyMass = transmitting.BodyMass;
            Kv = transmitting.Kv;
            Torque = transmitting.Torque;
            ShortDesignation = transmitting.ShortDesignation;
            FullDesignation = transmitting.FullDesignation;
            Unit = transmitting.Unit;
            return this;
        }
    }
}
