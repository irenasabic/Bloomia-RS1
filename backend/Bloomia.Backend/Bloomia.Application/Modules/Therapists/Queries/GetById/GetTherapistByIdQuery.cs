using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Therapists.Queries.GetById
{
    public sealed class GetTherapistByIdQuery : IRequest<GetTherapistByIdQueryDto>
    {
        public int Id { get; set; }
    }
}
