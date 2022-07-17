using System.ComponentModel.DataAnnotations;

namespace Application.Aggregates.CarModelAggregate.Commands.Create
{
    public class CreateCarModelRequest
    {

        public CreateCarModelRequest(string name, string carPhoto, int carPhotoLenght, int seatNumber, int carBrandId)
        {
            Name = name;
            CarPhoto = carPhoto;
            CarPhotoLenght = carPhotoLenght;
            SeatNumber = seatNumber;
            CarBrandId = carBrandId;
        }

        [Required]
        public string? Name { get; }

        public string? CarPhoto { get; set; }

        public int CarPhotoLenght { get; set; }
        public int SeatNumber { get; set; }
        public int CarBrandId { get; set; }

    }
}
