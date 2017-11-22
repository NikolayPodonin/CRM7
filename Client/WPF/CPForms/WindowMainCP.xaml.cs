using CRM7.DataModel.Catalog;
using CRM7.DataModel.Catalog.CatalogPosition;
using CRM7.DataModel.Commercial;
using CRM7.DataModel.Management;
using CRM7.DataModel.Product;
using CRM7.DataModel.Product.Rotor;
using CRM7.DataModel.Product.Valve;
using CRM7.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.WPF.CPForms
{
    /// <summary>
    /// Логика взаимодействия для WindowMainCP.xaml
    /// </summary>
    public partial class WindowMainCP : Window
    {
        //вместо этого будет шлюз через WCF
        Catalog catalog;
        ValveInCatalog valveInCatalog;

        public WindowMainCP()
        {
            InitializeComponent();

            Catalogue cat = new Catalogue();
            catalog = cat.GetAllCatalogs().First();

            //Здесь мы обращаемся на сервер каждый раз, чтобы получить характеристики моделей арматуры, которые отобразятся в окне.
            lbx_Manufacturer.SelectionChanged += (s, e) =>
            {
                if(lbx_Manufacturer.SelectedItem != null)
                {
                    lbx_Type.Items.Clear();
                    foreach (var valveType in cat.GetValveTypesOfManufacturerInCatalog(catalog.Id, ((Company)lbx_Manufacturer.SelectedItem).Id))
                    {
                        lbx_Type.Items.Add(valveType);
                    }
                    lbx_Type.SelectedIndex = 0;
                }
            };
            lbx_Type.SelectionChanged += (s, e) =>
            {
                if(lbx_Type.SelectedItem != null)
                {
                    lbx_Series.Items.Clear();
                    foreach (var series in cat.GetValveSeriesOfTypeInCatalog(catalog.Id, ((Company)lbx_Manufacturer.SelectedItem).Id, ((ValveType)lbx_Type.SelectedItem).Id))
                    {
                        lbx_Series.Items.Add(series);
                    }
                    lbx_Series.SelectedIndex = 0;
                }
            };
            lbx_Series.SelectionChanged += (s, e) =>
            {
                if(lbx_Series.SelectedItem != null)
                {
                    lbx_Connection.Items.Clear();
                    foreach (var connect in cat.GetValveConnectionOfSeriesInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id))
                    {
                        lbx_Connection.Items.Add(connect);
                    }
                    lbx_Connection.SelectedIndex = 0;
                }
            };
            lbx_Connection.SelectionChanged += (s, e) =>
            {
                if(lbx_Connection.SelectedItem != null)
                {
                    lbx_Environment.Items.Clear();
                    foreach (var envir in cat.GetValveEnvironmentOfConnectionInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id))
                    {
                        lbx_Environment.Items.Add(envir);
                    }
                    lbx_Environment.SelectedIndex = 0;
                }
            };
            lbx_Environment.SelectionChanged += (s, e) =>
            {
                if(lbx_Environment.SelectedItem != null)
                {
                    lbx_MaterialBody.Items.Clear();
                    foreach (var mb in cat.GetValveMaterialBodyOfEnvironmentInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id))
                    {
                        lbx_MaterialBody.Items.Add(mb);
                    }
                    lbx_MaterialBody.SelectedIndex = 0;
                }
            };
            lbx_MaterialBody.SelectionChanged += (s, e) =>
            {
                if(lbx_MaterialBody.SelectedItem != null)
                {
                    lbx_Consolidation.Items.Clear();
                    foreach (var mb in cat.GetValveConsolidationOfMaterialInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id))
                    {
                        lbx_Consolidation.Items.Add(mb);
                    }
                    lbx_Consolidation.SelectedIndex = 0;
                }
            };            
            lbx_Consolidation.SelectionChanged += (s, e) =>
            {
                if (lbx_Consolidation.SelectedItem != null)
                {
                    lbx_Controlling.Items.Clear();
                    foreach (var ctr in cat.GetControllingOfConsolidationInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id,
                        ((Consolidation)lbx_Consolidation.SelectedItem).Id))
                    {
                        lbx_Controlling.Items.Add(ctr);
                    }
                    lbx_Controlling.SelectedIndex = 0;
                }
            };
            // Дальше к элементам окна привязываются уже не характеристики арматуры, а сохраненные в клиенте модели арматуры, но отображаются только их характеристики.
            lbx_Controlling.SelectionChanged += (s, e) =>
            {
                if(lbx_Controlling.SelectedItem != null)
                {
                    lbx_DN.Items.Clear();
                    foreach (var dn in cat.GetDiametersOfControllingInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id,
                        ((Consolidation)lbx_Consolidation.SelectedItem).Id, 
                        (bool)lbx_Controlling.SelectedItem))
                    {
                        lbx_DN.Items.Add(dn);
                    }
                    lbx_DN.SelectedIndex = 0;
                }                
            };
            lbx_DN.SelectionChanged += (s, e) =>
            {
                if(lbx_DN.SelectedItem != null)
                {
                    lbx_PN.Items.Clear();
                    foreach (var pn in cat.GetPNsOfDiameterInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id,
                        ((Consolidation)lbx_Consolidation.SelectedItem).Id, 
                        (bool)lbx_Controlling.SelectedItem,
                        (string)lbx_DN.SelectedItem))
                    {
                        lbx_PN.Items.Add(pn);
                    }
                    lbx_PN.SelectedIndex = 0;
                }                
            };
            //Отсюда начинаются другие элементы, модель арматуры мы уже выбрали.
            lbx_PN.SelectionChanged += (s, e) =>
            {
                if(lbx_PN.SelectedItem != null)
                {
                    lbx_RotorType.Items.Clear();
                    foreach (var rt in cat.GetRotorTypesOfPNInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id,
                        ((Consolidation)lbx_Consolidation.SelectedItem).Id,
                        (bool)lbx_Controlling.SelectedItem,
                        (string)lbx_DN.SelectedItem,
                        (double)lbx_PN.SelectedItem))
                    {
                        lbx_RotorType.Items.Add(rt);
                    }
                    lbx_RotorType.SelectedIndex = 0;
                }                
            };
            lbx_RotorType.SelectionChanged += (s, e) =>
            {
                if (lbx_RotorType.SelectedItem != null)
                {
                    lbx_Rotors.Items.Clear();
                    valveInCatalog = cat.GetValveInCatalog(catalog.Id,
                        ((Company)lbx_Manufacturer.SelectedItem).Id,
                        ((ValveType)lbx_Type.SelectedItem).Id,
                        ((ValveSeries)lbx_Series.SelectedItem).Id,
                        ((ValveConnection)lbx_Connection.SelectedItem).Id,
                        ((CRM7.DataModel.Product.Environment)lbx_Environment.SelectedItem).Id,
                        ((Material)lbx_MaterialBody.SelectedItem).Id,
                        ((Consolidation)lbx_Consolidation.SelectedItem).Id,
                        (bool)lbx_Controlling.SelectedItem,
                        (string)lbx_DN.SelectedItem,
                        (double)lbx_PN.SelectedItem,
                        ((RotorType)lbx_RotorType.SelectedItem).Id);

                    dud_ValvePrice.DataContext = valveInCatalog;

                    //условие надо будет изменить на не содержащее строковых сравнений.
                    if (((RotorType)lbx_RotorType.SelectedItem).Name != "Голый шток" && ((RotorType)lbx_RotorType.SelectedItem).Name != "Ручной рычаг")
                    {
                        lbx_Rotors.IsEnabled = true;
                        chb_OtherRotor.IsEnabled = true;
                        foreach (var rm in cat.GetRotorsForValveInCatalog(catalog.Id, valveInCatalog.Id))
                        {
                            lbx_Rotors.Items.Add(rm);
                        }
                    }
                    else
                    {
                        lbx_Rotors.IsEnabled = false;
                        chb_OtherRotor.IsEnabled = false;
                    }
                }                    
            };
            lbx_Rotors.SelectionChanged += (s, e) =>
            {
                if(lbx_Rotors.SelectedItem != null)
                    dud_RotorPrice.DataContext = (RotorInCatalog)lbx_Rotors.SelectedItem;
            };
            lbx_SOFs.SelectionChanged += (s, e) =>
            {
                if(lbx_SOFs.SelectedItem != null)
                    dud_SOFPrice.DataContext = (SofInCatalog)lbx_SOFs.SelectedItem;
            };

            chb_OtherRotor.Checked += (s, e) =>
            {
                but_RotorOption.IsEnabled = true;
            };
            chb_OtherRotor.Unchecked += (s, e) =>
            {
                but_RotorOption.IsEnabled = false;
            };
            chb_SOF.Checked += (s, e) =>
            {
                if(valveInCatalog != null)
                {
                    lbx_SOFs.Items.Clear();
                    lbx_SOFs.IsEnabled = true;
                    foreach (var sof in cat.GetSofsForValveInCatalog(catalog.Id, valveInCatalog.Id))
                    {
                        lbx_SOFs.Items.Add(sof);
                    }
                }                
            };
            chb_SOF.Unchecked += (s, e) =>
            {
                lbx_SOFs.Items.Clear();
                lbx_SOFs.IsEnabled = false;
            };

            but_AddPosition.Click += (s, e) =>
            {
                ProposalPosition pos = new ProposalPosition() { Amount = 1 };
                pos.Valve = new ValveInPosition() { BaseValue = (decimal)dud_ValvePrice.Value, ValveModel = valveInCatalog.ValveModel };
                dgr_Positions.Items.Add(pos);
            };

            foreach (var company in cat.GetValveManufacturersInCatalog(catalog.Id))
            {
                lbx_Manufacturer.Items.Add(company);
            }            
        }

        private void but_RotorOption_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
