using Menu.Common.SearchCriteria;
using Menu.Data.Dtos;

namespace Menu.BusinessLogics.Contracts
{
    public interface IEmployeeService
    {
        public List<EmployeeViewModel> GetEmployeeList(SearchCriteriaBase filter);
        public EmployeeViewModel GetEmployeeById(int Id);
        public EmployeeViewModel UpdateEmployee(EmployeeViewModel model);
    }
}
