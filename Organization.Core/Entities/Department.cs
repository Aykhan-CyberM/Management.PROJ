

using Organization.Core.Interfaces;
using System.Xml.Linq;

namespace Organization.Core.Interfaces
{
    public class Department : IEntity
    {
        public int Id { get; }
        public string GroupName { get; set; }
        public int EmployeeLimit { get; set; }
        public int CompanyId { get; set; }
        private static int _count { get; set; }
        private Department()
        {
            Id = _count++;
        }
        public Department(string group_name, int emplyoeeLimit, int companyId) : this()
        {
            CompanyId = companyId;
            GroupName = group_name;
            EmployeeLimit = emplyoeeLimit;

        }
        public override string ToString()
        {
            return $"Name:{GroupName},Id:{Id}";
        }

    }

}