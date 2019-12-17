using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BITCollege_TravisTaylor.Models;
//using Utility;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        private BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        /// <summary>
        /// Drops a course from a student's registrations.
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public bool dropCourse(int registrationId)
        {
            bool droppedCourse = false;
            Registration courseToDrop = (from results
                                              in db.Registrations
                                         where results.RegistrationNumber == registrationId
                                         select results).SingleOrDefault();
            try
            {
                db.Registrations.Remove(courseToDrop);
                droppedCourse = true;
                db.SaveChanges();
                return droppedCourse;
            }

            catch (Exception exception)
            {
                return droppedCourse;
            }

        }

        /// <summary>
        /// Registers a student for a given course.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="courseId"></param>
        /// <param name="notes"></param>
        /// <returns></returns>
        public int registerCourse(int studentId, int courseId, string notes)
        {

            try
            {
                Registration incompleteCourseRecord = (from results
                                                      in db.Registrations
                                                       where results.StudentId == studentId
                                                       where results.CourseId == courseId
                                                       where results.Grade == null
                                                       select results).SingleOrDefault();
                if (incompleteCourseRecord != null)
                {
                    //If the student has a pending registration, return -100
                    return -100;
                }


                //Finding the amount of times the student has taken the course
                IQueryable<Registration> CourseAttempts = from results
                                                                 in db.Registrations
                                                          where results.CourseId == courseId
                                                          where results.StudentId == studentId
                                                          select results;
                int studentAttempts = CourseAttempts.Count();

                //If the course isn't a mastery course, maxAttempts returns null
                int? maxAttempts = (from results
                                      in db.MasteryCourses
                                    where results.CourseId == courseId
                                    select results.MaximumAttempts).SingleOrDefault();

                if (maxAttempts != null)
                {
                    if (studentAttempts >= maxAttempts && maxAttempts > 0)
                    {
                        //If the student has exceeded max attempts, return -200
                        return -200;
                    }
                }

                //If the conditions are satisfied, add the course
                BITCollege_TravisTaylor.Models.Registration newRegistration = new BITCollege_TravisTaylor.Models.Registration();
                newRegistration.CourseId = courseId;
                newRegistration.StudentId = studentId;
                newRegistration.Notes = notes;
                newRegistration.RegistrationNumber = (long)StoredProcedures.nextNumber("NextRegistrationNumbers");
                newRegistration.RegistrationDate = DateTime.Today;
                newRegistration.Grade = null;
                Course registeredCourse = (from results
                                           in db.Courses
                                           where results.CourseId == newRegistration.CourseId
                                           select results).SingleOrDefault();
                Student student = (from results
                                   in db.Students
                                   where results.StudentId == studentId
                                   select results).SingleOrDefault();
                GPAState state = (from results
                                  in db.GPAStates
                                  where results.GPAStateId == student.GPAStateId
                                  select results).SingleOrDefault();
                double registrationTuition = registeredCourse.TuitionAmount;
                double adjustedTuitionRate = state.tuitionRateAdjustment(student);
                student.OutstandingFees += adjustedTuitionRate * registrationTuition;
                db.Registrations.Add(newRegistration);
                db.SaveChanges();
                return 0;
            }

            catch (Exception exception)
            {
                //If any exceptions are thrown, return -300
                return -300;
            }
        }

        /// <summary>
        /// Updates the grade for a registration that has null for a grade.
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="registrationId"></param>
        /// <param name="notes"></param>
        public void updateGrade(double grade, int registrationId, string notes)
        {
            Registration courseToBeUpdated = (from results
                                 in db.Registrations
                                              where results.RegistrationId == registrationId
                                              where results.Grade == null
                                              select results).SingleOrDefault();

            //If the course grade is null and the course type is mastery or graded, update the grade and also calculate GPA.
            if (courseToBeUpdated != null && courseToBeUpdated.course.CourseType != "Audit")
            {
                courseToBeUpdated.Grade = grade;
                courseToBeUpdated.Notes = notes;
                db.SaveChanges();
                double calculatedGPA = calculateGPA(courseToBeUpdated.student.StudentId);
                
                Student student = (from results
                                  in db.Students
                                  where results.StudentId == courseToBeUpdated.student.StudentId
                                  select results).SingleOrDefault();
                student.GradePointAverage = calculatedGPA;
                db.SaveChanges();
                student.changeState(); 
                db.SaveChanges();
            }

            //If the course grade is null and the course type is audit, update the grade
            else if(courseToBeUpdated != null && courseToBeUpdated.course.CourseType == "Audit")
            {
                courseToBeUpdated.Grade = grade;
                courseToBeUpdated.Notes = notes;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Calculates the GPA of a given student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        private double calculateGPA(int studentId)
        {
            IQueryable<Registration> coursesGraded = from results
                                                     in db.Registrations
                                                     where results.Grade != null
                                                     where results.StudentId == studentId
                                                     select results;

            double? grades;
            string courseType;
            double gpv;
            double creditHours;
            double totalProduct = 0;
            double totalCreditHours = 0;
            foreach (Registration courseGrade in coursesGraded)
            {
                creditHours = courseGrade.course.CreditHours;
                courseType = courseGrade.course.CourseType;
                if (courseType != "Audit")
                {
                    grades = courseGrade.Grade;
                    CourseType courseTypeLookup  = BusinessRules.courseTypeLookup(courseType);
                    double gradesValue = (double)grades;
                    gpv = BusinessRules.gradeLookup(gradesValue, courseTypeLookup);
                    double product = gpv * creditHours;
                    totalProduct += product;
                    totalCreditHours += creditHours;
                }
            }

            double gpa = totalProduct / totalCreditHours;
            
            return gpa;
        }

        ////////////////
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

                catch (Exception e)
                {
                    //Return null if the above fails
                    return null;
                }
            }
        }
        /// <summary>
        /// given:  Enum listing course types
        /// </summary>
        public enum CourseType
        {
            GRADED, MASTERY, AUDIT
        }

        /// <summary>
        /// given:  Struct to align letter grades with gradepoint values
        /// Acts as an ENUM but with double values
        /// </summary>
        public struct GradePointValue
        {
            public const double A_PLUS = 4.5;
            public const double A = 4;
            public const double B_PLUS = 3.5;
            public const double B = 3;
            public const double C_PLUS = 2.5;
            public const double C = 2;
            public const double D = 1;
            public const double F = 0;
            public const double PASS = 4;
            public const double FAIL = 0;
            public const double INCOMPLETE = -1;
        }

        public static class BusinessRules
        {
            const string UNDEFINED = "";

            /// <summary>
            /// Given:
            /// defines the mask display format for the various course types
            /// </summary>
            /// <param name="accountType">string course type name</param>
            /// <returns>string format</returns>
            public static string courseFormat(string courseType)
            {
                string[] COURSE_TYPE = { "Audit", "Mastery", "Graded" };
                string[] COURSE_MASK = { ">L-00-00", ">L-00-0-00", ">L-00-00-00" };


                //initial format (empty string)
                string format = UNDEFINED;

                //compare account type to predefined types
                for (int i = 0; i < COURSE_TYPE.Length; i++)
                {
                    //if a match, return the corresonding mask
                    if (courseType.ToLower() == COURSE_TYPE[i].ToLower())
                    {
                        format = COURSE_MASK[i];
                        break;
                    }
                }
                //return the mask or empty string
                return format;
            }



            /// <summary>
            /// Given:
            /// CourseTypeLookup:  Matches string description
            /// with CourseType enum
            /// </summary>
            /// <param name="courseDescription">String description of course</param>
            /// <returns>CourseType enum</returns>
            public static CourseType courseTypeLookup(string courseDescription)
            {
                CourseType courseType = CourseType.AUDIT;

                //switch course.CourseType
                switch (courseDescription)
                {
                    case "Graded":
                        courseType = CourseType.GRADED;
                        break;
                    case "Mastery":
                        courseType = CourseType.MASTERY;
                        break;
                    default:
                        courseType = CourseType.AUDIT;
                        break;
                }

                return courseType;
            }


            /// <summary>
            /// Given:  Looks up letter grade based on course type and earned grade
            /// </summary>
            /// <param name="grade">double earned grade</param>
            /// <param name="courseType">uses course type enum</param>
            /// <returns></returns>
            public static double gradeLookup(double grade, CourseType courseType)
            {
                double gradePoint = GradePointValue.INCOMPLETE;

                switch (courseType)
                {
                    case CourseType.GRADED:
                        {
                            if (grade >= .90)
                            {
                                gradePoint = GradePointValue.A_PLUS;
                            }
                            else if (grade >= .80)
                            {
                                gradePoint = GradePointValue.A;
                            }
                            else if (grade >= .75)
                            {
                                gradePoint = GradePointValue.B_PLUS;
                            }
                            else if (grade >= .70)
                            {
                                gradePoint = GradePointValue.B;
                            }
                            else if (grade >= .65)
                            {
                                gradePoint = GradePointValue.C_PLUS;
                            }
                            else if (grade >= .60)
                            {
                                gradePoint = GradePointValue.C;
                            }
                            else if (grade >= .50)
                            {
                                gradePoint = GradePointValue.D;
                            }
                            else
                            {
                                gradePoint = GradePointValue.F;
                            }
                            break;
                        }
                    case CourseType.MASTERY:
                        {
                            gradePoint = grade >= .75 ? GradePointValue.PASS : GradePointValue.FAIL;
                            break;
                        }
                    default:
                        {
                            gradePoint = GradePointValue.INCOMPLETE;
                            break;
                        }
                }

                return gradePoint;

            }

        }
    }
}
