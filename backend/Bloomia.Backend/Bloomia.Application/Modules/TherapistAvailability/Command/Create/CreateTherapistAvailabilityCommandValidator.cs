using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Create
{
    public class CreateTherapistAvailabilityCommandValidator:AbstractValidator<CreateTherapistAvailabilityCommand>
    {
        public CreateTherapistAvailabilityCommandValidator() {

            RuleFor(x => x.AvailableDate).NotNull().WithMessage("Must enter the AvailableDate field!");
            RuleFor(x => x.StartTime).NotNull().WithMessage("Must enter the StartTime field!");

            RuleFor(x => x.AvailableDate).
                Must(d=>d>DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1))).
               WithMessage("Available date must be today or a future date!");

            RuleFor(x => x.StartTime)
                  .Must(t=>t>=new TimeOnly(0,0) && t<=new TimeOnly(23,59))
                  .WithMessage("Start time must be a valid time between 00:00 & 23:59");
            RuleFor(x => x.StartTime)
                .Must(t => t >= new TimeOnly(8, 0) && t <= new TimeOnly(20, 0))
                .WithMessage("Start time must be within business hours (08:00 - 17:00). ");

            RuleFor(x => x.StartTime)
                .Must((command, startTime) =>
                {
                    var combined = command.AvailableDate.ToDateTime(startTime);
                    var combinedUtcTime = combined.ToUniversalTime();
                    return combinedUtcTime > DateTime.UtcNow;
                })
                .WithMessage("The scheduled time must be greater than the current time");
        }
    }

}
