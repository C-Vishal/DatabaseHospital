using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    public partial class fAddRecordHistory : Form
    {
        DataSet DS = new DataSet();

        public fAddRecordHistory()
        {
            InitializeComponent();
        }

        private void fAddRecordHistory_Shown(object sender, EventArgs e)
        {
            try
            {
                DS = new DataSet();
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DASpecs = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT doctors.doctorID, doctors.lname + ' ' + doctors.fname + ' ' " +
                                       "+ doctors.mname as 'dname' FROM doctors;";
                com.CommandText = selectcommand;
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "DoctorsSelectTable");

                cbDoctors.DataSource = DS.Tables["DoctorsSelectTable"];
                cbDoctors.DisplayMember = "dname";
                cbDoctors.ValueMember = "doctorID";
                cbDoctors.SelectedIndex = -1;

                dtPicker.CustomFormat = "dd.MM.yyyy (HH:mm)";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sqlIns = "INSERT INTO history VALUES (@doctorID, @patientID, @hdate, @htime, @htext, @mark);";

            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, Global.dbConnection);
                cmdIns.Parameters.Add("@doctorID", SqlDbType.Int);
                cmdIns.Parameters["@doctorID"].Value = (int)cbDoctors.SelectedValue;

                cmdIns.Parameters.Add("@patientID", SqlDbType.Int);
                cmdIns.Parameters["@patientID"].Value = Global.formHistory.PatientID;

                cmdIns.Parameters.Add("@hdate", SqlDbType.Date);
                cmdIns.Parameters["@hdate"].Value = dtPicker.Value.Date;

                cmdIns.Parameters.Add("@htime", SqlDbType.Time);
                cmdIns.Parameters["@htime"].Value = dtPicker.Value.ToShortTimeString();

                cmdIns.Parameters.Add("@htext", SqlDbType.NText);
                cmdIns.Parameters["@htext"].Value = Memo.Text;

                cmdIns.Parameters.Add("@mark", SqlDbType.NVarChar);
                cmdIns.Parameters["@mark"].Value = tbMark.Text;
                
                cmdIns.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                Close();
                Global.formHistory.ChangeGridTable();
            }
        }

        private void CheckOKButton()
        {
            if ((cbDoctors.SelectedIndex > -1) && (Memo.Text != "")) btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckOKButton();
        }

        private void Memo_TextChanged(object sender, EventArgs e)
        {
            CheckOKButton();
        }
    }
}
