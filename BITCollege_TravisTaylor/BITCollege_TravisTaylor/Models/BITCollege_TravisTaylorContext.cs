using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BITCollege_TravisTaylor.Models
{
    public class BITCollege_TravisTaylorContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BITCollege_TravisTaylorContext() : base("name=BITCollege_TravisTaylorContext")
        {
        }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.GPAState> GPAStates { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.SuspendedState> SuspendedStates{ get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.HonoursState> HonoursStates { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.RegularState> RegularStates { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.ProbationState> ProbationStates { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.Program> Programs { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.Registration> Registrations { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.MasteryCourse> MasteryCourses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.GradedCourse> GradedCourses { get; set; }
        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.AuditCourse> AuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.StudentCard> StudentCards { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.NextStudentNumber> NextStudentNumbers { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.NextRegistrationNumber> NextRegistrationNumbers { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.NextGradedCourse> NextGradedCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.NextAuditCourse> NextAuditCourses { get; set; }

        public System.Data.Entity.DbSet<BITCollege_TravisTaylor.Models.NextMasteryCourse> NextMasteryCourses { get; set; }
    }
}
