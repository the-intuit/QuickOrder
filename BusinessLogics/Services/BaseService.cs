using AutoMapper;
using Menu.Repositories.EF.Contracts;

namespace Menu.BusinessLogics.Services
{
    public class BaseService<T>
    {
        public readonly IEfUnitOfWork _uow;
        public readonly IMapper _mapper;
        public readonly ILogger<T> _logger;
        public BaseService(ILogger<T> logger, IEfUnitOfWork uow, IMapper mapper)
        {
            _logger = logger;
            _uow = uow;
            _mapper = mapper;
        }
    } 
}
