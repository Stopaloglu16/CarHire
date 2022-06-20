using Application.Common.Interfaces;
using Domain.Entities.AddressAggregate;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.AddressAggregate.Commands.Create
{
    public class CreateAddressCommand : IRequest<int>
    {

        public CreateAddressCommand(string _Address1, string _City, string _Postcode, AddressType _addressType)
        {
            Address1 = _Address1;
            City = _City;
            Postcode = _Postcode;
            addressType = _addressType;
        }

        [Required]
        [StringLength(50)]
        public string Address1 { get; }

        [Required]
        [StringLength(50)]
        public string City { get; }

        [Required]
        [StringLength(10)]
        public string Postcode { get; }
        public AddressType addressType { get; }

    }


    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new Address
            {
                Address1 = request.Address1,
                City = request.City,
                Postcode = request.Postcode,
                addressType = request.addressType
            };

            _context.Addresses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }


}
