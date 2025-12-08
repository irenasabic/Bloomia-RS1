using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Therapists.Commands.Update
{
    public class UpdateTherapistCommandValidator : AbstractValidator<UpdateTherapistCommand>
    {
        public UpdateTherapistCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                 .EmailAddress().WithMessage("Email invalid format")
                                 .Matches(@"@(gmail\.com|yahoo\.com|edu\.)$")
                                 .WithMessage("Email domain must me @gmail, @yahoo or @edu ");

        }
    }
}
