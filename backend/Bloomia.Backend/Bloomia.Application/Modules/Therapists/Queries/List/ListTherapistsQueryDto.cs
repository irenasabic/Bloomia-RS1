using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Therapists.Queries.List
{
    public sealed class ListTherapistsQueryDto
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Specialization { get; set; }
        public float RatingAvg { get; set; }
        public string? ProfileImage { get; set; }
        public string? Gender { get; set; }
    }
}
