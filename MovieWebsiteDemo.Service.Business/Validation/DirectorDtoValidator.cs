using FluentValidation;
using MovieWebsiteDemo.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebsiteDemo.Service.Business.Validation
{
    public class DirectorDtoValidator : AbstractValidator<DirectorDto>
    {
        public DirectorDtoValidator()
        {
            RuleFor(x => x.DirectorName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DirectorBirthDate).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DirectorPhoto).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.DirectorBiography).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");

        }
    }
}
