using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EWSoftware.MaskedLabelControl;
using BITCollege_TravisTaylor.Models;


namespace WindowsApplication
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// </summary>
    public class ConstructorData
    {
        /// <summary>
        /// Gets/sets the student object data
        /// </summary>
        public Student student { get; set; }

        /// <summary>
        /// Gets/sets the registration object data
        /// </summary>
        public Registration registration { get; set; }
    }
}
