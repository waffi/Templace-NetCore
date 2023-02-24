using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        
        private IRepositoryWrapper _repository;

        public ProductController(ILogger<ProductController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet()]
        public IEnumerable<Product> Get()
        {
            return _repository.Product.FindAll();
        }
    }
}