using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.Valve;
using CRM7.DataModel.Product;
using CRM7.DataModel;
using CRM7.DataModel.Product.SOF;
using CRM7.DataModel.Commercial;
using CRM7.Service;
using CRM7.DataModel.Management;
using CRM7.DataModel.Files;
using System.IO;
using System.Windows/*.Forms*/;

namespace Client
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            Management man = new Management();

            //var ct = /*man.GetAllUsers().First();*/ man.AddUser(new User(), man.AddAccessGroup(new AccessGroup() { Name = "Admin" }).Id, man.AddContact(new Contact() { FirstName = "Pikkolo" }).Id);
            //for (int i = 0; i < 5; i++)
            //{
            //    var comt = man.AddCompanyType(new CompanyType() { Name = $"CompanyType {i}" });
            //    var comt2 = man.AddCompanyType(new CompanyType() { Name = $"CompanyType {i + 5}" });
            //    var com = man.GetAllCompanies()[i];
            //    var com2 = man.GetAllCompanies()[i + 5];
            //    com.Type = comt;
            //    com2.Type = comt2;
            //    man.UpdateCompany(com);
            //    man.UpdateCompany(com2);
            //}

            //WPF.WindowContragents contr = new WPF.WindowContragents();
            Application app = new Application();
            //app.Run(contr);
            
            ProductModels pmod = new ProductModels();
                        
            var consol = pmod.AddConsolidation(new Consolidation() { Name = "PTFE+C" });
            var envir = pmod.AddEnvironment(new CRM7.DataModel.Product.Environment() { Name = "Вода" });
            var connect = pmod.AddValveConnection(new ValveConnection() { Name = "Приварное" });
            var valveType = pmod.AddValveType(new ValveType() { Name = "Шар" });
            var valveSeries = pmod.AddValveSeries(new ValveSeries() { Name = "ШК3" });
            var bodyMaterialType = pmod.AddMaterialType(new MaterialType() { Name = "НЖ" });
            var bodyMaterial = pmod.AddMaterial(new Material() { Name = "Нержавеющая сталь 03Х17Н14М3" }, bodyMaterialType.Id);

            var manufacType = man.AddCompanyType(new CompanyType() { Name = "GearManufacturer", Description = "Производитель электроприводов." });
            var cont = /*man.GetAllContacts().First()*/ man.AddContact(new Contact() { FirstName = "Николай", LastName="Подонин" });
            var manufac = man.AddCompany(new Company() { Name = "Auma" }, cont.Id, manufacType.Id);
            var valveMod = /*pmod.GetAllValveModels().First()*/ pmod.AddValveModel(new ValveModel() { DN = "125/100", PN = 2.5 }, consol.Id, envir.Id, valveType.Id, valveSeries.Id, connect.Id, bodyMaterial.Id, manufac.Id);
            var rotorType = pmod.AddRotorType(new RotorType() { Name = "Электропривод" });
            var EAMod = pmod.AddElectricActuatorModel(new ElectricActuatorModel() { Name = "SQ-200" }, manufac.Id, rotorType.Id);
            var valveRotDismatch = pmod.AddValveRotorDismatch(valveMod.Id, EAMod.Id);

            Catalogue cat = new Catalogue();
            var catal = /*cat.GetAllCatalogs().First()*/ cat.AddCatalog(new CRM7.DataModel.Catalog.Catalog());
            cat.AddValveInCatalog(new CRM7.DataModel.Catalog.CatalogPosition.ValveInCatalog(), catal.Id, valveMod.Id);


            WPF.CPForms.WindowMainCP CP = new WPF.CPForms.WindowMainCP();
            app.Run(CP);
            
        }
    }
}
