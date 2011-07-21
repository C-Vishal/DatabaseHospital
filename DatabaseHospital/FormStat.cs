using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DatabaseHospital
{
    public partial class fStat : Form
    {
        public fStat()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fStat_Shown(object sender, EventArgs e)
        {
            try
            {
                String selectcommand = "SELECT COUNT(doctorID) as 'cd' FROM doctors;";
                SqlCommand com = new SqlCommand(selectcommand, Global.dbConnection);
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                lCountDoctors.Text = dr.GetInt32(dr.GetOrdinal("cd")).ToString();
                dr.Close();

                com.CommandText = "SELECT COUNT(patientID) as 'cp' FROM patients;";
                dr = com.ExecuteReader();
                dr.Read();
                lCountPatients.Text = dr.GetInt32(dr.GetOrdinal("cp")).ToString();
                dr.Close();

                com.CommandText = "SELECT COUNT(addressID) as 'ca' FROM addresses;";
                dr = com.ExecuteReader();
                dr.Read();
                lCountAddr.Text = dr.GetInt32(dr.GetOrdinal("ca")).ToString();
                dr.Close();

                com.CommandText = "SELECT COUNT(recordID) as 'cr' FROM history;";
                dr = com.ExecuteReader();
                dr.Read();
                lCountHistory.Text = dr.GetInt32(dr.GetOrdinal("cr")).ToString();
                dr.Close();

                com.CommandText = "SELECT MIN(hdate) as 'mhdate' FROM history;";
                dr = com.ExecuteReader();
                dr.Read();
                lfirstRec.Text = dr.GetDateTime(dr.GetOrdinal("mhdate")).ToShortDateString();
                dr.Close();

                com.CommandText = "SELECT MAX(hdate) as 'mhdate' FROM history;";
                dr = com.ExecuteReader();
                dr.Read();
                lLastRec.Text = dr.GetDateTime(dr.GetOrdinal("mhdate")).ToShortDateString();
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }
    }
}
