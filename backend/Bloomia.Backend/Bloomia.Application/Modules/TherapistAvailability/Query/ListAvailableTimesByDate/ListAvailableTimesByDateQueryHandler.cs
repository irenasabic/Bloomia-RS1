using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.List
{
    public class ListAvailableTimesByDateQueryHandler(IAppDbContext context) : IRequestHandler<ListAvailableTimesByDateQuery, ListAvailableTimesByDateQueryDto>
    {
        public async Task<ListAvailableTimesByDateQueryDto> Handle(ListAvailableTimesByDateQuery request, CancellationToken cancellationToken)
        {
            var therapist = await context.Therapists.Include(x => x.User).Where(x => x.UserId == request.UserId).FirstOrDefaultAsync(cancellationToken);
            if (therapist == null)
            {
                throw new BloomiaNotFoundException(message: "Therapist not found try to login first!");
            }
         
            var AllAvailableTimes = await context.TherapistAvailabilities
                    .Where(x => x.TherapistId == therapist.Id && x.Date == request.Date && 
                            !x.IsDeleted && !x.IsBooked).ToListAsync(cancellationToken);
            var dto = new ListAvailableTimesByDateQueryDto
            {
                RequestedDate = request.Date
            };
            foreach(var i in AllAvailableTimes)
            {
                var time = i.StartTime;
                dto.Times.Add(time);
            }
            return dto;
        }
    }
}
