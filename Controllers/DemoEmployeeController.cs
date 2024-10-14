using Menu.BusinessLogics.Contracts;
using Menu.Common.SearchCriteria;
using Menu.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    [ApiController]
    //[ApiController, Authorize]
    [Route("api/[controller]Service",Name = "Employee")]
    public class DemoEmployeeController : ControllerBase
    {
        private readonly IEmployeeService _iEmployeeService;
        public readonly ILogger<DemoEmployeeController> _logger;
        public DemoEmployeeController(IEmployeeService iEmployeeService, ILogger<DemoEmployeeController> logger)  
        {
            _iEmployeeService = iEmployeeService;
            _logger = logger;
        }


        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<EmployeeViewModel> Get()
        {
            SearchCriteriaBase filter = new SearchCriteriaBase();

            return _iEmployeeService.GetEmployeeList(filter);
        }

        [HttpGet("{Id:int}", Name = "GetById")]
        public EmployeeViewModel GetById(int Id)
        {
            return _iEmployeeService.GetEmployeeById(Id);
        }

        [HttpPost(Name = "UpdateEmployees")]
        public IActionResult Post([FromBody] EmployeeViewModel employee)
        {
            var result = _iEmployeeService.UpdateEmployee(employee);
            return Ok(result);
        }
    }
}
