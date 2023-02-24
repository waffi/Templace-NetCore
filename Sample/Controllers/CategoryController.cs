using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private IRepositoryWrapper _repository;

        public UserController(ILogger<UserController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("user/")]
        public IActionResult Get()
        {
            return Ok(_repository.User.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_repository.User.Find(x => x.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/")]
        public IActionResult Post(User user)
        {
            _repository.User.Create(user);
            _repository.Save();

            if (user.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("user/{id}")]
        public IActionResult Put(int id, User user)
        {
            var entity = _repository.User.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            entity.FirstName = user.FirstName;

            _repository.User.Update(entity);
            _repository.Save();

            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("user/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _repository.User.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            _repository.User.Delete(entity);
            _repository.Save();

            return new JsonResult("Deleted Successfully");
        }
    }
}