using FluentValidation;

namespace FluentValidationDemo;

public class Validator :    AbstractValidator<User>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Name).Length(15);
        RuleFor(x => x.Age).NotNull().InclusiveBetween(18, 40);
        RuleFor(x => x.Address).NotNull().NotEmpty().NotEmpty().MaximumLength(10)
                .Must(address=> address.ToLower().Contains("block")).WithMessage("Address must contain Block");
        RuleFor(x => x.Email).EmailAddress();
        RuleFor(x => x.Phone).Length(11);
    }

}