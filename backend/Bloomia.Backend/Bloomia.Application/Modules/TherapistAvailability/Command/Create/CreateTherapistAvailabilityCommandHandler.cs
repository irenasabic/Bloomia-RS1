using Bloomia.Domain.Entities.TherapistRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Create
{
    public class CreateTherapistAvailabilityCommandHandler(IAppDbContext context) : IRequestHandler<CreateTherapistAvailabilityCommand, CreateTherapistAvailabilityCommandDto>
    {
        public async Task<CreateTherapistAvailabilityCommandDto> Handle(CreateTherapistAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var therapist = await context.Therapists.Include(x => x.User).Where(x => x.UserId == request.UserId).FirstOrDefaultAsync(cancellationToken);
            if (therapist == null) {
                throw new BloomiaNotFoundException(message: "Therapist not found try to login!");
            }

             var therapistAvailability=await context.TherapistAvailabilities.Include(x=>x.Therapist)
                            .Where(x=>x.TherapistId==therapist.Id).ToListAsync(cancellationToken);

            var session = therapistAvailability.FirstOrDefault(x => x.Date == request.AvailableDate && x.StartTime == request.StartTime);

            if (session != null)
            {
                throw new BloomiaConflictException("The appointment has already been entered!");
            }
            var newAppointment = new TherapistAvailabilityEntity
            {
                TherapistId = therapist.Id,
                Therapist = therapist,
                Date = request.AvailableDate,
                StartTime = request.StartTime,
                IsBooked = false,
                CreatedAtUtc = DateTime.UtcNow
            };
           context.TherapistAvailabilities.Add(newAppointment);
           await context.SaveChangesAsync(cancellationToken);

            var dto = new CreateTherapistAvailabilityCommandDto
            {
                Note = "You have successfully added an appointment!",
                Date = newAppointment.Date,
                Time = newAppointment.StartTime
            };
            return dto;
        }
    }
}
