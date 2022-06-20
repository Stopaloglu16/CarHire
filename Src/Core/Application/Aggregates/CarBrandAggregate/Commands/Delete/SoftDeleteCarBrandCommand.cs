using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.CarBrandsAggregate;
using MediatR;

namespace Application.Aggregates.CarBrandAggregate.Commands.Delete
{

    public class SoftDeleteCarBrandCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class SoftDeleteCarBrandCommandHandler : IRequestHandler<SoftDeleteCarBrandCommand>
    {
        private readonly IApplicationDbContext _context;

        public SoftDeleteCarBrandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SoftDeleteCarBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarBrands.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CarBrand), request.Id);
            }

            entity.IsDeleted = 1;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
