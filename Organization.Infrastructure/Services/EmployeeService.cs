
using Organization.Core.Interfaces;
using Organization.Core.Interfaces;
using Organization.Infrastructure.DBcontex;
using Organization.Infrastructure.Services;
using Organization.Infrastructure.Utilities.Exceptions;

namespace Organization.Infrastructure.Services
{
    public class EmployeeService
    {
        private static int index_counter = 0;
        private readonly DepartmentService departmentService;
        public EmployeeService()
        {
            departmentService = new DepartmentService();
        }
        public void Create(string Name, string Surname, int DepartmentId, int Salary)
        {
            if (String.IsNullOrWhiteSpace(Name) || String.IsNullOrWhiteSpace(Surname) || Salary < 0)
            {
                throw new ArgumentNullException();
            }

            foreach (var department in AppDbContext.Departments)
            {
                if (department is null)
                {
                    throw new AddDepartmentFailedException("this Department is not exist");
                }
                if (department.Id == DepartmentId) { break; }
            }
            Employee newEmployee = new(Name, Surname, DepartmentId, Salary);
            AppDbContext.Employees[index_counter++] = newEmployee;
        }
        public void GetAll()
        {
            for (int i = 0; i < index_counter; i++)
            {

                Console.WriteLine("\n************************************************************************\n");
                Console.WriteLine($"Employee id: {AppDbContext.Employees[i].Id}; " +
                    $"Employee Name: {AppDbContext.Employees[i].Name}; " +
                    $"Employee Salary: {AppDbContext.Employees[i].Salary}" +
                $"Employee Surname: {AppDbContext.Employees[i].Surname};");
                departmentService.GetById(AppDbContext.Employees[i].DepartmentId);

                Console.WriteLine("\n************************************************************************\n");
            }
        }
        public void GetByName(string nameOrSurname)
        {
            if (String.IsNullOrEmpty(nameOrSurname))
            {
                throw new ArgumentNullException();
            }

            bool isExsist = false;
            string fullname = String.Empty;
            for (int i = 0; i < index_counter; i++)
            {
                fullname = AppDbContext.Employees[i].Name + " " + AppDbContext.Employees[i].Surname;

                if (fullname.ToUpper().Contains(nameOrSurname.ToUpper()))
                {
                    isExsist = true;
                    Console.WriteLine("\n************************************************************************\n");
                    Console.WriteLine($"Student id: {AppDbContext.Employees[i].Id}; " +
                        $"Student Name: {AppDbContext.Employees[i].Name}; " +
                        $"Student Surname: {AppDbContext.Employees[i].Surname};");
                    departmentService.GetById(AppDbContext.Employees[i].DepartmentId);
                    Console.WriteLine("\n************************************************************************\n");
                }
            }

            if (!isExsist)
            {
                throw new NotFoundException("Employee not Found dude");
            }


        }

    }
}
