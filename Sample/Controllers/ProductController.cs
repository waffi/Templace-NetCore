using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;

namespace Sample.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;

        private IRepositoryWrapper _repository;

        public AddressController(ILogger<AddressController> logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("address/")]
        public IActionResult Get()
        {
            return Ok(_repository.Address.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("address/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_repository.Address.Find(x => x.Id == Id).FirstOrDefault());
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("address/")]
        public IActionResult Post(Address address)
        {
            _repository.Address.Create(address);
            _repository.Save();

            if (address.Id == 0)
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
        [Route("address/{id}")]
        public IActionResult Put(int id, Address user)
        {
            var entity = _repository.Address.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            entity.Description = user.Description;

            _repository.Address.Update(entity);
            _repository.Save();

            return Ok("Updated Successfully");
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("address/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _repository.Address.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            _repository.Address.Delete(entity);
            _repository.Save();

            return new JsonResult("Deleted Successfully");
        }
    }
}