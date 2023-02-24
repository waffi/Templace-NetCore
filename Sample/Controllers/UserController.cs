using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;
using Sample.Service;

namespace Sample.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        
        private UserService _userService;

        private AddressService _addressService;

        private CreditCardService _creditCardService;

        public UserController(
            ILogger<UserController> logger,
            UserService userService,
            AddressService addressService,
            CreditCardService creditCardService)
        {
            _logger = logger;
            _userService = userService;
            _addressService = addressService;
            _creditCardService = creditCardService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Route("user/")]
        public IActionResult Get()
        {
            return Ok(_userService.FindAll());
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.FindById(id));
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
            user = _userService.Create(user);

            if (user.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok(user);
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
            user = _userService.Update(id, user);

            return Ok(user);
        }

        /// <summary>
        /// Get Address By User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{id}/address/")]
        public IActionResult GetAddresByUserI(int id)
        {
            return Ok(_addressService.FindByUserId(id));
        }

        /// <summary>
        /// Post Address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/{id}/address/")]
        public IActionResult Post(int id, Address address)
        {
            address = _addressService.Create(id, address);

            if (address.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok(address);
        }

        /// <summary>
        /// Get Credit Card By User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("user/{id}/credit-card/")]
        public IActionResult GetCreditCardByUserI(int id)
        {
            return Ok(_creditCardService.FindByUserId(id));
        }

        /// <summary>
        /// Post Credit Card
        /// </summary>
        /// <param name="id"></param>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("user/{id}/credit-card/")]
        public IActionResult Post(int id, CreditCard creditCard)
        {
            creditCard = _creditCardService.Create(id, creditCard);

            if (creditCard.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok(creditCard);
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
           _userService.Delete(id);

            return new JsonResult("Deleted Successfully");
        }
    }
}