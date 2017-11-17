using CRM7.DataModel.Management;
using CRM7.Mapping;
using CRM7.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM7.Service
{
    public partial class Management
    {
        #region Company

        #region AddSmth

        /// <summary>
        /// Добавить тип компании.
        /// </summary>
        /// <param name="companyType">Тип компании.</param>
        /// <returns>Тип компании.</returns>
        public CompanyType AddCompanyType(CompanyType companyType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.CompanyTypes.Where(i => i.Id == companyType.Id).Count() == 1)
                {
                    return companyType;
                }
                companyType = context.CompanyTypes.Add(companyType);
                context.SaveChanges();
                return companyType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить тип компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Добавить компанию.
        /// </summary>
        /// <param name="company">Компания.</param>
        /// <param name="companyTypeId">Id типа компании.</param>
        /// <returns>Компания.</returns>
        public Company AddCompany(Company company, Guid supervisorId, Guid? companyTypeId = null)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Companies.Where(i => i.Id == company.Id).Count() == 1)
                {
                    return company;
                }
                if (companyTypeId != null)
                {
                    company.Type = context.CompanyTypes.Find(companyTypeId);
                }
                company.Supervisor = context.Contacts.Find(supervisorId);
                company = context.Companies.Add(company);
                context.SaveChanges();
                return company;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить компанию. Смотри вложенное исключение", e);
            }
        }
        
        /// <summary>
        /// Добавить производственный объект или отдел.
        /// </summary>
        /// <param name="Facility">Производственный объект или отдел.</param>
        /// <param name="parentObjectId">Id компании.</param>
        /// <returns></returns>
        public Facility AddFacility(Facility Facility, Guid parentObjectId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Facilities.Where(i => i.Id == Facility.Id).Count() == 1)
                {
                    return Facility;
                }
                Facility.ParentObject = context.Facilities.Find(parentObjectId);
                Facility = context.Facilities.Add(Facility);
                context.SaveChanges();
                return Facility;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить производственный объект. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Добавить должность.
        /// </summary>
        /// <param name="post">Должность.</param>
        /// <param name="FacilityId">Id объекта организации.</param>
        /// <returns></returns>
        public Post AddPost(Post post, Guid FacilityId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Posts.Where(i => i.Id == post.Id).Count() == 1)
                {
                    return post;
                }
                post.Facility = context.Facilities.Find(FacilityId);
                post = context.Posts.Add(post);
                context.SaveChanges();
                return post;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Добавить группу доступа.
        /// </summary>
        /// <param name="accessGroup">Группа доступа.</param>
        /// <returns>Группа доступа.</returns>
        public AccessGroup AddAccessGroup(AccessGroup accessGroup)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.AccessGroups.Where(i => i.Id == accessGroup.Id).Count() == 1)
                {
                    return accessGroup;
                }
                accessGroup = context.AccessGroups.Add(accessGroup);
                context.SaveChanges();
                return accessGroup;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить группу доступа. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Добавить пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <param name="accessGroupId">Id группы доступа.</param>
        /// <param name="contactId">Id контакта.</param>
        /// <returns></returns>
        public User AddUser(User user, Guid accessGroupId, Guid contactId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Users.Where(i => i.Id == user.Id).Count() == 1)
                {
                    return user;
                }
                user.Access = context.AccessGroups.Find(accessGroupId);
                user.Contact = context.Contacts.Find(contactId);
                user = context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить пользователя. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Добавить контакт.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        /// <returns>Контакт.</returns>
        public Contact AddContact(Contact contact)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                if (context.Contacts.Where(i => i.Id == contact.Id).Count() == 1)
                {
                    return contact;
                }
                contact = context.Contacts.Add(contact);
                context.SaveChanges();
                return contact;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось добавить контакт. Смотри вложенное исключение", e);
            }
        }

        #endregion

        #region UpdateSmth

        /// <summary>
        /// Изменить тип компании.
        /// </summary>
        /// <param name="companyType">Тип компании.</param>
        /// <returns>Тип компании.</returns>
        public CompanyType UpdateCompanyType(CompanyType companyType)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                CompanyType tempType = context.CompanyTypes.Find(companyType.Id);
                if(tempType == null)
                {
                    throw new ArgumentNullException("CompanyType", "Типа компании с таким Id нет в базе.");
                }
                tempType = tempType.CloneFrom(companyType);
                context.SaveChanges();
                return tempType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить тип компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Изменить компанию.
        /// </summary>
        /// <param name="company">Компания.</param>
        /// <returns>Компания.</returns>
        public Company UpdateCompany(Company company)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Company tempCompany = context.Companies.Find(company.Id);
                if (tempCompany == null)
                {
                    throw new ArgumentNullException(nameof(CompanyType), LocalizedStrings.NotExistsSmth);
                }
                tempCompany = tempCompany.CloneFrom(company);
                tempCompany.Type = context.CompanyTypes.Find(company.Type.Id);
                tempCompany.Supervisor = context.Contacts.Find(company.SupervisorId);
                if(company.ParentObject != null)
                {
                    tempCompany.ParentObject = context.Companies.Find(company.ParentObject.Id);
                }                
                context.SaveChanges();
                return tempCompany;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить компанию. Смотри вложенное исключение", e);
            }
        }
              
        /// <summary>
        /// Изменить производственный объект.
        /// </summary>
        /// <param name="Facility">Производственный объект.</param>
        /// <returns></returns>
        public Facility UpdateFacility(Facility Facility)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Facility tempFacility = context.Facilities.Find(Facility.Id);
                if (tempFacility == null)
                {
                    throw new ArgumentNullException("Facility", "Объекта с таким Id нет в базе.");
                }
                tempFacility = tempFacility.CloneFrom(Facility);
                tempFacility.ParentObject = context.Facilities.Find(Facility.ParentObject.Id);
                context.SaveChanges();
                return tempFacility;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить объект. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Изменить должность.
        /// </summary>
        /// <param name="post">Должность.</param>
        /// <returns></returns>
        public Post UpdatePost(Post post)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Post tempPost = context.Posts.Find(post.Id);
                if (tempPost == null)
                {
                    throw new ArgumentNullException("Post", "Должности с таким Id нет в базе.");
                }
                tempPost = tempPost.CloneFrom(post);
                tempPost.Facility = context.Facilities.Find(post.Facility.Id);                
                if (post.Employee != null)
                {
                    tempPost.Employee = context.Contacts.Find(post.Employee.Id);
                }
                context.SaveChanges();
                return tempPost;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Изменить группу доступа.
        /// </summary>
        /// <param name="accessGroup">Группа доступа.</param>
        /// <returns>Группа доступа.</returns>
        public AccessGroup UpdateAccessGroup(AccessGroup accessGroup)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);


                AccessGroup tempGroup = context.AccessGroups.Find(accessGroup.Id);
                if (tempGroup == null)
                {
                    throw new ArgumentNullException("AccessGroup", "Группы доступа с таким Id нет в базе.");
                }
                tempGroup = tempGroup.CloneFrom(accessGroup);
                context.SaveChanges();
                return tempGroup;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить группу доступа. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Изменить пользователя.
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Пользователь.</returns>
        public User UpdateUser(User user)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                User tempUser = context.Users.Find(user.Id);
                if (tempUser == null)
                {
                    throw new ArgumentNullException("User", "Пользователя с таким Id нет в базе.");
                }
                tempUser = tempUser.CloneFrom(user);
                tempUser.Contact = context.Contacts.Find(user.Contact.Id);
                tempUser.Access = context.AccessGroups.Find(user.Access.Id);
                context.SaveChanges();
                return tempUser;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Изменить контакт.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        /// <returns>Контакт.</returns>
        public Contact UpdateContact(Contact contact)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Contact tempContact = context.Contacts.Find(contact.Id);
                if (tempContact == null)
                {
                    throw new ArgumentNullException("Contact", "Контакта с таким Id нет в базе.");
                }
                tempContact = tempContact.CloneFrom(contact);
                context.SaveChanges();
                return tempContact;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось изменить контакт. Смотри вложенное исключение", e);
            }
        }

        #endregion

        #region GetSmth

        /// <summary>
        /// Получить тип компании.
        /// </summary>
        /// <param name="companyTypeId">Id Типа компании.</param>
        /// <returns>Тип компании.</returns>
        public CompanyType GetCompanyType(Guid companyTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                CompanyType tempType = context.CompanyTypes.Find(companyTypeId);
                if (tempType == null)
                {
                    throw new ArgumentNullException("CompanyType", "Типа компании с таким Id нет в базе.");
                }
                return tempType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить тип компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить компанию.
        /// </summary>
        /// <param name="companyId">Id Компании.</param>
        /// <returns>Компания.</returns>
        public Company GetCompany(Guid companyId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Company tempCompany = context.Companies.Find(companyId);
                if (tempCompany == null)
                {
                    throw new ArgumentNullException("CompanyType", "Компании с таким Id нет в базе.");
                }
                return tempCompany;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить компанию. Смотри вложенное исключение", e);
            }
        }
        
        /// <summary>
        /// Получить производственный объект.
        /// </summary>
        /// <param name="FacilityId">Id Производственного объекта.</param>
        /// <returns></returns>
        public Facility GetFacility(Guid FacilityId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Facility tempFacility = context.Facilities.Find(FacilityId);
                if (tempFacility == null)
                {
                    throw new ArgumentNullException("Facility", "Объекта с таким Id нет в базе.");
                }
                return tempFacility;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить объект. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить должность.
        /// </summary>
        /// <param name="post">Id Должности.</param>
        /// <returns></returns>
        public Post GetPost(Guid postId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Post tempPost = context.Posts.Find(postId);
                if (tempPost == null)
                {
                    throw new ArgumentNullException("Post", "Должности с таким Id нет в базе.");
                }
                return tempPost;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить группу доступа.
        /// </summary>
        /// <param name="accessGroupId">Id Группы доступа.</param>
        /// <returns>Группа доступа.</returns>
        public AccessGroup GetAccessGroup(Guid accessGroupId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);


                AccessGroup tempGroup = context.AccessGroups.Find(accessGroupId);
                if (tempGroup == null)
                {
                    throw new ArgumentNullException("AccessGroup", "Группы доступа с таким Id нет в базе.");
                }
                return tempGroup;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить группу доступа. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить пользователя.
        /// </summary>
        /// <param name="user">Id Пользователя.</param>
        /// <returns>Пользователь.</returns>
        public User GetUser(Guid userId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                User tempUser = context.Users.Find(userId);
                if (tempUser == null)
                {
                    throw new ArgumentNullException("User", "Пользователя с таким Id нет в базе.");
                }
                return tempUser;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить контакт.
        /// </summary>
        /// <param name="contactId">Id Контакта.</param>
        /// <returns>Контакт.</returns>
        public Contact GetContact(Guid contactId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Contact tempContact = context.Contacts.Find(contactId);
                if (tempContact == null)
                {
                    throw new ArgumentNullException("Contact", "Контакта с таким Id нет в базе.");
                }
                return tempContact;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить контакт. Смотри вложенное исключение", e);
            }
        }

        #endregion

        #region GetAllSmth

        /// <summary>
        /// Получить все типы компании.
        /// </summary>
        /// <returns>Типы компании.</returns>
        public List<CompanyType> GetAllCompanyTypes()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List <CompanyType> tempType = context.CompanyTypes.Include("Companies").ToList();
                return tempType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить типы компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить все типы компании одного куратора.
        /// </summary>
        /// <param name="supervisorId">Id куратора компании.</param>
        /// <returns>Типы компаний.</returns>
        public List<CompanyType> GetAllSupervisorCompanyTypes(Guid supervisorId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<CompanyType> tempCompanyType = context.Contacts.Find(supervisorId).SupervisedCompanies.Select(i => i.Type).Distinct().ToList();
                return tempCompanyType;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Companies + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все компании.
        /// </summary>
        /// <returns>Компании.</returns>
        public List<Company> GetAllCompanies()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List <Company> tempCompany = context.Companies.ToList();
                return tempCompany;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Companies + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все компании одного куратора.
        /// </summary>
        /// <param name="supervisorId">Id куратора компании.</param>
        /// <returns>Компании.</returns>
        public List<Company> GetAllSupervisorCompanies(Guid supervisorId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);
                List<Company> tempCompany = context.Contacts.Find(supervisorId).SupervisedCompanies.ToList();
                return tempCompany;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception(LocalizedStrings.Companies + LocalizedStrings.CantGetSmth + LocalizedStrings.SeeInnerException, e);
            }
        }

        /// <summary>
        /// Получить все родительские компании.
        /// </summary>
        /// <returns>Компании.</returns>
        public List<Facility> GetChildFacilities(Guid parentId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List<Company> tempCompanies = context.Companies.Where(i => i.ParentObjectId == parentId).ToList();
                List<Facility> tempFacilities = context.Facilities.Where(i => i.ParentObjectId == parentId).ToList();
                List<Facility> tempObjects = new List<Facility>();
                tempObjects.AddRange(tempCompanies);
                tempObjects.AddRange(tempFacilities);
                return tempObjects;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить все производственные объекты.
        /// </summary>
        /// <returns>Производственные объекты.</returns>
        public List<Facility> GetAllFacilities()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List<Facility> tempFacility = context.Facilities.ToList();
                return tempFacility;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить объекты. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить все должности.
        /// </summary>
        /// <returns>Должности.</returns>
        public List<Post> GetAllPosts()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List <Post> tempPost = context.Posts.ToList();
                return tempPost;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить должности. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить все группы доступа.
        /// </summary>
        /// <returns>Группы доступа.</returns>
        public List<AccessGroup> GetAllAccessGroups()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List <AccessGroup> tempGroup = context.AccessGroups.ToList();
                return tempGroup;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить группы доступа. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить всех пользователей.
        /// </summary>
        /// <returns>Пользователи.</returns>
        public List<User> GetAllUsers()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List < User> tempUser = context.Users.ToList();
                return tempUser;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить должности. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Получить все контакты.
        /// </summary>
        /// <returns>Контакты.</returns>
        public List<Contact> GetAllContacts()
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                List<Contact> tempContacts = context.Contacts.ToList();
                return tempContacts;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Получить контакты. Смотри вложенное исключение", e);
            }
        }

        #endregion

        #region DeleteSmth

        /// <summary>
        /// Удалить тип компании.
        /// </summary>
        /// <param name="companyTypeId">Id Типа компании.</param>
        /// <returns>Тип компании.</returns>
        public void DeleteCompanyType(Guid companyTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                CompanyType tempType = context.CompanyTypes.Find(companyTypeId);
                if (tempType == null)
                {
                    throw new ArgumentNullException("CompanyType", "Типа компании с таким Id нет в базе.");
                }
                context.CompanyTypes.Remove(tempType);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Удалить тип компании. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Удалить компанию.
        /// </summary>
        /// <param name="companyId">Id Компании.</param>
        /// <returns>Компания.</returns>
        public void DeleteCompany(Guid companyId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Company tempCompany = context.Companies.Find(companyId);
                if (tempCompany == null)
                {
                    throw new ArgumentNullException(nameof(Company), LocalizedStrings.Company + LocalizedStrings.NotExistsSmth);
                }
                context.Companies.Remove(tempCompany);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(LocalizedStrings.Company + LocalizedStrings.CantDeleteSmth + ":\n" + e.Message);
                throw new Exception(LocalizedStrings.Company + LocalizedStrings.CantDeleteSmth, e);
            }
        }
        
        /// <summary>
        /// Удалить производственный объект.
        /// </summary>
        /// <param name="FacilityId">Id Производственного объекта.</param>
        /// <returns></returns>
        public void DeleteFacility(Guid FacilityId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Facility tempFacility = context.Facilities.Find(FacilityId);
                if (tempFacility == null)
                {
                    throw new ArgumentNullException(nameof(Facility), LocalizedStrings.Facility + LocalizedStrings.NotExistsSmth);
                }
                context.Facilities.Remove(tempFacility);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(LocalizedStrings.Facility + LocalizedStrings.CantDeleteSmth + ":\n" + e.Message);
                throw new Exception(LocalizedStrings.Facility + LocalizedStrings.CantDeleteSmth, e);
            }
        }

        /// <summary>
        /// Удалить должность.
        /// </summary>
        /// <param name="post">Id Должности.</param>
        /// <returns></returns>
        public void DeletePost(Guid postId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Post tempPost = context.Posts.Find(postId);
                if (tempPost == null)
                {
                    throw new ArgumentNullException("Post", "Должности с таким Id нет в базе.");
                }
                context.Posts.Remove(tempPost);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Удалить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Удалить группу доступа.
        /// </summary>
        /// <param name="accessGroupId">Id Группы доступа.</param>
        /// <returns>Группа доступа.</returns>
        public void DeleteAccessGroup(Guid accessGroupId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);


                AccessGroup tempGroup = context.AccessGroups.Find(accessGroupId);
                if (tempGroup == null)
                {
                    throw new ArgumentNullException("AccessGroup", "Группы доступа с таким Id нет в базе.");
                }
                context.AccessGroups.Remove(tempGroup);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Удалить группу доступа. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="user">Id Пользователя.</param>
        /// <returns>Пользователь.</returns>
        public void DeleteUser(Guid userId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                User tempUser = context.Users.Find(userId);
                if (tempUser == null)
                {
                    throw new ArgumentNullException("User", "Пользователя с таким Id нет в базе.");
                }
                context.Users.Remove(tempUser);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Удалить должность. Смотри вложенное исключение", e);
            }
        }

        /// <summary>
        /// Удалить контакт.
        /// </summary>
        /// <param name="contactId">Id Контакта.</param>
        /// <returns>Контакт.</returns>
        public void DeleteContact(Guid contactId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Contact tempContact = context.Contacts.Find(contactId);
                if (tempContact == null)
                {
                    throw new ArgumentNullException("Contact", "Контакта с таким Id нет в базе.");
                }
                context.Contacts.Remove(tempContact);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw new Exception("Не удалось Удалить контакт. Смотри вложенное исключение", e);
            }
        }

        #endregion

        #region IsSmthExist

        /// <summary>
        /// Добавлен ли в базу данных тип компании.
        /// </summary>
        /// <param name="companyTypeId">Id Типа компании.</param>
        /// <returns>Тип компании.</returns>
        public bool IsCompanyTypeExist(Guid companyTypeId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                CompanyType tempType = context.CompanyTypes.Find(companyTypeId);
                if (tempType == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлена ли в базу данных компания.
        /// </summary>
        /// <param name="companyId">Id Компании.</param>
        /// <returns>Компания.</returns>
        public bool IsCompanyExist(Guid companyId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Company tempCompany = context.Companies.Find(companyId);
                if (tempCompany == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлен ли в базу данных производственный объект.
        /// </summary>
        /// <param name="FacilityId">Id Производственного объекта.</param>
        /// <returns></returns>
        public bool IsFacilityExist(Guid FacilityId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Facility tempFacility = context.Facilities.Find(FacilityId);
                if(tempFacility == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлена ли в базу данных должность.
        /// </summary>
        /// <param name="post">Id Должности.</param>
        /// <returns></returns>
        public bool IsPostExist(Guid postId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Post tempPost = context.Posts.Find(postId);
                if (tempPost == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлена ли в базу данных группу доступа.
        /// </summary>
        /// <param name="accessGroupId">Id Группы доступа.</param>
        /// <returns>Группа доступа.</returns>
        public bool IsAccessGroupExist(Guid accessGroupId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);


                AccessGroup tempGroup = context.AccessGroups.Find(accessGroupId);
                if (tempGroup == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлен ли в базу данных пользователь.
        /// </summary>
        /// <param name="user">Id Пользователя.</param>
        /// <returns>Пользователь.</returns>
        public bool IsUserExist(Guid userId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                User tempUser = context.Users.Find(userId);
                if (tempUser == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        /// <summary>
        /// Добавлен ли в базу данных контакт.
        /// </summary>
        /// <param name="contactId">Id Контакта.</param>
        /// <returns>Контакт.</returns>
        public bool IsContactExist(Guid contactId)
        {
            try
            {
                ModelContext context = new ModelContext(LocalizedStrings.DatabaseName);

                Contact tempContact = context.Contacts.Find(contactId);
                if (tempContact == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Diagnostic.WriteMessage(e.Message);
                throw e;
            }
        }

        #endregion

        #endregion
    }
}
