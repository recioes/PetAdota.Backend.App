using Core.Entities;
using FluentValidation;

namespace Core.Validators
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(animal => animal.Name)
                .NotEmpty().WithMessage("The animal's name is required.")
                .MaximumLength(50).WithMessage("The animal's name must be at most 50 characters.");

            RuleFor(animal => animal.Type)
                .NotEmpty().WithMessage("The animal's type is required.")
                .MaximumLength(30).WithMessage("The animal's type must be at most 30 characters.");

            RuleFor(animal => animal.Age)
                .GreaterThanOrEqualTo(0).WithMessage("The animal's age must be a positive value.")
                .LessThanOrEqualTo(50).WithMessage("The animal's age must be 50 years or less.");

            RuleFor(animal => animal.Breed)
                .NotEmpty().WithMessage("The animal's breed is required.")
                .MaximumLength(30).WithMessage("The animal's breed must be at most 30 characters.");

            RuleFor(animal => animal.Status)
                .IsInEnum().WithMessage("The animal's status must be a valid value.");

            RuleFor(animal => animal.ImageUrl)
                .NotEmpty().WithMessage("The image URL is required.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute)).WithMessage("The image URL must be a valid URL.");

            RuleFor(animal => animal.Description)
                .MaximumLength(500).WithMessage("The animal's description must be at most 500 characters.")
                .NotEmpty().WithMessage("The animal's description is required.");
        }
    }

}
