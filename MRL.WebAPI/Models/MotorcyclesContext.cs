using Microsoft.EntityFrameworkCore;

namespace MRL.WebAPI.Models;

public partial class MotorcyclesContext : DbContext
{
    public MotorcyclesContext()
    {
    }

    public MotorcyclesContext(DbContextOptions<MotorcyclesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Motorcycle> Motorcycles { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:MotorcycleReviewListDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC075A9E1F5D");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0730E7EDCE");
        });

        modelBuilder.Entity<Motorcycle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motorcyc__3214EC074752A39D");

            entity.HasOne(d => d.Brand).WithMany(p => p.Motorcycles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Motorcycl__Power__5441852A");

            entity.HasOne(d => d.Category).WithMany(p => p.Motorcycles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Motorcycl__Categ__5535A963");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC07ACFF987F");

            entity.Property(e => e.OverallScore).HasComputedColumnSql("(((((([HandlingScore]+[SpeedScore])+[ComfortScore])+[BrakesScore])+[StabilityScore])+[ValueScore])/(6.0))", true);
            entity.Property(e => e.ReviewDate).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Motorcycle).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Motorcy__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserId__5BE2A6F2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07693C329B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
