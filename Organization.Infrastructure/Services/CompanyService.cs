

using Organization.Core.Entities;
using Organization.Infrastructure.DBcontex;
using System.Data;

namespace Organization.Infrastructure.Services
{
    public class CompanyService
    {
        private static int index_counter = 0;
        public void Create(string? name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException();
            }
            bool isExist = false;
            for (int i = 0; i < index_counter; i++)
            {
                if (AppDbContext.Companies[i].CompanyName.ToUpper() == name.ToUpper())
                {
                    isExist = true; break;
                }
            }
            if (isExist)
            {
                throw new DuplicateNameException("This course name already exist");
            }
            Company newCompany = new(name);
            AppDbContext.Companies[index_counter++] = newCompany;
        }

        public void GetAll()
        {
            for (int i = 0; i < index_counter; i++)
            {
                Console.WriteLine($"ID:{AppDbContext.Companies[i].Id} -> Name:{AppDbContext.Companies[i].CompanyName} ");
            }
        }
    }
}