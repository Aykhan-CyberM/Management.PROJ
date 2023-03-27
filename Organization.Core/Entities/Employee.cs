
using Organization.Core.Interfaces;
using System.Runtime.CompilerServices;

namespace Organization.Core.Interfaces;

public class Employee : IEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Salary { get; set; }
    public int DepartmentId { get; set; }
    public int _counter { get; set; }
    private Employee()
    {
        Id = _counter++;
    }
    public Employee(string name, string surname, int id, int departmentId, decimal salary) : this()
    {
        Id = id;
        Name = name;
        Surname = surname;
        Salary = salary;
        DepartmentId = departmentId;

    }

    public Employee(string name, string surname, int departmentId,int salary)
    {
        Name = name;
        Surname = surname;
        DepartmentId = departmentId;
        Salary = salary;
    }

    public override string ToString()
    {
        return $"Name:{Name},Surname:{Surname},Id:{Id}";
    }
}