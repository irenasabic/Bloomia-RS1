using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Users.Queries.List
{
    public class ListUsersQueryDto
    {
        public required int Id { get; init; }
        public required string Firstname { get; init; }
        public required string Lastname { get; init; }
        public string? Fullname { get; init; }
        public string? Email { get; init; }
        public string? Username { get; init; }
        public string? Role { get; init; }
        public bool IsEnabled { get; init; }
    }
}
