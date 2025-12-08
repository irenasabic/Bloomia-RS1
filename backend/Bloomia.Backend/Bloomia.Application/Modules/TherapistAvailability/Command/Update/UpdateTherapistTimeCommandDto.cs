using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Update
{
    public class UpdateTherapistTimeCommandDto
    {
        public int TherapistId { get; set; }
        public int TherapistAvailabilityId { get; set; }
        public DateOnly OldDate { get; set; }
        public DateOnly NewDate { get; set; }
        public TimeOnly OldTime { get; set; }
        public TimeOnly NewTime { get; set; }
    }
}
