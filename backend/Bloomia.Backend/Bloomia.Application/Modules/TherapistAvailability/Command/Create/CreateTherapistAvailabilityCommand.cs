using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Create
{
    public class CreateTherapistAvailabilityCommand:IRequest<CreateTherapistAvailabilityCommandDto>
    {
        public DateOnly AvailableDate {  get; init; }
        public TimeOnly StartTime { get; init; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}
