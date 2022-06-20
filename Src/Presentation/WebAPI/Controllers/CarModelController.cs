using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class CarModelController : ApiController
    {

        [HttpGet]
        public async Task<ActionResult<CarModelList>> Get()
        {
            return await Mediator.Send(new GetCarModelsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarModelCommand command)
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
        public async Task<ActionResult> Update(int id, UpdateCarModelCommand command)
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
