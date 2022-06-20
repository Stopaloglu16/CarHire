using Application.Aggregates.CarBrandAggregate.Commands.Create;
using Application.Aggregates.CarBrandAggregate.Commands.Update;
using Application.Aggregates.CarBrandAggregate.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    // [Authorize]
    public class CarBrandController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<CarBrandList>> Get()
        {
            return await Mediator.Send(new GetCarBrandsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarBrandCommand command)
        {
            try
            {
                return await Mediator.Send(command);
            }
            catch (Exception ex)
            {
                await Task.Delay(500);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateCarBrandCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
