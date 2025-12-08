using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Therapists.Commands.Update.ChangeTherapistPassword
{
    public class ChangeTherapistPasswordCommandValidator : AbstractValidator<ChangeTherapistPasswordCommand>
    {
        public ChangeTherapistPasswordCommandValidator()
        {
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number");

        }
    }
}
