using FluentValidation;
using System;
using TimeManagementLib.Models;

namespace Time_Management_App.Validators
{
    public class StudentModuleValidator : AbstractValidator<Module>
    {
        [Obsolete] // Used for the CascadeMode (Not sure whats the new method)
        public StudentModuleValidator()
        {
            // This is used to only display one error message if all the errors have occurred in a rule
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.StopOnFirstFailure;

            // Validation for the StudentModules class
            RuleFor(module => module.Code)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .Length(2, 10).WithMessage("{PropertyName} must be between 2 and 10 characters")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("{PropertyName} can't contain special characters");

            RuleFor(module => module.Name)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .Length(2, 30).WithMessage("{PropertyName} must be between 2 and 30 characters")
                .Matches(@"^[a-zA-Z0-9 ]+$").WithMessage("{PropertyName} can't contain special characters");

            RuleFor(module => module.Credits)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .LessThanOrEqualTo(25).WithMessage("{PropertyName} must be less than or equal to 25")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1");

            RuleFor(module => module.HoursPerWeek)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .LessThanOrEqualTo(100).WithMessage("{PropertyName} must be less than or equal to 100")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1");
        }
        ~StudentModuleValidator()
        {
        }

    }
}
