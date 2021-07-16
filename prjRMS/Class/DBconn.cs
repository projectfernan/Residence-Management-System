using ADODB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjRMS
{
    class DBconn
    {
        public delegate void MainDbStat(bool DbStat);
        public event MainDbStat RetStat;

        public Connection MySql = new Connection();
        public Recordset rs = new Recordset();

        public bool MySqlConn(string Host, string Uid, string Pwd, string DbName)
        {
            try
            {
                MakePing p = new MakePing();
                if (p.PingIp(Host)==false) 
                {
                    return false;
                }

                if (MySql.State == 1) 
                { 
                    MySql.Close(); 
                }

                MySql = new Connection();
                MySql.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                MySql.Open("Driver={MySQL ODBC 8.0 Unicode Driver}; "
                                          + "Server=" + Host + ";"
                                          + "Port=3306;"
                                          + "Option=3;"
                                          + "Database=" + DbName + ";"
                                          + "UID=" + Uid + ";"
                                          + "PWD=" + Pwd + ";character set=utf8;");
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ServerConn()
        { 
            try
            {
                MakePing p = new MakePing();
                if (p.PingIp(Properties.Settings.Default.Server) == false)
                {
                    if (RetStat != null)
                    {
                        RetStat(false);
                    }
                    return false;
                }

                if (MySql.State == 1) 
                { 
                    MySql.Close(); 
                }

                MySql = new Connection();
                MySql.CursorLocation = ADODB.CursorLocationEnum.adUseClient;
                MySql.Open("Driver={MySQL ODBC 8.0 Unicode Driver}; "
                                          + "Server=" + Properties.Settings.Default.Server + ";"
                                          + "Port=3306;"
                                          + "Option=3;"
                                          + "Database=" + Properties.Settings.Default.Database + ";"
                                          + "UID=" + Properties.Settings.Default.Uid + ";"
                                          + "PWD=" + Properties.Settings.Default.Pwd + ";character set=utf8;");
                if (RetStat != null)
                {
                    RetStat(true);
                }
                return true;
            }
            catch
            {
                if (RetStat != null)
                {
                    RetStat(false);
                }
                return false;
            }
        }

        public bool rsCUD(string query)
        {
            try
            {
                if (ServerConn())
                {
                    object ra;
                    rs = MySql.Execute(query,out ra,(int)CommandTypeEnum.adCmdText);
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to connect to server!","Recordset Query",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
