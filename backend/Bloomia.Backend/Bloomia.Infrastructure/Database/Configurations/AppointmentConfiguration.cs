using Bloomia.Domain.Entities.Payments;
using Bloomia.Domain.Entities.ReviewsFolder;
using Bloomia.Domain.Entities.Sessions;
using Bloomia.Domain.Entities.TherapistRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloomia.Infrastructure.Database.Configurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<AppointmentEntity>
    {
        public void Configure(EntityTypeBuilder<AppointmentEntity> builder)
        {
            builder.ToTable("Appointments");

            builder.HasKey(x=>x.Id);

            builder.HasOne(x => x.Client)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ChatSessions)
              .WithOne(x => x.Appointment)
              .HasForeignKey(x => x.AppointmentId)
              .OnDelete(DeleteBehavior.NoAction);

            // Added a unique index with the IsDeleted=0 filter so a released time slot can be reused after cancellation.
            builder.HasIndex(x => x.TherapistAvailabilityId)
                    .IsUnique()
                    .HasFilter("[IsDeleted]=0");


            builder.HasOne(x => x.TherapistAvailability)
                .WithOne(x => x.Appointment)
                .HasForeignKey<AppointmentEntity>(x => x.TherapistAvailabilityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
