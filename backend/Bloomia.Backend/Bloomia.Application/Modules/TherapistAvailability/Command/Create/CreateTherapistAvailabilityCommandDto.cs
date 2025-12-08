using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Create
{
    public class CreateTherapistAvailabilityCommandDto
    {
        public string Note {  get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time {  get; set; }
    }
}
