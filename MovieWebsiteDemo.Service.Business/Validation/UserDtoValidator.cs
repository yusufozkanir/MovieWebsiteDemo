using FluentValidation;
using MovieWebsiteDemo.Core.DTOs;

namespace MovieWebsiteDemo.Service.Business.Validation
{
    public class UserDtoValidator : AbstractValidator<UserAppDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            //RuleFor(x => x.UserPassword).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

        }
    }
}
