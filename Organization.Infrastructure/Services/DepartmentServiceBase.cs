using Organization.Infrastructure.DBcontex;
using Organization.Infrastructure.Utilities.Exceptions;

namespace Organization.Infrastructure.Services
{
    public class DepartmentServiceBase
    {
        public void GetAllDepartment(string? company_name)
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
                        if (department.CompanyId == AppDbContext.Companies[i].Id)
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