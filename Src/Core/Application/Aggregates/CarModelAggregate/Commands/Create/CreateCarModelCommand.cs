using Application.Common.Interfaces;
using Domain.Entities.CarModelAggregate;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarModelAggregate.Commands.Create
{

    public class CreateCarModelCommand : IRequest<int>
    {
        public CreateCarModelCommand(string name, string carPhoto, int carPhotoLenght, int seatNumber, int carBrandId)
        {
            Name = name;
            CarPhoto = carPhoto;
            CarPhotoLenght = carPhotoLenght;
            SeatNumber = seatNumber;
            CarBrandId = carBrandId;
        }

        [Required]
        public string? Name { get; }

        public string CarPhoto { get; set; }

        public int CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }
        public int CarBrandId { get; set; }
    }


    public class CreateCarModelCommandHandler : IRequestHandler<CreateCarModelCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarModelCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
        {
            var entity = new CarModel();

            entity.Name = request.Name;
            entity.CarPhoto = request.CarPhoto;
            entity.CarPhotoLenght = request.CarPhotoLenght;
            entity.SeatNumber = request.SeatNumber;
            entity.CarBrandId = request.CarBrandId;

            _context.CarModels.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
