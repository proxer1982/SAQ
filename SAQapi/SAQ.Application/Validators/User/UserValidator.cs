using FluentValidation;

using SAQ.Application.Dtos.Request;

namespace SAQ.Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName)
                 .NotNull().WithMessage("El campo nombre no puede ser nulo.")
                 .NotEmpty().WithMessage("El campo nombre no puede estar vacio");
        }
    }
}
