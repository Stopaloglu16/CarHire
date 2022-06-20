using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.AddressAggregate;
using MediatR;

namespace Application.Aggregates.AddressAggregate.Commands.Update
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id { get; set; }
        public string? Address1 { get; set; }
        public string? City { get; set; }
        public string? Postcode { get; set; }
    }


    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }

            entity.Address1 = request.Address1;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }

}
