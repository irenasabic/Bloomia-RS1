using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Users.Queries.GetById
{
    public class GetUserByIdQueryDto
    {
        public required int Id { get; init; }
        public required string Firstname { get; init; }
        public required string Lastname { get; init; }
        public string? Username { get; init; }
        public string? Fullname { get; init; }
        public required string Email { get; init; }
        public required string Role { get; init; }
        public required bool IsEnabled { get; init; }
    }
}
