using FluentValidation;
using TimeManagementLib.Models;

namespace Time_Management_App.Validators
{
    public class SignUpValidator : AbstractValidator<Student>
    {
        [System.Obsolete]
        public SignUpValidator()
        {
            // This is used to only display one error message if all the errors have occurred in a rule
            ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.StopOnFirstFailure;

            // Validation for the StudentSignUp class

            RuleFor(student => student.StudentId)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .Length(2, 10).WithMessage("{PropertyName} must be between 2 and 10")
                .Matches("^ST[a-zA-Z0-9]+$").WithMessage("{PropertyName} can't contain special characters");

            RuleFor(student => student.Name)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .Length(2, 20).WithMessage("{PropertyName} must be between 2 and 20")
                .Matches("^[a-zA-Z]+$").WithMessage("{PropertyName} must only contain letters");

            RuleFor(student => student.Surname)
                .NotEmpty().WithMessage("Please enter your {PropertyName}")
                .Length(2, 20).WithMessage("{PropertyName} must be between 2 and 20")
                .Matches("^[a-zA-Z]+$").WithMessage("{PropertyName} must only contain letters");

            RuleFor(student => student.Password)
                .NotEmpty().WithMessage("Please enter a {PropertyName}")
                .Length(8, 20).WithMessage("{PropertyName} must be between 8 and 20")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*]).{8,20}$")
                .WithMessage("{PropertyName} must contain at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character");

            RuleFor(student => student.StartDate)
                .Must(StartDate => StartDate >= System.DateTime.Now).WithMessage("{PropertyName} must be in the future");

            RuleFor(student => student.NumberOfWeeks)
                .LessThanOrEqualTo(52).WithMessage("{PropertyName} must be less than or equal to 20")
                .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} must be greater than or equal to 1");
        }
        ~SignUpValidator()
        {
        }
    }
}
