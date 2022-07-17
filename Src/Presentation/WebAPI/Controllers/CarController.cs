using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Queries;
using Application.Repositories;
using Domain.Entities.CarAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CarController : ApiController
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }


        [HttpGet]
        public async Task<IEnumerable<CarDto>> Get()
        {
            return await _carRepository.GetCars();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarRequest car)
        {
            try
            {

                return Ok(1);

            }
            catch (Exception ex)
            {
                await Task.Delay(500);
                return BadRequest(ex.Message);
            }
        }

    }




}
