using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.CarBrandsAggregate;
using MediatR;

namespace Application.Aggregates.CarBrandAggregate.Commands.Update
{

    public class UpdateCarBrandCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }


    public class UpdateCarBrandCommandHandler : IRequestHandler<UpdateCarBrandCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCarBrandCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCarBrandCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarBrands.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CarBrand), request.Id);
            }

            entity.Name = request.Name;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
