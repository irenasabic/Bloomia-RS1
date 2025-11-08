using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Application.Modules.Users.Commands.Delete
{
    public class DeleteUserCommandHandler(IAppDbContext context, IAppCurrentUser currentUser)
    : IRequestHandler<DeleteUserCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken ct)
        {
            if (currentUser.UserId is null)
                throw new BloomiaBusinessRuleException("USER_NOT_AUTH", "Korinsik nije autentifikovan.");

            //samo admin može obrisati korisnički račun 
            if (!currentUser.IsAdmin)
                throw new BloomiaBusinessRuleException("USER_NOT_AUTH", "Samo admin može obrisati korisnika.");


            var user = await context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == request.Id, ct);

            if (user is null)
                throw new BloomiaNotFoundException("Korisnik nije pronađen.");


            user.IsEnabled = false;

            await context.SaveChangesAsync(ct);

            return Unit.Value;
        }


    }
}
