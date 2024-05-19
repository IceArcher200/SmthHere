using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Library.MyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Library
{
    public class ApplicationContext : DbContext
    {
        // /*
        public DbSet<Client> Client => Set<Client>();
        public DbSet<Street> Street => Set<Street>();
        public DbSet<EducationLevel> EducationLevel => Set<EducationLevel>();
        public DbSet<Employer> Employer => Set<Employer>();
        public DbSet<MenuInfo> MenuInfo => Set<MenuInfo>();
        public DbSet<VacancyType> VacancyType => Set<VacancyType>();
        public DbSet<Specialty> Specialty => Set<Specialty>();
        public DbSet<Vacancy> Vacancy => Set<Vacancy>();
        public DbSet<Worker> Worker => Set<Worker>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserInfo> UserInfo => Set<UserInfo>("UserInfo");
        public DbSet<Archival_Vacancy> Archival_Vacancy => Set<Archival_Vacancy>();
        public ApplicationContext()
        {
            //Database.EnsureCreated();
        }
        // */

        ////////////////////////////////////////////////////////
        /*
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Composition> Compositions => Set<Composition>();
        public DbSet<Exampler> Examplers => Set<Exampler>();
        public DbSet<PlaceOfPublication> PlacesOfPublications => Set<PlaceOfPublication>();
        public DbSet<CompositionsAndPublishers> CompositionsAndPublishers => Set<CompositionsAndPublishers>("CompositionsAndPublishers");
        public DbSet<GivenExamplers> GivenExamplers => Set<GivenExamplers>("GivenExamplers");
        public DbSet<InterlibrarySubscription> InterlibrarySubscriptions => Set<InterlibrarySubscription>();
        public DbSet<PublishingHouse> PublishingHouses => Set<PublishingHouse>();
        public DbSet<ReadersAndPenaltys> ReadersAndPenaltys => Set<ReadersAndPenaltys>("ReadersAndPenaltys");
        public DbSet<AuthorsAndCompositions> AuthorsAndCompositions => Set<AuthorsAndCompositions>("AuthorAndComposition");
        public DbSet<Storage> Storages => Set<Storage>();

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Professor> Professors => Set<Professor>();
        public DbSet<Student> Students => Set<Student>();

        //public DbSet<Category> Categories => Set<Category>();
        public DbSet<MenuInfo> MenuInfo => Set<MenuInfo>();
        public DbSet<Penalty> Penalties => Set<Penalty>();
        public DbSet<TypeOfComposition> TypesOfComposition => Set<TypeOfComposition>();

        public DbSet<Degree> Degrees => Set<Degree>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Rank> Ranks => Set<Rank>();

        public DbSet<User> Users => Set<User>();
        public DbSet<UserInfo> UserInfo => Set<UserInfo>("UserInfo");
        public ApplicationContext()
        {
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "Library.db"));

            optionsBuilder.UseSqlite("Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "MyDB.db"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<Reader>(ReaderConfigure);
            modelBuilder.Entity<Exampler>(ExamplerConfigure);
            modelBuilder.Entity<Composition>(CompositionConfigure);
            modelBuilder.Entity<PlaceOfPublication>(PlaceOfPublicationConfigure); */
            modelBuilder.Entity<User>(UserConfigure);
        }
        /* 
        public void ArchiveConfigure(EntityTypeBuilder<Archival_Vacancy> builder)
        {
            //builder.HasOne(s => s.Street);

            builder.HasOne()

        }
        */
        /*
        public void ReaderConfigure(EntityTypeBuilder<Reader> builder)
        {
            //builder.HasOne(c => c.Category).WithMany(r => r.Readers).HasForeignKey(c => c.CategoryId);




            builder.HasMany(c=>c.InterlibrarySubscriptions).WithOne(r=>r.Reader).HasForeignKey(c=>c.ReaderId);


            builder.HasMany(e => e.Examplers)
                    .WithMany(e => e.Readers)
                    .UsingEntity<GivenExamplers>(
                        "GivenExamplers",
                        l => l.HasOne<Exampler>(e => e.Exampler).WithMany(e => e.GivenExamplers).HasForeignKey(e => e.ExamplerId).HasPrincipalKey(e => e.Id),
                        r => r.HasOne<Reader>(e => e.Reader).WithMany(e => e.GivenExamplers).HasForeignKey(e => e.ReaderId).HasPrincipalKey(e => e.Id),
                        j => j.HasKey(e => e.Id));



            builder.HasMany(e => e.Penaltys)
                    .WithMany(e => e.Readers)
                    .UsingEntity<ReadersAndPenaltys>(
                        "ReadersAndPenaltys",
                        l => l.HasOne<Penalty>(e => e.Penalty).WithMany(e => e.ReadersAndPenaltys).HasForeignKey(e => e.PenaltyId).HasPrincipalKey(e => e.Id),
                        r => r.HasOne<Reader>(e => e.Reader).WithMany(e => e.ReadersAndPenaltys).HasForeignKey(e => e.ReaderId).HasPrincipalKey(e => e.Id),
                        j => j.HasKey(e => e.Id));
        }
        public void ExamplerConfigure(EntityTypeBuilder<Exampler> builder)  
        {
            builder.HasOne(s => s.Composition).WithMany(e => e.Examplers).HasForeignKey(s => s.CompositionId);
            builder.HasOne(s => s.Storage).WithMany(e => e.Examplers).HasForeignKey(s => s.StorageId);

        }
        public void CompositionConfigure(EntityTypeBuilder<Composition> builder)
        {
            builder.HasOne(t => t.Type).WithMany(c => c.Compositions).HasForeignKey(t => t.TypeId);
            builder.HasMany(e => e.Authors)
                    .WithMany(e => e.Compositions)
                    .UsingEntity<AuthorsAndCompositions>(
                        "AuthorAndComposition",
                        l => l.HasOne<Author>(e => e.Author).WithMany(e => e.AuthorsAndCompositions).HasForeignKey(e => e.AuthorId).HasPrincipalKey(e => e.Id),
                        r => r.HasOne<Composition>(e => e.Composition).WithMany(e => e.AuthorsAndCompositions).HasForeignKey(e => e.CompositionId).HasPrincipalKey(e => e.Id),
                        j => j.HasKey(e => e.Id));
            builder.HasMany(e => e.PlaceOfPublications)
                    .WithMany(e => e.Compositions)
                    .UsingEntity<CompositionsAndPublishers>(
                        "CompositionsAndPublishers",
                        l => l.HasOne<PlaceOfPublication>(e => e.PlaceOfPublication).WithMany(e => e.CompositionsAndPublishers).HasForeignKey(e => e.PlaceOfPublicationId).HasPrincipalKey(e => e.Id),
                        r => r.HasOne<Composition>(e => e.Composition).WithMany(e => e.CompositionsAndPublishers).HasForeignKey(e => e.CompostionId).HasPrincipalKey(e => e.Id),
                        j => j.HasKey(e => e.Id));
        }
        public void PlaceOfPublicationConfigure(EntityTypeBuilder<PlaceOfPublication> builder)
        {
            builder.HasOne(s => s.PublishingHouse).WithMany(e => e.PlaceOfPublications).HasForeignKey(s => s.PublishingHouseId);
        }
        */
        public void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.MenuInfos)
                    .WithMany(e => e.Users)
                    .UsingEntity<UserInfo>(
                        "UserInfo",
                        l => l.HasOne<MenuInfo>(e => e.MenuInfo).WithMany(e => e.UserInfos).HasForeignKey(e => e.MenuInfoId).HasPrincipalKey(e => e.Id),
                        r => r.HasOne<User>(e => e.User).WithMany(e => e.UserInfos).HasForeignKey(e => e.UserId).HasPrincipalKey(e => e.Id),
                        j => j.HasKey(e => new { e.MenuInfoId, e.UserId }));
        }

    }
}