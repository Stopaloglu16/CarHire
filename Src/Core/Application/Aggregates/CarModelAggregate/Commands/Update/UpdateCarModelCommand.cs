using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.CarModelAggregate;
using MediatR;

namespace Application.Aggregates.CarModelAggregate.Commands.Update
{
    public class UpdateCarModelCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CarPhoto { get; set; }
        public int? CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }
        public int CarBrandId { get; set; }
    }


    public class UpdateCarModelCommandHandler : IRequestHandler<UpdateCarModelCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCarModelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarModels.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CarModel), request.Id);
            }

            entity.Name = request.Name;
            entity.CarPhoto = request.CarPhoto;
            entity.CarPhotoLenght = request.CarPhotoLenght;
            entity.SeatNumber = request.SeatNumber;
            entity.CarBrandId = request.CarBrandId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
