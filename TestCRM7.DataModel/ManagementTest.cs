using CRM7.DataModel.Management;
using CRM7.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCRM7.DataModel
{
    [TestClass]
    public class ManagementTest
    {

        Management management;

        CompanyType companyType;

        Company company;
        
        Facility Facility;
        Facility Facility2;

        Post post;
        Post post2;
        Post post3;

        AccessGroup accessGroup;

        User user;
        User user2;
        User user3;

        Contact contact;

        [TestMethod]
        public void ManagementAddTest()
        {
            management = new Management();

            companyType = management.AddCompanyType(new CompanyType());

            company = management.AddCompany(new Company(), companyType.Id);

            Facility = management.AddFacility(new Facility(), company.Id);

            post = management.AddPost(new Post(), company.Id);

            accessGroup = management.AddAccessGroup(new AccessGroup());

            user = management.AddUser(new User(), accessGroup.Id, company.Id);
           

            contact = management.AddContact(new Contact());
        }

        public void ManagmentUpdateTest()
        {
            Management management = new Management();

            CompanyType companyTypeId = management.UpdateCompanyType(new CompanyType());

            Company companyId = management.UpdateCompany(new Company());
            
            Facility FacilityId = management.UpdateFacility(new Facility());
            Facility FacilityId2 = management.UpdateFacility(new Facility());

            Post postId = management.UpdatePost(new Post());
            Post postId2 = management.UpdatePost(new Post());
            Post postId3 = management.UpdatePost(new Post());

            AccessGroup accessGroupId = management.UpdateAccessGroup(new AccessGroup());

            User userId = management.UpdateUser(new User());
            User userId2 = management.UpdateUser(new User());
            User userId3 = management.UpdateUser(new User());

            Contact contactId = management.UpdateContact(new Contact());
        }

        public void ManagementGetTest()
        {
            Management management = new Management();

            CompanyType companyTypeId = management.GetCompanyType(companyType.Id);

            Company companyId = management.GetCompany(company.Id);
            
            Facility FacilityId = management.GetFacility(Facility.Id);
            Facility FacilityId2 = management.GetFacility(Facility.Id);

            Post postId = management.GetPost(post.Id);
            Post postId2 = management.GetPost(post.Id);
            Post postId3 = management.GetPost(post.Id);

            AccessGroup accessGroupId = management.GetAccessGroup(accessGroup.Id);

            User userId = management.GetUser(user.Id);
            User userId2 = management.GetUser(user.Id);
            User userId3 = management.GetUser(user.Id);

            Contact contactId = management.GetContact(contact.Id);
        }

        public void ManagementGetAllTest()
        {
            Management management = new Management();

            List<CompanyType> companyTypeId = management.GetAllCompanyTypes();

            List<Company> companyId = management.GetAllCompanies();
            
            List<Facility> FacilityId = management.GetAllFacilities();

            List<Post> postId = management.GetAllPosts();

            List<AccessGroup> accessGroupId = management.GetAllAccessGroups();

            List<User> userId = management.GetAllUsers();

            List<Contact> contactId = management.GetAllContacts();
        }
    }
}
