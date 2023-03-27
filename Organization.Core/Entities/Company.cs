




using Organization.Core.Interfaces;

namespace Organization.Core.Entities;

public class Company : IEntity
{
    public int Id { get; }
    public string CompanyName { get; set; }
    private static int _count;
    private Company()
    {
        Id = _count++;
    }
    public Company(string companyName) : this()
    {
        CompanyName = companyName;
    }
}



