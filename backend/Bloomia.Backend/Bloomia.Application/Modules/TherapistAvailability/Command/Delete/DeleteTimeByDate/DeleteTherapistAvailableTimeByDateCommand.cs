using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Command.Delete.DeleteTimeByDate
{
    public class DeleteTherapistAvailableTimeByDateCommand:IRequest<string>
    {
        public DateOnly Date {  get; set; }
        public TimeOnly TimeToDelete { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
