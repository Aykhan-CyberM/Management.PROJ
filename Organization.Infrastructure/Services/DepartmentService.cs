

using Organization.Infrastructure.Utilities.Exceptions;
using Organization.Core.Interfaces;
using Organization.Infrastructure.DBcontex;
using Organization.Infrastructure.Utilities.Exceptions;

using System.Data;
using System.Diagnostics.Metrics;

namespace Organization.Infrastructure.Services
{
    public class DepartmentService
    {
        private static int index_counter = 0;

        public string DepartmentName { get; private set; }

        private int EmployeeLimit;

        public void Create(string? name, int employeeLimit, int companyId)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            bool isExist = false;
            for (int i = 0; i < index_counter; i++)
            {
                if (AppDbContext.Departments[i].GroupName.ToUpper() == name.ToUpper())
                {
                    isExist = true; break;
                }
            }
            if (isExist)
            {
                throw new DuplicateNameException("This department name already exist");
            }


            foreach (var company in AppDbContext.Companies)
            {
                if (company is null)
                {
                    throw new AddCompanyFailedException("this company is not exist");
                }

                if (company.Id == companyId) { break; }
            }

            Department newdepartment = new(name, employeeLimit, companyId);
            AppDbContext.Departments[index_counter++] = newdepartment;
        }

        public void GetAll()
        {
            for (int i = 0; i < index_counter; i++)
            {
                String tempcompany = String.Empty;
                foreach (var company in AppDbContext.Companies)
                {
                    if (company == null) break;
                    if (AppDbContext.Departments[i].CompanyId == company.Id)
                    {
                        tempcompany = company.CompanyName;
                        break;
                    }
                }
                Console.WriteLine($"id: {AppDbContext.Departments[i].Id}; " +
                    $"Dpeartment: {AppDbContext.Departments[i].GroupName}; " +

                    $"Employee Limit: {AppDbContext.Departments[i].EmployeeLimit}; " +
                    $"Belongs to: {tempcompany}");

            }

        }
        public void GetById(int id)
        {
            
            for (int i = 0; i < index_counter; i++)
            {
                if (AppDbContext.Departments[i].Id == id)
                {
                    String tempcompany = String.Empty;
                    foreach (var company in AppDbContext.Companies)
                    {
                        if (company == null) break;
                        if (AppDbContext.Departments[i].CompanyId == company.Id)
                        {
                            tempcompany = company.CompanyName;
                            break;
                        }
                    }
                    Console.WriteLine($"Department id: {AppDbContext.Departments[i].Id}; " +
                    $"Department: {AppDbContext.Departments[i].GroupName}; " +
                    $"Employee Limit: {AppDbContext.Departments[i].EmployeeLimit}; " +
                    $"Belongs to: {tempcompany}");
                    return;
                }

            }
        }
        public  void GetAllDepartment(string? company_name)
        {
            if (String.IsNullOrEmpty(company_name))
            {
                throw new ArgumentNullException();

            }
            for (int i = 0; i < AppDbContext.Companies.Length; i++)
            
                if (AppDbContext.Companies[i].CompanyName.Equals(company_name))
                {
                    foreach (var department in AppDbContext.Departments)
                    {
                        if (department == null) 
                        {
                            break;
                        }
                        if(department.CompanyId == AppDbContext.Companies[i].Id)
                        {
                            Console.WriteLine(department.GroupName);
                        }
                        break;
                    }
                }
                else
                {
                    throw new NotExistException("Not Found DUDE!");
                }

            }
        }


    }
