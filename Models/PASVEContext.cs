using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PASVE.Models
{
    public partial class PASVEContext : DbContext
    {
        public PASVEContext()
        {
        }

        public PASVEContext(DbContextOptions<PASVEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<BranchesDepartment> BranchesDepartments { get; set; } = null!;
        public virtual DbSet<Business> Businesses { get; set; } = null!;
        public virtual DbSet<Career> Careers { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Classroom> Classrooms { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<ErrorHistory> ErrorHistories { get; set; } = null!;
        public virtual DbSet<Evidence> Evidences { get; set; } = null!;
        public virtual DbSet<EvidencesAuthor> EvidencesAuthors { get; set; } = null!;
        public virtual DbSet<GenderType> GenderTypes { get; set; } = null!;
        public virtual DbSet<Installment> Installments { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectsClassesUser> ProjectsClassesUsers { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectsCareer> SubjectsCareers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } = null!;
        public virtual DbSet<UsersCareer> UsersCareers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=PASVE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branches", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkBusiness).HasColumnName("fk_Business");

                entity.Property(e => e.FkCity).HasColumnName("fk_City");

                entity.HasOne(d => d.FkBusinessNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.FkBusiness)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branches__fk_Bus__787EE5A0");

                entity.HasOne(d => d.FkCityNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.FkCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branches__fk_Cit__778AC167");
            });

            modelBuilder.Entity<BranchesDepartment>(entity =>
            {
                entity.HasKey(e => new { e.FkBranch, e.FkDepartment })
                    .HasName("PK__Branches__FB82A5A45F4D0E38");

                entity.ToTable("Branches_Departments", "University");

                entity.Property(e => e.FkBranch).HasColumnName("fk_Branch");

                entity.Property(e => e.FkDepartment).HasColumnName("fk_Department");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkBranchNavigation)
                    .WithMany(p => p.BranchesDepartments)
                    .HasForeignKey(d => d.FkBranch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branches___fk_Br__3A179ED3");

                entity.HasOne(d => d.FkDepartmentNavigation)
                    .WithMany(p => p.BranchesDepartments)
                    .HasForeignKey(d => d.FkDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Branches___fk_De__3B0BC30C");
            });

            modelBuilder.Entity<Business>(entity =>
            {
                entity.ToTable("Businesses", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Career>(entity =>
            {
                entity.ToTable("Careers", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkDepartmet).HasColumnName("fk_Departmet");

                entity.Property(e => e.FkDirector).HasColumnName("fk_Director");

                entity.HasOne(d => d.FkDepartmetNavigation)
                    .WithMany(p => p.Careers)
                    .HasForeignKey(d => d.FkDepartmet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Careers__fk_Depa__43A1090D");

                entity.HasOne(d => d.FkDirectorNavigation)
                    .WithMany(p => p.Careers)
                    .HasForeignKey(d => d.FkDirector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Careers__fk_Dire__42ACE4D4");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities", "Globalization");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkState).HasColumnName("fk_State");

                entity.HasOne(d => d.FkStateNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.FkState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cities__fk_State__6EF57B66");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Classes", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FkClassroom).HasColumnName("fk_Classroom");

                entity.Property(e => e.FkTeacher).HasColumnName("fk_Teacher");

                entity.Property(e => e.RowId).ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FkClassroomNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkClassroom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__fk_Clas__4C6B5938");

                entity.HasOne(d => d.FkTeacherNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.FkTeacher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classes__fk_Teac__4B7734FF");
            });

            modelBuilder.Entity<Classroom>(entity =>
            {
                entity.ToTable("Classrooms", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkBranch).HasColumnName("fk_Branch");

                entity.HasOne(d => d.FkBranchNavigation)
                    .WithMany(p => p.Classrooms)
                    .HasForeignKey(d => d.FkBranch)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Classroom__fk_Br__44CA3770");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries", "Globalization");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentTypes", "General");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Abbreviation).HasMaxLength(5);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ErrorHistory>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Error_Hi__A25C5AA6589D6641");

                entity.ToTable("Error_History", "Logs");

                entity.Property(e => e.ErrorProcedure).HasMaxLength(128);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Msgerror)
                    .HasMaxLength(4000)
                    .HasColumnName("MSGERROR");
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.ToTable("Evidences", "Evidence");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkInstallment).HasColumnName("fk_Installment");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Installment)
                    .WithMany(p => p.Evidences)
                    .HasForeignKey(d => d.FkInstallment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evidences__fk_In__1C873BEC");

                entity.HasOne(d => d.LoadForNavigation)
                    .WithMany(p => p.Evidences)
                    .HasForeignKey(d => d.LoadFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evidences__LoadF__1E6F845E");
            });

            modelBuilder.Entity<EvidencesAuthor>(entity =>
            {
                entity.HasKey(e => new { e.FkEvidence, e.FkAuthor })
                    .HasName("PK__Evidence__74C126015F01FFD7");

                entity.ToTable("Evidences_Authors", "Evidence");

                entity.Property(e => e.FkEvidence).HasColumnName("fk_Evidence");

                entity.Property(e => e.FkAuthor).HasColumnName("fk_Author");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkAuthorNavigation)
                    .WithMany(p => p.EvidencesAuthors)
                    .HasForeignKey(d => d.FkAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evidences__fk_Au__24285DB4");

                entity.HasOne(d => d.FkEvidenceNavigation)
                    .WithMany(p => p.EvidencesAuthors)
                    .HasForeignKey(d => d.FkEvidence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Evidences__fk_Ev__2334397B");
            });

            modelBuilder.Entity<GenderType>(entity =>
            {
                entity.ToTable("GenderTypes", "General");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Abbreviation).HasMaxLength(5);

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Installment>(entity =>
            {
                entity.ToTable("Installments", "Evidence");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FkProject).HasColumnName("fk_Project");

                entity.Property(e => e.Number).ValueGeneratedOnAdd();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Installments)
                    .HasForeignKey(d => d.FkProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Installme__fk_Pr__72910220");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects", "Evidence");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProjectsClassesUser>(entity =>
            {
                entity.HasKey(e => new { e.FkProject, e.FkClass, e.FkUser })
                    .HasName("PK__Projects__3EC758A43ECE6ED3");

                entity.ToTable("Projects_Classes_Users", "University");

                entity.Property(e => e.FkProject).HasColumnName("fk_Project");

                entity.Property(e => e.FkClass).HasColumnName("fk_Class");

                entity.Property(e => e.FkUser).HasColumnName("fk_User");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkClassNavigation)
                    .WithMany(p => p.ProjectsClassesUsers)
                    .HasForeignKey(d => d.FkClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projects___fk_Cl__55BFB948");

                entity.HasOne(d => d.FkProjectNavigation)
                    .WithMany(p => p.ProjectsClassesUsers)
                    .HasForeignKey(d => d.FkProject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projects___fk_Pr__54CB950F");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.ProjectsClassesUsers)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projects___fk_Us__56B3DD81");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("States", "Globalization");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FkCountry).HasColumnName("fk_Country");

                entity.HasOne(d => d.FkCountryNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.FkCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__States__fk_Count__6A30C649");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subjects", "University");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SubjectsCareer>(entity =>
            {
                entity.HasKey(e => new { e.FkSubject, e.FkCareer })
                    .HasName("PK__Subjects__8D77604158B752D6");

                entity.ToTable("Subjects_Careers", "University");

                entity.Property(e => e.FkSubject).HasColumnName("fk_Subject");

                entity.Property(e => e.FkCareer).HasColumnName("fk_Career");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkCareerNavigation)
                    .WithMany(p => p.SubjectsCareers)
                    .HasForeignKey(d => d.FkCareer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subjects___fk_Ca__4D2A7347");

                entity.HasOne(d => d.FkSubjectNavigation)
                    .WithMany(p => p.SubjectsCareers)
                    .HasForeignKey(d => d.FkSubject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subjects___fk_Su__4C364F0E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "Security");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FkDocumentType).HasColumnName("fk_DocumentType");

                entity.Property(e => e.FkGenderType).HasColumnName("fk_GenderType");

                entity.Property(e => e.FkUserType).HasColumnName("fk_UserType");

                entity.Property(e => e.RowId).ValueGeneratedOnAdd();

                entity.Property(e => e.Telephone).HasMaxLength(15);

                entity.Property(e => e.UpdateAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.FkDocumentTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkDocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__fk_Docume__208CD6FA");

                entity.HasOne(d => d.FkGenderTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkGenderType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__fk_Gender__2180FB33");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__fk_UserTy__22751F6C");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserTypes", "General");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<UsersCareer>(entity =>
            {
                entity.HasKey(e => new { e.FkUser, e.FkCareer })
                    .HasName("PK__Users_Ca__3AFD7979984DD0A4");

                entity.ToTable("Users_Careers", "University");

                entity.Property(e => e.FkUser).HasColumnName("fk_User");

                entity.Property(e => e.FkCareer).HasColumnName("fk_Career");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FkCareerNavigation)
                    .WithMany(p => p.UsersCareers)
                    .HasForeignKey(d => d.FkCareer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users_Car__fk_Ca__4865BE2A");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.UsersCareers)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users_Car__fk_Us__477199F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
