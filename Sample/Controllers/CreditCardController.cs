using Microsoft.AspNetCore.Mvc;
using Sample.Entity.Models;
using Sample.Entity.RepositoryContract;
using Sample.Service;

namespace Sample.Controllers
{
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        
        private CreditCardService _creditCardService;

        public CreditCardController(ILogger<CreditCardController> logger, CreditCardService creditCardService)
        {
            _logger = logger;
            _creditCardService = creditCardService;
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("creditCard/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_creditCardService.FindById(id));
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="id"></param>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("creditCard/{id}")]
        public IActionResult Put(int id, CreditCard creditCard)
        {
            creditCard = _creditCardService.Update(id, creditCard);

            return Ok(creditCard);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("creditCard/{id}")]
        public IActionResult Delete(int id)
        {
           _creditCardService.Delete(id);

            return new JsonResult("Deleted Successfully");
        }
    }
}