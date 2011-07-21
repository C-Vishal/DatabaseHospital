using System;
using System.Data;
//using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseHospital
{
    // Класс для глобальных переменных
    public sealed class Global
    {
        private static SqlConnection _dbCon;
        public static SqlConnection dbConnection
        {
            get { return _dbCon; }
            set { _dbCon = value; }
        }

        public static bool dbOpened
        {
            get { if (_dbCon.State == ConnectionState.Open) return true; else return false; }
        }

        private static string _dbserver;
        public static string dbServer
        {
            get { return _dbserver; }
            set { _dbserver = value; }
        }

        private static string _database;
        public static string DatabaseString
        {
            get { return _database; }
            set { _database = value; }
        }

        private static string _dbusername;
        public static string dbUser
        {
            get { return _dbusername; }
            set { _dbusername = value; }

        }

        private static string _dbpwd;
        public static string dbPassword
        {
            get { return _dbpwd; }
            set { _dbpwd = value; }
        }

        private static fLists _formLists;
        public static fLists formLists
        {
            get { return _formLists; }
            set { _formLists = value; }
        }

        private static fDoctorsAddr _formDocAddr;
        public static fDoctorsAddr formDoctorsAddr
        {
            get { return _formDocAddr; }
            set { _formDocAddr = value; }
        }

        private static fShedule _fShed;
        public static fShedule formShedule
        {
            get { return _fShed; }
            set { _fShed = value; }
        }

        private static fHistory _fHist;
        public static fHistory formHistory
        {
            get { return _fHist; }
            set { _fHist = value; }
        }

        private static fAddRecordHistory _fAddRec;
        public static fAddRecordHistory formAddRecord
        {
            get { return _fAddRec; }
            set { _fAddRec = value; }
        }

        private static fTickets _fTickets;
        public static fTickets formTickets
        {
            get { return _fTickets; }
            set { _fTickets = value; }
        }

        private static fAddTicket _fAddTicket;
        public static fAddTicket formAddTicket
        {
            get { return _fAddTicket; }
            set { _fAddTicket = value; }
        }

        private static fOptions _fOptions;
        public static fOptions formOptions
        {
            get { return _fOptions; }
            set { _fOptions = value; }
        }

        private static fStat _fStat;
        public static fStat formStat
        {
            get { return _fStat; }
            set { _fStat = value; }
        }
    
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fMain());
        }
    }
}
