using FluentValidation;
using MovieWebsiteDemo.Core.DTOs;

namespace MovieWebsiteDemo.Service.Business.Validation
{
    //Ders 36
    public class MovieDtoValidator : AbstractValidator<MovieDto>
    {
        public MovieDtoValidator()
        {
            RuleFor(x => x.MovieTitle).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieSummary).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Producer).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ScreenWriter).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieType).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieDuration).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieReleaseDate).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieTrailer).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.MovieRating).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
            // RuleFor(x => x.DirectorId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

        }
    }
}
