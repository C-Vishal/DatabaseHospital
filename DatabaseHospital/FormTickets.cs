using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    public partial class fTickets : Form
    {
        DataSet DS = new DataSet();

        public fTickets()
        {
            InitializeComponent();
        }

        private void fTickets_Shown(object sender, EventArgs e)
        {
            DS = new DataSet();
            DS.Tables.Add("tickets");
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

        }

        private void ChangeGridTable()
        {
            int id;
            try { id = (int)cbDoctors.SelectedValue; }
            catch { return; };

            try
            {
                SqlDataAdapter DARecords = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String recscommand = "SELECT rtbl.patname, tickets.ticketID, tickets.tdate, tickets.ttime " +
                                     "FROM tickets INNER JOIN (" +
                                                                "SELECT patients.patientID, (patients.lname+' '+patients.fname+' '+patients.mname) as 'patname' " +
                                                                "FROM patients) rtbl " +
                                     "ON tickets.patientID = rtbl.patientID " +
                                     "WHERE tickets.doctorID = " + id.ToString() + ";";
                com.CommandText = recscommand;

                DS.Tables["tickets"].Clear();
                DARecords.SelectCommand = new SqlCommand(recscommand, Global.dbConnection);
                DARecords.Fill(DS, "tickets");
                DGV.DataSource = DS.Tables["tickets"];
                DGV.Columns["patname"].HeaderText = "Ф.И.О. пациента";
                DGV.Columns["patname"].Width = 200;
                DGV.Columns["ttime"].HeaderText = "Время";
                DGV.Columns["tdate"].HeaderText = "Дата";
                DGV.Columns["ticketID"].Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }

        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGridTable();

            if (cbDoctors.SelectedIndex > -1)
            {
                btnRefresh.Enabled = true;
                if (DGV.Rows.Count > 0) btnRemove.Enabled = true;
                else btnRemove.Enabled = false;
            }
            else
            {
                btnRefresh.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string cmdDel = "DELETE FROM tickets WHERE tickets.ticketID = " +
                             DGV.SelectedRows[0].Cells["ticketID"].Value.ToString() +
                             ";";
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

        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            Global.formAddTicket.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ChangeGridTable();
        }
    }
}
