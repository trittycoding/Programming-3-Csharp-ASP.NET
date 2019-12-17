using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BITCollege_TravisTaylor.Models;
using Utility;


namespace WindowsApplication
{
    /// <summary>
    /// Processes transactions contained within an encrypted XML file. Transactions can either register
    /// a student for a class or grade an existing registration.
    /// </summary>
    class Batch
    {
        BITCollege_TravisTaylorContext db = new BITCollege_TravisTaylorContext();

        //Attributes
        private string inputFileName;
        private string logFileName;
        private string logData = "";

        /// <summary>
        /// Processes the errors between each query in processDetails. Checks the differences between queries.
        /// </summary>
        /// <param name="beforeQuery"></param>
        /// <param name="afterQuery"></param>
        /// <param name="message"></param>
        private void processErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);
            foreach(XElement x in errors)
            {
                logData += inputFileName + "\r\n";
                logData += x.Element("program") + "\r\n";
                logData += x.Element("student_no") + "\r\n";
                logData += x.Element("course_no") + "\r\n";
                logData += x.Element("registration_no") + "\r\n";
                logData += x.Element("type") + "\r\n";
                logData += x.Element("grade") + "\r\n";
                logData += x.Element("notes") + "\r\n";
                logData += x.Nodes().Count() + "\r\n";
                logData += message + "\r-----------------\n\r";
            }
        }

        /// <summary>
        /// Processes the root element's attributes to ensure a valid file
        /// </summary>
        private void processHeaders()
        {
            //Loading the xdocument object with the xml file
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Load(inputFileName);

            //Pull root element
            XElement root = xdoc.Element("student_update");

            //Grab attributes within the root element
            XAttribute date = root.Attribute("date");
            XAttribute program = root.Attribute("program");
            XAttribute checksum = root.Attribute("checksum");

            //Values within attributes
            DateTime dateValue = DateTime.Parse(date.Value);
            string programAckValue = program.Value;
            string checksumValue = checksum.Value;
            long checksumParsed = long.Parse(checksumValue);

            //Counting the attributes in the root element
            int rootAttributeCount = root.Attributes().Count();

            //if the root attribute count is 3 then proceed.
            if (rootAttributeCount != 3)
            {
                throw new Exception("incorrect number of attributes in root element.\r\n");
            }

            DateTime today = DateTime.Today;
            bool dateComparison = dateValue.Equals(today);
            if(dateComparison == false)
            {
                throw new Exception("date is not valid.\r\n");
            }

            string programValidation = (from results in db.Programs
                                        where results.ProgramAcronym == programAckValue
                                        select results.ProgramAcronym).SingleOrDefault();

            if(programValidation == null)
            {
                throw new Exception("program acronym does not exist.\r\n");
            }
                   
            //Grab all child elements of the root to validate checksum
            IEnumerable<XElement> children = from results in root.Descendants()
                                                where results.Name == "student_no"
                                                select results;
            long total = 0;

            foreach(XElement x in children)
            {
                //Grab each student number within each student_no element, parse and add
                string studentNumber = x.Value;
                long studentNumberParsed = long.Parse(studentNumber);
                total += studentNumberParsed;
            }

            if(total != checksumParsed)
            {
                throw new Exception("checksum is not valid\r\n");
            }

        }

        /// <summary>
        /// Ensures individual transactions are valid, discards transactions that aren't valid.
        /// </summary>
        private void processDetails()
        {
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Load(inputFileName);
            XElement root = xdoc.Element("student_update");

            //Grab attributes within the root element
            XAttribute date = root.Attribute("date");
            XAttribute program = root.Attribute("program");
            XAttribute checksum = root.Attribute("checksum");

            //Values within attributes
            DateTime dateValue = DateTime.Parse(date.Value);
            string programAckValue = program.Value;
            string checksumValue = checksum.Value;
            long checksumParsed = long.Parse(checksumValue);

            //Get all transactions in the document
            IEnumerable<XElement> transactions = from results in xdoc.Descendants()
                                             where results.Name == "transaction"
                                             select results;

            //Getting all of the nodes where the node count is equal to seven
            IEnumerable<XElement> nodeCount = from results in transactions
                                              where results.Nodes().Count() == 7
                                              select results;

            //Compare the transactions to the node count queries 
            processErrors(transactions, nodeCount, "Node count is not equal to seven\r\n");

            //Query to get all programs that are equal to the root's value for program -----> Failing at this point
            IEnumerable<XElement> programs = from results in nodeCount
                                             where results.Element("program").Value == programAckValue
                                             select results;

            //Comparing programs to the node count query
            processErrors(nodeCount, programs, "Program listed is not equal to the root value.\r\n");

            //Querying to get the types where the values are numeric
            IEnumerable<XElement> types = from results in programs
                                          where Numeric.isNumeric(results.Element("type").Value, System.Globalization.NumberStyles.Number)
                                          where results.Element("type").Value == "1" || results.Element("type").Value == "2"
                                          select results;

            //Comparing types vs program queries
            processErrors(programs, types, "Type is not numeric\r\n");

            //If grade is *, or numeric (and is within the valid grade range)
            IEnumerable<XElement> grades = from results in types
                                           where Numeric.isNumeric(results.Element("grade").Value, System.Globalization.NumberStyles.Float) && 
                                           double.Parse(results.Element("grade").Value) >= 0 && double.Parse(results.Element("grade").Value) <= 100
                                           || results.Element("grade").Value == "*"
                                           select results;

            //Comapring grades vs. type queries
            processErrors(types, grades, "Value for grade isn't valid\r\n");

            //Getting student numbers from db
            IQueryable<long> dbStudentNumbers = from results in db.Students
                                                select results.StudentNumber;

            //Querying for student numbers
            IEnumerable<XElement> studentNumbers = from results in grades
                                                   where dbStudentNumbers.Contains(long.Parse(results.Element("student_no").Value))
                                                   select results;

            //Comparing student number to grades query
            processErrors(grades, studentNumbers, "Student Number does not exist within database\r\n");

            //Query DB to get course numbers
            IQueryable<string> dbCourseNumbers = from results in db.Courses
                                                 select results.CourseNumber;

            //Query to get course numbers: type 2 then grading, type 1 for registration 
            IEnumerable<XElement> courseNumbers = from results in studentNumbers
                                                  where dbCourseNumbers.Contains(results.Element("course_no").Value) && results.Element("type").Value == "1"
                                                  || results.Element("type").Value == "2" && results.Element("course_no").Value == "*"
                                                  select results;

            //Comparing courseNumbers query to student numbers query
            processErrors(studentNumbers, courseNumbers, "Invalid course number\r\n");

            //Querying db for registration numbers
            IQueryable<long> dbRegistrationNumbers = from results in db.Registrations
                                                     select results.RegistrationNumber;

            //Querying for registration numbers 
            IEnumerable<XElement> registrationNumbers = from results in courseNumbers
                                                        where results.Element("type").Value == "2" && dbRegistrationNumbers.Contains(long.Parse(results.Element("registration_no").Value))
                                                        || results.Element("type").Value == "1" && results.Element("registration_no").Value == "*"
                                                        select results;

            //Comparing registration numbers to course numbers
            processErrors(courseNumbers, registrationNumbers, "Registration number doesn't exist\r\n");

            //Pass the error free result set to processTransactions method
            processTransactions(registrationNumbers);
            
        }

        /// <summary>
        /// Performs the appropriate operation of CollegeRegistration dependent on what type of transaction it is.
        /// </summary>
        /// <param name="transactionRecords"></param>
        private void processTransactions(IEnumerable<XElement> transactionRecords)
        {
            //Loop through each transaction and grab each child element value
            foreach(XElement node in transactionRecords)
            {
                string typeValue = node.Element("type").Value;
                string studentNumberValue = node.Element("student_no").Value;
                string courseNumberValue = node.Element("course_no").Value;
                string registrationNumberValue = node.Element("registration_no").Value;
                string gradeValue = node.Element("grade").Value;
                string notes = node.Element("notes").Value;

                //Parse numerical values
                long studentNumberParsed = long.Parse(studentNumberValue);

                //If the type is 1 (registration), then register the course for the student
                if(typeValue.Equals("1") && registrationNumberValue.Equals("*") && gradeValue.Equals("*"))
                {

                    int? courseID = (from results
                                     in db.Courses
                                     where results.CourseNumber == courseNumberValue
                                     select results.CourseId).SingleOrDefault();

                    int? studentID = (from results
                                     in db.Students
                                     where results.StudentNumber == studentNumberParsed
                                     select results.StudentId).SingleOrDefault();

                    if (studentID != null && courseID != null)
                    {
                        int course = (int)courseID;
                        int student = (int)studentID;
                        ServiceReference.CollegeRegistrationClient localWS = new ServiceReference.CollegeRegistrationClient();
                        int returnCode = localWS.registerCourse(student, course, notes);
                        db.SaveChanges();

                        //Successful registration 
                        if(returnCode == 0)
                        {
                            logData += "Successful registration for student number: " + studentNumberValue + ". Course selected: " + courseNumberValue + "\r\n";
                        }

                        //Failed Registrations
                        else if(returnCode == -100 || returnCode == -200 || returnCode == -300)
                        {
                            logData += registerError(returnCode);
                        }

                        //Unknown error when registering
                        else
                        {
                            logData += registerError(returnCode);
                        }

                    }
                }
                
                //If the type is 2 (grading), then update the grade
                else if(typeValue.Equals("2") && !registrationNumberValue.Equals("*") && !gradeValue.Equals("*"))
                {
                    double gradeParsed = (double.Parse(gradeValue)) / 100;
                    long registrationParsed = long.Parse(registrationNumberValue);

                    int? registrationID = (from results
                                                      in db.Registrations
                                          where results.RegistrationNumber == registrationParsed
                                          select results.RegistrationId).SingleOrDefault();


                    //If the grade is within range
                    if (gradeParsed >=0 && gradeParsed <= 1 && registrationID != null)
                    {
                        int registration = (int)registrationID;
                        ServiceReference.CollegeRegistrationClient localWS = new ServiceReference.CollegeRegistrationClient();

                        try
                        {
                            localWS.updateGrade(gradeParsed, registration, notes);
                            db.SaveChanges();
                            logData += "Grade " + gradeValue + " applied to student " + studentNumberValue + " for registration " + registrationNumberValue + "\r\n";
                        }
                        catch (Exception)
                        {

                            logData += "Problem with transaction: update for " + registrationNumberValue + " was unsuccessful\r\n";
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Writes log data to the specified log file. If a log file isn't present, it is created.
        /// </summary>
        /// <returns></returns>
        public string writeLogData()
        {
            //backup log data
            string logCopy = logData;
            string completedFileName = "COMPLETE-" + inputFileName;

            //If it exists, delete it
            if (File.Exists(completedFileName))
            {
                File.Delete(completedFileName);
            }

            //Rename the file to be completed 
            else
            {
                if (File.Exists(inputFileName))
                {
                    File.Move(inputFileName, completedFileName);
                }
                
            }

            //Streamwriter writes the log data to an actual file

            StreamWriter streamwriter = new StreamWriter(logFileName, false);
            streamwriter.Write(logCopy);
            streamwriter.Close();

            //Reset log data for the next file
            logData = "";
            logFileName = "";

            return logCopy;
        }

        /// <summary>
        /// Ensures that the filename exists, is in the format of "YYYY-DayOfYear-ProgramAcronym" and is current.
        /// </summary>
        /// <param name="programAcronym"></param>
        /// <param name="key"></param>
        public void processTransmission(string programAcronym, string key)
        {
            //Building the file name
            DateTime today = DateTime.Today;
            inputFileName = String.Concat(today.Year.ToString(), '-', today.DayOfYear.ToString(), '-', programAcronym, ".xml");

            //Building log file name
            int indexOfExtension = inputFileName.IndexOf('.');
            string inputFileNameExtensionless = inputFileName.Substring(0, indexOfExtension);
            logFileName = String.Concat(inputFileNameExtensionless, "LOG.txt");

            //Encrypted File Name
            string encryptedFileName = inputFileName + ".encrypted";

            try
            {
                //Determining if the encrypted file exists. If an exception occurs, it will throw to catch block.
                if (File.Exists(encryptedFileName))
                {
                    Encryption.decrypt(encryptedFileName, inputFileName, key);
                    //If it exists, then decrypt
                    if (File.Exists(inputFileName))
                    {
                        processHeaders();
                        processDetails();
                    }

                    //Filename does not exist
                    else
                    {
                        logData += String.Concat("The specified filename ", inputFileName, " does not exist.\n");
                    }
                }

                //Filename does not exist
                else
                {
                    logData += String.Concat("The specified filename ", encryptedFileName, " does not exist.\n");
                }
            }
            catch (Exception exception)
            {
                logData += String.Concat("An exception has occurred when trying to load file ", inputFileName, ". The exception generated is: ", exception.Message, ".\n");
            }

        }

        /// <summary>
        /// Returns a string message according to the error code received from the web service.
        /// </summary>
        /// <param name="errorcode"></param>
        /// <returns>String error Message</returns>
        public static string registerError(int errorcode)
        {
            if (errorcode == -100)
            {
                return "Student cannot register for a course in which there is already an ungraded registration.\n";
            }

            else if (errorcode == -200)
            {
                return "Student has exceeded maximum attempts on a mastery course.\n";
            }

            else if (errorcode == -300)
            {
                return "An error has occurred while updating the registration.\n";
            }

            else
            {
                return "Unknown error.\n";
            }
        }
    }
}
