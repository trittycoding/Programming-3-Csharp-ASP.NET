using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//the following for linq to xml
using System.Xml.Linq;
//for writing to files
using System.IO;


namespace ADEV3000Windows
{
    public partial class frmFileIO : Form
    {
        public frmFileIO()
        {
            InitializeComponent();
        }

        XDocument xDocDetails;

        /// <summary>
        /// given
        /// Extracts attribute from xml element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttributes_Click(object sender, EventArgs e)
        {
            XElement xeleElement  = xDocDetails.Element("humanresources");
            XAttribute eleAttribute = xeleElement.Attribute("date");

            rtxtData.Clear();
            rtxtData.Text += "ELEMENT: " + xeleElement.Name + "\r\nCONTAINS ATTRIBUTE: " +
                eleAttribute.Name + "\r\nWITH VALUE: " + eleAttribute.Value + "\r\n==============\r\n";

        }

        /// <summary>
        /// given
        /// form load - load xml document content
        /// into xDocument object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFileIO_Load(object sender, EventArgs e)
        {
            xDocDetails = XDocument.Load("InData.xml");
        }

        /// <summary>
        /// given
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// given
        /// read from xml file
        /// get all descendent elements of
        /// humanresources including a count
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElements_Click(object sender, EventArgs e)
        {
                IEnumerable<XElement> employeeElements = xDocDetails.Descendants("humanresources");

            rtxtData.Clear();
            rtxtData.Text += "DOCUMENT: InData.xml CONTAINS EMPLOYEES\r\n";

            //note this loop only executes once - everything under human
            //resources is considered one element
            foreach (XElement xele in employeeElements)
            {
                rtxtData.Text += "\r\nNAME: " + xele.Name + " VALUE: " + xele.Value; 
            }

            rtxtData.Text += "\r\nCOUNT: " + employeeElements.Count();
        }

        /// <summary>
        /// given
        /// read from xml file
        /// use linq to filter data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFilter_Click(object sender, EventArgs e)
        {

            IEnumerable<XElement> filteredElements =
                xDocDetails.Descendants().Where(d => d.Name == "last");

            rtxtData.Clear();
            rtxtData.Text += "DOCUMENT: InData.xml CONTAINS LAST NAMES\r\n";

            //note this loop executes 3 times
            //one for each occurrence of the last name
            foreach (XElement xele in filteredElements)
            {
                rtxtData.Text += "\r\nNAME: " + xele.Name + " VALUE: " + xele.Value;
            }
            rtxtData.Text += "\r\nCOUNT: " + filteredElements.Count();

        }

        /// <summary>
        /// example of writing to a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWrite_Click(object sender, EventArgs e)
        {
            StreamWriter srLog = new StreamWriter("OutData.txt");

            srLog.Write(rtxtData.Text);
            srLog.Close();
 
        }


        /// <summary>
        /// given
        /// lambda expression followed by using results
        /// in subsequent lambda expression
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElementLambda_Click(object sender, EventArgs e)
        {

            IEnumerable<XElement> totalEmployees =
                xDocDetails.Descendants().Where(d => d.Name == "employee");

            IEnumerable<XElement> highType =
                totalEmployees.Where(highTypes => int.Parse(highTypes.Element("type").Value) > 100);

            rtxtData.Clear();
            rtxtData.Text += "DOCUMENT: InData.xml CONTAINS FIRST NAMES WITH TYPE > 100 \r\n";

            foreach (XElement xele in highType)
            {
                rtxtData.Text += "\r\nNAME: " + xele.Name + " VALUE: " + xele.Value;
            }


            //note:  above can be done in one statement
            IEnumerable<XElement> singleStmt =
                xDocDetails.Descendants().Where(highTypeVals => int.Parse(highTypeVals.Element("type").Value) > 100);

            rtxtData.Text += "\r\n========================";
            rtxtData.Text += "\r\nDOCUMENT: InData.xml CONTAINS FIRST NAMES WITH TYPE > 100 \r\n";

            foreach (XElement xele in highType)
            {
                rtxtData.Text += "\r\nNAME: " + xele.Name + " VALUE: " + xele.Value;
            }


        }

    }
}
