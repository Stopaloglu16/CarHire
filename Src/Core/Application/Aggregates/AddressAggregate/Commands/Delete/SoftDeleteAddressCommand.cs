using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.AddressAggregate;
using MediatR;

namespace Application.Aggregates.AddressAggregate.Commands.Delete
{

    public class SoftDeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class SoftDeleteAddressCommandHandler : IRequestHandler<SoftDeleteAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public SoftDeleteAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SoftDeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }

            entity.IsDeleted = 1;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
