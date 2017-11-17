using CRM7.DataModel.Catalog;
using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Management;
using CRM7.DataModel.Product;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.SOF;
using CRM7.DataModel.Product.Valve;
using CRM7.Mapping;
using CRM7.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace CRM7.Service
{
    //Прототип класса с прототипами функций
    public class Catalogue
    {

        /// <summary>
        /// Добавить каталог.
        /// </summary>
        /// <param name="catalog">Каталог.</param>
        /// <returns>Каталог.</returns>
        public Catalog AddCatalog(Catalog catalog)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Catalogs.Where(i => i.Id == catalog.Id).Count() > 0)
                {
                    return catalog;
                }
                catalog = context.Catalogs.Add(catalog);
                context.SaveChanges();
                return catalog;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Catalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить позицию арматуры в каталог.
        /// </summary>
        /// <param name="valveInCatalog">Позиция арматуры в каталоге.</param>
        /// <param name="catalogId">Id каталога.</param>
        /// <returns>Добавленная в каталог позиция.</returns>
        public ValveInCatalog AddValveInCatalog(ValveInCatalog valveInCatalog, Guid catalogId, Guid valveModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.ValveInCatalogs.Where(i => i.Id == valveInCatalog.Id).Count() > 0)
                {
                    return valveInCatalog;
                }
                valveInCatalog.Catalog = context.Catalogs.Find(catalogId);
                valveInCatalog.ValveModel = context.ValveModels.Find(valveModelId);
                valveInCatalog = context.ValveInCatalogs.Add(valveInCatalog);
                context.SaveChanges();
                return valveInCatalog;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Catalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }



        /// <summary>
        /// Получить все каталоги.
        /// </summary>        
        /// <returns>Каталоги.</returns>
        public List<Catalog> GetAllCatalogs()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<Catalog> tempCatalogs = context.Catalogs.ToList();
                return tempCatalogs;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Catalogs + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        #region GetValveProperties

        /// <summary>
        /// Получить названия всех производителей арматуры.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <returns>Список названий производителей арматуры.</returns>
        public List<Company> GetValveManufacturersInCatalog(Guid catalogId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<Company> tempManufacturers = context.Catalogs.Find(catalogId).Valves.Select(i => i.ValveModel.Manufacturer).Distinct().ToList();
                return tempManufacturers;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveManufacturers + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы арматуры от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <returns>Типы арматуры.</returns>
        public List<ValveType> GetValveTypesOfManufacturerInCatalog(Guid catalogId, Guid manufacturerId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel).Where(i => i.ManufacturerId == manufacturerId).ToList();
                List<ValveType> tempValveTypes = vm.Select(i => i.Type).Distinct().ToList();                                
                return tempValveTypes;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveTypes + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все серии арматуры одного типа от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <returns>Серии арматуры.</returns>
        public List<ValveSeries> GetValveSeriesOfTypeInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel).Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId).ToList();
                List<ValveSeries> tempValveSeries = vm.Select(i => i.Series).Distinct().ToList();
                return tempValveSeries;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveSeries + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы присоединения арматуры одной серии одного типа от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <returns>Типы присоединений арматуры.</returns>
        public List<ValveConnection> GetValveConnectionOfSeriesInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, Guid seriesId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId && i.SeriesId == seriesId).ToList();
                List<ValveConnection> tempValveConnection = vm.Select(i => i.Connection).Distinct().ToList();
                return tempValveConnection;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveConnections + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все среды для арматуры одного типы присоединения одной серии одного типа от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <returns>Среды для арматуры.</returns>
        public List<DataModel.Product.Environment> GetValveEnvironmentOfConnectionInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, Guid seriesId, Guid connectionId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId && i.SeriesId == seriesId && i.ConnectionId == connectionId).ToList();
                List<DataModel.Product.Environment> tempValveEnvironment = vm.Select(i => i.Environment).Distinct().ToList();
                return tempValveEnvironment;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Environments + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все материалы корпуса для арматуры одной среды одного типы присоединения одной серии одного типа от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <returns>Материалы корпуса арматуры.</returns>
        public List<Material> GetValveMaterialBodyOfEnvironmentInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, Guid seriesId, Guid connectionId, Guid environmentId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId 
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId).ToList();
                List<Material> tempBodyMaterial = vm.Select(i => i.BodyMaterial).Distinct().ToList();
                return tempBodyMaterial;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Materials + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы уплотнений для арматуры одного материала корпуса одной среды одного типы присоединения одной серии одного типа от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId"> Id материала корпуса.</param>
        /// <returns>Типы уплотнения арматуры.</returns>
        public List<Consolidation> GetValveConsolidationOfMaterialInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, Guid seriesId, Guid connectionId, Guid environmentId, Guid materialId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId && i.BodyMaterialId == materialId).ToList();
                List<Consolidation> tempValveConsolidation = vm.Select(i => i.Consolidation).Distinct().ToList();
                return tempValveConsolidation;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidations + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели арматуры одного типа уплотнения, одного материала корпуса, одной среды, 
        /// одного типы присоединения, одной серии, одного типа, от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <returns>Модели арматуры.</returns>
        public List<ValveModel> GetValveModelsOfConsolidationInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, 
                                                                        Guid seriesId, Guid connectionId, Guid environmentId, 
                                                                        Guid materialId, Guid consolidationId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.ValveModel)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId && i.BodyMaterialId == materialId
                            && i.ConsolidationId == consolidationId).ToList();
                return vm;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidations + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        #endregion

    }
}
