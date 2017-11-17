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
    public partial class Products
    {

        ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

        #region Valves

        /// <summary>
        /// Добавить новый физически существующий экземпляр арматуры.
        /// </summary>
        /// <param name="valve">Физически существующий экземпляр арматуры.</param>
        /// <param name="valveModelId">Id модели арматуры.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Guid AddValve(Valve valve, Guid valveModelId)
        {
            try
            {
                
                if (context.Valves.Where(i => i.Id == valve.Id).Count() == 1)
                {
                    return valve.Id;
                }
                valve.Model = context.ValveModels.Find(valveModelId);

                //valve.Coefficient = valve.Model.Coefficient;
                //valve.Currency = valve.Model.Currency;
                //valve.Diskount = valve.Model.Diskount;
                //valve.BaseValue = valve.Model.BaseValue;
                //valve.Markup = valve.Model.Markup;

                valve = context.Valves.Add(valve);
                context.SaveChanges();

                return valve.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить арматуру " + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр арматуры.
        /// </summary>
        /// <param name="valveId">Id экземпляра арматуры.</param>
        /// <returns></returns>
        public Valve GetValve(Guid valveId)
        {
            try
            {
                
                return context.Valves.Find(valveId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить арматуру " + e);
            }
        }

        /// <summary>
        /// Получить всю имеющуюся арматуру.
        /// </summary>
        /// <returns></returns>
        public List<Valve> GetAllValves()
        {
            try
            {
                
                return context.Valves.ToList();
            }
            catch(Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить арматуру " + e);
            }
        }

      
        /// <summary>
        /// Удалить арматуру.
        /// </summary>
        /// <param name="valveIds">Id одного или нескольких экземпляров арматуры.</param>
        /// <returns></returns>
        public bool DeleteValves(params Guid[] valveIds)
        {
            try
            {
                
                foreach (Guid Id in valveIds)
                {
                    Valve valve = context.Valves.Find(Id);
                    context.Valves.Remove(valve);
                }
                return context.SaveChanges() > 0;
            }
            catch(Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить арматуру " + e);
            }
        }

        #endregion

        #region ElectricActuators

        /// <summary>
        /// Добавить новый физически существующий экземпляр электропривода.
        /// </summary>
        /// <param name="electricActuator">Физически существующий экземпляр электропривода.</param>
        /// <param name="eaModelId">Id модели электропривода.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Guid AddElectricActuator(ElectricActuator electricActuator, Guid eaModelId)
        {
            try
            {
                
                if (context.ElectricActuators.Where(i => i.Id == electricActuator.Id).Count() == 1)
                {
                    return electricActuator.Id;
                }
                electricActuator.Model = context.ElectricActuatorModels.Find(eaModelId);

                //electricActuator.Coefficient = electricActuator.Model.Coefficient;
                //electricActuator.Currency = electricActuator.Model.Currency;
                //electricActuator.Diskount = electricActuator.Model.Diskount;
                //electricActuator.BaseValue = electricActuator.Model.BaseValue;
                //electricActuator.Markup = electricActuator.Model.Markup;

                electricActuator = context.ElectricActuators.Add(electricActuator);
                context.SaveChanges();

                return electricActuator.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить электропривод " + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр электропривода.
        /// </summary>
        /// <param name="electricActuatorId">Id экземпляра электропривода.</param>
        /// <returns></returns>
        public ElectricActuator GetElectricActuator(Guid electricActuatorId)
        {
            try
            {
                
                return context.ElectricActuators.Find(electricActuatorId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить привод " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся электропривода.
        /// </summary>
        /// <returns></returns>
        public List<ElectricActuator> GetAllElectricActuators()
        {
            try
            {
                
                return context.ElectricActuators.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить привод " + e);
            }
        }

        /// <summary>
        /// Удалить электропривод.
        /// </summary>
        /// <param name="electricActuatorIds">Id одного или нескольких экземпляров электропривода.</param>
        /// <returns></returns>
        public bool DeleteElectricActuators(params Guid[] electricActuatorIds)
        {
            try
            {
                
                foreach (Guid Id in electricActuatorIds)
                {
                    ElectricActuator electricActuator = context.ElectricActuators.Find(Id);
                    context.ElectricActuators.Remove(electricActuator);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить привод " + e);
            }
        }

        #endregion

        #region PneumaticActuators

        /// <summary>
        /// Добавить новый физически существующий экземпляр пневморотора.
        /// </summary>
        /// <param name="pneumaticActuator">Физически существующий экземпляр пневморотора.</param>
        /// <param name="paModelId">Id модели пневмопривода.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Guid AddPneumaticActuator(PneumaticActuator pneumaticActuator, Guid paModelId)
        {
            try
            {
                
                if (context.PneumaticActuators.Where(i => i.Id == pneumaticActuator.Id).Count() == 1)
                {
                    return pneumaticActuator.Id;
                }
                pneumaticActuator.Model = context.PneumaticActuatorModels.Find(paModelId);

                //pneumaticActuator.Coefficient = pneumaticActuator.Model.Coefficient;
                //pneumaticActuator.Currency = pneumaticActuator.Model.Currency;
                //pneumaticActuator.Diskount = pneumaticActuator.Model.Diskount;
                //pneumaticActuator.BaseValue = pneumaticActuator.Model.BaseValue;
                //pneumaticActuator.Markup = pneumaticActuator.Model.Markup;

                pneumaticActuator = context.PneumaticActuators.Add(pneumaticActuator);
                context.SaveChanges();

                return pneumaticActuator.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить пневмопривод " + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр пневмопривода.
        /// </summary>
        /// <param name="pneumaticActuatorId">Id экземпляра пневмопривода.</param>
        /// <returns></returns>
        public PneumaticActuator GetPneumaticActuator(Guid pneumaticActuatorId)
        {
            try
            {
                
                return context.PneumaticActuators.Find(pneumaticActuatorId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить привод " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся пневмопривода.
        /// </summary>
        /// <returns></returns>
        public List<PneumaticActuator> GetAllPneumaticActuators()
        {
            try
            {
                
                return context.PneumaticActuators.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить привод " + e);
            }
        }

        /// <summary>
        /// Удалить пневмопривод.
        /// </summary>
        /// <param name="pneumaticActuatorIds">Id одного или нескольких экземпляров пневмопривода.</param>
        /// <returns></returns>
        public bool DeletePneumaticActuators(params Guid[] pneumaticActuatorIds)
        {
            try
            {
                
                foreach (Guid Id in pneumaticActuatorIds)
                {
                    PneumaticActuator pneumaticActuator = context.PneumaticActuators.Find(Id);
                    context.PneumaticActuators.Remove(pneumaticActuator);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить привод " + e);
            }
        }

        #endregion

        #region ManualGears

        /// <summary>
        /// Добавить физически существующий ручной редуктор.
        /// </summary>
        /// <param name="manualGear">Физически существующий экземпляр ручного редуктора.</param>
        /// <param name="mgModelId">Id модели ручного редуктора.</param>
        /// <returns>Добавленный экземпляр.</returns>
        public Guid AddManualGear(ManualGear manualGear, Guid mgModelId)
        {
            try
            {
                
                if (context.ManualGears.Where(i => i.Id == manualGear.Id).Count() == 1)
                {
                    return manualGear.Id;
                }
                manualGear.Model = context.ManualGearModels.Find(mgModelId);

                //manualGear.Coefficient = manualGear.Model.Coefficient;
                //manualGear.Currency = manualGear.Model.Currency;
                //manualGear.Diskount = manualGear.Model.Diskount;
                //manualGear.BaseValue = manualGear.Model.BaseValue;
                //manualGear.Markup = manualGear.Model.Markup;

                manualGear = context.ManualGears.Add(manualGear);
                context.SaveChanges();

                return manualGear.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить редуктор " + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр ручного редуктора.
        /// </summary>
        /// <param name="manualGearId">Id экземпляра ручного редуктора.</param>
        /// <returns></returns>
        public ManualGear GetManualGear(Guid manualGearId)
        {
            try
            {
                
                return context.ManualGears.Find(manualGearId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить ручной редуктор " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся ручные редуктора.
        /// </summary>
        /// <returns></returns>
        public List<ManualGear> GetAllManualGears()
        {
            try
            {
                
                return context.ManualGears.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить ручные редуктора " + e);
            }
        }

        /// <summary>
        /// Удалить ручной редуктор.
        /// </summary>
        /// <param name="manualGearIds">Id одного или нескольких экземпляров ручного редуктора.</param>
        /// <returns></returns>
        public bool DeleteManualGears(params Guid[] manualGearIds)
        {
            try
            {
                
                foreach (Guid Id in manualGearIds)
                {
                    ManualGear manualGear = context.ManualGears.Find(Id);
                    context.ManualGears.Remove(manualGear);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить ручной редуктор " + e);
            }
        }

        #endregion

        #region EAOptons

        /// <summary>
        /// Добавить физически существующую опцию электропривода.
        /// </summary>
        /// <param name="eaOption">Физически существующая опция электропривода.</param>
        /// <param name="eaOptionModelId">Id модели опции электропривода.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Guid AddEAOption(EAOption eaOption, Guid eaOptionModelId)
        {
            try
            {
                
                if (context.EAOptions.Where(i => i.Id == eaOption.Id).Count() == 1)
                {
                    return eaOption.Id;
                }
                eaOption.Model = context.EAOptionModels.Find(eaOptionModelId);

                //eaOption.Coefficient = eaOption.Model.Coefficient;
                //eaOption.Currency = eaOption.Model.Currency;
                //eaOption.Diskount = eaOption.Model.Diskount;
                //eaOption.BaseValue = eaOption.Model.BaseValue;
                //eaOption.Markup = eaOption.Model.Markup;

                eaOption = context.EAOptions.Add(eaOption);
                context.SaveChanges();

                return eaOption.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить опцию электропривода" + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр опции электропривода.
        /// </summary>
        /// <param name="eaOptionId">Id экземпляра опции электропривода.</param>
        /// <returns></returns>
        public EAOption GetEAOption(Guid eaOptionId)
        {
            try
            {
                
                return context.EAOptions.Find(eaOptionId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить опцию привода " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся опции электропривода.
        /// </summary>
        /// <returns></returns>
        public List<EAOption> GetAllEAOptions()
        {
            try
            {
                
                return context.EAOptions.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить опции приводов " + e);
            }
        }

        /// <summary>
        /// Удалить опцию электропривода.
        /// </summary>
        /// <param name="eaOptionIds">Id одного или нескольких экземпляров опций электропривода.</param>
        /// <returns></returns>
        public bool DeleteEAOptions(params Guid[] eaOptionIds)
        {
            try
            {
                
                foreach (Guid Id in eaOptionIds)
                {
                    EAOption eaOption = context.EAOptions.Find(Id);
                    context.EAOptions.Remove(eaOption);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить опцию привода " + e);
            }
        }

        #endregion

        #region PAOptions

        /// <summary>
        /// Добавить физически существующую опцию пневмопривода.
        /// </summary>
        /// <param name="paOption">Физически существующая опция пневмопривода.</param>
        /// <param name="paOptionModelId">Id модели опции пневмопривода.</param>
        /// <returns>Id добавленного экземпляра.</returns>
        public Guid AddPAOption(PAOption paOption, Guid paOptionModelId)
        {
            try
            {
                
                if (context.PAOptions.Where(i => i.Id == paOption.Id).Count() == 1)
                {
                    return paOption.Id;
                }
                paOption.Model = context.PAOptionModels.Find(paOptionModelId);

                //paOption.Coefficient = paOption.Model.Coefficient;
                //paOption.Currency = paOption.Model.Currency;
                //paOption.Diskount = paOption.Model.Diskount;
                //paOption.BaseValue = paOption.Model.BaseValue;
                //paOption.Markup = paOption.Model.Markup;

                paOption = context.PAOptions.Add(paOption);
                context.SaveChanges();

                return paOption.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить опцию пневмопривода" + e);
            }
        }

        /// <summary>
        /// Получить физически существующий экземпляр опции пневмопривода.
        /// </summary>
        /// <param name="paOptionId">Id экземпляра опции пневмопривода.</param>
        /// <returns></returns>
        public PAOption GetPAOption(Guid paOptionId)
        {
            try
            {
                
                return context.PAOptions.Find(paOptionId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить опцию привода " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся опции пневмопривода.
        /// </summary>
        /// <returns></returns>
        public List<PAOption> GetAllPAOptions()
        {
            try
            {
                
                return context.PAOptions.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить опции приводов " + e);
            }
        }

        /// <summary>
        /// Удалить опцию пневмопривода.
        /// </summary>
        /// <param name="paOptionIds">Id одного или нескольких экземпляров опций пневмопривода.</param>
        /// <returns></returns>
        public bool DeletePAOptions(params Guid[] paOptionIds)
        {
            try
            {
                
                foreach (Guid Id in paOptionIds)
                {
                    PAOption PAOption = context.PAOptions.Find(Id);
                    context.PAOptions.Remove(PAOption);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить опцию привода " + e);
            }
        }

        #endregion

        #region SOF

        /// <summary>
        /// Добавить новый физически существующий комплект фланцев.
        /// </summary>
        /// <param name="sof">Физически существующий комплект фланцев.</param>
        /// <param name="sofModelId">Id модели фланцев.</param>
        /// <returns>Id добавленного комплекта.</returns>
        public Guid AddSOF(SOF sof, Guid sofModelId)
        {
            try
            {
                
                if (context.SOFs.Where(i => i.Id == sof.Id).Count() == 1)
                {
                    return sof.Id;
                }
                sof.Model = context.SofModels.Find(sofModelId);

                //sof.Coefficient = sof.Model.Coefficient;
                //sof.Currency = sof.Model.Currency;
                //sof.Diskount = sof.Model.Diskount;
                //sof.BaseValue = sof.Model.BaseValue;
                //sof.Markup = sof.Model.Markup;

                sof = context.SOFs.Add(sof);                
                context.SaveChanges();

                return sof.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить комплект фланцев" + e);
            }
        }


        /// <summary>
        /// Получить физически существующий экземпляр комплекта фланцев.
        /// </summary>
        /// <param name="sofId">Id экземпляра комплекта фланцев.</param>
        /// <returns></returns>
        public SOF GetSOF(Guid sofId)
        {
            try
            {
                
                return context.SOFs.Find(sofId);
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить комплект фланцев " + e);
            }
        }

        /// <summary>
        /// Получить все имеющиеся комплекты фланцев.
        /// </summary>
        /// <returns></returns>
        public List<SOF> GetAllSOFs()
        {
            try
            {
                
                return context.SOFs.ToList();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось получить комплекты фланцев " + e);
            }
        }

        /// <summary>
        /// Удалить комплект фланцев.
        /// </summary>
        /// <param name="sofIds">Id одного или нескольких экземпляров комплектов фланцев.</param>
        /// <returns></returns>
        public bool DeleteSOFs(params Guid[] sofIds)
        {
            try
            {
                
                foreach (Guid Id in sofIds)
                {
                    SOF sof = context.SOFs.Find(Id);
                    context.SOFs.Remove(sof);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить комплект фланцев " + e);
            }
        }

        #endregion
    }
}
