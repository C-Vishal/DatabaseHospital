using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    public partial class fMain : Form
    {
        // Начальная инициализация объектов и значений
        private void InitVars()
        {
            Global.dbConnection = new SqlConnection();
            Global.formLists = new fLists();
            Global.formLists.Owner = this;
            Global.formDoctorsAddr = new fDoctorsAddr();
            Global.formDoctorsAddr.Owner = this;
            Global.formShedule = new fShedule();
            Global.formShedule.Owner = this;
            Global.formHistory = new fHistory();
            Global.formHistory.Owner = this;
            Global.formAddRecord = new fAddRecordHistory();
            Global.formAddRecord.Owner = this;
            Global.formTickets = new fTickets();
            Global.formTickets.Owner = this;
            Global.formAddTicket = new fAddTicket();
            Global.formAddTicket.Owner = this;
            Global.formOptions = new fOptions();
            Global.formOptions.Owner = this;
            Global.dbServer         = "badmeat.no-ip.org";
            Global.DatabaseString   = "hospital_db";
            Global.dbUser           = "hospital";
            Global.dbPassword       = "hospital";
            Global.formStat = new fStat();
            Global.formStat.Owner = this;

        }

        public fMain()
        {
            InitializeComponent();
            InitVars();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (Global.dbOpened) DisconnectSqlServer();
            Application.Exit();
        }

        // Открытие соединения с SQL сервером ( успех - 0, ошибка - 1 )
        private bool ConnectSqlServer(string srv, string dbstring, string username, string pass)
        {
            Global.dbConnection.ConnectionString = "Server="+srv+";database="+dbstring+";User id="+username+";password="+pass+";";
            try
            {
                Global.dbConnection.Open();
                return false;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Number + ": " + ex.Message, "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
        }

        // Закрытие соединения с SQL сервером ( успех - 0, ошибка - 1 )
        private bool DisconnectSqlServer()
        {
            try
            {
                Global.dbConnection.Close();
                return false;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("ERROR " + ex.Number + ": " + ex.Message, "Ошибка!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
        }

        // Изменение состояния кнопок при подключении/отключении к серверу
        private void ChangeButtonsState()
        {
            btnConnect.Enabled = !btnConnect.Enabled;
            btnDisconnect.Enabled = !btnDisconnect.Enabled;
            btnLists.Enabled = !btnLists.Enabled;
            btnTickets.Enabled = !btnTickets.Enabled;
            btnHistory.Enabled = !btnHistory.Enabled;
            btnStat.Enabled = !btnStat.Enabled;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ConnectSqlServer(Global.dbServer, Global.DatabaseString, Global.dbUser, Global.dbPassword)) return;
            ChangeButtonsState();            
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (DisconnectSqlServer()) return;
            ChangeButtonsState();
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            Global.formLists.ShowDialog();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Global.formHistory.ShowDialog();
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            Global.formTickets.ShowDialog();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            Global.formOptions.ShowDialog();
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            Global.formStat.ShowDialog();
        }
    }
}
