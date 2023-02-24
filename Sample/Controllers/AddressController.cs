using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;
using Sample.Service;

namespace Sample.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        
        private AddressService _addressService;

        public AddressController(ILogger<AddressController> logger, AddressService addressService)
        {
            _logger = logger;
            _addressService = addressService;
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("address/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_addressService.FindById(id));
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("address/{id}")]
        public IActionResult Put(int id, Address address)
        {
            address = _addressService.Update(id, address);

            return Ok(address);
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
           _addressService.Delete(id);

            return new JsonResult("Deleted Successfully");
        }
    }
}