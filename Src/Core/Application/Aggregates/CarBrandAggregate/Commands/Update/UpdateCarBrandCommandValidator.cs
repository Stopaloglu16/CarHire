using FluentValidation;

namespace Application.Aggregates.CarBrandAggregate.Commands.Update
{

    public class UpdateCarBrandCommandValidator : AbstractValidator<UpdateCarBrandCommand>
    {
        public UpdateCarBrandCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
