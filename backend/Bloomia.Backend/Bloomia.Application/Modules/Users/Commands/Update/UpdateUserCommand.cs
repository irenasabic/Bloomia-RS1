using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? GenderId { get; set; }
        public int? LocationId { get; set; }
        public int? LanguageId { get; set; }
        public bool? IsEnabled { get; set; } //Admin može deaktivirati korisnika
        public int? RoleId { get; set; } //Admin može mijenjati rolu korisnika
        public string? ProfileImage { get; set; }
    }
}
