using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.ListAllTimesByDate
{
    public class ListTherapistTimesByDateQuery:IRequest<ListTherapistTimesByDateQueryDto>
    {
        public DateOnly Date { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}
