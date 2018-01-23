using CRM7.DataModel.Catalog;
using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Management;
using CRM7.DataModel.OnlineStore;
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
    // будет дописываться
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
        /// <param name="valveModelId">Id модели арматуры.</param>
        /// <param name="rotorTypeId">Id типа ротора.</param>
        /// <returns>Добавленная в каталог позиция.</returns>
        public ValveInCatalog AddValveInCatalog(ValveInCatalog valveInCatalog, Guid catalogId, Guid valveModelId , Guid rotorTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.ValveInCatalogs.Where(i => i.Id == valveInCatalog.Id).Count() > 0)
                {
                    return valveInCatalog;
                }
                valveInCatalog.Catalog = context.Catalogs.Find(catalogId);
                valveInCatalog.Model = context.ValveModels.Find(valveModelId);
                valveInCatalog.RotorType = context.RotorTypes.Find(rotorTypeId);
                valveInCatalog = context.ValveInCatalogs.Add(valveInCatalog);
                context.SaveChanges();
                return valveInCatalog;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveInCatalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить позицию ротора в каталог.
        /// </summary>
        /// <param name="rotorInCatalog">Позиция ротора.</param>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="rotorModelId">Id модели ротора.</param>
        /// <returns></returns>
        public RotorInCatalog AddRotorInCatalog(RotorInCatalog rotorInCatalog, Guid catalogId, Guid rotorModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.RotorInCatalogs.Where(i => i.Id == rotorInCatalog.Id).Count() > 0)
                {
                    return rotorInCatalog;
                }
                rotorInCatalog.Catalog = context.Catalogs.Find(catalogId);
                rotorInCatalog.Model = context.RotorModels.Find(rotorModelId);
                rotorInCatalog = context.RotorInCatalogs.Add(rotorInCatalog);
                context.SaveChanges();
                return rotorInCatalog;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.RotorInCatalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить позицию фланцев в каталог.
        /// </summary>
        /// <param name="sofInCatalog">Позиция ротора.</param>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="sofModelId">Id модели фланцев.</param>
        /// <returns></returns>
        public SofInCatalog AddSofInCatalog(SofInCatalog sofInCatalog, Guid catalogId, Guid sofModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.SofInCatalogs.Where(i => i.Id == sofInCatalog.Id).Count() > 0)
                {
                    return sofInCatalog;
                }
                sofInCatalog.Catalog = context.Catalogs.Find(catalogId);
                sofInCatalog.Model = context.SofModels.Find(sofModelId);
                sofInCatalog = context.SofInCatalogs.Add(sofInCatalog);
                context.SaveChanges();
                return sofInCatalog;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofInCatalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
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

        /// <summary>
        /// Получить все категории продукции из каталога.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <returns></returns>
        public List<ProductCategory> GetProductCategoriesFromCatalog(Guid catalogId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<ProductCategory> tempCategories = context.Catalogs.Find(catalogId).GetAllModels().Select(i => i.Category).Distinct().ToList();
                return tempCategories;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Catalogs + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        #region GetValveProperties

        /// <summary>
        /// Получить всех производителей арматуры.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <returns>Список названий производителей арматуры.</returns>
        public List<Company> GetValveManufacturersInCatalog(Guid catalogId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<Company> tempManufacturers = context.Catalogs.Find(catalogId).Valves.Select(i => i.Model.Manufacturer).Distinct().ToList();
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model).Where(i => i.ManufacturerId == manufacturerId).ToList();
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model).Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId).ToList();
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
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
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
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
        /// Получить все возможные виды регулирования одного типа уплотнения, одного материала корпуса, одной среды, 
        /// одного типы присоединения, одной серии, одного типа, от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId">Id материала корпуса.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <returns>Виды регулирования (запорная/регулирующая).</returns>
        public List<bool> GetControllingOfConsolidationInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId, 
                                                                        Guid seriesId, Guid connectionId, Guid environmentId, 
                                                                        Guid materialId, Guid consolidationId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId && i.BodyMaterialId == materialId
                            && i.ConsolidationId == consolidationId).ToList();
                return vm.Select(v => v.Controlling).Distinct().ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Controlling + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все возможные диаметры одного вида регулирования одного типа уплотнения, одного материала корпуса, одной среды, 
        /// одного типы присоединения, одной серии, одного типа, от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId">Id материала корпуса.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <param name="controlling">Запорная/регулирующая</param>
        /// <returns>Диаметры.</returns>
        public List<string> GetDiametersOfControllingInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId,
                                                                        Guid seriesId, Guid connectionId, Guid environmentId,
                                                                        Guid materialId, Guid consolidationId, bool controlling)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId && i.BodyMaterialId == materialId
                            && i.ConsolidationId == consolidationId && i.Controlling == controlling).ToList();
                return vm.Select(v => v.DN).Distinct().ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.DNs + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все возможные давления одного димаетра одного вида регулирования одного типа уплотнения, одного материала корпуса, одной среды, 
        /// одного типы присоединения, одной серии, одного типа, от производителя в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId">Id материала корпуса.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <param name="controlling">Запорная/регулирующая</param>
        /// <param name="DN">Диаметр</param>
        /// <returns>Давления.</returns>
        public List<double> GetPNsOfDiameterInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId,
                                                                        Guid seriesId, Guid connectionId, Guid environmentId,
                                                                        Guid materialId, Guid consolidationId, bool controlling,
                                                                        string DN)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveModel> vm = cat.Valves.Select(i => i.Model)
                    .Where(i => i.ManufacturerId == manufacturerId && i.TypeId == typeId
                            && i.SeriesId == seriesId && i.ConnectionId == connectionId
                            && i.EnvironmentId == environmentId && i.BodyMaterialId == materialId
                            && i.ConsolidationId == consolidationId && i.Controlling == controlling
                            && i.DN == DN).ToList();
                return vm.Select(v => v.PN).Distinct().ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PNs + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все роторы одного типа в каталоге, которые можно поставить на модель арматуры.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId">Id материала корпуса.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <param name="controlling">Запорная/регулирующая</param>
        /// <param name="DN">Диаметр</param>
        /// <param name="PN">Давление.</param>
        /// <returns>Типы роторов.</returns>
        public List<RotorType> GetRotorTypesOfPNInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId,
                                                                        Guid seriesId, Guid connectionId, Guid environmentId,
                                                                        Guid materialId, Guid consolidationId, bool controlling,
                                                                        string DN, double PN)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                List<ValveInCatalog> vc = cat.Valves.Where(i => i.Model.ManufacturerId == manufacturerId && i.Model.TypeId == typeId
                            && i.Model.SeriesId == seriesId && i.Model.ConnectionId == connectionId
                            && i.Model.EnvironmentId == environmentId && i.Model.BodyMaterialId == materialId
                            && i.Model.ConsolidationId == consolidationId && i.Model.Controlling == controlling
                            && i.Model.DN == DN && i.Model.PN == PN).ToList();
                return vc.Select(v => v.RotorType).Distinct().ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.RotorTypes + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить позицию арматуры в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="manufacturerId">Id производителя.</param>
        /// <param name="typeId">Id типа арматуры.</param>
        /// <param name="seriesId">Id серии арматуры.</param>
        /// <param name="connectionId">Id типа соединения арматуры.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="materialId">Id материала корпуса.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <param name="controlling">Запорная/регулирующая</param>
        /// <param name="DN">Диаметр</param>
        /// <param name="PN">Давление.</param>
        /// <param name="rotorTypeId">Id типа ротора.</param>
        /// <returns>Роторы.</returns>
        public ValveInCatalog GetValveInCatalog(Guid catalogId, Guid manufacturerId, Guid typeId,
                                                                        Guid seriesId, Guid connectionId, Guid environmentId,
                                                                        Guid materialId, Guid consolidationId, bool controlling,
                                                                        string DN, double PN, Guid rotorTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                ValveInCatalog vc = cat.Valves.Where(i => i.Model.ManufacturerId == manufacturerId && i.Model.TypeId == typeId
                            && i.Model.SeriesId == seriesId && i.Model.ConnectionId == connectionId
                            && i.Model.EnvironmentId == environmentId && i.Model.BodyMaterialId == materialId
                            && i.Model.ConsolidationId == consolidationId && i.Model.Controlling == controlling
                            && i.Model.DN == DN && i.Model.PN == PN).Single(rm => rm.RotorTypeId == rotorTypeId);
                return vc;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveInCatalog + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }
                

        /// <summary>
        /// Получить все модели роторов для модели арматуры в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="valveInCatalogId">Id арматуры в каталоге.</param>
        /// <returns>Роторы.</returns>
        public List<RotorInCatalog> GetRotorsForValveInCatalog(Guid catalogId, Guid valveInCatalogId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                ValveInCatalog vc = cat.Valves.Single(i => i.Id == valveInCatalogId);
                List<RotorModel> rms = vc.Model.RotorDismatches.Select(rd => rd.RotorModel).Where(rm => rm.TypeId == vc.RotorTypeId).ToList();
                List<RotorInCatalog> result = new List<RotorInCatalog>();
                foreach (var ric in cat.Rotors)
                {
                    foreach(var rotm in rms)
                    {
                        if(ric.ModelId == rotm.Id)
                        {
                            result.Add(ric); 
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.RotorInCatalog + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все фланцы для модели арматуры в каталоге.
        /// </summary>
        /// <param name="catalogId">Id каталога.</param>
        /// <param name="valveInCatalogId">Id арматуры в каталоге.</param>
        /// <returns>Роторы.</returns>
        public List<SofInCatalog> GetSofsForValveInCatalog(Guid catalogId, Guid valveInCatalogId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Catalog cat = context.Catalogs.Find(catalogId);
                ValveInCatalog vc = cat.Valves.Single(i => i.Id == valveInCatalogId);
                List<SofModel> sms = vc.Model.SofDismatches.Select(sd => sd.SofModel).ToList();
                List<SofInCatalog> result = new List<SofInCatalog>();
                foreach (var sic in cat.SOFs)
                {
                    foreach (var sofm in sms)
                    {
                        if (sic.ModelId == sofm.Id)
                        {
                            result.Add(sic);
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofInCatalog + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        #endregion

    }
}
