using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService; 
        }

        [HttpPost("rentACar")]
        public IActionResult RentACar(Rental rental)
        {
            var result = _rentalService.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpGet("getAllRentalCars")]
        public IActionResult GetAllRentalCars()
        {
            var result = _rentalService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
