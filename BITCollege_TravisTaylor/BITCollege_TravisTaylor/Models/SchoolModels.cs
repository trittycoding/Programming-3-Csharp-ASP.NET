using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace BITCollege_TravisTaylor.Models
{
    /// <summary>
    /// Class that represents a student's GPA state.
    /// </summary>
    public abstract class GPAState
    {
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();
        /// <summary>
        /// Modifies or returns GPA state ID, i.e. the key attributed to each gpa state.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int GPAStateId { get; set; }

        /// <summary>
        /// Modifies or returns the lowest limit possible for GPA.
        /// </summary>
        [Required]
        [Display(Name ="Lower\nLimit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double LowerLimit { get; set; }

        /// <summary>
        /// Modifies or returns the highest possible limit for GPA.
        /// </summary>
        [Required]
        [Display(Name ="Upper\nLimit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double UpperLimit { get; set; }

        /// <summary>
        /// Modifies or returns tuition rate factor that is applied in the tuition rate adjustment calculation.
        /// </summary>
        [Required]
        [Display(Name ="Tuition\nRate\nFactor")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double TuitionRateFactor { get; set; }

        /// <summary>
        /// Returns a description of the student's current GPA state.
        /// </summary>
        [Display(Name ="Description")]
        public string Description
        {
            get
            {
                string stateNameFull = this.GetType().Name;
                string stateName = stateNameFull.Substring(0, stateNameFull.IndexOf("State"));
                return stateName;
            }
        }

        /// <summary>
        /// The calculation performed to determine the tuition rate adjustment for a given student. The better a student's GPA, the less the student
        /// would have to pay for tuition.
        /// </summary>
        /// <param name="student">Requires a student object to determine that student object's tuition rate adjustment.</param>
        /// <returns>Returns a double representing the tuition rate adjustment for that given student object.</returns>
        public virtual double tuitionRateAdjustment(Student student)
        {
            return 0;
        }

        /// <summary>
        /// Performs a check to see if a given student object's state has changed.
        /// </summary>
        /// <param name="student"></param>
        public virtual void stateChangeCheck(Student student)
        {

        }

        /// <summary>
        /// Navigational property from GPAState to student. A GPA state can have 0 to many students. 
        /// </summary>
        public virtual ICollection<Student> student { get; set; }
    }

    /// <summary>
    /// A class representing a student.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Modifies or returns a given student's student ID.C:\Users\Administrator\source\repos\BITCollege_TravisTaylor\BITCollege_TravisTaylor\BITCollege_TravisTaylor\Migrations\
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        /// <summary>
        /// Modifies or returns a given student's GPA state.
        /// </summary>
        [Required]
        [ForeignKey("gPAState")]
        public int GPAStateId { get; set; }

        /// <summary>
        /// Modifies or returns a given student's program of study.
        /// </summary>
        [ForeignKey("program")]
        public int? ProgramId { get; set; }

        /// <summary>
        /// Modifies or returns a given student's student number.
        /// </summary>
        [Display(Name = "Student\nNumber")]
        public long StudentNumber { get; set; }

        /// <summary>
        /// Modifies or returns a student's first name. 
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength =1, ErrorMessage ="First name must be between 1-35 characters")]
        [Display(Name ="First\nName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Modifies or returns a student's last name. 
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Last name must be between 1-35 characters")]
        [Display(Name ="Last\nName")]
        public string LastName { get; set; }

        /// <summary>
        /// Modifies or returns a student's current street address.
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Address must be between 1-35 characters")]
        [Display(Name ="Address")]
        public string Address { get; set; }

        /// <summary>
        /// Modifies or returns a student's current city.
        /// </summary>
        [Required]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "City must be between 1-35 characters")]
        [Display(Name ="City")]
        public string City { get; set; }

        /// <summary>
        /// Modifies or returns a student's current province.
        /// </summary>
        [Required]
        [StringLength(2)]
        [Display(Name ="Province")]
        [RegularExpression("^(?:AB|BC|MB|N[BLTSU]|ON|PE|QC|SK|YT)*$", ErrorMessage ="Please enter a valid canadian province.")]
        public string Province { get; set; }

        /// <summary>
        /// Modifies or returns a student's current postal code.
        /// </summary>
        [Required]
        [Display(Name ="Postal\nCode")]
        [RegularExpression("[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] [0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]", ErrorMessage ="Please enter a valid postal code.")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Modifies or returns the date in which the student record was created.
        /// </summary>
        [Required]
        [Display(Name ="Date\nCreated")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Modifies or returns a student's GPA.
        /// </summary>
        [Display(Name ="Grade\nPoint\nAverage")]
        [DisplayFormat(DataFormatString ="{0:#.##}")]
        public double? GradePointAverage { get; set; }

        /// <summary>
        /// Modifies or returns a student's outstanding fees.
        /// </summary>
        [Display(Name ="Outstanding\nFees")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public double OutstandingFees { get; set; }

        /// <summary>
        /// Modifies or returns notes for a given student.
        /// </summary>
        [Display(Name ="Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Returns the student's full name.
        /// </summary>
        [Display(Name ="Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        /// <summary>
        /// Returns a student's full address.
        /// </summary>
        [Display(Name ="Address")]
        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1} {2},{3}", Address, City, Province, PostalCode);
            }
        }

        /// <summary>
        /// Sets the next student number to the value returned by the stored procedure "next_number".
        /// </summary>
        public void setNextStudentNumber()
        {
            try
            {
                this.StudentNumber = (long)StoredProcedures.nextNumber("Students");
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Changes the state of a student object.
        /// </summary>
        public void changeState()
        {
            BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();
            //Retrieving the GPAstate object from table where == our GPA state.
            GPAState query = (from results
                                          in db.GPAStates
                                          where results.GPAStateId == this.GPAStateId
                                          select results).SingleOrDefault();
            GPAState retrievedState = query;
            int comparedState = 0;

            do
            {
                //New represents the new state, such as Probation State.
                //That version of stateChangeCheck is called and passed the student object.
                //The student object is evaluated against the limits of the current state. 
                retrievedState.stateChangeCheck(this);

                //oldGPAId = a placeholder for the old value.
                comparedState = retrievedState.GPAStateId;
                

                //new is queryed again to evaluate the new current limits.
                retrievedState = (from results
                                          in db.GPAStates
                         where results.GPAStateId == this.GPAStateId
                         select results).SingleOrDefault();
                   
            }
            while (retrievedState.GPAStateId != comparedState);
            retrievedState.tuitionRateAdjustment(this);

        }

        /// <summary>
        /// Navigational property from student to program. A student can be in only one program.
        /// </summary>
        public virtual Program program { get; set; }

        /// <summary>
        /// Navigational property from student to GPA state. A student can only be in one GPA state.
        /// </summary>
        public virtual GPAState gPAState { get; set; }

        /// <summary>
        /// Navigational property from student to registration. A student can have zero to many registrations.
        /// </summary>
        public virtual ICollection<Registration> registration { get; set; }

        /// <summary>
        /// Navigational property from student to student card. A student can have zero to many student cards.
        /// </summary>
        public virtual ICollection<StudentCard> studentCard { get; set; }
    }

    /// <summary>
    /// A class representing a school program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Modifies or returns a program's unique ID.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

        /// <summary>
        /// Modifies or returns a program's 
        /// </summary>
        [Required]
        [Display(Name ="Program")]
        public string ProgramAcronym { get; set; }

        /// <summary>
        /// Modifies or returns a program's description.
        /// </summary>
        [Required]
        [Display(Name ="Program\nName")]
        public string Description { get; set; }

        /// <summary>
        /// Navigational property from program to student. A program can have zero to many students.
        /// </summary>
        public virtual ICollection<Student> student { get; set; }

        /// <summary>
        /// Navigational property from program to course. A program can have zero to many courses.
        /// </summary>
        public virtual ICollection<Course> course { get; set; }
    }

    /// <summary>
    /// Class representing student registration operations.
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// Default constructor for the Registration class.
        /// </summary>
        public Registration()
        {

        }

        /// <summary>
        /// Modifies or returns registration id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        /// <summary>
        /// Modifies or returns a student's registration number.
        /// </summary>
        [Display(Name ="Registration\nNumber")]
        public long RegistrationNumber { get; set; }

        /// <summary>
        /// Modifies or returns a student's ID.
        /// </summary>
        [Required]
        [ForeignKey("student")]
        public int StudentId { get; set; }

        /// <summary>
        /// Modifies or returns a course's ID.
        /// </summary>
        [Required]
        [ForeignKey("course")]
        public int CourseId { get; set; }

        /// <summary>
        /// Modifies or returns a student's registration date.
        /// </summary>
        [Required]
        [Display(Name ="Registration\nDate")]
        [DisplayFormat(DataFormatString ="{0:d}")]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Modifies or returns a student's grade.
        /// </summary>
        [Display(Name ="Grade")]
        [Range(0, 100, ErrorMessage ="Please enter a valid grade value.")]
        [DisplayFormat(NullDisplayText ="Ungraded")]
        public double? Grade { get; set; }

        /// <summary>
        /// Modifies or returns registration notes for a given student.
        /// </summary>
        [Display(Name ="Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Sets the next registration number to the value returned by the stored procedure method "next_number".
        /// </summary>
        public void setNextRegistrationNumber()
        {
            try
            {
                this.RegistrationNumber = (long)StoredProcedures.nextNumber("Registrations");
            }

            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Navigational property from registration to student. A registration can have only one student. 
        /// </summary>
        public virtual Student student { get; set; }

        /// <summary>
        /// Navigational property from registration to course. A registration can only have one course.
        /// </summary>
        public virtual Course course { get; set; }
    }

    /// <summary>
    /// Class representing a course.
    /// </summary>
    public abstract class Course
    {
        /// <summary>
        /// Modifies or returns a course's course ID.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int? CourseId { get; set; }

        /// <summary>
        /// Modifies or returns a course's program ID.
        /// </summary>
        [ForeignKey("program")]
        public int? ProgramId { get; set; }

        /// <summary>
        /// Modifies or returns a course's course number.
        /// </summary>
        [Display(Name ="Course\nNumber")]
        public string CourseNumber { get; set; }

        /// <summary>
        /// Modifies or returns a course's title.
        /// </summary>
        [Required]
        [Display(Name ="Title")]
        public string Title { get; set; }

        /// <summary>
        /// Modifies or returns a course's credit hours.
        /// </summary>
        [Required]
        [Display(Name ="Credit\nHours")]
        [DisplayFormat(DataFormatString ="{0:#}")]
        public double CreditHours { get; set; }

        /// <summary>
        /// Modifies or returns a course's tuition cost.
        /// </summary>
        [Required]
        [Display(Name ="Tuition\nAmount")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public double TuitionAmount { get; set; }

        /// <summary>
        /// Returns a course's type.
        /// </summary>
        [Display(Name ="Course\nType")]
        public string CourseType
        {
            get
            {
                string courseTypeFull = this.GetType().Name;
                int course = courseTypeFull.IndexOf("Course");
                string courseType = courseTypeFull.Substring(0, course);
                return courseType;
            }
        }

        /// <summary>
        /// Modifies or returns notes on a course.
        /// </summary>
        [Display(Name ="Notes")]
        public string Notes { get; set; }

        /// <summary>
        /// Sets the next available course number.
        /// </summary>
        public abstract void setNextCourseNumber();

        /// <summary>
        /// Navigational property from course to program. A course can have zero to one program.
        /// </summary>
        public virtual Program program { get; set; }

        /// <summary>
        /// Navigational property from course to registration. A course can have zero to many registrations. 
        /// </summary>
        public virtual ICollection<Registration> registration { get; set; }
    }

    /// <summary>
    /// Class representing a graded course.
    /// </summary>
    public class GradedCourse : Course
    {
        /// <summary>
        /// Modifies or returns a course's assignment weight.
        /// </summary>
        [Required]
        [Display(Name ="Assignment\nWeight")]
        [DisplayFormat(DataFormatString ="{0:P2}")]
        public double AssignmentWeight { get; set; }

        /// <summary>
        /// Modifies or returns a course's midterm exam weight.
        /// </summary>
        [Required]
        [Display(Name =("Midterm\nWeight"))]
        [DisplayFormat(DataFormatString ="{0:P2}")]
        public double MidtermWeight { get; set; }

        /// <summary>
        /// Modifies or returns a course's final exam weight.
        /// </summary>
        [Required]
        [Display(Name ="Final\nWeight")]
        [DisplayFormat(DataFormatString ="{0:P2}")]
        public double FinalWeight { get; set; }

        /// <summary>
        /// Sets the next available course number.
        /// </summary>
        public override void setNextCourseNumber()
        {
            try
            {
                long nextNumber = (long)StoredProcedures.nextNumber("NextGradedCourses");
                string gradedCoursePrefix = "G-";
                this.CourseNumber = gradedCoursePrefix + nextNumber.ToString();
            }

            catch(Exception e)
            {
                throw e;
            }
        }
    }

    /// <summary>
    /// Class representing an audit course.
    /// </summary>
    public class AuditCourse : Course
    {
        /// <summary>
        /// Sets the next available course number.
        /// </summary>
        public override void setNextCourseNumber()
        {
            try
            {
                long nextNumber = (long)StoredProcedures.nextNumber("NextAuditCourses");
                string auditCoursePrefix = "A-";
                this.CourseNumber = auditCoursePrefix + nextNumber.ToString();
            }

            catch(Exception e)
            {
                throw e;
            }
        }
    }

    /// <summary>
    /// Class representing a mastery course.
    /// </summary>
    public class MasteryCourse : Course
    {
        /// <summary>
        /// Modifies or returns the maximum attempts a student can take the course.
        /// </summary>
        [Required]
        [Display(Name ="Maximum\nAttempts")]
        [DisplayFormat(DataFormatString ="{0:#}")]
        public int MaximumAttempts { get; set; }

        /// <summary>
        /// Sets the next available course number.
        /// </summary>
        public override void setNextCourseNumber()
        {
            try
            {
                long nextNumber = (long)StoredProcedures.nextNumber("NextMasteryCourses");
                string masteryCoursePrefix = "M-";
                this.CourseNumber = masteryCoursePrefix + nextNumber.ToString();
            }

            catch(Exception e)
            {
                throw e;
            }
        }
    }

    /// <summary>
    /// Class representing a suspended GPA state.
    /// </summary>
    public class SuspendedState : GPAState
    {
        private static SuspendedState suspendedState;

        /// <summary>
        /// Constructs an instance of the SuspendState class.
        /// </summary>
        private SuspendedState()
        {
            this.LowerLimit = 0.00;
            this.UpperLimit = 1.00;
            this.TuitionRateFactor = 1.1;
        }

        /// <summary>
        /// Returns an instance of a SuspendState object.
        /// </summary>
        /// <returns>Instance of SuspendState.</returns>
        public static SuspendedState getInstance()
        {
            if(suspendedState == null)
            {
                suspendedState = db.SuspendedStates.SingleOrDefault();
                if(suspendedState == null)
                {
                    suspendedState = new SuspendedState();
                    db.SuspendedStates.Add(suspendedState);
                    db.SaveChanges();
                }
            }
            return suspendedState;
        }

        /// <summary>
        /// Calcuates the adjusted tuition rate for a given student based on GPA.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>The adjusted tuition rate for a given student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            double suspendedTuitionRate = 1.1;
            if(student.GradePointAverage < 0.75 && student.GradePointAverage > 0.5)
            {
                suspendedTuitionRate = 1.12;
            }
            if(student.GradePointAverage < 0.5)
            {
                suspendedTuitionRate = 1.15;
            }

            return suspendedTuitionRate;
        }

        /// <summary>
        /// Checks to see if a student's state has changed.
        /// </summary>
        /// <param name="student"></param>
        public override void stateChangeCheck(Student student)
        {
            if(student.GradePointAverage >= UpperLimit)
            {
                student.GPAStateId = ProbationState.getInstance().GPAStateId;
                db.SaveChanges();
            }
        }

    }

    /// <summary>
    /// Class representing a probation GPA state.
    /// </summary>
    public class ProbationState : GPAState
    {
        private static ProbationState probationState;

        /// <summary>
        /// Constructs an instance of the ProbationState class.
        /// </summary>
        private ProbationState()
        {
            this.LowerLimit = 1.00;
            this.UpperLimit = 2.00;
            this.TuitionRateFactor = 1.075;
        }

        /// <summary>
        /// Retrieves an instance of the ProbationState Class.
        /// </summary>
        /// <returns>Instance of ProbationState.</returns>
        public static ProbationState getInstance()
        {
            if(probationState == null)
            {
                probationState = db.ProbationStates.SingleOrDefault();
                if(probationState == null)
                {
                    probationState = new ProbationState();
                    db.ProbationStates.Add(probationState);
                    db.SaveChanges();
                }
            }
            return probationState;
        }

        /// <summary>
        /// Checks to see if a student's state has changed. 
        /// </summary>
        /// <param name="student"></param>
        public override void stateChangeCheck(Student student)
        {
            if(student.GradePointAverage >= UpperLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
                db.SaveChanges();
            }
            if(student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = SuspendedState.getInstance().GPAStateId;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Calculates the adjusted tuition rate for a given student based on GPA.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>The adjusted tuition rate for a given student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            IQueryable<Registration> query = from results
                        in db.Registrations
                        where results.Grade != null && results.StudentId == student.StudentId
                        select results;

            int count = query.Count();
            double probationTuitionRate = 1.075;

            if(count >= 5)
            {
                probationTuitionRate = 1.035;
            }
            return probationTuitionRate;
        }
    }

    /// <summary>
    /// Class representing a regular GPA state. 
    /// </summary>
    public class RegularState : GPAState
    {
        private static RegularState regularState;

        /// <summary>
        /// Constructs an instance of the RegularState class.
        /// </summary>
        private RegularState()
        {
            this.LowerLimit = 2.00;
            this.UpperLimit = 3.70;
            this.TuitionRateFactor = 1;
        }

        /// <summary>
        /// Retrieves an instance of the RegularState class.
        /// </summary>
        /// <returns>Instance of RegularState.</returns>
        public static RegularState getInstance()
        {
            if(regularState == null)
            {
                regularState = db.RegularStates.SingleOrDefault();
                if(regularState == null)
                {
                    regularState = new RegularState();
                    db.RegularStates.Add(regularState);
                    db.SaveChanges();
                }
            }
            return regularState;
        }

        /// <summary>
        /// Calculates the adjusted tuition rate for a given student based on GPA.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>The adjusted tuition rate for a given student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            return TuitionRateFactor;
        }

        /// <summary>
        /// Checks to see if a student's state has changed.
        /// </summary>
        /// <param name="student"></param>
        public override void stateChangeCheck(Student student)
        {
            if(student.GradePointAverage >= UpperLimit)
            {
                student.GPAStateId = HonoursState.getInstance().GPAStateId;
                db.SaveChanges();
            }
            if (student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = SuspendedState.getInstance().GPAStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class representing an honours GPA state.
    /// </summary>
    public class HonoursState : GPAState
    {
        private static HonoursState honoursState;

        /// <summary>
        /// Construts an instance of the HonoursState class.
        /// </summary>
        private HonoursState()
        {
            this.LowerLimit = 3.7;
            this.UpperLimit = 4.5;
            this.TuitionRateFactor = 0.9;
        }

        /// <summary>
        /// Retrives an instance of the HonoursState class.
        /// </summary>
        /// <returns></returns>
        public static HonoursState getInstance()
        {
            if(honoursState == null)
            {
                honoursState = db.HonoursStates.SingleOrDefault();
                if(honoursState == null)
                {
                    honoursState = new HonoursState();
                    db.HonoursStates.Add(honoursState);
                    db.SaveChanges();
                }
            }
            return honoursState;
        }

        /// <summary>
        /// Calculates the adjusted tuition rate for a given student based on GPA.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>The adjusted tuition rate for a given student.</returns>
        public override double tuitionRateAdjustment(Student student)
        {
            IQueryable<Registration> query = from results
                                             in db.Registrations
                                             where results.Grade != null && results.StudentId == student.StudentId
                                             select results;

            int count = query.Count();
            double honoursTuitionRate = 0.9;

            if (count >= 5 && student.GradePointAverage > 4.25)
            {
                honoursTuitionRate = 0.83;
            }
            else if (count >= 5)
            {
                honoursTuitionRate = 0.85;
            }
            else if (student.GradePointAverage > 4.25)
            {
                honoursTuitionRate = 0.88;
            }
            return honoursTuitionRate;
        }

        /// <summary>
        /// Checks to see if a student's gpa state has changed.
        /// </summary>
        /// <param name="student"></param>
        public override void stateChangeCheck(Student student)
        {
            if(student.GradePointAverage < LowerLimit)
            {
                student.GPAStateId = RegularState.getInstance().GPAStateId;
                db.SaveChanges();
            }
        }
    }

    /// <summary>
    /// Class representing the next available student number. Is an auxillary class.
    /// </summary>
    public class NextStudentNumber
    {
        private static NextStudentNumber nextStudentNumber;
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instance of the NextStudentNumber class.
        /// </summary>
        private NextStudentNumber()
        {
            this.NextAvailableNumber = 20000000;
        }

        /// <summary>
        /// Retrieves or sets the next available student number id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextStudentNumberId { get; set; }

        /// <summary>
        /// Retrieves or sets the next available number.
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Retrieves an instance of the NextStudentNumber class.
        /// </summary>
        /// <returns>A NextStudentNumber object</returns>
        public static NextStudentNumber getInstance()
        {
            if(nextStudentNumber == null)
            {
                nextStudentNumber = db.NextStudentNumbers.SingleOrDefault();
                if(nextStudentNumber == null)
                {
                    nextStudentNumber = new NextStudentNumber();
                    db.NextStudentNumbers.Add(nextStudentNumber);
                    db.SaveChanges();
                }
            }
                return nextStudentNumber;
      
        }
    }

    /// <summary>
    /// Class representing the next registration number.
    /// </summary>
    public class NextRegistrationNumber
    {
        private static NextRegistrationNumber nextRegistrationNumber;
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instances of the NextRegistrationNumber class.
        /// </summary>
        private NextRegistrationNumber()
        {
            this.NextAvailableNumber = 700;
        }

        /// <summary>
        /// Retrieves or sets the next registration number id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextRegistrationNumberId { get; set; }

        /// <summary>
        /// Retrieves or sets the next available number.
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Retrieves an instance of the NextRegistrationNumber class.
        /// </summary>
        /// <returns>A NextRegistrationNumber object</returns>
        public static NextRegistrationNumber getInstance()
        {
            if(nextRegistrationNumber == null)
            {
                nextRegistrationNumber = db.NextRegistrationNumbers.SingleOrDefault();
                if(nextRegistrationNumber == null)
                {
                    nextRegistrationNumber = new NextRegistrationNumber();
                    db.NextRegistrationNumbers.Add(nextRegistrationNumber);
                    db.SaveChanges();
                }
            }
            return nextRegistrationNumber;
        }
    }

    /// <summary>
    /// Class representing the next graded course.
    /// </summary>
    public class NextGradedCourse
    {
        private static NextGradedCourse nextGradedCourse;
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instance of the NextGradedCourse class.
        /// </summary>
        private NextGradedCourse()
        {
            this.NextAvailableNumber = 200000;
        }

        /// <summary>
        /// Retrieves or sets the next graded course id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextGradedCourseId { get; set; }

        /// <summary>
        /// Retrieves or sets the next available number.
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Retrieves an instance of the NextRegistrationNumber class.
        /// </summary>
        /// <returns>A NextRegistrationNumber object</returns>
        public static NextGradedCourse getInstance()
        {
            if(nextGradedCourse == null)
            {
                nextGradedCourse = db.NextGradedCourses.SingleOrDefault();
                if(nextGradedCourse == null)
                {
                    nextGradedCourse = new NextGradedCourse();
                    db.NextGradedCourses.Add(nextGradedCourse);
                    db.SaveChanges();
                }
            }
            return nextGradedCourse;
        }
    }

    /// <summary>
    /// Class representing the next audit course.
    /// </summary>
    public class NextAuditCourse
    {
        private static NextAuditCourse nextAuditCourse;
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instance of the NextAuditCourse class.
        /// </summary>
        private NextAuditCourse()
        {
            this.NextAvailableNumber = 2000;
        }

        /// <summary>
        /// Retrieves or sets next audit course id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextAuditCourseId { get; set; }

        /// <summary>
        /// Retrieves or sets the next available number.
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Retrieves an instance of the NextAuditCourse class.
        /// </summary>
        /// <returns>A NextAuditCourse object</returns>
        public static NextAuditCourse getInstance()
        {
            if(nextAuditCourse == null)
            {
                nextAuditCourse = db.NextAuditCourses.SingleOrDefault();
                if(nextAuditCourse == null)
                {
                    nextAuditCourse = new NextAuditCourse();
                    db.NextAuditCourses.Add(nextAuditCourse);
                    db.SaveChanges();
                }
            }
            return nextAuditCourse;
        }
    }

    /// <summary>
    /// Class representing the next mastery course.
    /// </summary>
    public class NextMasteryCourse
    {
        private static NextMasteryCourse nextMasteryCourse;
        protected static BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Constructs an instance of the NextMasteryCourse class.
        /// </summary>
        private NextMasteryCourse()
        {
            this.NextAvailableNumber = 20000;
        }

        /// <summary>
        /// Retrieves or sets the next mastery course id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NextMasteryCourseId { get; set; }

        /// <summary>
        /// Retrieves or sets the next available number.
        /// </summary>
        public long NextAvailableNumber { get; set; }

        /// <summary>
        /// Retrieves an instance of the NextMasteryCourse class.
        /// </summary>
        /// <returns>A NextMasteryCourse object</returns>
        public static NextMasteryCourse getInstance()
        {
            if(nextMasteryCourse == null)
            {
                nextMasteryCourse = db.NextMasteryCourses.SingleOrDefault();
                if(nextMasteryCourse == null)
                {
                    nextMasteryCourse = new NextMasteryCourse();
                    db.NextMasteryCourses.Add(nextMasteryCourse);
                    db.SaveChanges();
                }
            }
            return nextMasteryCourse;
        }
    }

    /// <summary>
    /// Class representing a student card.
    /// </summary>
    public class StudentCard
    {
        /// <summary>
        /// Retrieves or sets a student card id.
        /// </summary>
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }

        /// <summary>
        /// Retrieves or sets the card number.
        /// </summary>
        [Display(Name ="Card\nNumber")]
        public long CardNumber { get; set; }

        /// <summary>
        /// Retrieves or sets a given student's id.
        /// </summary>
        [Required]
        [ForeignKey("student")]
        public int StudentId { get; set; }

        /// <summary>
        /// Navigational property from StudentCard to student. A student card can have one and only one student.
        /// </summary>
        public virtual Student student { get; set;}
    }

    /// <summary>
    /// A static class that exeutes stored sql procedures.
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Executes the stored procedure "next_number" and returns the value from the executed statement. 
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns>Long or null</returns>
        public static long? nextNumber(string tableName)
        {
            try
            {
                //Establishing that the database used will be BITCollege_TravisTaylorContext
                SqlConnection connection = new SqlConnection("Data Source=localhost; Initial Catalog=BITCollege_TravisTaylorContext;Integrated Security=True");

                //The return value can be null or a long
                long? returnValue = 0;

                //We are loading the stored procedure next_number
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);

                //Setting the command type to stored procedure.
                storedProcedure.CommandType = System.Data.CommandType.StoredProcedure;

                //Adding a table name passed in the parameter to the stored procedure as an argument
                storedProcedure.Parameters.AddWithValue("@TableName", tableName);

                //Establishing the output variable from the procedure
                SqlParameter outputParameter = new SqlParameter("@NewVal", System.Data.SqlDbType.BigInt) { Direction = System.Data.ParameterDirection.Output };

                //Adding the output variable to the procedure
                storedProcedure.Parameters.Add(outputParameter);

                //Opening a connection to the DBMS
                connection.Open();

                //Executing the statement as it's a non-query
                storedProcedure.ExecuteNonQuery();

                //Close the connection
                connection.Close();

                //Assign the output variable's value to a variable named returnValue
                returnValue = (long?)outputParameter.Value;
                return returnValue;
            }

            catch(Exception e)
            {
                //Return null if the above fais
                return null;
            }
        }
    }
} 