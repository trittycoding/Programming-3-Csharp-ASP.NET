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
    public partial class frmWCFService : Form
    {
        public frmWCFService()
        {
            InitializeComponent();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ConcatenateService.ConcatenateClient service 
                = new ConcatenateService.ConcatenateClient();

            lblResult.Text = service.NameAddress(txtName.Text, txtAddress.Text);


        }
    }
}
