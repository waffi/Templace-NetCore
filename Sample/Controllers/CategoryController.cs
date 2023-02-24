using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        
        private IRepositoryWrapper _repository;

        public CategoryController(ILogger<CategoryController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet()]
        public IEnumerable<Category> Get()
        {
            return _repository.Category.FindAll();
        }
    }
}