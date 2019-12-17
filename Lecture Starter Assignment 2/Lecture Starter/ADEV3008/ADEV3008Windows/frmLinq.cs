using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADEV3000Windows
{
    public partial class frmLinq : Form
    {
        //given
        //Arrays used in the code examples that follow
        String[] cities = { "Toronto", "Ottawa", "Winnipeg", "Montreal", "Calgary" };
        String[] countries = { "Canada", "USA", "Mexico", "Argentina", "Brazil" };
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23 };
        int[] fives = { 5, 10, 15, 20, 25, 30, 35 };



        public frmLinq()
        {
            InitializeComponent();
        }

        /// <summary>
        /// For Lecture:  select example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            //TRADITIONAL SYNTAX
            //query:  result set
            //results: temporary variable containing the 
            //evolving result set
            //cities:  datasource
            IEnumerable<String> query =
                from results
                in cities
                select results + ",";

            //LAMBDA SYNTAX
            IEnumerable<String> lambdaQuery = cities;


            foreach (String city in query)
                lblValue.Text += city + ",";

        }

        /// <summary>
        /// For Lecture:  Where example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWhere_Click(object sender, EventArgs e)
        {
            IEnumerable<int> query =
                 from results
                 in primes
                 where results > 10
                 //this where applies to result set of previous where
                 where results / 2 > 7
                 select results;


            IEnumerable<int> lambdaQuery = primes
                    .Where(x => x > 10)
                    .Where(x => x / 2 > 7) ;

            //All students with gpa > 4
            //data context object
            // BITCollege_JSContext db = BITCollege_JSContext();
            //TRAD
            //IQueryable<Student> query = from results in db.Students
            //                              where results.GradePointAverage > 4
            //                              select results;

            //LAMBDA
            //IQueryable<Student> lambdaQuery = 
            //    db.Students.Where(x => x.GradePointAverage > 4);


            foreach (int prime in query)
                lblValue.Text += prime + ",";


        }

        /// <summary>
        /// For Lecture:  Join Example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            ////var query =
            ////    from results
            ////    in primes
            ////    from moreResults
            ////    in fives
            ////    where results == moreResults
            ////    select results;

            ////foreach (int item in query)
            ////    lblValue.Text += item + ",";


            IEnumerable<int> query =
                from results in primes
                join moreResults in fives
                on results equals moreResults
                select results;


            foreach (int item in query)
                lblValue.Text += item + ",";


        }

        /// <summary>
        /// For Lecture:  Let example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLet_Click(object sender, EventArgs e)
        {
            var query =
                from result in primes
                join moreResults in fives
                on result equals moreResults
                let sum = result + moreResults
                select sum;

            foreach (int item in query)
                lblValue.Text += item + ",";


        }

        /// <summary>
        /// For Lecture:  Lambda example
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLambda_Click(object sender, EventArgs e)
        {
            var query = cities.Where(value => value.Length == 8);

            foreach (String city in query)
                lblValue.Text +=
                 city + ",";

            //Result:  Winnipeg,Montreal


        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblValue.Text = "";
        }

        private void frmLinq_Load(object sender, EventArgs e)
        {

        }
    }
}
