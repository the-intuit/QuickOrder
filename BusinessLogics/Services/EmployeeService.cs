using AutoMapper;
using Menu.BusinessLogics.Contracts;
using Menu.Common.SearchCriteria;
using Menu.Data;
using Menu.Data.Dtos;
using Menu.Repositories.EF.Contracts;

namespace Menu.BusinessLogics.Services
{
    public class EmployeeService : BaseService<EmployeeService>, IEmployeeService
    {
        public EmployeeService(ILogger<EmployeeService> logger, IEfUnitOfWork uow, IMapper mapper) : base(logger, uow, mapper)
        { }

        public List<EmployeeViewModel> GetEmployeeList(SearchCriteriaBase filter)
        {
            filter.SortColumn = filter.SortColumn ?? "ID";
            var query = _uow.EmployeeRepository.AsQueryable().ToList();
            var totalRecords = query.Count();
            var obj = _mapper.Map<List<EmployeeViewModel>>(query);
            _logger.Log(LogLevel.Information, "TestMessage");
            return obj;
        }
        public EmployeeViewModel GetEmployeeById(int Id)
        {
            var result = _uow.EmployeeRepository.FirstOrDefault(x => x.EmployeeID == Id);
            return _mapper.Map<EmployeeViewModel>(result);
        }

        public EmployeeViewModel UpdateEmployee(EmployeeViewModel model)
        {
            var empData = _mapper.Map<EmployeeData>(model);
            _uow.EmployeeRepository.Update(empData);
            _uow.Commit();
            return model;
        }
    }
}