


using Organization.Core.Interfaces;
using Organization.Core.Entities;
using Organization.Core.Interfaces;
using Organization.Infrastructure.Services;


namespace Organization.Infrastructure.DBcontex;




public static class AppDbContext
{
    public static Employee[] Employees { get; set; } = new Employee[1000];
    public static Department[] Departments { get; set; } = new Department[100];
    public static Company[] Companies { get; set; } = new Company[100];

}