
using EGID.Test.API.Data.Dtos;
using FluentValidation;

namespace EGID.Test.API.Data.Validations
{
    public class SaveOrderResourceValidator : AbstractValidator<SaveOrderResource>
    {
        public SaveOrderResourceValidator()
        {
            //RuleFor(a => a.)
            //    .NotEmpty()
            //    .MaximumLength(50);           
        }
    }
}
