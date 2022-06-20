using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Aggregates.CarModelAggregate.Queries
{
    public class GetCarModelsQuery : IRequest<CarModelList>
    {

    }

    public class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, CarModelList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCarModelsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarModelList> Handle(GetCarModelsQuery request, CancellationToken cancellationToken)
        {
            return new CarModelList
            {
                carModelDtos = await _context.CarModels
                           .ProjectTo<CarModelDto>(_mapper.ConfigurationProvider)
                           .OrderBy(x => x.Name)
                           .ToListAsync(cancellationToken)
            };
        }
    }
}
