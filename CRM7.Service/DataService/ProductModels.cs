using CRM7.DataModel.Product;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.SOF;
using CRM7.DataModel.Product.Valve;
using CRM7.Mapping;
using CRM7.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM7.Service
{

    public class ProductModels
    {
        #region Add statement

        /// <summary>
        /// Добавить серию арматуры.
        /// </summary>
        /// <param name="series">Серия арматуры.</param>
        /// <returns></returns>
        public ValveSeries AddValveSeries(ValveSeries series)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.ValveSeries.Where(i => i.Id == series.Id).Count() > 0)
                {
                    return series;
                }
                series = context.ValveSeries.Add(series);
                context.SaveChanges();
                return series;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Catalog + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить тип уплотнения.
        /// </summary>
        /// <param name="consolidation"> Новый тип уплотнения.</param>
        /// <returns>Id типа уплотнения.</returns>
        public Consolidation AddConsolidation(Consolidation consolidation)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.Consolidations.Where(i => i.Id == consolidation.Id).Count() > 0)
                {
                    return consolidation;
                }
                consolidation = context.Consolidations.Add(consolidation);
                context.SaveChanges();
                return consolidation;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить тип рабочей среды. 
        /// </summary>
        /// <param name="environment">Тип рабочей среды.</param>
        /// <returns></returns>
        public DataModel.Product.Environment AddEnvironment(DataModel.Product.Environment environment)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.Environments.Where(i => i.Id == environment.Id).Count() > 0)
                {
                    return environment;
                }
                environment = context.Environments.Add(environment);
                context.SaveChanges();
                return environment;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Environment + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Добавить тип материала.
        /// </summary>
        /// <param name="materialType">Тип материала.</param>
        /// <returns></returns>
        public MaterialType AddMaterialType(MaterialType materialType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.MaterialTypes.Where(i => i.Id == materialType.Id).Count() == 1)
                {
                    return materialType;
                }
                materialType = context.MaterialTypes.Add(materialType);
                context.SaveChanges();
                return materialType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.MaterialType + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить материал.
        /// </summary>
        /// <param name="material">Материал.</param>
        /// <param name="materialTypeId">Id типа материала.</param>
        /// <returns></returns>
        public Material AddMaterial(Material material, Guid materialTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.Materials.Where(i => i.Id == material.Id).Count() == 1)
                {
                    return material;
                }
                material.Type = context.MaterialTypes.Find(materialTypeId);
                material = context.Materials.Add(material);
                context.SaveChanges();
                return material;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Material + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить тип арматуры.
        /// </summary>
        /// <param name="rotorType">Тип арматуры.</param>
        /// <returns></returns>
        public ValveType AddValveType(ValveType valveType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveTypes.Where(i => i.Id == valveType.Id).Count() == 1)
                {
                    return valveType;
                }
                valveType = context.ValveTypes.Add(valveType);
                context.SaveChanges();
                return valveType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveType + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить тип присоединения арматуры.
        /// </summary>
        /// <param name="valveConnection">Тип присоединения арматуры.</param>
        /// <returns></returns>
        public ValveConnection AddValveConnection(ValveConnection valveConnection)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveConnections.Where(i => i.Id == valveConnection.Id).Count() == 1)
                {
                    return valveConnection;
                }
                valveConnection = context.ValveConnections.Add(valveConnection);
                context.SaveChanges();
                return valveConnection;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveConnection + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить новую модель арматуры.
        /// </summary>
        /// <param name="model">Модель арматуры.</param>
        /// <param name="consolidationId">Id типа уплотнения.</param>
        /// <param name="environmentId">Id среды.</param>
        /// <param name="valveTypeId">Id типа арматуры.</param>
        /// <param name="valveConnectionId">Id типа присоединения.</param>
        /// <param name="bodyMaterialId">Id материала корпуса.</param>
        /// <param name="manufacturerId">Id компании-изготовителя.</param>
        /// <returns></returns>
        public ValveModel AddValveModel(ValveModel model, Guid consolidationId, Guid environmentId, Guid valveTypeId, Guid valveSeriesId, Guid valveConnectionId, Guid bodyMaterialId, Guid manufacturerId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Consolidation = context.Consolidations.Find(consolidationId);
                model.Environment = context.Environments.Find(environmentId);
                model.Type = context.ValveTypes.Find(valveTypeId);
                model.Series = context.ValveSeries.Find(valveSeriesId);
                model.Connection = context.ValveConnections.Find(valveConnectionId);
                model.BodyMaterial = context.Materials.Find(bodyMaterialId);
                model.Manufacturer = context.Companies.Find(manufacturerId);
                model = context.ValveModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить тип ротора.
        /// </summary>
        /// <param name="rotorType">Тип арматуры.</param>
        /// <returns></returns>
        public RotorType AddRotorType(RotorType rotorType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.RotorTypes.Where(i => i.Id == rotorType.Id).Count() == 1)
                {
                    return rotorType;
                }
                rotorType = context.RotorTypes.Add(rotorType);
                context.SaveChanges();
                return rotorType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.RotorType + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель ручного редуктора.
        /// </summary>
        /// <param name="model">Модель ручного редуктора.</param>
        /// <param name="manufacturerId">Id компании-изготовителя.</param>
        /// <returns></returns>
        public ManualGearModel AddManualGearModel(ManualGearModel model, Guid manufacturerId, Guid rotorTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ManualGearModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model.Type = context.RotorTypes.Find(rotorTypeId);
                model = context.ManualGearModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ManualGearModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель электропривода.
        /// </summary>
        /// <param name="model">Модель электропривода.</param>
        /// <param name="manufacturerId">Id компании-производителя.</param>
        /// <returns></returns>
        public ElectricActuatorModel AddElectricActuatorModel(ElectricActuatorModel model, Guid manufacturerId, Guid rotorTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ElectricActuatorModels.Where(eam => eam.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model.Type = context.RotorTypes.Find(rotorTypeId);
                model = context.ElectricActuatorModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ElectricActuatorModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель пневмопривода.
        /// </summary>
        /// <param name="model">Модель пневмопривода.</param>
        /// <param name="manufacturerId">Id компании-изготовителя.</param>
        /// <returns></returns>
        public PneumaticActuatorModel AddPneumaticActuatorModel(PneumaticActuatorModel model, Guid manufacturerId, Guid rotorTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.PneumaticActuatorModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model.Type = context.RotorTypes.Find(rotorTypeId);
                model = context.PneumaticActuatorModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель опции электропривода.
        /// </summary>
        /// <param name="model">Модель опции электропривода.</param>
        /// <param name="manufacturerId">Id компании изготовителя.</param>
        /// <returns></returns>
        public EAOptionModel AddEAOptionModel(EAOptionModel model, Guid manufacturerId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.EAOptionModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model = context.EAOptionModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.EAOptionModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель опции пневмопривода.
        /// </summary>
        /// <param name="model">Модель опции пневмопривода.</param>
        /// <param name="manufacturerId">Id компании-изготовителя.</param>
        /// <returns></returns>
        public PAOptionModel AddPAOptionModel(PAOptionModel model, Guid manufacturerId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.PAOptionModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model = context.PAOptionModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PAOptionModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить модель фланцев.
        /// </summary>
        /// <param name="model">Модель фланцев.</param>
        /// <param name="manufacturerId">Id компании-изготовителя.</param>
        /// <returns></returns>
        public SofModel AddSofModel(SofModel model, Guid manufacturerId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.SofModels.Where(i => i.Id == model.Id).Count() == 1)
                {
                    return model;
                }
                model.Manufacturer = context.Companies.Single(c => c.Id == manufacturerId);
                model = context.SofModels.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofModel + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить соответствие между моделями арматуры и ротора.
        /// </summary>
        /// <returns></returns>
        public ValveRotorDismatch AddValveRotorDismatch(Guid valveModelId, Guid rotorModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveRotorDismatches.Where(i => i.ValveModelId == valveModelId && i.RotorModelId == rotorModelId).Count() > 0)
                {
                    return context.ValveRotorDismatches.Where(i => i.ValveModelId == valveModelId && i.RotorModelId == rotorModelId).First();
                }
                ValveRotorDismatch vrd = new ValveRotorDismatch();
                vrd.ValveModel = context.ValveModels.Find(valveModelId);
                vrd.RotorModel = context.RotorModels.Find(rotorModelId);
                vrd = context.ValveRotorDismatches.Add(vrd);
                context.SaveChanges();
                return vrd;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveRotorDismatch + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Добавить соответствие между моделями арматуры и фланцев.
        /// </summary>
        /// <returns></returns>
        public ValveSofDismatch AddValveSofDismatch(Guid valveModelId, Guid sofModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveSofDismatches.Where(i => i.ValveModelId == valveModelId && i.SofModelId == sofModelId).Count() > 0)
                {
                    return context.ValveSofDismatches.Where(i => i.ValveModelId == valveModelId && i.SofModelId == sofModelId).First();
                }
                ValveSofDismatch vrd = new ValveSofDismatch();
                vrd.ValveModel = context.ValveModels.Find(valveModelId);
                vrd.SofModel = context.SofModels.Find(sofModelId);
                vrd = context.ValveSofDismatches.Add(vrd);
                context.SaveChanges();
                return vrd;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveSofDismatch + LocalizedStrings.CantAddSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }


        #endregion

        #region Get statement

        #region Get single statment

        /// <summary>
        /// Получить тип уплотнения по Id.
        /// </summary>
        /// <param name="typeId">Id типа уплотнения.</param>
        /// <returns></returns>
        public Consolidation GetConsolidation(Guid typeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Consolidation consolidation = context.Consolidations.Find(typeId);
                return consolidation;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Получить тип рабочей среды.
        /// </summary>
        /// <param name="typeId">Id типа рабочей среды.</param>
        /// <returns></returns>
        public DataModel.Product.Environment GetEnvironment(Guid typeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                DataModel.Product.Environment environment = context.Environments.Find(typeId);
                return environment;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Получить тип материала.
        /// </summary>
        /// <param name="typeId">Id типа материала.</param>
        /// <returns></returns>
        public MaterialType GetMaterialType(Guid typeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                MaterialType materialType = context.MaterialTypes.Find(typeId);
                return materialType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Получить материал.
        /// </summary>
        /// <param name="materialId">Id материала.</param>
        /// <returns></returns>
        public Material GetMaterial(Guid materialId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Material material = context.Materials.Find(materialId);
                return material;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Получить тип арматуры.
        /// </summary>
        /// <param name="valveTypeId">Id типа арматуры.</param>
        /// <returns></returns>
        public ValveType GetValveType(Guid valveTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveType valveType = context.ValveTypes.Find(valveTypeId);
                return valveType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Получить тип присоединения.
        /// </summary>
        /// <param name="valveConnectionId">Id типа присоединения арматуры.</param>
        /// <returns></returns>
        public ValveConnection GetValveConnection(Guid valveConnectionId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveConnection valveConnection = context.ValveConnections.Find(valveConnectionId);
                return valveConnection;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель арматуры.
        /// </summary>
        /// <param name="modelId">Id модели арматуры.</param>
        /// <returns></returns>
        public ValveModel GetValveModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveModel model = context.ValveModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель ручного редуктора.
        /// </summary>
        /// <param name="modelId">Id модели ручного редуктора.</param>
        /// <returns></returns>
        public ManualGearModel GetManualGearModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ManualGearModel model = context.ManualGearModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ManualGearModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель электропривода.
        /// </summary>
        /// <param name="modelId">Id модели электропривода.</param>
        /// <returns></returns>
        public ElectricActuatorModel GetElectricActuatorModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ElectricActuatorModel model = context.ElectricActuatorModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ElectricActuatorModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель пневмопривода.
        /// </summary>
        /// <param name="modelId">Id модели пневмопривода.</param>
        /// <returns></returns>
        public PneumaticActuatorModel GetPneumaticActuatorModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                PneumaticActuatorModel model = context.PneumaticActuatorModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель опции электропривода.
        /// </summary>
        /// <param name="modelId">Id модели опции электропривода.</param>
        /// <returns></returns>
        public EAOptionModel GetEAOptionModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                EAOptionModel model = context.EAOptionModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.EAOptionModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель опции пневмопривода.
        /// </summary>
        /// <param name="modelId">Id модели опции пневмопривода.</param>
        /// <returns></returns>
        public PAOptionModel GetPAOptionModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                PAOptionModel model = context.PAOptionModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PAOptionModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить модель фланцев.
        /// </summary>
        /// <param name="modelId">Id модели фланцев.</param>
        /// <returns></returns>
        public SofModel GetSofModel(Guid modelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                SofModel model = context.SofModels.Find(modelId);
                return model;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofModel + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        #endregion

        #region Get many statement
        
        /// <summary>
        /// Получить все типы уплотнения.
        /// </summary>
        /// <returns></returns>
        public List<Consolidation> GetAllConsolidations()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.Consolidations.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidations + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы рабочей среды.
        /// </summary>
        /// <returns></returns>
        public List<DataModel.Product.Environment> GetAllEnvironments()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.Environments.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Environments + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы материалов.
        /// </summary>
        /// <returns></returns>
        public List<MaterialType> GetAllMaterialTypes()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.MaterialTypes.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.MaterialTypes + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все материалы.
        /// </summary>
        /// <returns></returns>
        public List<Material> GetAllMaterials()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.Materials.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Materials + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы арматуры.
        /// </summary>
        /// <returns></returns>
        public List<ValveType> GetAllValveTypes()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.ValveTypes.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveTypes + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все типы присоединения арматуры.
        /// </summary>
        /// <returns></returns>
        public List<ValveConnection> GetAllValveConnections()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.ValveConnections.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveConnections + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели арматуры.
        /// </summary>
        /// <returns></returns>
        public List<ValveModel> GetAllValveModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.ValveModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели ручных редукторов.
        /// </summary>
        /// <returns></returns>
        public List<ManualGearModel> GetAllManualGearModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.ManualGearModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ManualGearModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели электроприводов.
        /// </summary>
        /// <returns></returns>
        public List<ElectricActuatorModel> GetAllElectricActuatorModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.ElectricActuatorModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ElectricActuatorModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели пневмоприводов.
        /// </summary>
        /// <returns></returns>
        public List<PneumaticActuatorModel> GetAllPneumaticActuatorModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.PneumaticActuatorModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PneumaticActuatorModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели опций электропривода.
        /// </summary>
        /// <returns></returns>
        public List<EAOptionModel> GetAllEAOptionModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.EAOptionModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.EAOptionModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели опций пневмопривода.
        /// </summary>
        /// <returns></returns>
        public List<PAOptionModel> GetAllPAOptionModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.PAOptionModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PAOptionModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все модели фланцев.
        /// </summary>
        /// <returns></returns>
        public List<SofModel> GetAllSofModels()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                return context.SofModels.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofModels + LocalizedStrings.CantGetSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        #endregion

        #endregion

        #region Update statement

        /// <summary>
        /// Изменить существующий тип уплотнения.
        /// </summary>
        /// <param name="consolidation">Существующий тип уплотнения.</param>
        /// <returns>Id типа уплотнения.</returns>
        public Consolidation UpdateConsolidation(Consolidation consolidation)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Consolidation consolid = context.Consolidations.Find(consolidation.Id);
                if (consolid == null)
                {
                    throw new ArgumentNullException(nameof(Consolidation), LocalizedStrings.Consolidation + LocalizedStrings.NotExistsSmth);
                }
                consolid = consolid.CloneFrom(consolidation);
                context.SaveChanges();
                return consolid;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить тип рабочей среды.
        /// </summary>
        /// <param name="environment">Тип рабочей среды.</param>
        /// <returns></returns>
        public DataModel.Product.Environment UpdateEnvironment(DataModel.Product.Environment environment)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                DataModel.Product.Environment environ = context.Environments.Find(environment.Id);
                if (environ == null)
                {
                    throw new ArgumentNullException(nameof(DataModel.Product.Environment), LocalizedStrings.Environment + LocalizedStrings.NotExistsSmth);
                }
                environ = environ.CloneFrom(environment);
                context.SaveChanges();
                return environ;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Environment + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить тип материала.
        /// </summary>
        /// <param name = "materialType" > Тип материала.</param>
        /// <returns></returns>
        public MaterialType UpdateMaterialType(MaterialType materialType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                MaterialType mt = context.MaterialTypes.Find(materialType.Id);
                if (mt == null)
                {
                    throw new ArgumentNullException(nameof(MaterialType), LocalizedStrings.MaterialType + LocalizedStrings.NotExistsSmth);
                }
                mt = mt.CloneFrom(materialType);
                context.SaveChanges();
                return mt;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.MaterialType + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить материал.
        /// </summary>
        /// <param name="material">Материал.</param>
        /// <returns></returns>
        public Material UpdateMaterial(Material material)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Material mat = context.Materials.Find(material.Id);
                if (mat == null)
                {
                    throw new ArgumentNullException(nameof(Material), LocalizedStrings.Material + LocalizedStrings.NotExistsSmth);
                }
                mat = mat.CloneFrom(material);
                context.SaveChanges();
                return mat;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Material + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }


        /// <summary>
        /// Изменить тип арматуры.
        /// </summary>
        /// <param name="valveType">Тип арматуры.</param>
        /// <returns></returns>
        public ValveType UpdateValveType(ValveType valveType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveType vt = context.ValveTypes.Find(valveType.Id);
                if (vt == null)
                {
                    throw new ArgumentNullException(nameof(ValveType), LocalizedStrings.ValveType + LocalizedStrings.NotExistsSmth);
                }
                vt = vt.CloneFrom(valveType);
                context.SaveChanges();
                return vt;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveType + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить тип присоединения арматуры.
        /// </summary>
        /// <param name="valveConnection">Тип присоединения арматуры.</param>
        /// <returns></returns>
        public ValveConnection UpdateValveConnection(ValveConnection valveConnection)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveConnection vc = context.ValveConnections.Find(valveConnection.Id);
                if (vc == null)
                {
                    throw new ArgumentNullException(nameof(ValveConnection), LocalizedStrings.ValveConnection + LocalizedStrings.NotExistsSmth);
                }
                vc = vc.CloneFrom(valveConnection);
                context.SaveChanges();
                return vc;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveConnection + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель арматуры.
        /// </summary>
        /// <param name="model">Модель арматуры.</param>
        /// <returns></returns>
        public ValveModel UpdateValveModel(ValveModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveModel vm = context.ValveModels.Find(model.Id);
                if (vm == null)
                {
                    throw new ArgumentNullException(nameof(ValveModel), LocalizedStrings.ValveModel + LocalizedStrings.NotExistsSmth);
                }
                vm = vm.CloneFrom(model);
                context.SaveChanges();
                return vm;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель ручного редуктора.
        /// </summary>
        /// <param name="model">Модель ручного редуктора.</param>
        /// <returns></returns>
        public ManualGearModel UpdateManualGearModel(ManualGearModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ManualGearModel mgm = context.ManualGearModels.Find(model.Id);
                if (mgm == null)
                {
                    throw new ArgumentNullException(nameof(ManualGearModel), LocalizedStrings.ManualGearModel + LocalizedStrings.NotExistsSmth);
                }
                mgm = mgm.CloneFrom(model);
                context.SaveChanges();
                return mgm;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ManualGearModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель электропривода.
        /// </summary>
        /// <param name="model">Модель электропривода.</param>
        /// <returns></returns>
        public ElectricActuatorModel UpdateElectricActuatorModel(ElectricActuatorModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ElectricActuatorModel eam = context.ElectricActuatorModels.Find(model.Id);
                if (eam == null)
                {
                    throw new ArgumentNullException(nameof(ElectricActuatorModel), LocalizedStrings.ElectricActuatorModel + LocalizedStrings.NotExistsSmth);
                }
                eam = eam.CloneFrom(model);
                context.SaveChanges();
                return eam;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ElectricActuatorModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель пневмопривода.
        /// </summary>
        /// <param name="model">Модель пневмопривода.</param>
        /// <returns></returns>
        public PneumaticActuatorModel UpdatePneumaticActuatorModel(PneumaticActuatorModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                PneumaticActuatorModel pam = context.PneumaticActuatorModels.Find(model.Id);
                if (pam == null)
                {
                    throw new ArgumentNullException(nameof(PneumaticActuatorModel), LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.NotExistsSmth);
                }
                pam = pam.CloneFrom(model);
                context.SaveChanges();
                return pam;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель опции электропривода.
        /// </summary>
        /// <param name="model">Модель опции электропривода.</param>
        /// <returns></returns>
        public EAOptionModel UpdateEAOptionModel(EAOptionModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                EAOptionModel eaom = context.EAOptionModels.Find(model.Id);
                if (eaom == null)
                {
                    throw new ArgumentNullException(nameof(EAOptionModel), LocalizedStrings.EAOptionModel + LocalizedStrings.NotExistsSmth);
                }
                eaom = eaom.CloneFrom(model);
                context.SaveChanges();
                return eaom;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.EAOptionModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель опции пневмопривода.
        /// </summary>
        /// <param name="model">Модель опции пневмопривода.</param>
        /// <returns></returns>
        public PAOptionModel UpdatePAOptionModel(PAOptionModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                PAOptionModel paom = context.PAOptionModels.Find(model.Id);
                if (paom == null)
                {
                    throw new ArgumentNullException(nameof(PAOptionModel), LocalizedStrings.PAOptionModel + LocalizedStrings.NotExistsSmth);
                }
                paom = paom.CloneFrom(model);
                context.SaveChanges();
                return paom;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PAOptionModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Изменить модель фланцев.
        /// </summary>
        /// <param name="model">Модель фланцев.</param>
        /// <returns></returns>
        public SofModel UpdateSofModel(SofModel model)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                SofModel sm = context.SofModels.Find(model.Id);
                if (sm == null)
                {
                    throw new ArgumentNullException(nameof(SofModel), LocalizedStrings.SofModel + LocalizedStrings.NotExistsSmth);
                }
                sm = sm.CloneFrom(model);
                context.SaveChanges();
                return sm;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofModel + LocalizedStrings.CantUpdateSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }


        #endregion

        #region Delete statement
                

        /// <summary>
        /// Удалить тип уплотнения.
        /// </summary>
        /// <param name="id">Id типа уплотнения.</param>
        /// <returns></returns>
        public void DeleteConsolidation(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Consolidation tempConsolidation = context.Consolidations.Find(id);
                if (tempConsolidation == null)
                {
                    throw new ArgumentNullException(nameof(Consolidation), LocalizedStrings.Consolidation + LocalizedStrings.CantDeleteSmth);
                }
                context.Consolidations.Remove(tempConsolidation);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Consolidation + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Удалить тип среды.
        /// </summary>
        /// <param name="id">Id среды.</param>
        /// <returns></returns>
        public void DeleteEnvironment(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                DataModel.Product.Environment tempEnvironment = context.Environments.Find(id);
                if (tempEnvironment == null)
                {
                    throw new ArgumentNullException(nameof(DataModel.Product.Environment), LocalizedStrings.Environment + LocalizedStrings.CantDeleteSmth);
                }
                context.Environments.Remove(tempEnvironment);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Environment + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Удалить тип материала.
        /// </summary>
        /// <param name="id">Id типa материала.</param>
        /// <returns></returns>
        public void DeleteMaterialType(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                MaterialType tempMaterialType = context.MaterialTypes.Find(id);
                if (tempMaterialType == null)
                {
                    throw new ArgumentNullException(nameof(MaterialType), LocalizedStrings.MaterialType + LocalizedStrings.CantDeleteSmth);
                }
                context.MaterialTypes.Remove(tempMaterialType);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.MaterialType + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }
        
        /// <summary>
        /// Удалить материал.
        /// </summary>
        /// <param name="id">Id материалa.</param>
        /// <returns></returns>
        public void DeleteMaterial(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Material tempMaterial = context.Materials.Find(id);
                if (tempMaterial == null)
                {
                    throw new ArgumentNullException(nameof(Material), LocalizedStrings.Material + LocalizedStrings.CantDeleteSmth);
                }
                context.Materials.Remove(tempMaterial);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Material + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить тип арматуры.
        /// </summary>
        /// <param name="id">Id типa арматуры.</param>
        /// <returns></returns>
        public void DeleteValveType(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                ValveType tempValveType = context.ValveTypes.Find(id);
                if (tempValveType == null)
                {
                    throw new ArgumentNullException(nameof(ValveType), LocalizedStrings.ValveType + LocalizedStrings.CantDeleteSmth);
                }
                context.ValveTypes.Remove(tempValveType);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveType + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить тип присоединения арматуры.
        /// </summary>
        /// <param name="id">Id типa присоединения арматуры.</param>
        /// <returns></returns>
        public void DeleteValveConnection(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                ValveConnection tempValveConnection = context.ValveConnections.Find(id);
                if (tempValveConnection == null)
                {
                    throw new ArgumentNullException(nameof(ValveConnection), LocalizedStrings.ValveConnection + LocalizedStrings.CantDeleteSmth);
                }
                context.ValveConnections.Remove(tempValveConnection);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveConnection + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель арматуры.
        /// </summary>
        /// <param name="id">Id модели арматуры.</param>
        /// <returns></returns>
        public void DeleteValveModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                ValveModel tempValveModel = context.ValveModels.Find(id);
                if (tempValveModel == null)
                {
                    throw new ArgumentNullException(nameof(ValveModel), LocalizedStrings.ValveModel + LocalizedStrings.CantDeleteSmth);
                }
                context.ValveModels.Remove(tempValveModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ValveModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель ручного редуктора.
        /// </summary>
        /// <param name="id">Id модели ручного редуктора.</param>
        /// <returns></returns>
        public void DeleteManualGearModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                ManualGearModel tempManualGearModel = context.ManualGearModels.Find(id);
                if (tempManualGearModel == null)
                {
                    throw new ArgumentNullException(nameof(ManualGearModel), LocalizedStrings.ManualGearModel + LocalizedStrings.CantDeleteSmth);
                }
                context.ManualGearModels.Remove(tempManualGearModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ManualGearModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель электропривода.
        /// </summary>
        /// <param name="id">Id модели электропривода.</param>
        /// <returns></returns>
        public void DeleteElectricActuatorModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                ElectricActuatorModel tempElectricActuatorModel = context.ElectricActuatorModels.Find(id);
                if (tempElectricActuatorModel == null)
                {
                    throw new ArgumentNullException(nameof(ElectricActuatorModel), LocalizedStrings.ElectricActuatorModel + LocalizedStrings.CantDeleteSmth);
                }
                context.ElectricActuatorModels.Remove(tempElectricActuatorModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.ElectricActuatorModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель пневмопривода.
        /// </summary>
        /// <param name="id">Id модели пневмопривода.</param>
        /// <returns></returns>
        public void DeletePneumaticActuatorModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                PneumaticActuatorModel tempPneumaticActuatorModel = context.PneumaticActuatorModels.Find(id);
                if (tempPneumaticActuatorModel == null)
                {
                    throw new ArgumentNullException(nameof(PneumaticActuatorModel), LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.CantDeleteSmth);
                }
                context.PneumaticActuatorModels.Remove(tempPneumaticActuatorModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PneumaticActuatorModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель опции электропривода.
        /// </summary>
        /// <param name="id">Id модели опции электропривода.</param>
        /// <returns></returns>
        public void DeleteEAOptionModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                EAOptionModel tempEAOptionModel = context.EAOptionModels.Find(id);
                if (tempEAOptionModel == null)
                {
                    throw new ArgumentNullException(nameof(EAOptionModel), LocalizedStrings.EAOptionModel + LocalizedStrings.CantDeleteSmth);
                }
                context.EAOptionModels.Remove(tempEAOptionModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.EAOptionModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель опции пневмопривода.
        /// </summary>
        /// <param name="id">Id модели опции пневмопривода.</param>
        /// <returns></returns>
        public void DeletePAOptionModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                PAOptionModel tempPAOptionModel = context.PAOptionModels.Find(id);
                if (tempPAOptionModel == null)
                {
                    throw new ArgumentNullException(nameof(PAOptionModel), LocalizedStrings.PAOptionModel + LocalizedStrings.CantDeleteSmth);
                }
                context.PAOptionModels.Remove(tempPAOptionModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.PAOptionModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Удалить модель фланцев.
        /// </summary>
        /// <param name="id">Id модели фланцев.</param>
        /// <returns></returns>
        public void DeleteSofModel(Guid id)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                SofModel tempSofModel = context.SofModels.Find(id);
                if (tempSofModel == null)
                {
                    throw new ArgumentNullException(nameof(SofModel), LocalizedStrings.SofModel + LocalizedStrings.CantDeleteSmth);
                }
                context.SofModels.Remove(tempSofModel);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.SofModel + LocalizedStrings.CantDeleteSmth + ", " + LocalizedStrings.SeeInnerException, e);
            }
        }

        #endregion
    }
}
