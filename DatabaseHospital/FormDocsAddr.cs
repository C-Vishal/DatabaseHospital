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
    public partial class fDoctorsAddr : Form
    {
        DataSet DS = new DataSet();


        public fDoctorsAddr()
        {
            InitializeComponent();
        }

        private void fDoctorsAddr_Shown(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        private void ChangeGridTable()
        {
            int id;
            try { id = (int)cbDoctors.SelectedValue; }
            catch { return; };

            try
            {
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DAAddresses = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT docaddr.doctorID, docaddr.streetID, streets.streetTitle " +
                           "FROM docaddr INNER JOIN streets ON docaddr.streetID = streets.streetID " +
                           "WHERE docaddr.doctorID = " + id + " ORDER BY streetTitle;";

                String streetscommand = "SELECT * FROM streets ORDER BY streetTitle";

                com.CommandText = selectcommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "StreetsSelectTable");
                DAAddresses.SelectCommand = new SqlCommand(streetscommand, Global.dbConnection);
                DAAddresses.Fill(DS, "streets");

                DGV.DataSource = DS.Tables["StreetsSelectTable"];
                DGV.Columns["doctorID"].Visible = false;
                //DGV.Columns["doctorID"].ReadOnly = true;
                DGV.Columns["streetID"].Visible = false;
                //DGV.Columns["streetID"].ReadOnly = true;

                DGV.Columns.Remove("streetTitle");
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "streetTitle";
                comboCol.DataSource = DS.Tables["streets"];
                comboCol.DataPropertyName = "streetID";
                comboCol.DisplayMember = "streetTitle";
                comboCol.ValueMember = "streetID";
                comboCol.HeaderText = "Улица";
                comboCol.Width = 200;
                comboCol.DisplayStyleForCurrentCellOnly = true;
                comboCol.ValueType = typeof(string);

                DGV.Columns.Add(comboCol);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGridTable();
        }

        private void DGV_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            DGV.Rows[e.Row.Index - 1].Cells["doctorID"].Value = (int)cbDoctors.SelectedValue;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id;
            try { id = (int)cbDoctors.SelectedValue; }
            catch { return; };

            SqlDataAdapter DAUpdate = new SqlDataAdapter();
            SqlCommand com = new SqlCommand();

            String commandText = "SELECT * FROM docaddr WHERE doctorID = " + id + ";";
            com.Connection = Global.dbConnection;
            com.CommandText = commandText;
            DAUpdate.SelectCommand = com;

            DataTable DT = new DataTable("docaddr");
            DT = DS.Tables["StreetsSelectTable"].Copy();
            

            SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
            try { DAUpdate.Update(DT); }
            catch
            {
                MessageBox.Show("Скорее всего вы пытаетесь добавить улицу, которая уже есть в списке.",
                                "Ошибка!",
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            };

        ChangeGridTable();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ChangeGridTable();
        }
    }
}
