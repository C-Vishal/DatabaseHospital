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
    public partial class fShedule : Form
    {
        DataSet DS = new DataSet();
        DateTimePicker[,] dt = new DateTimePicker[7, 2];
        NumericUpDown[] nup = new NumericUpDown[7];
        CheckBox[] cbs = new CheckBox[7];
        
        public fShedule()
        {
            InitializeComponent();

            dt[0, 0] = dt11; dt[0, 1] = dt12;
            dt[1, 0] = dt21; dt[1, 1] = dt22;
            dt[2, 0] = dt31; dt[2, 1] = dt32;
            dt[3, 0] = dt41; dt[3, 1] = dt42;
            dt[4, 0] = dt51; dt[4, 1] = dt52;
            dt[5, 0] = dt61; dt[5, 1] = dt62;
            dt[6, 0] = dt71; dt[6, 1] = dt72;

            nup[0] = num1; nup[1] = num2; nup[2] = num3;
            nup[3] = num4; nup[4] = num5; nup[5] = num6;
            nup[6] = num7;

            cbs[0] = checkBox1; cbs[1] = checkBox2;
            cbs[2] = checkBox3; cbs[3] = checkBox4;
            cbs[4] = checkBox5; cbs[5] = checkBox6;
            cbs[6] = checkBox7; 

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dt11.Enabled = !dt11.Enabled;
            dt12.Enabled = !dt12.Enabled;
            num1.Enabled = !num1.Enabled;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dt21.Enabled = !dt21.Enabled;
            dt22.Enabled = !dt22.Enabled;
            num2.Enabled = !num2.Enabled;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            dt31.Enabled = !dt31.Enabled;
            dt32.Enabled = !dt32.Enabled;
            num3.Enabled = !num3.Enabled;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            dt41.Enabled = !dt41.Enabled;
            dt42.Enabled = !dt42.Enabled;
            num4.Enabled = !num4.Enabled;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            dt51.Enabled = !dt51.Enabled;
            dt52.Enabled = !dt52.Enabled;
            num5.Enabled = !num5.Enabled;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            dt61.Enabled = !dt61.Enabled;
            dt62.Enabled = !dt62.Enabled;
            num6.Enabled = !num6.Enabled;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            dt71.Enabled = !dt71.Enabled;
            dt72.Enabled = !dt72.Enabled;
            num7.Enabled = !num7.Enabled;
        }

        private void fShedule_Shown(object sender, EventArgs e)
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

        private void SheduleStateEnable(int wid, TimeSpan tbegin, TimeSpan tend, int cab)
        {
            cbs[wid].Checked = true;
            dt[wid, 0].Value += tbegin;
            dt[wid, 1].Value += tend;
            nup[wid].Value = cab;
        }

        private void SheduleStateDisable(int wid)
        {
            cbs[wid].Checked = false;
            dt[wid, 0].Value = new DateTime(2000, 1, 1);
            dt[wid, 1].Value = new DateTime(2000, 1, 1);
            nup[wid].Value = 0;
        }

        private void cbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id;
            try { id = (int)cbDoctors.SelectedValue; }
            catch { return; };

            if (id > -1) BtnSave.Enabled = true;
            else BtnSave.Enabled = false;

            for (int i = 0; i < 7; i++) SheduleStateDisable(i);

            String selectcommand = "SELECT * FROM shedule WHERE shedule.doctorID = " + id + ";";

            SqlCommand com = new SqlCommand(selectcommand, Global.dbConnection);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                SheduleStateEnable(dr.GetInt32(dr.GetOrdinal("weekdayID")),
                                   dr.GetTimeSpan(dr.GetOrdinal("tbegin")),
                                   dr.GetTimeSpan(dr.GetOrdinal("tend")),
                                   dr.GetInt32(dr.GetOrdinal("cabnum")));
            }
            dr.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand();

            String commandText = "DELETE FROM shedule WHERE shedule.doctorID = " + cbDoctors.SelectedValue + ";";

            com.Connection = Global.dbConnection;
            com.CommandText = commandText;
            com.ExecuteNonQuery();

            for (int i = 0; i < 7; i++)
            {
                if (cbs[i].Checked)
                {
                    com.CommandText = "INSERT INTO shedule VALUES(" +
                                    cbDoctors.SelectedValue + "," +
                                    i + ",'" +
                                    dt[i, 0].Value.TimeOfDay.ToString() + "','" +
                                    dt[i, 1].Value.TimeOfDay.ToString() + "'," +
                                    nup[i].Value + ");";
                    com.ExecuteNonQuery();
                }
            }
        }




    }
}
