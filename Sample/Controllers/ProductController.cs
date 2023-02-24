using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        private IRepositoryWrapper _repository;

        public ProductController(ILogger<ProductController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("product/")]
        public IActionResult Get()
        {
            return Ok(_repository.Product.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_repository.Product.Find(x => x.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("product/")]
        public IActionResult Post(Product product)
        {
            _repository.Product.Create(product);
            _repository.Save();

            if (product.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("product/{id}")]
        public IActionResult Put(int id, Product category)
        {
            var entity = _repository.Product.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            entity.Name = category.Name;

            _repository.Product.Update(entity);
            _repository.Save();

            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("product/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _repository.Product.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            _repository.Product.Delete(entity);
            _repository.Save();

            return new JsonResult("Deleted Successfully");
        }
    }
}