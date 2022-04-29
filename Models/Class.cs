using System;
using System.Collections.Generic;

namespace PASVE.Models
{
    public partial class Class
    {
        public Class()
        {
            ProjectsClassesUsers = new HashSet<ProjectsClassesUser>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; } = null!;
        public int RowId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid FkTeacher { get; set; }
        public Guid FkClassroom { get; set; }
        public bool? Active { get; set; }

        public virtual Classroom FkClassroomNavigation { get; set; } = null!;
        public virtual User FkTeacherNavigation { get; set; } = null!;
        public virtual ICollection<ProjectsClassesUser> ProjectsClassesUsers { get; set; }
    }
}
