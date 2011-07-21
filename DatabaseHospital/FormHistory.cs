using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    public partial class fHistory : Form
    {
        DataSet DS = new DataSet();

        public fHistory()
        {
            InitializeComponent();
        }

        public int PatientID  
        { 
            get { return (int)cbPatients.SelectedValue; }  
        }

        private void fHistory_Shown(object sender, EventArgs e)
        {
            try
            {
                DS = new DataSet();
                DS.Tables.Add("records");
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DASpecs = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT patients.patientID, patients.lname + ' ' + patients.fname + ' ' " +
                                       "+ patients.mname as 'pname' FROM patients;";
                com.CommandText = selectcommand;
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "PatientsSelectTable");

                cbPatients.DataSource = DS.Tables["PatientsSelectTable"];
                cbPatients.DisplayMember = "pname";
                cbPatients.ValueMember = "patientID";
                cbPatients.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        public void ChangeGridTable()
        {
            int id;
            try { id = (int)cbPatients.SelectedValue; }
            catch { return; };

            try
            {
                SqlDataAdapter DARecords = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String recscommand = "SELECT history.recordID, history.doctorID, rtbl.docname, history.hdate, history.htime, " +
                                     "history.htext, history.mark " +
                                     "FROM history INNER JOIN (" +
                                                                "SELECT doctors.doctorID, (doctors.lname+' '+doctors.fname+' '+doctors.mname) as 'docname'" +
                                                                "FROM doctors) rtbl " +
                                     "ON history.doctorID = rtbl.doctorID " +
                                     "WHERE history.patientID = " + id.ToString() + ";";
                com.CommandText = recscommand;

                DS.Tables["records"].Clear();
                DARecords.SelectCommand = new SqlCommand(recscommand, Global.dbConnection);
                DARecords.Fill(DS, "records");
                DGV.DataSource = DS.Tables["records"];
                //DGV.Columns["recordID"].ReadOnly = true;
                DGV.Columns["recordID"].Visible = false;
                //DGV.Columns["doctorID"].ReadOnly = true;
                DGV.Columns["doctorID"].Visible = false;
                DGV.Columns["docname"].HeaderText = "Ф.И.О. врача";
                DGV.Columns["docname"].Width = 200;
                DGV.Columns["hdate"].HeaderText = "Дата";
                DGV.Columns["htime"].HeaderText = "Время";
                DGV.Columns["htext"].Visible = false;
                DGV.Columns["mark"].HeaderText = "Пометка";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }


        private void cbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGridTable();
            if (cbPatients.SelectedIndex > -1)
            {
                btnAdd.Enabled = true;
                btnRefresh.Enabled = true;
                if (DGV.Rows.Count > 0) btnRemove.Enabled = true;
                else btnRemove.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = false;
                btnRefresh.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DGV.Rows.Count>0)
                Memo.Text = DGV.SelectedRows[0].Cells["htext"].Value.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ChangeGridTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Global.formAddRecord.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string cmdDel = "DELETE FROM history WHERE history.recordID = "+
                             DGV.SelectedRows[0].Cells["recordID"].Value.ToString()+";";
            try
            {
                SqlCommand sqlDel = new SqlCommand(cmdDel, Global.dbConnection);
                sqlDel.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                ChangeGridTable();
            }
        }

        private void fHistory_Resize(object sender, EventArgs e)
        {
            splitContainer.Height = this.Height - 100;
        }
    }
}
