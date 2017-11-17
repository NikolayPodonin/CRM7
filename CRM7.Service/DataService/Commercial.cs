using CRM7.DataModel.Commercial;
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
    public class Commercial
    {     

        #region Proposal

        /// <summary>
        /// Добавить коммерческое предложение.
        /// </summary>
        /// <param name="proposal">Коммерческое предложение.</param>
        /// <returns></returns>
        public Proposal AddProposal(Proposal proposal)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.Proposals.Where(p => p.Id == proposal.Id).Count() == 1)
                {
                    return proposal;
                }
                Proposal prop = context.Proposals.Add(proposal);
                context.SaveChanges();
                return prop;
            }
            catch(Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить КП ", e);
            }
        }


        /// <summary>
        /// Изменить КП.
        /// </summary>
        /// <param name="proposal">КП.</param>
        /// <returns>КП.</returns>
        public Proposal UpdateProposal(Proposal proposal)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                Proposal tempProposal = context.Proposals.Find(proposal.Id);
                if (tempProposal == null)
                {
                    throw new ArgumentNullException("Proposal", "КП с таким Id нет в базе.");
                }
                tempProposal = tempProposal.CloneFrom(proposal);
                context.SaveChanges();
                return tempProposal;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить КП. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Удалить КП.
        /// </summary>
        /// <param name="proposalIds">Id одного или нескольких КП.</param>
        /// <returns></returns>
        public bool DeleteProposals(params Guid[] proposalIds)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                foreach (Guid Id in proposalIds)
                {
                    Proposal prop = context.Proposals.Find(Id);
                    foreach(ProposalPosition pos in prop.Positions)
                    {
                        context.ValveInPositions.Remove(pos.Valve);
                        context.RotorInPositions.Remove(pos.Rotor);
                        context.RotorOptionInPositions.RemoveRange(pos.RotorOptions);
                        context.SofInPositions.Remove(pos.SOF);
                    }
                    context.ProposalPositions.RemoveRange(prop.Positions);
                    context.Proposals.Remove(prop);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить КП " + e);
            }
        }

        #endregion

        #region ProposalPosition 

        /// <summary>
        /// Добавить позицию.
        /// </summary>
        /// <param name="position">Позиция.</param>
        /// <param name="proposalId">Id КП.</param>
        /// <returns></returns>
        public Guid AddPosition(ProposalPosition position, Guid proposalId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ProposalPositions.Where(p => p.Id == position.Id).Count() == 1)
                {
                    return position.Id;
                }
                position.Proposal = context.Proposals.Find(proposalId);
                ProposalPosition pos = context.ProposalPositions.Add(position);
                context.SaveChanges();
                return pos.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить КП " + e);
            }
        }

        /// <summary>
        /// Удалить позицию КП.
        /// </summary>
        /// <param name="positionIds">Id позиций КП.</param>
        /// <returns></returns>
        public bool DeletePositions(params Guid[] positionIds)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                foreach (Guid Id in positionIds)
                {
                    ProposalPosition pos = context.ProposalPositions.Find(Id);

                    context.ValveInPositions.Remove(pos.Valve);
                    context.RotorInPositions.Remove(pos.Rotor);
                    context.RotorOptionInPositions.RemoveRange(pos.RotorOptions);
                    context.SofInPositions.Remove(pos.SOF);

                    context.ProposalPositions.Remove(pos);
                }
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить КП " + e);
            }
        }

        #endregion

        #region ValveInPosition 

        /// <summary>
        /// Добавить арматуру в позицию.
        /// </summary>
        /// <param name="valveInPosition">Позиция.</param>
        /// <param name="positionId">Id КП.</param>
        /// <param name="valveModelId">Id модели арматуры.</param>
        /// <returns></returns>
        public Guid AddValveInPosition(ValveInPosition valveInPosition, Guid positionId, Guid valveModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.ValveInPositions.Where(p => p.Id == valveInPosition.Id).Count() == 1)
                {
                    return valveInPosition.Id;
                }
                valveInPosition.ValveModel = context.ValveModels.Find(valveModelId);
                valveInPosition.Position = context.ProposalPositions.Find(positionId);
                ValveInPosition vip = context.ValveInPositions.Add(valveInPosition);
                context.SaveChanges();
                return vip.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить КП " + e);
            }
        }

        /// <summary>
        /// Удалить арматуру из позиции КП.
        /// </summary>
        /// <param name="positionIds">Id арматуры в позиции КП.</param>
        /// <returns></returns>
        public bool DeleteValveInPosition(Guid valveInPositionId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                ValveInPosition valveInPosition = context.ValveInPositions.Find(valveInPositionId);
                context.ValveInPositions.Remove(valveInPosition);
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить арматуру " + e);
            }
        }

        #endregion

        #region RotorInPosition 

        /// <summary>
        /// Добавить ротор в позицию.
        /// </summary>
        /// <param name="rotorInPosition">Ротор.</param>
        /// <param name="positionId">Id позиция.</param>
        /// <param name="rotorModelId">Id модели ротора.</param>
        /// <returns></returns>
        public Guid AddRotorInPosition(RotorInPosition rotorInPosition, Guid positionId, Guid rotorModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.RotorInPositions.Where(p => p.Id == rotorInPosition.Id).Count() == 1)
                {
                    return rotorInPosition.Id;
                }
                rotorInPosition.RotorModel = context.RotorModels.Find(rotorModelId);
                rotorInPosition.Position = context.ProposalPositions.Find(positionId);
                RotorInPosition rip = context.RotorInPositions.Add(rotorInPosition);
                context.SaveChanges();
                return rip.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить ротор в позицию " + e);
            }
        }

        /// <summary>
        /// Удалить ротор из позиции КП.
        /// </summary>
        /// <param name="rotorInPositionId">Id ротора в позиции КП.</param>
        /// <returns></returns>
        public bool DeleteRotorInPosition(Guid rotorInPositionId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                RotorInPosition rotorInPosition = context.RotorInPositions.Find(rotorInPositionId);
                context.RotorInPositions.Remove(rotorInPosition);
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить ротор из позиции " + e);
            }
        }

        #endregion

        #region RotorOptionInPosition 

        /// <summary>
        /// Добавить арматуру в позиции.
        /// </summary>
        /// <param name="rotorOptionInPosition">Позиция.</param>
        /// <param name="positionId">Id КП.</param>
        /// <param name="rotorOptionModelId">Id модели арматуры.</param>
        /// <returns></returns>
        public Guid AddRotorOptionInPosition(RotorOptionInPosition rotorOptionInPosition, Guid positionId, Guid rotorOptionModelId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                if (context.RotorOptionInPositions.Where(p => p.Id == rotorOptionInPosition.Id).Count() == 1)
                {
                    return rotorOptionInPosition.Id;
                }
                rotorOptionInPosition.RotorOptionModel = context.RotorOptionModels.Find(rotorOptionModelId);
                rotorOptionInPosition.Position = context.ProposalPositions.Find(positionId);
                RotorOptionInPosition roip = context.RotorOptionInPositions.Add(rotorOptionInPosition);
                context.SaveChanges();
                return roip.Id;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось добавить КП " + e);
            }
        }

        /// <summary>
        /// Удалить арматуру в позиции КП.
        /// </summary>
        /// <param name="positionIds">Id позиций КП.</param>
        /// <returns></returns>
        public bool DeleteRotorOptionInPosition(Guid rotorOptionInPositionId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                RotorOptionInPosition rotorOptionInPosition = context.RotorOptionInPositions.Find(rotorOptionInPositionId);
                context.RotorOptionInPositions.Remove(rotorOptionInPosition);
                return context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new FaultException("Не удалось удалить арматуру " + e);
            }
        }

        #endregion
        

    }
}
