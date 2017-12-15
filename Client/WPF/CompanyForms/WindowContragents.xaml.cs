using CRM7.DataModel.Management;
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
using CRM7.Tools;

namespace Client.WPF
{
    /// <summary>
    /// Окно работы с контрагентами.
    /// </summary>
    public partial class WindowContragents : Window
    {
        public static User user; //в будущем будет глобальный параметр пользователя системы.
        Management man; // будет связью с сервером через WCF
        private CompanyType allTypes = new CompanyType() { Name = "All", Id = Guid.NewGuid()};
        private List<Company> companies;

        public WindowContragents()
        {
            InitializeComponent();
            man = new Management();

            //когда-то это будет работающий юзер.
            user = man.GetAllUsers().First();

            gridFacilityDetails.Visibility = Visibility.Collapsed;
            Facilities.SelectedItemChanged += (s, e) => 
            {
                if (Facilities.SelectedItem == null)
                {
                    DeleteButton.IsEnabled = false;
                    gridFacilityDetails.Visibility = Visibility.Collapsed;
                }
                else
                {
                    gridFacilityDetails.Visibility = Visibility.Visible;
                    if (((TreeViewItem)Facilities.SelectedItem).Tag is Company)
                    {
                        gridCompanyDetails.Visibility = Visibility.Visible;
                        gridCompanyDetails2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        gridCompanyDetails.Visibility = Visibility.Collapsed;
                        gridCompanyDetails2.Visibility = Visibility.Collapsed;
                    }
                }
                
            };
            

            foreach (var companyType in man.GetAllSupervisorCompanyTypes(user.ContactId))
            {
                cb_CompanyType.Items.Add(companyType);
            }
            cb_CompanyType.SelectedIndex = cb_CompanyType.Items.Add(allTypes);
            cb_CompanyType.SelectionChanged += cmdUpdateCompanyList_Click;

            companies = man.GetAllSupervisorCompanies(user.ContactId).ToList();
            FillTreeWithFacilities(Facilities, CompaniesOfSelectedType());   


        }

        private List<Company> CompaniesOfSelectedType()
        {
            var type = ((CompanyType)cb_CompanyType.SelectedItem);
            if (type.Id == allTypes.Id)
            {
                return companies;
            }
            return companies.Where(i => i.TypeId == type.Id).ToList();
        }

        /// <summary>
        /// Заполнение ветки дерева дочерними объектами.
        /// </summary>
        /// <param name="control">Узел для заполнения.</param>
        /// <param name="objects">Дочерние объекты.</param>
        private void FillTreeWithFacilities(ItemsControl control, IEnumerable<Facility> objects)
        {
            control.Items.Clear();
            foreach (Facility obj in objects)
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = obj;
                item.Header = obj.ToString();
                item.Items.Add("*");
                item.Expanded += Facilities_Expanded;
                item.Selected += (s, e) => { DeleteButton.IsEnabled = true; };
                control.Items.Add(item);
            }

            TreeViewItem newItem = new TreeViewItem();
            if (control.Name == "Facilities")
            {
                newItem.Tag = new Company();
            }
            else
            {
                newItem.Tag = new Facility() { ParentObjectId = ((Facility)control.Tag).Id };
            }
            newItem.Header = "+                                                                                              ";
            newItem.Selected += (s, e) => { DeleteButton.IsEnabled = false; };
            control.Items.Add(newItem);
        }

        /// <summary>
        /// Метод, вызываемый при нажатии на значек раскрытия вложенных элементов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Facilities_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            Facility obj = (Facility)item.Tag;
            try
            {
                FillTreeWithFacilities(item, man.GetChildFacilities(obj.Id));
            }
            catch(Exception ex)
            {
                Diagnostic.WriteMessage(ex.Message);
                MessageBox.Show(ex.Message, LocalizedStrings.Warning, MessageBoxButton.OK);
            }
        }

        private void cmdUpdateCompanyList_Click(object sender, RoutedEventArgs e)
        {
            FillTreeWithFacilities(Facilities, CompaniesOfSelectedType());
        }

        private void cmdDeleteFacility_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)Facilities.SelectedItem;
            Facility obj = (Facility)item.Tag;
            try
            {
                if (item.Tag is Company)
                {
                    man.DeleteCompany(obj.Id);
                    companies = man.GetAllSupervisorCompanies(user.ContactId);                    
                    FillTreeWithFacilities((ItemsControl)item.Parent, CompaniesOfSelectedType());
                }
                else if (item.Tag is Facility)
                {
                    man.DeleteFacility(obj.Id);
                    FillTreeWithFacilities((ItemsControl)item.Parent, man.GetChildFacilities(obj.Id));
                }
            }
            catch (Exception ex)
            {
                Diagnostic.WriteMessage(ex.Message);
                MessageBox.Show(ex.Message, LocalizedStrings.Warning, MessageBoxButton.OK);
            }            
        }

        private void cmdSaveFacility_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)Facilities.SelectedItem;
            Facility obj = (Facility)item.Tag;
            if (man.IsFacilityExist(obj.Id))
            {
                if (item.Tag is Company)
                {
                    man.UpdateCompany((Company)obj);
                    companies = man.GetAllSupervisorCompanies(user.ContactId);
                    FillTreeWithFacilities((ItemsControl)item.Parent, CompaniesOfSelectedType());
                }
                else if (item.Tag is Facility)
                {
                    man.UpdateFacility(obj);
                    FillTreeWithFacilities((ItemsControl)item.Parent, man.GetChildFacilities(obj.Id));
                }
            }
            else
            {
                if (item.Tag is Company)
                {
                    man.AddCompany((Company)obj, user.ContactId);
                    companies = man.GetAllSupervisorCompanies(user.ContactId);
                    FillTreeWithFacilities((ItemsControl)item.Parent, CompaniesOfSelectedType());
                }
                else if (item.Tag is Facility)
                {
                    man.AddFacility(obj, (Guid)obj.ParentObjectId);
                    FillTreeWithFacilities((ItemsControl)item.Parent, man.GetChildFacilities(obj.Id));
                }
            }
        }        
    }
}
