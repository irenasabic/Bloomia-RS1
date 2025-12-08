using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Update
{
    public class UpdateTherapistTimeCommandValidator:AbstractValidator<UpdateTherapistTimeCommand>
    {
        public UpdateTherapistTimeCommandValidator() {
            RuleFor(x => x.TherapistAvailabilityId).NotEmpty().WithMessage("TherapistAvailabilityId is requied field!");
            RuleFor(x => x.NewDate).NotEmpty().WithMessage("New date is requied field!");
            RuleFor(x => x.NewTime).NotEmpty().WithMessage("new time is requied field!");
            RuleFor(x => x.NewDate)
                .Must(x => x > DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)))
                .WithMessage("New date must be today or a future date!");
            RuleFor(x => x.NewTime)
                .Must(t => t >= new TimeOnly(8, 0) && t <= new TimeOnly(20, 0))
                .WithMessage("Start time must be within business hours (08:00 - 20:00). ");

            RuleFor(x=>x.NewTime)
                .Must((command, time) =>
                {
                    var combined = command.NewDate.ToDateTime(time);
                    var combinedUtc=combined.ToUniversalTime();
                    return combinedUtc > DateTime.UtcNow;
                }).WithMessage("The new scheduled time must be greater than the current time");
        }
    }
}
