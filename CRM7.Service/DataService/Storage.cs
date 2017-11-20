using CRM7.DataModel;
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
using System.Text;
using System.Threading.Tasks;

namespace CRM7.Service
{
    // будет переписываться под стандарт, заданный в ProductModels
    public class Storage
    {
        #region Работа со складами

        /// <summary>
        /// Добавить склад. 
        /// </summary>
        /// <param name="store">Склад.</param>
        /// <param name="ownerId">Компания-владелец.</param>
        /// <returns>Id склада.</returns>
        public Guid AddStorage(CRM7.DataModel.Storage store, Guid ownerId)
        {
            try
            {
                
                if (context.Storages.Where(i => i.Id == store.Id).Count() == 1)
                {
                    return store.Id;
                }
                store.Owner = context.Companies.Find(ownerId);
                store = context.Storages.Add(store);
                context.SaveChanges();
                return store.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить склад" + e);
            }
        }

        ///// <summary>
        ///// Изменить склад
        ///// </summary>
        ///// <param name="store">Склад</param>
        ///// <returns>Id склада</returns>
        //public Guid UpdateStorage(Storage store)
        //{
        //    try
        //    {
        //        
        //        Storage restore = context.Storages.Single(vm => vm.Id == store.Id);
        //        restore = store.Clone();
        //        context.SaveChanges();
        //        return restore.Id;
        //    }
        //    catch (Exception e)
        //    {
        //        Diagnostic.WriteMessage(e.Message);
        //        throw new FaultException("Не удалось изменить склад" + e);
        //    }
        //}

        /// <summary>
        /// Получить склад по Id
        /// </summary>
        /// <param name="storeGuid">Id склада</param>
        /// <returns>Склад</returns>
        public CRM7.DataModel.Storage GetStorage(Guid storeGuid)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeGuid);
                return store;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить склад" + e);
            }
        }

        /// <summary>
        /// Получить все склады
        /// </summary>
        /// <returns>Все склады</returns>
        public List<CRM7.DataModel.Storage> GetAllStorages()
        {
            try
            {
                
                return context.Storages.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить все склады" + e);
            }
        }

        /// <summary>
        /// Получить Id склада по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns>Id склада</returns>
        public Guid GetStorageId(string name)
        {
            try
            {
                
                return context.Storages.Single(s => s.Name == name).Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить Id склада по названию" + e);
            }
        }

        /// <summary>
        /// Получить все склады компании
        /// </summary>
        /// <param name="ownerId">Id компании</param>
        /// <returns>Список складов компании</returns>
        public List<CRM7.DataModel.Storage> GetCompanyStorages(Guid ownerId)
        {
            try
            {
                
                return context.Storages.Where(s => s.OwnerId == ownerId).ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить все склады компании" + e);
            }
        }

        #endregion

        ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

        #region Работа с позициями на складе.

        /// <summary>
        /// Добавить на склад существующую арматуру.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="valveIds">Id арматуры (один или много).</param>
        /// <returns>Количество изменений в базе данных.</returns>
        public int AddValvesToStorage(Guid storeId, params Guid[] valveIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in valveIds)
                {
                    Valve valve = context.Valves.Find(Id);
                    if (store.Valves.Where(i => i.Id == valve.Id).Count() == 1)
                    {
                        break;
                    }
                    store.Valves.Add(valve);
                }
                return context.SaveChanges(); 
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить арматуру на склад " + e);
            }
        }

        /// <summary>
        /// Удалить арматуру со склада.
        /// </summary>
        /// <param name="valveIds">Id одного или нескольких экземпляров арматуры.</param>
        /// <param name="storId">Id склада.</param>
        /// <returns></returns>
        public bool DeleteValvesFromStorage(Guid storeId, params Guid[] valveIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                int notDeleted = 0;
                foreach (Guid Id in valveIds)
                {
                    Valve valve = store.Valves.Single(v => v.Id == Id);
                    if(!store.Valves.Remove(valve)) notDeleted++;
                }
                return notDeleted == 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить арматуру " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие электропривода.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="electricActuatorIds">Id электроприводов (один или много).</param>
        /// <returns></returns>
        public int AddElectricActuatorsToStorage(Guid storeId, params Guid[] electricActuatorIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in electricActuatorIds)
                {
                    ElectricActuator rotor = context.ElectricActuators.Find(Id);
                    if (store.Rotors.Where(i => i.Id == rotor.Id).Count() == 1)
                    {
                        break;
                    }
                    store.Rotors.Add(rotor);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить электропривода на склад " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие пневмопривода.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="pneumaticActuatorIds">Id пневмоприводов (один или много).</param>
        /// <returns></returns>
        public int AddPneumaticActuatorsToStorage(Guid storeId, params Guid[] pneumaticActuatorIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in pneumaticActuatorIds)
                {
                    PneumaticActuator rotor = context.PneumaticActuators.Find(Id);
                    if (store.Rotors.Where(i => i.Id == rotor.Id).Count() == 1)
                    {
                        break;
                    }
                    store.Rotors.Add(rotor);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить пневмопривода на склад " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие ручные редукторы.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="manualGearIds">Id ручных редукторов (один или много).</param>
        /// <returns></returns>
        public int AddManualGearsToStorage(Guid storeId, params Guid[] manualGearIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in manualGearIds)
                {
                    ManualGear rotor = context.ManualGears.Find(Id);
                    if (store.Rotors.Where(i => i.Id == rotor.Id).Count() == 1)
                    {
                        break;
                    }
                    store.Rotors.Add(rotor);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить ручные редукторы на склад " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие опции электропривода.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="eaOptionIds">Id опций электропривода (один или много).</param>
        /// <returns></returns>
        public int AddEAOptionsToStorage(Guid storeId, params Guid[] eaOptionIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in eaOptionIds)
                {
                    EAOption rotorOption = context.EAOptions.Find(Id);
                    if (store.RotorOptions.Where(i => i.Id == rotorOption.Id).Count() == 1)
                    {
                        break;
                    }
                    store.RotorOptions.Add(rotorOption);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить опции электропривода на склад " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие опции пневмопривода.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="eaOptionIds">Id опций пневмоприводов (один или много).</param>
        /// <returns></returns>
        public int AddPAOptionsToStorage(Guid storeId, params Guid[] paOptionIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in paOptionIds)
                {
                    PAOption rotorOption = context.PAOptions.Find(Id);
                    if (store.RotorOptions.Where(i => i.Id == rotorOption.Id).Count() == 1)
                    {
                        break;
                    }
                    store.RotorOptions.Add(rotorOption);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить опции пневмопривода на склад " + e);
            }
        }

        /// <summary>
        /// Добавить на склад существующие опции пневмопривода.
        /// </summary>
        /// <param name="storeId">Id склада.</param>
        /// <param name="eaOptionIds">Id опций пневмоприводов (один или много).</param>
        /// <returns></returns>
        public int AddSofsToStorage(Guid storeId, params Guid[] sofIds)
        {
            try
            {
                
                CRM7.DataModel.Storage store = context.Storages.Find(storeId);
                foreach (Guid Id in sofIds)
                {
                    SOF sof = context.SOFs.Find(Id);
                    if (store.SOFs.Where(i => i.Id == sof.Id).Count() == 1)
                    {
                        break;
                    }
                    store.SOFs.Add(sof);
                }
                return context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить пневмопривода на склад " + e);
            }
        }
        
        #endregion

    }
}
