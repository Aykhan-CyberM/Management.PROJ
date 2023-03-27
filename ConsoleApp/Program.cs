using Organization.Infrastructure.Services;
using Organization.Core.Entities;
using Organization.Core.Interfaces;
using Organization.Infrastructure.Utilities.Exceptions;
using Organization.Infrastructure.DBcontex;
using System.Runtime.CompilerServices;

CompanyService companyService = new CompanyService();
DepartmentService departmentService = new DepartmentService();
EmployeeService employeeService = new EmployeeService();
Console.WriteLine("Welcome bro!");

while (true)
{
    Console.WriteLine
        ("!*!*!*!*!**!*!*!*!*!**!**!*!*!*!*!**!*"+
        "\n0->Exit" +
        "\n1-Create Company" +
        "\n2-List Company/Companies" +
        "\n3-Create Department" +
        "\n4-List Department" +
        "\n5-Add Employee" +
        "\n6-List Employees" +
        "\n7-Get All Employees by Name,Surname"+
        "\n!*!*!*!*!**!*!*!*!*!*!*!*!*!*!*!*!*!*!*");


    Console.WriteLine("Enter your choice bro:");
    string? response = Console.ReadLine();
    int menu;
    bool tryToInt = int.TryParse(response, out menu);
    if (tryToInt)
    {


        switch (menu)
        {
            case 0:
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("Enter Company Name:");
                try
                {
                    string? res_companyname = Console.ReadLine();
                    companyService.Create(res_companyname);
                    Console.WriteLine($"New Company is created: {res_companyname}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                break;
            case 2:
                Console.WriteLine("Company/Companies List:");
                companyService.GetAll();
                break;
            case 3:
                Console.WriteLine("Enter Department Name:");
                string? departmentName = Console.ReadLine();
            employeeLimit:
                Console.WriteLine("Enter Department Employee Limit:");
                string? departmentLimit = Console.ReadLine();
                int employeeLimit;
                bool tryToIntLimit = int.TryParse(departmentLimit, out employeeLimit);
                if (!tryToIntLimit)
                {
                    Console.WriteLine("Enter correct Format");
                    goto employeeLimit;
                }
            Select_Company:
                Console.WriteLine("Enter Company (Id):");
                companyService.GetAll();
                string? selectCompany = Console.ReadLine();
                int companyId;
                bool tryToIdCompany = int.TryParse(selectCompany, out companyId);
                if (!tryToIdCompany)
                {
                    Console.WriteLine("Enter correct Company Id");
                    goto Select_Company;
                }

                try
                {
                    departmentService.Create(departmentName, employeeLimit, companyId);
                    Console.WriteLine("Succesfully created");
                }
                catch (AddDepartmentFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto Select_Company;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 3;
                }
                break;
            case 4:
                Console.WriteLine("Department List:");
                departmentService.GetAll();
                break;
            case 5:              
                Console.WriteLine("Enter Employee Name:");
                string? employeeName = Console.ReadLine();
                Console.WriteLine("Enter Employee Surname:");
                string? employeeSurname = Console.ReadLine();
                Console.WriteLine("Enter Employee Salary");
                int salary = int.Parse(Console.ReadLine());
            selectDepartment:
                departmentService.GetAll();
                Console.WriteLine("Enter Department (Id):");
                string? selectDepartment = Console.ReadLine();
                int departmentId;
                bool tryToIdDepartment = int.TryParse(selectDepartment, out departmentId);
                if (!tryToIdDepartment)
                {
                    Console.WriteLine("Enter correct Department Id");
                    goto selectDepartment;
                }

                try
                {
                    employeeService.Create(employeeName, employeeSurname,departmentId,salary);
                    Console.WriteLine("Succesfully created");
                }
                catch (AddDepartmentFailedException ex)
                {
                    Console.WriteLine(ex.Message);
                    goto selectDepartment;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto case 7;
                }
                break;
            case 6:
                Console.WriteLine("Student List");
                employeeService.GetAll();
                break;

            case 7:
                Console.WriteLine("Enter Employee's Name DUDE!:");
                string? nameOrSurname = Console.ReadLine();
                try
                {
                    employeeService.GetByName(nameOrSurname);
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                break;
        
          
                
          
        }
    }
    else
    {
        Console.WriteLine("ENTER CORRECT ONE DUDE!");
    }
}