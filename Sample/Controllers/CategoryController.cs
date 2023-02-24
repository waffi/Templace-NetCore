using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        
        private IRepositoryWrapper _repository;

        public CategoryController(ILogger<CategoryController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("category/")]
        public IActionResult Get()
        {
            return Ok(_repository.Category.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("category/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_repository.Category.Find(x => x.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("category/")]
        public IActionResult Post(Category category)
        {
            _repository.Category.Create(category);
            _repository.Save();

            if (category.Id == 0)
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
        [Route("category/{id}")]
        public IActionResult Put(int id, Category category)
        {
            var entity = _repository.Category.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            entity.Name = category.Name;

            _repository.Category.Update(entity);
            _repository.Save();

            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("category/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _repository.Category.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            _repository.Category.Delete(entity);
            _repository.Save();

            return new JsonResult("Deleted Successfully");
        }
    }
}