using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.List
{
    public class ListAvailableTimesByDateQuery:IRequest<ListAvailableTimesByDateQueryDto>
    {
        public DateOnly Date {  get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
    }
}
