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
    public partial class fAddTicket : Form
    {
        DataSet DS = new DataSet();
        TimeSpan TicketTime = new TimeSpan();

        public fAddTicket()
        {
            InitializeComponent();
        }
        
        private void CheckButtons()
        {
            if (cbPatients.SelectedIndex > -1)
            {
                cbDoctors.Enabled = true;
                if (cbDoctors.SelectedIndex > -1)
                {
                    btnAdd.Enabled = true;
                    dtPicker.Enabled = true;
                }
                else
                {
                    btnAdd.Enabled = false;
                    dtPicker.Enabled = false;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                dtPicker.Enabled = false;
                cbDoctors.SelectedIndex = -1;
                cbDoctors.Enabled = false;
            }

        }

        private void cbPatients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try { id = (int)cbPatients.SelectedValue; } catch { return; };

            try
            {
                // Получим streetID выбранного пациента
                String selectcommand = "SELECT streets.streetID FROM streets, addresses, patients " +
                                       "WHERE  streets.streetID = addresses.streetID AND " +
                                       "addresses.addressID = patients.addressID AND patients.patientID = " +
                                       id.ToString() + ";";

                SqlCommand com = new SqlCommand(selectcommand, Global.dbConnection);
                SqlDataReader dr1 = com.ExecuteReader();

                dr1.Read();
                int streetID = dr1.GetInt32(dr1.GetOrdinal("streetID"));
                dr1.Close();

                // Получим список разрешенных врачей для этого streetID
                DS.Tables["doctors"].Clear();
                SqlDataAdapter DASelect = new SqlDataAdapter();

                selectcommand = "SELECT docaddr.doctorID, rtbl.dname FROM docaddr, " +
                                "(SELECT doctors.doctorID, ('('+specs.specTitle+') '+" +
                                "doctors.lname+' '+doctors.fname+' '+doctors.mname) as 'dname' " +
                                "FROM doctors, specs WHERE doctors.specID = specs.specID) rtbl " +
                                "WHERE docaddr.doctorID = rtbl.doctorID AND docaddr.streetID =" + streetID +
                                " ORDER BY rtbl.dname;";

                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "doctors");

                cbDoctors.DataSource = DS.Tables["doctors"];
                cbDoctors.DisplayMember = "dname";
                cbDoctors.ValueMember = "doctorID";
                cbDoctors.SelectedIndex = -1;
                cbDoctors.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }            
        }

        private bool FindFreeTicket(ref TimeSpan ts)
        {
            int wday=0;
            switch (dtPicker.Value.DayOfWeek)
            {
                case DayOfWeek.Monday:      { wday = 0; break; }
                case DayOfWeek.Tuesday:     { wday = 1; break; }
                case DayOfWeek.Wednesday:   { wday = 2; break; }
                case DayOfWeek.Thursday:    { wday = 3; break; }
                case DayOfWeek.Friday:      { wday = 4; break; }
                case DayOfWeek.Saturday:    { wday = 5; break; }
                case DayOfWeek.Sunday:      { wday = 6; break; }
            }

            int did = (int)cbDoctors.SelectedValue;

            try
            {
                // Получим начало и конец рабочего дня для выбранного врача
                String selectcommand = "SELECT shedule.tbegin, shedule.tend FROM shedule " +
                                       "WHERE shedule.doctorID = " + did.ToString() +
                                       " AND shedule.weekdayID = " + wday.ToString() + ";";

                SqlCommand com = new SqlCommand(selectcommand, Global.dbConnection);
                SqlDataReader dr = com.ExecuteReader();

                TimeSpan tbegin = new TimeSpan();
                TimeSpan tend = new TimeSpan();
                if (dr.HasRows)
                {
                    dr.Read();
                    tbegin = dr.GetTimeSpan(dr.GetOrdinal("tbegin"));
                    tend = dr.GetTimeSpan(dr.GetOrdinal("tend"));
                }
                else
                {
                    btnAdd.Enabled = false;
                    dr.Close();
                    return false;
                }
                dr.Close();


                // Получим время одного приёма для выбранного врача
                selectcommand = "SELECT doctors.apptime FROM doctors " +
                                "WHERE doctors.doctorID = " + did.ToString() + ";";

                com = new SqlCommand(selectcommand, Global.dbConnection);
                dr = com.ExecuteReader();

                TimeSpan apptime = new TimeSpan();
                dr.Read();
                apptime = dr.GetTimeSpan(dr.GetOrdinal("apptime"));
                dr.Close();

                // Получим время последнего назначенного приёма
                selectcommand = "SELECT * FROM (" +
                                        "SELECT MAX(tickets.ttime) as 'maxtime' FROM tickets " +
                                        "WHERE tickets.doctorID=" + did.ToString() + " AND tickets.tdate='" +
                                        dtPicker.Value.Date.ToString("yyyy-MM-dd") + "') rtbl " +
                                "WHERE rtbl.maxtime IS NOT NULL;";


                com = new SqlCommand(selectcommand, Global.dbConnection);

                dr = com.ExecuteReader();

                // Определим время следующего номерка
                TimeSpan tshed = new TimeSpan();
                tshed = tbegin;
                if (dr.HasRows) // уже есть номерки на этот день
                {
                    dr.Read();
                    tshed = dr.GetTimeSpan(dr.GetOrdinal("maxtime"));
                    if (tshed + apptime > tend) // но следующий уже не попадает в рабочее время
                    {
                        btnAdd.Enabled = false;
                        dr.Close();
                        return false;
                    }
                tshed = tshed + apptime;
                }
                
                dr.Close();

                ts = tshed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }

            return true;
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try { id = (int)cbDoctors.SelectedValue; }
            catch
            {
                dtPicker.Enabled = false;
                tBox.Text = "";
                btnAdd.Enabled = false;
                return;
            };
            if (id < 0)
            {
                dtPicker.Enabled = false;
                tBox.Text = "";
                btnAdd.Enabled = false;
                return;
            }

            dtPicker.Enabled = true;

            if (FindFreeTicket(ref TicketTime))
            {
                btnAdd.Enabled = true;
                tBox.Text = TicketTime.ToString();
            }
            else
            {
                btnAdd.Enabled = false;
                tBox.Text = "NOTICKET";
            }
        }


        // Первое появление формы
        private void fAddTicket_Shown(object sender, EventArgs e)
        {
            try
            {
                DS = new DataSet();
                DS.Tables.Add("doctors");
                SqlDataAdapter DASelect = new SqlDataAdapter();
                SqlCommand com = new SqlCommand();
                com.Connection = Global.dbConnection;

                String selectcommand = "SELECT patients.patientID, patients.lname + ' ' + patients.fname + ' ' " +
                                       "+ patients.mname as 'pname' FROM patients;";
                com.CommandText = selectcommand;
                DASelect.SelectCommand = new SqlCommand(selectcommand, Global.dbConnection);
                DASelect.Fill(DS, "patients");

                cbPatients.DataSource = DS.Tables["patients"];
                cbPatients.DisplayMember = "pname";
                cbPatients.ValueMember = "patientID";
                cbPatients.SelectedIndex = -1;

                cbDoctors.Enabled = false;
                cbDoctors.SelectedIndex = -1;
                dtPicker.Enabled = false;
                btnAdd.Enabled = false;
                tBox.Text = "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sqlIns = "INSERT INTO tickets VALUES (@doctorID, @patientID, @tdate, @ttime);";

            try
            {
                SqlCommand cmdIns = new SqlCommand(sqlIns, Global.dbConnection);
                cmdIns.Parameters.Add("@doctorID", SqlDbType.Int);
                cmdIns.Parameters["@doctorID"].Value = (int)cbDoctors.SelectedValue;

                cmdIns.Parameters.Add("@patientID", SqlDbType.Int);
                cmdIns.Parameters["@patientID"].Value = (int)cbPatients.SelectedValue;

                cmdIns.Parameters.Add("@tdate", SqlDbType.Date);
                cmdIns.Parameters["@tdate"].Value = dtPicker.Value.Date;

                cmdIns.Parameters.Add("@ttime", SqlDbType.Time);
                cmdIns.Parameters["@ttime"].Value = TicketTime;

                cmdIns.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString(), ex);
            }
            finally
            {
                Close();
            }
        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {
            if (FindFreeTicket(ref TicketTime))
            {
                btnAdd.Enabled = true;
                tBox.Text = TicketTime.ToString();
            }
            else
            {
                btnAdd.Enabled = false;
                tBox.Text = "NOTICKET";
            }

        }
    }
}
