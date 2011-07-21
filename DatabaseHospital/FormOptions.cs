using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseHospital
{
    public partial class fOptions : Form
    {
        public fOptions()
        {
            InitializeComponent();
        }

        private void fOptions_Shown(object sender, EventArgs e)
        {
            tbServer.Text = Global.dbServer;
            tbDatabase.Text = Global.DatabaseString;
            tbUser.Text = Global.dbUser;
            tbPassword.Text = Global.dbPassword;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Global.dbServer = tbServer.Text;
            Global.DatabaseString = tbDatabase.Text;
            Global.dbUser = tbUser.Text;
            Global.dbPassword = tbPassword.Text;
            Close();
        }
    }
}
