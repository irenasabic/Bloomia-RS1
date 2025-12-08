using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Update
{
    public class UpdateTherapistTimeCommand:IRequest<UpdateTherapistTimeCommandDto>
    {
        public int TherapistAvailabilityId { get; init; }
        public DateOnly NewDate {  get; init; }
        public TimeOnly NewTime { get; init; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
