using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.Tools
{
    public static class LocalizedStrings
    {

        /// <summary>
        /// Текущее имя базы данных.
        /// </summary>
        public static readonly string DatabaseName = "DbConnection";

        /// <summary>
        /// Предупреждение.
        /// </summary>
        public static readonly string Warning = "Предупреждение";

        /// <summary>
        /// Смотри вложенное исключение.
        /// </summary>
        public static readonly string SeeInnerException = " Смотри вложенное исключение.";

        /// <summary>
        /// ... с таким Id не существует в базе.
        /// </summary>
        public static readonly string NotExistsSmth = " с таким Id не существует в базе.";

        /// <summary>
        /// ... добавить не удалось.
        /// </summary>
        public static readonly string CantAddSmth = " добавить не удалось.";

        /// <summary>
        /// ... is not deleted. Нельзя удалить объект, для которой созданы другие объекты или документы.
        /// </summary>
        public static readonly string CantDeleteSmth = " is not deleted. Нельзя удалить объект, для которой созданы другие объекты или документы.";

        /// <summary>
        /// ... обновить не удалось.
        /// </summary>
        public static readonly string CantUpdateSmth = " обновить не удалось.";

        /// <summary>
        /// ... получить не удалось.
        /// </summary>
        public static readonly string CantGetSmth = " получить не удалось.";

        #region Commercial

        /// <summary>
        /// Компания.
        /// </summary>
        public static string Company = "Компания";

        /// <summary>
        /// Компании.
        /// </summary>
        public static string Companies = "Компании";

        /// <summary>
        /// Объект.
        /// </summary>
        public static string Facility = "Объект";

        #endregion

        #region Models and properties

        /// <summary>
        /// Категория продукции.
        /// </summary>
        public static readonly string ProductCategory = "Категория продукции";

        /// <summary>
        /// Категории продукции.
        /// </summary>
        public static readonly string ProductCategories = "Категории продукции";

        /// <summary>
        /// Модель.
        /// </summary>
        public static readonly string Model = "Модель";

        /// <summary>
        /// Модели.
        /// </summary>
        public static readonly string Models = "Модели";
        
        /// <summary>
        /// Среда.
        /// </summary>
        public static readonly string Environment = "Среда";

        /// <summary>
        /// Среды.
        /// </summary>
        public static readonly string Environments = "Среды";

        /// <summary>
        /// Типы материала.
        /// </summary>
        public static readonly string MaterialType = "Тип материала";

        /// <summary>
        /// Типы материалов.
        /// </summary>
        public static readonly string MaterialTypes = "Типы материалов";

        /// <summary>
        /// Материал.
        /// </summary>
        public static readonly string Material = "Материал";

        /// <summary>
        /// Материалы.
        /// </summary>
        public static readonly string Materials = "Материалы";

        /// <summary>
        /// Тип уплотнения.
        /// </summary>
        public static readonly string Consolidation = "Тип уплотнения";

        /// <summary>
        /// Типы уплотнения.
        /// </summary>
        public static readonly string Consolidations = "Типы уплотнения";

        /// <summary>
        /// Тип регулирования.
        /// </summary>
        public static readonly string Controlling = "Тип регулирования";

        /// <summary>
        /// Модель арматуры.
        /// </summary>
        public static readonly string ValveModel = "Модель арматуры";

        /// <summary>
        /// Модель арматуры.
        /// </summary>
        public static readonly string ValveModels = "Модель арматуры";

        /// <summary>
        /// Производители арматуры.
        /// </summary>
        public static readonly string ValveManufacturers = "Производители арматуры";

        /// <summary>
        /// Тип арматуры.
        /// </summary>
        public static readonly string ValveType = "Тип арматуры";

        /// <summary>
        /// Типы арматуры.
        /// </summary>
        public static readonly string ValveTypes = "Типы арматуры";

        /// <summary>
        /// Серии арматуры.
        /// </summary>
        public static readonly string ValveSeries = "Серии арматуры";

        /// <summary>
        /// Тип присоединения арматуры.
        /// </summary>
        public static readonly string ValveConnection = "Тип присоединения арматуры";

        /// <summary>
        /// Типы присоединения арматуры.
        /// </summary>
        public static readonly string ValveConnections = "Типы присоединения арматуры";

        /// <summary>
        /// Диаметр номинальный.
        /// </summary>
        public static readonly string DN = "Диаметр номинальный";

        /// <summary>
        /// Диаметры номинальные.
        /// </summary>
        public static readonly string DNs = "Диаметры номинальные";

        /// <summary>
        /// Давление номинальное.
        /// </summary>
        public static readonly string PN = "Давление номинальное";

        /// <summary>
        /// Давления номинальные.
        /// </summary>
        public static readonly string PNs = "Давления номинальные";

        /// <summary>
        /// Модель КОФ.
        /// </summary>
        public static readonly string SofModel = "Модель КОФ";

        /// <summary>
        /// Модели КОФ.
        /// </summary>
        public static readonly string SofModels = "Модели КОФ";

        /// <summary>
        /// Тип ротора.
        /// </summary>
        public static readonly string RotorType = "Тип ротора";

        /// <summary>
        /// Типы ротора.
        /// </summary>
        public static readonly string RotorTypes = "Типы ротора";

        /// <summary>
        /// Модель пневмопривода.
        /// </summary>
        public static readonly string PneumaticActuatorModel = "Модель пневмопривода";

        /// <summary>
        /// Модели пневмопривода.
        /// </summary>
        public static readonly string PneumaticActuatorModels = "Модели пневмопривода";

        /// <summary>
        /// Модель электропривода.
        /// </summary>
        public static readonly string ElectricActuatorModel = "Модель электропривода";

        /// <summary>
        /// Модели электропривода.
        /// </summary>
        public static readonly string ElectricActuatorModels = "Модели электропривода";

        /// <summary>
        /// Модель ручного редуктора.
        /// </summary>
        public static readonly string ManualGearModel = "Модель ручного редуктора";

        /// <summary>
        /// Модели ручного редуктора.
        /// </summary>
        public static readonly string ManualGearModels = "Модели ручного редуктора";
        
        /// <summary>
        /// Модель опций пневмопривода.
        /// </summary>
        public static readonly string PAOptionModel = "Модель опций пневмопривода";

        /// <summary>
        /// Модели опций пневмопривода.
        /// </summary>
        public static readonly string PAOptionModels = "Модели опций пневмопривода";

        /// <summary>
        /// Модель опций электропривода.
        /// </summary>
        public static readonly string EAOptionModel = "Модель опций электропривода";

        /// <summary>
        /// Модели опций электропривода.
        /// </summary>
        public static readonly string EAOptionModels = "Модели опций электропривода";
        
        /// <summary>
        /// Соответствие между моделями ротора и арматуры.
        /// </summary>
        public static readonly string ValveRotorDismatch = "Соответствие между моделями ротора и арматуры";

        /// <summary>
        /// Соответствие между моделями фланцев и арматуры.
        /// </summary>
        public static readonly string ValveSofDismatch = "Соответствие между моделями фланцев и арматуры";

        #endregion


        #region Catalog

        /// <summary>
        /// Каталог.
        /// </summary>
        public static string Catalog = "Каталог";

        /// <summary>
        /// Каталоги.
        /// </summary>
        public static string Catalogs = "Каталоги";

        /// <summary>
        /// Позиция арматуры в каталоге.
        /// </summary>
        public static string ValveInCatalog = "Позиция арматуры в каталоге";

        /// <summary>
        /// Позиция ротора в каталоге.
        /// </summary>
        public static string RotorInCatalog = "Позиция ротора в каталоге";

        /// <summary>
        /// Позиция опции ротора в каталоге
        /// </summary>
        public static string RotorOptionInCatalog = "Позиция опции ротора в каталоге";

        /// <summary>
        /// Позиция КОФ в каталоге.
        /// </summary>
        public static string SofInCatalog = "Позиция КОФ в каталоге";

        /// <summary>
        /// Добавленная вручную позиция в каталоге.
        /// </summary>
        public static readonly string ManualPositionInCatalog = "Добавленная вручную позиция в каталоге";

        #endregion

        #region Product


        #endregion

    }
}
