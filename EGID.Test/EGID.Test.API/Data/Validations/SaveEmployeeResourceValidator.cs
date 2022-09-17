using FluentValidation;
using EGID.Test.API.Data.Dtos;

namespace EGID.Test.API.Validations
{
    public class SaveEmployeeResourceValidator : AbstractValidator<SaveEmployeeResource>
    {
        public SaveEmployeeResourceValidator()
        {
            //RuleFor(m => m.Name)
            //    .NotEmpty()
            //    .MaximumLength(50);

            //RuleFor(m => m.DepartmentId)
            //    .NotEmpty()
            //    .WithMessage("'Department Id' must not be 0.");
        }
    }
}
