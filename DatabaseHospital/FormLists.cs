using System;
using System.Data;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    public partial class fLists : Form
    {
        private DataSet DS = new DataSet();

        public fLists()
        {
            InitializeComponent();
        }

        private void ResizeDGV()
        {
            DGV.Height = this.Height - 100;
        }

        // Получение списка врачей
        private void GridUpdateDoctorsTable()
        {
            try
            {
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DASpecs = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT doctors.doctorID, doctors.lname, doctors.fname, " +
                                   "doctors.mname, doctors.specID, specs.specTitle, doctors.specLevel, " +
                                   "doctors.apptime " +
                                   "FROM doctors INNER JOIN specs ON doctors.specID = specs.specID";
                String specscommand = "SELECT * FROM specs";
                com.CommandText = selectcommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "DoctorsSelectTable");
                DASpecs.SelectCommand = new SqlCommand(specscommand, Global.dbConnection);
                DASpecs.Fill(DS, "specs");


                DGV.DataSource = DS.Tables["DoctorsSelectTable"];
                DGV.Columns["doctorID"].Visible = false;
                //DGV.Columns["doctorID"].ReadOnly = true;
                DGV.Columns["specID"].Visible = false;
                //DGV.Columns["specID"].ReadOnly = true;

                DGV.Columns["fname"].HeaderText = "Имя";
                DGV.Columns["lname"].HeaderText = "Фамилия";
                DGV.Columns["mname"].HeaderText = "Отчество";
                DGV.Columns["apptime"].HeaderText = "Приём";
                DGV.Columns["speclevel"].HeaderText = "Разряд";


                DGV.Columns.Remove("specTitle");
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "specTitle";
                comboCol.DataSource = DS.Tables["specs"];
                comboCol.DataPropertyName = "specID";
                comboCol.DisplayMember = "specTitle";
                comboCol.ValueMember = "specID";
                comboCol.HeaderText = "Специальность";
                comboCol.DisplayStyleForCurrentCellOnly = true;
                comboCol.ValueType = typeof(string);

                DGV.Columns.Add(comboCol);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        // Получение списка адресов
        private void GridUpdateAddressesTable()
        {
            try
            {
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DAStreets = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT addresses.addressID, addresses.streetID, streets.streetTitle, " +
                                       "addresses.hnumber, addresses.anumber, addresses.building, addresses.info " +
                                   "FROM addresses INNER JOIN streets ON addresses.streetID = streets.streetID ORDER BY streetTitle";
                String specscommand = "SELECT * FROM streets ORDER BY streetTitle";
                com.CommandText = selectcommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "AddressesSelectTable");
                DAStreets.SelectCommand = new SqlCommand(specscommand, Global.dbConnection);
                DAStreets.Fill(DS, "streets");

                DGV.DataSource = DS.Tables["AddressesSelectTable"];
                DGV.Columns["addressID"].Visible = false;
                //DGV.Columns["AddressID"].ReadOnly = true;
                DGV.Columns["streetID"].Visible = false;
                //DGV.Columns["streetID"].ReadOnly = true;

                DGV.Columns["hnumber"].HeaderText = "№ дома";
                DGV.Columns["anumber"].HeaderText = "№ квартиры";
                DGV.Columns["building"].HeaderText = "Корпус";
                DGV.Columns["info"].HeaderText = "Доп. инф.";

                DGV.Columns.Remove("streetTitle");
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "streetTitle";
                comboCol.DataSource = DS.Tables["streets"];
                comboCol.DataPropertyName = "streetID";
                comboCol.DisplayMember = "streetTitle";
                comboCol.ValueMember = "streetID";
                comboCol.HeaderText = "Улица";
                comboCol.DisplayStyleForCurrentCellOnly = true;
                comboCol.ValueType = typeof(string);

                DGV.Columns.Add(comboCol);
                DGV.Columns["streetTitle"].DisplayIndex = 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        // Получение списка специализаций врачей
        private void GridUpdateSpecsTable()
        {
            try
            {
                SqlDataAdapter DASpecs = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String specscommand = "SELECT * FROM specs";
                com.CommandText = specscommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DASpecs.SelectCommand = new SqlCommand(specscommand, Global.dbConnection);
                DASpecs.Fill(DS, "specs");
                DGV.DataSource = DS.Tables["specs"];
                DGV.Columns["specTitle"].HeaderText = "Специализация";
                //DGV.Columns["specID"].ReadOnly = true;
                DGV.Columns["specID"].Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        // Получение списка улиц
        private void GridUpdateStreetsTable()
        {
            try
            {
                SqlDataAdapter DAStreets = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String specscommand = "SELECT * FROM streets";
                com.CommandText = specscommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DAStreets.SelectCommand = new SqlCommand(specscommand, Global.dbConnection);
                DAStreets.Fill(DS, "streets");
                DGV.DataSource = DS.Tables["streets"];
                //DGV.Columns["streetID"].ReadOnly = true;
                DGV.Columns["streetID"].Visible = false;
                DGV.Columns["streetTitle"].HeaderText = "Название улицы";
                DGV.Columns["streetTitle"].Width = 200;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        // Получение списка пациентов
        private void GridUpdatePatientsTable()
        {
            try
            {
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlDataAdapter DAAddresses = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT patients.patientID, patients.lname, patients.fname, patients.mname, " +
                                     "patients.bday, patients.phone, patients.addressID, rtbl.addr " +
                                     "FROM patients INNER JOIN (" +
                                                                "SELECT addresses.addressID, ('ул. '+" +
                                                                "streets.streetTitle+', д. '+" +
                                                                "CAST(addresses.hnumber as nvarchar(10))+" +
                                                                "', кв. '+CAST(addresses.anumber as nvarchar(10))+" +
                                                                "ISNULL(', корп. '+CAST(addresses.building as nvarchar(10)),'')) as 'addr' " +
                                                                "FROM addresses INNER JOIN streets ON addresses.streetID = streets.streetID) rtbl " +
                                     "ON patients.addressID = rtbl.addressID;";

                String addrcommand = "SELECT addresses.addressID, ('ул. '+" +
                                            "streets.streetTitle+', д. '+" +
                                            "CAST(addresses.hnumber as nvarchar(10))+" +
                                            "', кв. '+CAST(addresses.anumber as nvarchar(10))+" +
                                            "ISNULL(', корп. '+CAST(addresses.building as nvarchar(10)),'')) as 'addr' " +
                                            "FROM addresses INNER JOIN streets ON addresses.streetID = streets.streetID ORDER BY addr;";

                com.CommandText = selectcommand;
                DS = new DataSet();
                DGV.Columns.Clear();
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "PatientsSelectTable");
                DAAddresses.SelectCommand = new SqlCommand(addrcommand, Global.dbConnection);
                DAAddresses.Fill(DS, "addresses");

                DGV.DataSource = DS.Tables["PatientsSelectTable"];
                DGV.Columns["patientID"].Visible = false;
                //DGV.Columns["patientID"].ReadOnly = true;
                DGV.Columns["addressID"].Visible = false;
                //DGV.Columns["addressID"].ReadOnly = true;


                DGV.Columns["lname"].HeaderText = "Фамилия";
                DGV.Columns["fname"].HeaderText = "Имя";
                DGV.Columns["mname"].HeaderText = "Отчество";
                DGV.Columns["bday"].HeaderText = "День рождения";
                DGV.Columns["phone"].HeaderText = "Телефон";

                DGV.Columns.Remove("addr");
                DataGridViewComboBoxColumn comboCol = new DataGridViewComboBoxColumn();
                comboCol.Name = "addr";
                comboCol.DataSource = DS.Tables["addresses"];
                comboCol.DataPropertyName = "addressID";
                comboCol.DisplayMember = "addr";
                comboCol.ValueMember = "addressID";
                comboCol.HeaderText = "Адрес";
                comboCol.DisplayStyleForCurrentCellOnly = true;
                comboCol.ValueType = typeof(string);
                DGV.Columns.Add(comboCol);
                DGV.Columns["addr"].Width = 200;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        private void SQLUpdateDoctorsTable()
        {
            try
            {
                SqlDataAdapter DAUpdate = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();

                String commandText = "SELECT * FROM doctors";
                com.Connection = Global.dbConnection;
                com.CommandText = commandText;
                DAUpdate.SelectCommand = com;

                DataTable DT = new DataTable("doctors");
                DT = DS.Tables["DoctorsSelectTable"].Copy();

                SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
                DAUpdate.Update(DT);
            }
            catch (Exception ex)
            {
                throw new Exception("Похоже, что вы пытаетесь удалить поля, с которыми связаны данные в других разделах БД. Сначала нужно удалить связанную информацию.",ex);
            }
        }

        private void SQLUpdateAddressesTable()
        {
            try
            {
                SqlDataAdapter DAUpdate = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();

                String commandText = "SELECT * FROM addresses";
                com.Connection = Global.dbConnection;
                com.CommandText = commandText;
                DAUpdate.SelectCommand = com;

                DataTable DT = new DataTable("addresses");
                DT = DS.Tables["AddressesSelectTable"].Copy();

                SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
                DAUpdate.Update(DT);
            }
            catch (Exception ex)
            {
                throw new Exception("Похоже, что вы пытаетесь удалить поля, с которыми связаны данные в других разделах БД. Сначала нужно удалить связанную информацию.", ex);
            }
        }

/*        private void SQLUpdateWDaysTable()
        {
            SqlDataAdapter DAUpdate = new SqlDataAdapter();
            SqlCommand com = new SqlCommand();

            String commandText = "SELECT * FROM wdays";
            com.Connection = Global.dbConnection;
            com.CommandText = commandText;
            DAUpdate.SelectCommand = com;

            SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
            DAUpdate.Update(DS, "wdays");
        }*/

        private void SQLUpdateSpecsTable()
        {
            try
            {
                SqlDataAdapter DAUpdate = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();

                String commandText = "SELECT * FROM specs";
                com.Connection = Global.dbConnection;
                com.CommandText = commandText;
                DAUpdate.SelectCommand = com;

                SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
                DAUpdate.Update(DS, "specs");
            }
            catch (Exception ex)
            {
                throw new Exception("Похоже, что вы пытаетесь удалить поля, с которыми связаны данные в других разделах БД. Сначала нужно удалить связанную информацию.", ex);
            }
        }

        private void SQLUpdateStreetsTable()
        {
            try
            {
                SqlDataAdapter DAUpdate = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();

                String commandText = "SELECT * FROM streets";
                com.Connection = Global.dbConnection;
                com.CommandText = commandText;
                DAUpdate.SelectCommand = com;

                SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
                DAUpdate.Update(DS, "streets");
            }
            catch (Exception ex)
            {
                throw new Exception("Похоже, что вы пытаетесь удалить поля, с которыми связаны данные в других разделах БД. Сначала нужно удалить связанную информацию.", ex);
            }
        }

        private void SQLUpdatePatientsTable()
        {
            try
            {
                SqlDataAdapter DAUpdate = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();

                String commandText = "SELECT * FROM patients";
                com.Connection = Global.dbConnection;
                com.CommandText = commandText;
                DAUpdate.SelectCommand = com;

                DataTable DT = new DataTable("patients");
                DT = DS.Tables["PatientsSelectTable"].Copy();

                SqlCommandBuilder builder = new SqlCommandBuilder(DAUpdate);
                DAUpdate.Update(DT);
            }
            catch (Exception ex)
            {
                throw new Exception("Похоже, что вы пытаетесь удалить поля, с которыми связаны данные в других разделах БД. Сначала нужно удалить связанную информацию.", ex);
            }
        }

        private void ChangeGridTable()
        {
            switch (cbTablePicker.SelectedIndex)
            {
                case 0: { GridUpdateDoctorsTable(); break; }
                case 1: { GridUpdateAddressesTable(); break; }
                case 2: { GridUpdateSpecsTable(); break; }
                case 3: { GridUpdateStreetsTable(); break; }
                case 4: { GridUpdatePatientsTable(); break; }
            }
        }

        private void fLists_Shown(object sender, EventArgs e)
        {
            ResizeDGV();
            //cbTablePicker.SelectedIndex = -1;
        }

        private void fLists_Resize(object sender, EventArgs e)
        {
            ResizeDGV();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ChangeGridTable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (cbTablePicker.SelectedIndex)
            {
                case 0: { SQLUpdateDoctorsTable(); break; }
                case 1: { SQLUpdateAddressesTable(); break; }
                case 2: { SQLUpdateSpecsTable(); break; }
                case 3: { SQLUpdateStreetsTable(); break; }
                case 4: { SQLUpdatePatientsTable(); break; }
            }
        }

        private void cbTablePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGridTable();
            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
            if (cbTablePicker.SelectedIndex == 0) panelDoc.Visible = true;
            else panelDoc.Visible = false;

        }

        private void btnDocAddresses_Click(object sender, EventArgs e)
        {
            Global.formDoctorsAddr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.formShedule.ShowDialog();
        }



    }
}
