using Application.Aggregates.AddressAggregate.Queries;
using Application.Repositories;
using Domain.Entities.AddressAggregate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AddressController : ApiController
    {

        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(AddressDto addressDto)
        {
            try
            {

                var myrtn =  await _addressRepository.AddAsync(new Address() {
                    Address1 = addressDto.Address1,
                    City = addressDto.City,
                    Postcode = addressDto.Postcode

                });

                return Ok(myrtn.Id);

            }
            catch (Exception ex)
            {
                await Task.Delay(500);
                return BadRequest(ex.Message);
            }
        }


    }
}
