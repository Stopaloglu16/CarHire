using Application.Common.Interfaces;
using FluentValidation;

namespace Application.Aggregates.CarBrandAggregate.Commands.Create
{
    public class CreateCarBrandCommandValidator : AbstractValidator<CreateCarBrandCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCarBrandCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Name)
                  .MaximumLength(5)
                  .NotEmpty();
        }

    }
}
