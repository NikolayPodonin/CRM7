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
using CRM7.DataModel.Catalog.CatalogPosition;

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

            var category = pmod.AddProductCategory(new CRM7.DataModel.OnlineStore.ProductCategory() { Name = "Mobiles", IconCssProperty = "FlaticonBuilding-023-roof" });
            category = pmod.AddProductCategory(new CRM7.DataModel.OnlineStore.ProductCategory() { Name = "Bikes", IconCssProperty = "FlaticonCars-005-wheel" });
            category = pmod.AddProductCategory(new CRM7.DataModel.OnlineStore.ProductCategory() { Name = "Flowers", IconCssProperty = "FlaticonCars-057-fan" });
            category = pmod.AddProductCategory(new CRM7.DataModel.OnlineStore.ProductCategory() { Name = "Bikes", IconCssProperty = "FlaticonCars-005-wheel" });
            category = pmod.AddProductCategory(new CRM7.DataModel.OnlineStore.ProductCategory() { Name = "Bikes", IconCssProperty = "FlaticonCars-005-wheel" });

            //var consol = /*pmod.GetAllConsolidations().First() */pmod.AddConsolidation(new Consolidation() { Name = "PTFE+C" });
            //var envir = /*pmod.GetAllEnvironments().First()*/ pmod.AddEnvironment(new CRM7.DataModel.Product.Environment() { Name = "Вода" });
            //var connect = /*pmod.GetAllValveConnections().First()*/ pmod.AddValveConnection(new ValveConnection() { Name = "Приварное" });
            //var valveType = /*pmod.GetAllValveTypes().First()*/ pmod.AddValveType(new ValveType() { Name = "Шар" });
            //var valveSeries = pmod.AddValveSeries(new ValveSeries() { Name = "ШК4" });
            //var bodyMaterialType = /*pmod.GetAllMaterialTypes().First()*/ pmod.AddMaterialType(new MaterialType() { Name = "НЖ" });
            //var bodyMaterial = /*pmod.GetAllMaterials().First()*/ pmod.AddMaterial(new Material() { Name = "Нержавеющая сталь 03Х17Н14М3" }, bodyMaterialType.Id);

            //var manufacType = man.AddCompanyType(new CompanyType() { Name = "GearManufacturer", Description = "Производитель электроприводов." });
            //var cont = /*man.GetAllContacts().First() */ man.AddContact(new Contact() { FirstName = "Николай", LastName = "Подонин" });
            //var manufac = /*man.GetAllCompanies().First()*/ man.AddCompany(new Company() { Name = "Auma" }, cont.Id, manufacType.Id);
            //var valveMod = /*pmod.GetAllValveModels().First()*/ pmod.AddValveModel(new ValveModel() { DN = "125/100", PN = 2.5 }, consol.Id, envir.Id, valveType.Id, valveSeries.Id, connect.Id, bodyMaterial.Id, manufac.Id, category.Id);
            //var rotorType = pmod.AddRotorType(new RotorType() { Name = "Электропривод" });
            ////var EAMod = pmod.GetAllElectricActuatorModels().First() /*pmod.AddElectricActuatorModel(new ElectricActuatorModel() { Name = "SQ-200" }, manufac.Id, rotorType.Id)*/;
            ////var SofMod = /*pmod.GetAllSofModels().First()*/ pmod.AddSofModel(new SofModel() { Name = "КФЦЧ 20х18" }, manufac.Id);
            ////var valveRotDismatch = pmod.AddValveRotorDismatch(valveMod.Id, EAMod.Id);
            ////var valveSofDis = pmod.AddValveSofDismatch(valveMod.Id, SofMod.Id);


            Catalogue cat = new Catalogue();
            //var catal = /*cat.GetAllCatalogs().First()*/ cat.AddCatalog(new CRM7.DataModel.Catalog.Catalog() { Name = "OnlineStore", Description = "Каталог для онлайн магазина." });

            //var catal = cat.GetAllCatalogs().First();
            //var valveMod = pmod.GetAllValveModels().First();
            //var rotorType = pmod.GetAllRotorTypes().First();

            //cat.AddValveInCatalog(new CRM7.DataModel.Catalog.CatalogPosition.ValveInCatalog(), catal.Id, valveMod.Id, rotorType.Id);
            //cat.AddRotorInCatalog(new RotorInCatalog(), catal.Id, EAMod.Id);
            //cat.AddSofInCatalog(new SofInCatalog(), catal.Id, SofMod.Id);
            

            //WPF.CPForms.WindowMainCP CP = new WPF.CPForms.WindowMainCP();
            //WPF.CPForms.WindowOptionsCP op = new WPF.CPForms.WindowOptionsCP();
            //WPF.PassportForms.WindowPassport wp = new WPF.PassportForms.WindowPassport();
            //WPF.LoginForm.LoginWindow lw = new WPF.LoginForm.LoginWindow();
            //app.Run(lw);
            
        }
    }
}
