using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class User
    {
        public User()
        {
            Careers = new HashSet<Career>();
            Classes = new HashSet<Class>();
            Evidences = new HashSet<Evidence>();
            EvidencesAuthors = new HashSet<EvidencesAuthor>();
            ProjectsClassesUsers = new HashSet<ProjectsClassesUser>();
            UsersCareers = new HashSet<UsersCareer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Photo { get; set; }
        public int Age { get; set; }
        public string? Telephone { get; set; }
        public string Email { get; set; } = null!;
        public string Document { get; set; } = null!;
        public Guid FkDocumentType { get; set; }
        public Guid FkGenderType { get; set; }
        public Guid FkUserType { get; set; }
        public bool? Active { get; set; }
        public int RowId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Password { get; set; } = null!;

        public virtual DocumentType FkDocumentTypeNavigation { get; set; } = null!;
        public virtual GenderType FkGenderTypeNavigation { get; set; } = null!;
        public virtual UserType UserType { get; set; } = null!;
        public virtual ICollection<Career> Careers { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Evidence> Evidences { get; set; }
        public virtual ICollection<EvidencesAuthor> EvidencesAuthors { get; set; }
        public virtual ICollection<ProjectsClassesUser> ProjectsClassesUsers { get; set; }
        public virtual ICollection<UsersCareer> UsersCareers { get; set; }
    }
}
