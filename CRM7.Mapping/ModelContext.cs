using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using CRM7.DataModel;
using CRM7.DataModel.Commercial;
using CRM7.DataModel.Product;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.Valve;
using CRM7.DataModel.Product.SOF;
using CRM7.DataModel.Management;
using CRM7.DataModel.Files;
using CRM7.DataModel.Passport;
using CRM7.DataModel.Organizer;
using CRM7.DataModel.Catalog;
using CRM7.DataModel.Catalog.CatalogPosition;

namespace CRM7.Mapping
{
    public class ModelContext : DbContext
    {

        public ModelContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ModelContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ModelContext, MigrationConfig>());
        }

        #region Model

        #region Commercial

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<CPOption> AdditionallyCosts { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<ProposalPosition> ProposalPositions { get; set; }

        public DbSet<RotorInPosition> RotorInPositions { get; set; }

        public DbSet<RotorOptionInPosition> RotorOptionInPositions { get; set; }

        public DbSet<ValveInPosition> ValveInPositions { get; set; }

        public DbSet<SofInPosition> SofInPositions { get; set; }
        
        public DbSet<ManualProductInPosition> ManualProductInPositions { get; set; }

        #endregion Commercial

        #region Product

        public DbSet<Consolidation> Consolidations { get; set; }

        public DbSet<DataModel.Product.Environment> Environments { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<MaterialType> MaterialTypes { get; set; }

        #region ManualProduct

        public DbSet<ManualProductModel> MaualProductModels { get; set; }

        public DbSet<ManualProduct> ManualProducts { get; set; }

        #endregion

        #region Valve

        public DbSet<Valve> Valves { get; set; }
        
        public DbSet<ValveConnection> ValveConnections { get; set; }

        public DbSet<ValveModel> ValveModels { get; set; }

        public DbSet<ValveRotorDismatch> ValveRotorDismatches { get; set; }

        public DbSet<ValveSofDismatch> ValveSofDismatches { get; set; }

        public DbSet<ValveType> ValveTypes { get; set; }

        public DbSet<ValveSeries> ValveSeries { get; set; }

        #endregion Valve

        #region Rotor

        public DbSet<RotorModel> RotorModels { get; set; }
        
        public DbSet<RotorType> RotorTypes { get; set; }

        public DbSet<Rotor> Rotors { get; set; }

        public DbSet<RotorOptionModel> RotorOptionModels { get; set; }

        public DbSet<RotorOption> RotorOptions { get; set; }

        public DbSet<ElectricActuatorModel> ElectricActuatorModels { get; set; }

        public DbSet<ElectricActuator> ElectricActuators { get; set; }

        public DbSet<EAOptionModel> EAOptionModels { get; set; }

        public DbSet<EAOption> EAOptions { get; set; }

        public DbSet<PneumaticActuatorModel> PneumaticActuatorModels { get; set; }

        public DbSet<PneumaticActuator> PneumaticActuators { get; set; }

        public DbSet<PAOptionModel> PAOptionModels { get; set; }

        public DbSet<PAOption> PAOptions { get; set; }

        public DbSet<ManualGearModel> ManualGearModels { get; set; }

        public DbSet<ManualGear> ManualGears { get; set; }

        public DbSet<RotorOptionDismatch> RotorOptionDismatches { get; set; }

        #endregion Rotor

        #region SOF

        public DbSet<SOF> SOFs { get; set; }

        public DbSet<SofModel> SofModels { get; set; }

        #endregion

        #endregion Product

        #region Managment

        public DbSet<CompanyType> CompanyTypes { get; set; }
        
        public DbSet<Company> Companies { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        
        public DbSet<AccessGroup> AccessGroups { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion

        #region Organizer

        public DbSet<DataModel.Organizer.Task> Tasks { get; set; }

        public DbSet<DataModel.Organizer.TaskReminder> TaskReminders { get; set; }

        public DbSet<DataModel.Organizer.TaskComment> TaskComments { get; set; }

        public DbSet<DataModel.Organizer.DayReport> DayReports { get; set; }

        #endregion Organizer

        #region Catalog

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<ValveInCatalog> ValveInCatalogs { get; set; }

        public DbSet<RotorInCatalog> RotorInCatalogs { get; set; }

        public DbSet<RotorOptionInCatalog> RotorOptionInCatalogs { get; set; }

        public DbSet<SofInCatalog> SofInCatalogs { get; set; }

        public DbSet<ManualProductInCatalog> ManualProductInCatalogs { get; set; }        

        #endregion

        public DbSet<File> Documents { get; set; }        

        public DbSet<PassportValve> PassportValve { get; set; }

        public DbSet<Storage> Storages { get; set; }
        
        #endregion Model

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Proposal>().HasMany(i => i.Positions).WithRequired(i => i.Proposal).HasForeignKey(i => i.ProposalId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasOptional(i => i.ContragentOrganization).WithMany(i => i.InternalProposals).HasForeignKey(i => i.ContragentOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasOptional(i => i.Recipient).WithMany(i => i.TakedProposals).HasForeignKey(i => i.RecipientId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasRequired(i => i.MakerOrganization).WithMany(i => i.ExternalProposals).HasForeignKey(i => i.MakerOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasRequired(i => i.Maker).WithMany(i => i.MakedProposals).HasForeignKey(i => i.MakerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasOptional(i => i.SigningPerson).WithMany(i => i.SignedProposals).HasForeignKey(i => i.RecipientId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Proposal>().HasMany(i => i.AdditionallyCost).WithOptional(i => i.Proposal).HasForeignKey(i => i.ProposalId).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Invoice>().HasRequired(i => i.ContragentOrganization).WithMany(i => i.ExternalInvoices).HasForeignKey(i => i.ContragentOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasRequired(i => i.MakerOrganization).WithMany(i => i.InternalInvoices).HasForeignKey(i => i.MakerOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasRequired(i => i.Maker).WithMany(i => i.MakedInvoices).HasForeignKey(i => i.MakerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasOptional(i => i.Proposal).WithMany(i => i.Invoices).HasForeignKey(i => i.ProposalId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Invoice>().HasOptional(i => i.Specification).WithMany(i => i.Invoices).HasForeignKey(i => i.SpecificationId).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Specification>().HasRequired(i => i.ContragentOrganization).WithMany(i => i.ExternalSpecifications).HasForeignKey(i => i.ContragentOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Specification>().HasRequired(i => i.MakerOrganization).WithMany(i => i.InternalSpecifications).HasForeignKey(i => i.MakerOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Specification>().HasRequired(i => i.Maker).WithMany(i => i.MakedSpecifications).HasForeignKey(i => i.MakerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Specification>().HasRequired(i => i.Recipient).WithMany(i => i.TakedSpecifications).HasForeignKey(i => i.RecipientId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Specification>().HasOptional(i => i.Proposal).WithRequired(i => i.Specification).Map(c => c.MapKey("SpecificationId")).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<Contract>().HasRequired(i => i.ContragentOrganization).WithMany(i => i.ExternalContracts).HasForeignKey(i => i.ContragentOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Contract>().HasRequired(i => i.MakerOrganization).WithMany(i => i.InternalContracts).HasForeignKey(i => i.MakerOrganizationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Contract>().HasRequired(i => i.Maker).WithMany(i => i.MakedContracts).HasForeignKey(i => i.MakerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Contract>().HasMany(i => i.Specifications).WithRequired(i => i.Contract).HasForeignKey(i => i.ContractId).WillCascadeOnDelete(false);
                        
            modelBuilder.Entity<ProposalPosition>().HasRequired(i => i.Proposal).WithMany().HasForeignKey(i => i.ProposalId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProposalPosition>().HasOptional(i => i.Valve).WithRequired(i => i.Position).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProposalPosition>().HasOptional(i => i.Rotor).WithOptionalPrincipal(i => i.Position).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProposalPosition>().HasMany(i => i.RotorOptions).WithOptional(i => i.Position).HasForeignKey(i => i.PositionId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ProposalPosition>().HasOptional(i => i.SOF).WithRequired(i => i.Position).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<ValveInPosition>().HasRequired(i => i.Position).WithOptional(i => i.Valve).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveInPosition>().HasRequired(i => i.ValveModel).WithMany().HasForeignKey(i => i.ValveModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveInPosition>().HasOptional(i => i.ReservedValve).WithOptionalDependent(i => i.ReservedBy).Map(c => c.MapKey("ReservedValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveInPosition>().HasOptional(i => i.Rotor).WithOptionalPrincipal(i => i.Valve).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveInPosition>().HasOptional(i => i.SOF).WithOptionalPrincipal(i => i.Valve).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<RotorInPosition>().HasOptional(i => i.Position).WithOptionalDependent(i => i.Rotor).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorInPosition>().HasRequired(i => i.RotorModel).WithMany().HasForeignKey(i => i.RotorModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorInPosition>().HasOptional(i => i.ReservedRotor).WithOptionalDependent(i => i.ReservedBy).Map(c => c.MapKey("ReservedRotorId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorInPosition>().HasOptional(i => i.Valve).WithOptionalDependent(i => i.Rotor).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorInPosition>().HasMany(i => i.RotorOptions).WithOptional(i => i.Rotor).HasForeignKey(i => i.RotorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RotorOptionInPosition>().HasOptional(i => i.Position).WithMany(i => i.RotorOptions).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOptionInPosition>().HasRequired(i => i.RotorOptionModel).WithMany().HasForeignKey(i => i.RotorOptionModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOptionInPosition>().HasOptional(i => i.Rotor).WithMany(i => i.RotorOptions).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOptionInPosition>().HasOptional(i => i.ReservedRotorOption).WithOptionalDependent(i => i.ReservedBy).Map(c => c.MapKey("ReservedRotorOptionId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<SofInPosition>().HasRequired(i => i.Position).WithOptional(i => i.SOF).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<SofInPosition>().HasRequired(i => i.SofModel).WithMany().HasForeignKey(i => i.SofModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SofInPosition>().HasOptional(i => i.ReservedSof).WithOptionalDependent(i => i.ReservedBy).Map(c => c.MapKey("ReservedSofId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<ManualProductInPosition>().HasRequired(i => i.Position).WithOptional(i => i.ManualProduct).Map(c => c.MapKey("PositionId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<ManualProductInPosition>().HasRequired(i => i.ManualProductModel).WithMany().HasForeignKey(i => i.ManualProductModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ManualProductInPosition>().HasOptional(i => i.ReservedManualProduct).WithOptionalDependent(i => i.ReservedBy).Map(c => c.MapKey("ReservedManualProductId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<Valve>().HasRequired(i => i.Model).WithMany().HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Valve>().HasOptional(i => i.Storage).WithMany(i => i.Valves).HasForeignKey(i => i.StorageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Valve>().HasOptional(i => i.Rotor).WithOptionalPrincipal(i => i.Valve).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Valve>().HasOptional(i => i.ReservedBy).WithOptionalPrincipal(i => i.ReservedValve).Map(c => c.MapKey("ReservedValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Valve>().HasOptional(i => i.SOF).WithOptionalPrincipal(i => i.Valve).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<Rotor>().HasRequired(i => i.Model).WithMany().HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rotor>().HasOptional(i => i.Storage).WithMany(i => i.Rotors).HasForeignKey(i => i.StorageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rotor>().HasOptional(i => i.Valve).WithOptionalDependent(i => i.Rotor).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rotor>().HasMany(i => i.RotorOptions).WithOptional(i => i.Rotor).HasForeignKey(i => i.RotorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Rotor>().HasOptional(i => i.ReservedBy).WithOptionalPrincipal(i => i.ReservedRotor).Map(c => c.MapKey("ReservedRotorId")).WillCascadeOnDelete(false);
       
            modelBuilder.Entity<RotorOption>().HasRequired(i => i.Model).WithMany().HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOption>().HasOptional(i => i.Storage).WithMany(i => i.RotorOptions).HasForeignKey(i => i.StorageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOption>().HasOptional(i => i.Rotor).WithMany(i => i.RotorOptions).HasForeignKey(i => i.RotorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOption>().HasOptional(i => i.ReservedBy).WithOptionalPrincipal(i => i.ReservedRotorOption).Map(c => c.MapKey("ReservedRotorOptionId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<SOF>().HasRequired(i => i.Model).WithMany().HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SOF>().HasOptional(i => i.Storage).WithMany(i => i.SOFs).HasForeignKey(i => i.StorageId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SOF>().HasOptional(i => i.Valve).WithOptionalDependent(i => i.SOF).Map(c => c.MapKey("ValveId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<SOF>().HasOptional(i => i.ReservedBy).WithOptionalPrincipal(i => i.ReservedSof).Map(c => c.MapKey("ReservedSofId")).WillCascadeOnDelete(false);

            modelBuilder.Entity<ManualProduct>().HasRequired(i => i.ManualProductModel).WithMany().HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ManualProduct>().HasOptional(i => i.Storage).WithMany(i => i.ManualProducts).HasForeignKey(i => i.StorageId).WillCascadeOnDelete(false);

            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Manufacturer).WithMany().HasForeignKey(i => i.ManufacturerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.BodyMaterial).WithMany().HasForeignKey(i => i.BodyMaterialId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Connection).WithMany().HasForeignKey(i => i.ConnectionId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Consolidation).WithMany().HasForeignKey(i => i.ConsolidationId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Environment).WithMany().HasForeignKey(i => i.EnvironmentId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Type).WithMany().HasForeignKey(i => i.TypeId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasRequired(i => i.Series).WithMany().HasForeignKey(i => i.SeriesId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasOptional(i => i.CloseElementMaterial).WithMany().HasForeignKey(i => i.CloseElementMaterialId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasOptional(i => i.InsideConsolidationMaterial).WithMany().HasForeignKey(i => i.InsideConsolidationMaterialId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasOptional(i => i.RodConsolidationMaterial).WithMany().HasForeignKey(i => i.RodConsolidationMaterialId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ValveModel>().HasOptional(i => i.RodMaterial).WithMany().HasForeignKey(i => i.RodMaterialId).WillCascadeOnDelete(false);
            

            modelBuilder.Entity<RotorModel>().HasRequired(i => i.Manufacturer).WithMany().HasForeignKey(i => i.ManufacturerId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorModel>().HasRequired(i => i.Type).WithMany().HasForeignKey(i => i.TypeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RotorOptionModel>().HasRequired(i => i.Manufacturer).WithMany().HasForeignKey(i => i.ManufacturerId).WillCascadeOnDelete(false);

            modelBuilder.Entity<SofModel>().HasRequired(i => i.Manufacturer).WithMany().HasForeignKey(i => i.ManufacturerId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Facility>().HasOptional(i => i.ParentObject).WithMany(i => i.Facilities).HasForeignKey(i => i.ParentObjectId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasRequired(i => i.Supervisor).WithMany(i => i.SupervisedCompanies).HasForeignKey(i => i.SupervisorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>().HasOptional(i => i.Type).WithMany(i => i.Companies).HasForeignKey(i => i.TypeId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>().HasOptional(i => i.Employee).WithOptionalPrincipal(i => i.Post).Map(c => c.MapKey("EmployeeId")).WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>().HasRequired(i => i.Facility).WithMany(i => i.Posts).HasForeignKey(i => i.FacilityId).WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().HasRequired(i => i.Access).WithMany(i => i.Users).HasForeignKey(i => i.AccessId).WillCascadeOnDelete(false);
                        
            modelBuilder.Entity<Task>().HasRequired(i => i.Orderer).WithMany(i => i.AssignedTasks).HasForeignKey(i => i.OrdererId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasRequired(i => i.Executor).WithMany(i => i.ReceivedTasks).HasForeignKey(i => i.ExecutorId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasMany(i => i.ChildTasks).WithOptional(i => i.ParentTask).HasForeignKey(i => i.ParentTaskId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasMany(i => i.Reminders).WithRequired(i => i.Task).HasForeignKey(i => i.TaskId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Task>().HasMany(i => i.Comments).WithRequired(i => i.Task).HasForeignKey(i => i.TaskId).WillCascadeOnDelete(false);


            modelBuilder.Entity<Catalog>().HasMany(i => i.Valves).WithRequired(i => i.Catalog).HasForeignKey(i => i.CatalogId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Catalog>().HasMany(i => i.Rotors).WithRequired(i => i.Catalog).HasForeignKey(i => i.CatalogId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Catalog>().HasMany(i => i.RotorOptions).WithRequired(i => i.Catalog).HasForeignKey(i => i.CatalogId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Catalog>().HasMany(i => i.SOFs).WithRequired(i => i.Catalog).HasForeignKey(i => i.CatalogId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Catalog>().HasMany(i => i.ManualProducts).WithRequired(i => i.Catalog).HasForeignKey(i => i.CatalogId).WillCascadeOnDelete(false);
            
            modelBuilder.Entity<ValveInCatalog>().HasRequired(i => i.Model).WithMany(i => i.ValveInCatalogs).HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorInCatalog>().HasRequired(i => i.Model).WithMany(i => i.RotorInCatalogs).HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<RotorOptionInCatalog>().HasRequired(i => i.Model).WithMany(i => i.RotorOptionInCatalogs).HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<SofInCatalog>().HasRequired(i => i.Model).WithMany(i => i.SofInCatalogs).HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            modelBuilder.Entity<ManualProductInCatalog>().HasRequired(i => i.Model).WithMany(i => i.ManualProductInCatalogs).HasForeignKey(i => i.ModelId).WillCascadeOnDelete(false);
            
        }
    }
}
