using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.TherapistAvailability.Query.List
{
    public class ListAvailableTimesByDateQueryDto
    {
        public DateOnly RequestedDate {  get; set; }
        public List<TimeOnly> Times { get; set; }=new List<TimeOnly>();

    }
}
