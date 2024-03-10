using Microsoft.EntityFrameworkCore;

namespace PetClinic.Model.Repository
{
    public class PetClinicDbContext: DbContext
    {
        public DbSet<Client> Client { get; set; }
 public PetClinicDbContext(DbContextOptions<PetClinicDbContext> options)
        : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasKey(entity => entity.Id);
                entity.Property(entity => entity.Name).HasMaxLength(100).IsRequired();
                entity.Property(entity => entity.BirthDate).IsRequired();
                entity.Property(entity => entity.StreetAddress).HasMaxLength(200).IsRequired();
                entity.Property(entity => entity.ZipCode).HasMaxLength(4).IsRequired();
                entity.Property(entity => entity.City).HasMaxLength(100).IsRequired();
                entity.Property(entity => entity.Sex).HasMaxLength(1).IsRequired();
                entity.Property(entity => entity.PhoneNumber).HasMaxLength(8).IsRequired();
                entity.Property(entity => entity.Email).HasMaxLength(100).IsRequired();
            });
        }
    }
}
