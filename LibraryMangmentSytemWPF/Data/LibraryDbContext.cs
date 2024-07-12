

using LibraryMangmentSytemWPF.Models.Concrets;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace LibraryMangmentSytemWPF.Data;
public class LibraryDbContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
                    .HasMany(e => e.Books)
                    .WithOne(e => e.Category)
                    .HasForeignKey(e => e.CategoryId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Author>()
                    .HasMany(e => e.Books)
                    .WithOne(e => e.Author)
                    .HasForeignKey(e => e.AuthorId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Theme>()
                    .HasMany(e => e.Books)
                    .WithOne(e => e.Theme)
                    .HasForeignKey(e => e.ThemeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<T_Card>()
                    .HasOne(e => e.Book)
                    .WithMany(e => e.T_Cards)
                    .HasForeignKey(e => e.BookId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<S_Card>()
                   .HasOne(e => e.Book)
                   .WithMany(e => e.S_Cards)
                   .HasForeignKey(e => e.BookId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Press>()
                    .HasMany(e => e.Books)
                    .WithOne(e => e.Press)
                    .HasForeignKey(e => e.PressId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Department>()
                    .HasMany(e => e.Teachers)
                    .WithOne(e => e.Department)
                    .HasForeignKey(e => e.DepartmentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Faculty>()
                    .HasMany(e => e.Groups)
                    .WithOne(e => e.Faculty)
                    .HasForeignKey(e => e.FacultyId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Group>()
                    .HasMany(e => e.Students)
                    .WithOne(e => e.Group)
                    .HasForeignKey(e => e.GroupId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Lib>()
                    .HasMany(e => e.S_Cards)
                    .WithOne(e => e.Lib)
                    .HasForeignKey(e => e.LibId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Lib>()
                    .HasMany(e => e.T_Cards)
                    .WithOne(e => e.Lib)
                    .HasForeignKey(e => e.LibId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Teacher>()
                    .HasMany(e => e.T_Card)
                    .WithOne(e => e.Teacher)
                    .HasForeignKey(e => e.TeacherId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<S_Card>()
                    .HasOne(e => e.Student)
                    .WithMany(e => e.S_Cards)
                    .HasForeignKey(e => e.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);




    }

    public DbSet<Category> Categories { get; set; }
	public DbSet<Author> Authors { get; set; }
	public DbSet<Book> Books { get; set; }
	public DbSet<Department> Departments { get; set; }
	public DbSet<Faculty> Faculties { get; set; }
	public DbSet<Group> Groups { get; set; }
	public DbSet<Lib> Libs { get; set; }
	public DbSet<Press> Press { get; set; }
	public DbSet<S_Card> S_Cards { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<T_Card> T_Cards { get; set; }
	public DbSet<Teacher> Teachers { get; set; }	
	public DbSet<Theme> Themes { get; set; }

}

