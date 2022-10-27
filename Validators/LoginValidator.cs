using FluentValidation;
using TimeManagementLib.Models;

namespace Time_Management_App.Validators
{
    public class LoginValidator : AbstractValidator<Student>
    {
        public LoginValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Please enter your student ID");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please enter your password");
        }
        ~LoginValidator()
        {
        }
    }
}
