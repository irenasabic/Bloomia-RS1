using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bloomia.Application.Modules.Users.Commands.Update
{
    public class UpdateUserCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
        : IRequestHandler<UpdateUserCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken ct)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Id == request.Id, ct);

            if (user == null)
                throw new BloomiaNotFoundException($"Korisnik sa id-jem {request.Id} nije pronađen.");

            var currentUserId = currentUser.UserId;
            var isAdmin = currentUser.IsAdmin;

            //provjera: admin može update bilo koga, korisnik samo svoj profil
            if(!isAdmin && currentUserId != request.Id)
            {
                throw new BloomiaBusinessRuleException("USER_NOT_AUTH", "Samo admin ili vlasnik profila mogu update podatke.");
            }

            if(!string.IsNullOrWhiteSpace(request.Email) && request.Email != "string")
            {
                bool emailExists = await context.Users
                    .AnyAsync(u => u.Id != request.Id && u.Email == request.Email, ct);
                if (emailExists)
                    throw new BloomiaConflictException("Email već postoji.");
            }

            if (!string.IsNullOrWhiteSpace(request.Username) && request.Username != "string")
            {
                bool usernameExists = await context.Users
                    .AnyAsync(u => u.Id != request.Id && u.Username == request.Username, ct);
                if (usernameExists)
                    throw new BloomiaConflictException("Email već postoji.");
            }

            if (request.LanguageId.HasValue && request.LanguageId.Value > 0)
            {
                bool langExists = await context.Languages
                    .AnyAsync(l => l.Id == request.LanguageId.Value, ct);
                if (!langExists)
                    throw new BloomiaConflictException("Odabrani jezik ne postoji.");
                user.LanguageId = request.LanguageId.Value;
            }

            if (request.GenderId.HasValue && request.GenderId.Value > 0)
            {
                bool exists = await context.Genders.AnyAsync(g => g.Id == request.GenderId.Value, ct);
                if (!exists) throw new BloomiaConflictException("Odabrani pol ne postoji.");
                user.GenderId = request.GenderId.Value;
            }

            if (request.LocationId.HasValue && request.LocationId.Value > 0)
            {
                bool exists = await context.Locations.AnyAsync(l => l.Id == request.LocationId.Value, ct);
                if (!exists) throw new BloomiaConflictException("Odabrana lokacija ne postoji.");
                user.LocationId = request.LocationId.Value;
            }

            //update podataka koje mogu mijenjati admin i korisnik (klijent ili terapeut)
            if (!string.IsNullOrWhiteSpace(request.Firstname) && request.Firstname != "string")
                user.Firstname = request.Firstname.Trim();
            if (!string.IsNullOrWhiteSpace(request.Lastname) && request.Lastname != "string")
                user.Lastname = request.Lastname.Trim();
            if (!string.IsNullOrWhiteSpace(user.Firstname) && !string.IsNullOrWhiteSpace(user.Lastname))
                user.Fullname = $"{user.Firstname} {user.Lastname}";
            if (!string.IsNullOrWhiteSpace(request.Username) && request.Username != "string")
                user.Username = request.Username.Trim();
            if (!string.IsNullOrWhiteSpace(request.Email) && request.Email != "string")
                user.Email = request.Email.Trim();
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber) && request.PhoneNumber != "string")
                user.PhoneNumber = request.PhoneNumber;
            if (!string.IsNullOrWhiteSpace(request.ProfileImage) && request.ProfileImage != "string")
                user.ProfileImage = request.ProfileImage;

            //update podataka koje može mijenjati samo admin
            if(isAdmin)
            {
                if(request.RoleId.HasValue && request.RoleId.Value > 0)
                    user.RoleId = request.RoleId.Value;
                if(request.IsEnabled.HasValue)
                    user.IsEnabled = request.IsEnabled.Value;
            }

            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }
    }
}
