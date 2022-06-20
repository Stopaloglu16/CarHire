using Application.Aggregates.CarHireAggregate.Commands.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
   
    public class CarHireController : ApiController
    {

        //[HttpGet]
        //public async Task<ActionResult<CarBrandList>> Get()
        //{
        //    return await Mediator.Send(new GetCarBrandsQuery());
        //}

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCarHireCommand command)
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

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, UpdateCarBrandCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

    }


}
