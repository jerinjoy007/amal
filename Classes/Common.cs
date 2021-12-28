using Gramboo;
using Gramboo.Controls;
using Gramboo.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Net;
using System.Xml;
using System.Collections.Specialized;
using NuGet;

 


namespace project.Classes
{
    public static class Common
    {
        public static string DbName = "";
        public static DataGridViewCellStyle  styl = new DataGridViewCellStyle();
        public static DataGridViewCellStyle hdrstyl = new DataGridViewCellStyle(); 
      

        public static double GetNextID(Gramboo.Database.Table table_name, string field_name, DataController dc, int company_id, int branchID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GEN.NEXTID";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@table_name", (table_name.DatabaseName.ToUpper() == dc.ConnectionProperties.DatabseName.ToUpper() ? "" : table_name.DatabaseName + ".") + table_name.OwnerName + "." + table_name.Name);
            cmd.Parameters.AddWithValue("@field_name", field_name);
            cmd.Parameters.AddWithValue("@company_ID", company_id);
            cmd.Parameters.AddWithValue("@branch_id", branchID);
            cmd.Parameters.AddWithValue("@ResValOut", 0);

            return Convert.ToDouble(dc.GetData(cmd).Tables[0].Rows[0][0]);
        }

        public static void FillProductCode(GrbComboBox cmb, DataController dc, int companyid, int branchid, DateTime date, string criteria = "")
        {
            using (SqlCommand cmd = new SqlCommand("Select * FROM STK.GetOrnamentStatus('" + date.ToString("dd-MMM-yyyy") + "'," + companyid + "," + branchid + ") " + (criteria.Trim().Length > 0 ? " WHERE " + criteria : "")))
            {
                using (DataTable dt = dc.GetData(cmd, "Prodcodes").Tables[0])
                {
                    cmb.DisplayMember = "ProdCode";
                    cmb.ValueMember = "ProdCodeId";
                    cmb.DataSource = dt;

                }
            }
        }




        public static bool ValidateDelete(string TableName, string validatequery)
        {
            switch (TableName)
            {
                case "":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }

            }
        }

        public static void  InsertTLog(string action,long userid, DataController dc)
        {

            dc.ExecuteSqlTransaction(new SqlCommand("Insert into SYST.TLog(Taction,Tdate,UserId) Values('"+ action +"','"+ DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss tt") +"',"+ userid +")"),"TLog");

        }
        
        
        public static void ExecuteCommand(string command)
        {

            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
       


        public static string GetNextVoucherNo(int VoucherType, DateTime VoucherDate, DataController dc, int company_id, int branchID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "NUM.GenerateVoucherNo";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@VchType", VoucherType);
            cmd.Parameters.AddWithValue("@VchDate", VoucherDate);
            cmd.Parameters.AddWithValue("@companyID", company_id);
            cmd.Parameters.AddWithValue("@branchid", branchID);
            cmd.Parameters.AddWithValue("@RETVALOUT", 0);

            return dc.GetData(cmd).Tables[0].Rows[0][0].ToString();
        }
       

        public static void SwitchCompany(int ToCompany, int ToBranch)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType().BaseType == typeof(Gramboo.Controls.GrbForm))
                {

                    ((GrbForm)frm).SwitchAccount(ToCompany, ToBranch);
                }
            }

        }
         
        public static DataGridViewCellStyle GetGridCellStyle()
        {
            //dgv.DefaultCellStyle.ForeColor = Color.Black;
            //dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Ariel", 9, FontStyle.Regular);
            //dgv.RowsDefaultCellStyle.Font = new Font("Ariel", 9, FontStyle.Regular);
            styl.Font =new System.Drawing.Font("Ariel",8,System.Drawing.FontStyle.Regular);
            styl.ForeColor=System.Drawing.Color.Black ;
            
            return styl;
        }


         public static DataGridViewCellStyle GetGridHeaderCellStyle()
        {
            hdrstyl.Font=new System.Drawing.Font("Ariel",8,System.Drawing.FontStyle.Regular);
            return hdrstyl;
        }


      

        public static bool SetDatabaseLogon(ReportDocument cr, DataController DBConn, bool IsSubReport = false, bool VerifyDatabase = true)
        {
            for (int i = 0; i < cr.Database.Tables.Count; i++)
            {
                TableLogOnInfo logOnInfo = new TableLogOnInfo();

                logOnInfo = cr.Database.Tables[i].LogOnInfo;
                DBConn.ConnectionProperties.GenerateSQLConnectionString();
                // Set the connection information for the table in the report.
                logOnInfo.ConnectionInfo.ServerName = DBConn.ConnectionProperties.DatabseName;
                logOnInfo.ConnectionInfo.DatabaseName = DBConn.ConnectionProperties.DatabseName;
                logOnInfo.ConnectionInfo.UserID = DBConn.ConnectionProperties.DBUsername;
                logOnInfo.ConnectionInfo.Password = DBConn.ConnectionProperties.DBPassword;
                logOnInfo.TableName = cr.Database.Tables[i].Name;

                cr.Database.Tables[i].ApplyLogOnInfo(logOnInfo);

            }

            if (IsSubReport == false)
            {
                for (int i = 0; i < cr.Subreports.Count; i++)
                {

                    SetDatabaseLogon(cr.Subreports[i], DBConn, true);
                }
            }
            if(cr.DataSourceConnections.Count>0)
            cr.DataSourceConnections[0].SetConnection(DBConn.ConnectionProperties.DatabseName, DBConn.ConnectionProperties.DatabseName, DBConn.ConnectionProperties.DBUsername, DBConn.ConnectionProperties.DBPassword);
            try
            {
                if (VerifyDatabase)
                    cr.VerifyDatabase();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void EnableSpecs(int ItemId, System.Windows.Forms.DataGridViewCell Diawt,
             System.Windows.Forms.DataGridViewCell StWt, System.Windows.Forms.DataGridViewCell NetWt,
             System.Windows.Forms.DataGridViewCell Gwt, System.Windows.Forms.DataGridViewCell MC,
             System.Windows.Forms.DataGridViewCell MCPerc, System.Windows.Forms.DataGridViewCell WstPerc,
             System.Windows.Forms.DataGridViewCell Wst,System.Windows.Forms.DataGridViewCell Touch,
             DataController dc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ITM.EnableSpecs";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter DiaWt = new SqlParameter("@Diawt", DbType.Boolean);
            DiaWt.Direction = ParameterDirection.Output;

          //  SqlParameter PlkWt = new SqlParameter("@PlWt", DbType.Boolean);
           // PlkWt.Direction = ParameterDirection.Output;
            SqlParameter StoWt = new SqlParameter("@StWt", DbType.Boolean);
            StoWt.Direction = ParameterDirection.Output;
            SqlParameter NetWgt = new SqlParameter("@NetWt", DbType.Boolean);
            NetWgt.Direction = ParameterDirection.Output;
            SqlParameter Grwt = new SqlParameter("@Gwt", DbType.Boolean);
            Grwt.Direction = ParameterDirection.Output;
            SqlParameter mc = new SqlParameter("@MC", DbType.Boolean);
            mc.Direction = ParameterDirection.Output;
            SqlParameter mcperc = new SqlParameter("@McPerc", DbType.Boolean);
            mcperc.Direction = ParameterDirection.Output;
            SqlParameter wstp = new SqlParameter("@WstPerc", DbType.Boolean);
            wstp.Direction = ParameterDirection.Output;
            SqlParameter wst = new SqlParameter("@Wst", DbType.Boolean);
            wst.Direction = ParameterDirection.Output;
            SqlParameter Touh = new SqlParameter("@Touch", DbType.Boolean);
            Touh.Direction = ParameterDirection.Output;
           cmd.Parameters.AddWithValue("@ItemId", ItemId);
           cmd.Parameters.Add(DiaWt);
         //  cmd.Parameters.Add(PlWt);
           cmd.Parameters.Add(StoWt);
           cmd.Parameters.Add(NetWgt);
           cmd.Parameters.Add(Grwt);
           cmd.Parameters.Add(mc);
           cmd.Parameters.Add(mcperc);
           cmd.Parameters.Add(wstp);
           cmd.Parameters.Add(wst);
           cmd.Parameters.Add(Touh);  
           dc.GetData(cmd);
         

           Diawt.ReadOnly  = Convert.ToBoolean(cmd.Parameters["@Diawt"].Value);
          // PlWt.ReadOnly = Convert.ToBoolean(cmd.Parameters["@PlWt"].Value);
           StWt.ReadOnly= Convert.ToBoolean(cmd.Parameters["@StWt"].Value);
           NetWt.ReadOnly = Convert.ToBoolean(cmd.Parameters["@NetWt"].Value);
           Gwt.ReadOnly = Convert.ToBoolean(cmd.Parameters["@Gwt"].Value);
           MC.ReadOnly = Convert.ToBoolean(cmd.Parameters["@MC"].Value);
           MCPerc.ReadOnly = Convert.ToBoolean(cmd.Parameters["@McPerc"].Value);
           WstPerc.ReadOnly = Convert.ToBoolean(cmd.Parameters["@WstPerc"].Value);
           Wst.ReadOnly = Convert.ToBoolean(cmd.Parameters["@Wst"].Value);
           Touch.ReadOnly = Convert.ToBoolean(cmd.Parameters["@Touch"].Value);

           //sizerange.SelectedValue = -1;
           //PriceRange.SelectedValue = -1;
           //Sieve.SelectedValue = -1;
        }



        public static bool BackUpOrRestore(string BackupPath, string ServerName, string UserName, string Password, string DatabaseName, string Action)
        {

            ////try
            ////{

            ////    //if (Directory.Exists(BackupPath))
            ////    //{
            ////    //    //Connect to the local, default instance of SQL Server. 
            ////    Server srv = new Server(new ServerConnection(ServerName, UserName, Password));
            ////    srv.BackupDirectory = BackupPath;

            ////    //Reference the AdventureWorks2008R2 database. 
            ////    Database db = default(Database);
            ////    db = srv.Databases[DatabaseName];

            ////    //Store the current recovery model in a variable. 
            ////    int recoverymod;
            ////    recoverymod = (int)db.DatabaseOptions.RecoveryModel;

            ////    //Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file. 
            ////    BackupDeviceItem bdi = default(BackupDeviceItem);
            ////    bdi = new BackupDeviceItem(BackupPath + "\\" + DatabaseName + DateTime.Now.ToString("dd-MMM-yyyy")+".Bak", DeviceType.File);


            ////    if (Action == "Backup")
            ////    {




            ////        //Define a Backup object variable. 
            ////        Backup bk = new Backup();

            ////        //Specify the type of backup, the description, the name, and the database to be backed up. 
            ////        bk.Action = BackupActionType.Database;
            ////        bk.BackupSetDescription = "Full backup of " + DatabaseName;
            ////        bk.BackupSetName = DatabaseName + " Backup";
            ////        bk.Database = DatabaseName;


            ////        //Add the device to the Backup object. 
            ////        bk.Devices.Add(bdi);
            ////        //Set the Incremental property to False to specify that this is a full database backup. 
            ////        bk.Incremental = false;

            ////        //Set the expiration date. 
            ////        System.DateTime backupdate = new System.DateTime();
            ////        backupdate = new System.DateTime(2006, 10, 5);
            ////        bk.ExpirationDate = backupdate;

            ////        //Specify that the log must be truncated after the backup is complete. 
            ////        bk.LogTruncation = BackupTruncateLogType.Truncate;

            ////        //Run SqlBackup to perform the full database backup on the instance of SQL Server. 
            ////        bk.SqlBackup(srv);

            ////        //Inform the user that the backup has been completed. 
            ////        Console.WriteLine("Full Backup complete.");

            ////        //Remove the backup device from the Backup object. 
            ////        bk.Devices.Remove(bdi);

            ////        ////Make a change to the database, in this case, add a table called test_table. 
            ////        //Microsoft.SqlServer.Management.Smo.Table t = default(Microsoft.SqlServer.Management.Smo.Table);
            ////        //t = new Microsoft.SqlServer.Management.Smo.Table(db, "test_table");
            ////        //Microsoft.SqlServer.Management.Smo.Column c = default(Microsoft.SqlServer.Management.Smo.Column);
            ////        //c = new Microsoft.SqlServer.Management.Smo.Column(t, "col", DataType.Int);
            ////        //t.Columns.Add(c);
            ////        //t.Create();

            ////        ////Create another file device for the differential backup and add the Backup object. 
            ////        //BackupDeviceItem bdid = default(BackupDeviceItem);
            ////        //bdid = new BackupDeviceItem("Test_Differential_Backup1", DeviceType.File);

            ////        ////Add the device to the Backup object. 
            ////        //bk.Devices.Add(bdid);

            ////        ////Set the Incremental property to True for a differential backup. 
            ////        //bk.Incremental = true;

            ////        ////Run SqlBackup to perform the incremental database backup on the instance of SQL Server. 
            ////        //bk.SqlBackup(srv);

            ////        ////Inform the user that the differential backup is complete. 
            ////        //Console.WriteLine("Differential Backup complete.");

            ////        ////Remove the device from the Backup object. 
            ////        //bk.Devices.Remove(bdid);

            ////        return true;
            ////    }
            ////    //Delete the AdventureWorks2008R2 database before restoring it
            ////    // db.Drop();
            ////    else
            ////    {
            ////        //Define a Restore object variable.
            ////        Restore rs = new Restore();

            ////        //Set the NoRecovery property to true, so the transactions are not recovered. 
            ////        rs.NoRecovery = false;

            ////        //Add the device that contains the full database backup to the Restore object. 
            ////        rs.Devices.Add(bdi);

            ////        //Specify the database name. 
            ////        rs.Database = DatabaseName;
            ////        srv.KillDatabase(MOD.Classes.Common.DbName);
            ////        //Restore the full database backup with no recovery. 
            ////        rs.SqlRestore(srv);

            ////        //Inform the user that the Full Database Restore is complete. 
            ////        Console.WriteLine("Full Database Restore complete.");

            ////        //reacquire a reference to the database
            ////        db = srv.Databases[DatabaseName];

            ////        //Remove the device from the Restore object.
            ////        rs.Devices.Remove(bdi);

            ////        //Set the NoRecovery property to False. 
            ////        rs.NoRecovery = false;

            ////        ////Add the device that contains the differential backup to the Restore object. 
            ////        //rs.Devices.Add(bdid);

            ////        ////Restore the differential database backup with recovery. 
            ////        //rs.SqlRestore(srv);

            ////        ////Inform the user that the differential database restore is complete. 
            ////        //Console.WriteLine("Differential Database Restore complete.");

            ////        ////Remove the device. 
            ////        //rs.Devices.Remove(bdid);

            ////        ////Set the database recovery mode back to its original value.
            ////        //db.RecoveryModel = (RecoveryModel)recoverymod;

            ////        ////Drop the table that was added. 
            ////        //db.Tables["test_table"].Drop();
            ////        //db.Alter();

            ////        //Remove the backup files from the hard disk.
            ////        ////This location is dependent on the installation of SQL Server
            ////        //File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.MSSQLSERVER\\MSSQL\\Backup\\Test_Full_Backup1");
            ////        //File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.MSSQLSERVER\\MSSQL\\Backup\\Test_Differential_Backup1");

            ////        return true;
            ////    }
            ////}

            try
            {

                //if (Directory.Exists(BackupPath))
                //{
                //    //Connect to the local, default instance of SQL Server. 
                Server srv = new Server(new ServerConnection(ServerName, UserName, Password));
                srv.BackupDirectory = BackupPath;

                //Reference the AdventureWorks2008R2 database. 
                Microsoft.SqlServer.Management.Smo.Database db = default(Microsoft.SqlServer.Management.Smo.Database);
                db = srv.Databases[DatabaseName];

                //Store the current recovery model in a variable. 
                int recoverymod;
                recoverymod = (int)db.DatabaseOptions.RecoveryModel;

                //Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file. 
                BackupDeviceItem bdi = default(BackupDeviceItem);


                if (Action == "Backup")
                {



                    bdi = new BackupDeviceItem(BackupPath + "\\" + DatabaseName + DateTime.Now.ToString("dd-MMM-yyyy") + ".Bak", DeviceType.File);

                    //Define a Backup object variable. 
                    Backup bk = new Backup();

                    //Specify the type of backup, the description, the name, and the database to be backed up. 
                    bk.Action = BackupActionType.Database;
                    bk.BackupSetDescription = "Full backup of " + DatabaseName;
                    bk.BackupSetName = DatabaseName + " Backup";
                    bk.Database = DatabaseName;


                    //Add the device to the Backup object. 
                    bk.Devices.Add(bdi);
                    //Set the Incremental property to False to specify that this is a full database backup. 
                    bk.Incremental = false;

                    //Set the expiration date. 
                    System.DateTime backupdate = new System.DateTime();
                    backupdate = new System.DateTime(2006, 10, 5);
                    bk.ExpirationDate = backupdate;

                    //Specify that the log must be truncated after the backup is complete. 
                    bk.LogTruncation = BackupTruncateLogType.Truncate;

                    //Run SqlBackup to perform the full database backup on the instance of SQL Server. 
                    bk.SqlBackup(srv);

                    //Inform the user that the backup has been completed. 
                    Gramboo.General.ShowMessage("Full Backup complete.");

                    //Remove the backup device from the Backup object. 
                    bk.Devices.Remove(bdi);

                    ////Make a change to the database, in this case, add a table called test_table. 
                    //Microsoft.SqlServer.Management.Smo.Table t = default(Microsoft.SqlServer.Management.Smo.Table);
                    //t = new Microsoft.SqlServer.Management.Smo.Table(db, "test_table");
                    //Microsoft.SqlServer.Management.Smo.Column c = default(Microsoft.SqlServer.Management.Smo.Column);
                    //c = new Microsoft.SqlServer.Management.Smo.Column(t, "col", DataType.Int);
                    //t.Columns.Add(c);
                    //t.Create();

                    ////Create another file device for the differential backup and add the Backup object. 
                    //BackupDeviceItem bdid = default(BackupDeviceItem);
                    //bdid = new BackupDeviceItem("Test_Differential_Backup1", DeviceType.File);

                    ////Add the device to the Backup object. 
                    //bk.Devices.Add(bdid);

                    ////Set the Incremental property to True for a differential backup. 
                    //bk.Incremental = true;

                    ////Run SqlBackup to perform the incremental database backup on the instance of SQL Server. 
                    //bk.SqlBackup(srv);

                    ////Inform the user that the differential backup is complete. 
                    //Console.WriteLine("Differential Backup complete.");

                    ////Remove the device from the Backup object. 
                    //bk.Devices.Remove(bdid);

                    return true;
                }


                //Delete the AdventureWorks2008R2 database before restoring it
                // db.Drop();
                else
                {
                    //Define a Restore object variable.
                    Restore rs = new Restore();
                    bdi = new BackupDeviceItem(BackupPath  , DeviceType.File);

                    //Set the NoRecovery property to true, so the transactions are not recovered. 
                    rs.NoRecovery = false;

                    //Add the device that contains the full database backup to the Restore object. 
                    rs.Devices.Add(bdi);

                    //Specify the database name. 
                    rs.Database = DatabaseName;
                    srv.KillDatabase(project.Classes.Common.DbName);
                    //Restore the full database backup with no recovery.  
                    rs.SqlRestore(srv);

                    //Inform the user that the Full Database Restore is complete. 
                   Gramboo.General.ShowMessage ("Full Database Restore complete.");

                    //reacquire a reference to the database
                    db = srv.Databases[DatabaseName];

                    //Remove the device from the Restore object.
                    rs.Devices.Remove(bdi);

                    //Set the NoRecovery property to False. 
                    rs.NoRecovery = false;

                    ////Add the device that contains the differential backup to the Restore object. 
                    //rs.Devices.Add(bdid);

                    ////Restore the differential database backup with recovery. 
                    //rs.SqlRestore(srv);

                    ////Inform the user that the differential database restore is complete. 
                    //Console.WriteLine("Differential Database Restore complete.");

                    ////Remove the device. 
                    //rs.Devices.Remove(bdid);

                    ////Set the database recovery mode back to its original value.
                    //db.RecoveryModel = (RecoveryModel)recoverymod;

                    ////Drop the table that was added. 
                    //db.Tables["test_table"].Drop();
                    //db.Alter();

                    //Remove the backup files from the hard disk.
                    ////This location is dependent on the installation of SQL Server
                    //File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.MSSQLSERVER\\MSSQL\\Backup\\Test_Full_Backup1");
                    //File.Delete("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.MSSQLSERVER\\MSSQL\\Backup\\Test_Differential_Backup1");

                    return true;
                }
            }
            catch (Exception ex)
            {
                Gramboo.General.ShowMessage(ex.Message, "Error", MessageBoxIcon.Error, MessageBoxButtons.OK);
                return false;
            }
            //}

            //    else
            //    {
            //    return false;
            //}
        }

        // public static string SendSMS(DataController dc, string template, long refid, int company_id)
        //{

        //using (DataTable dt = dc.GetData(new SqlCommand("Select * from [SYST].[GetSmsString]('"Welcome","110100000003", "101"') "), "tbl").Tables[0])
        // using (DataTable dt = dc.GetData(new SqlCommand("Select * from [SYST].[GetSmsString]('" + template + "'," + refid + "," + company_id + ") "), "tbl").Tables[0])
        // {

        //   string Mobno, Message, Response = "";
        //  foreach (DataRow row in dt.Rows)
        //  {

        // Mobno = (row["MobNo"] == DBNull.Value ? "" : row["MobNo"].ToString());
        // Message = "HAI it is texting massage from our project :-project k ";// (row["CMessage"] == DBNull.Value ? "" : row["CMessage"].ToString());
        // Mobno = "919349823192";
        //Message = Message.Replace("&", "%26").Replace(" ", "%20");
        // HttpWebRequest request = WebRequest.Create("https://api.textlocal.in/send/?api_key=WWd4QiuHPmw-o0sG75UDNrrVLTRJtEATGCUR05srOy&method=sms&message=" + Message + "&to=" + Mobno + "&sender=project&format=xml") as HttpWebRequest;
        // HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        // Stream stream = response.GetResponseStream();
        // StreamReader reader = new StreamReader(stream, Encoding.UTF8);
        // String responseString = reader.ReadToEnd();
        // XmlDocument doc = new XmlDocument();
        // doc.LoadXml(responseString);
        // XmlElement root = doc.DocumentElement;
        // XmlNodeList nodes = root.SelectNodes("status");
        // foreach (XmlElement node in nodes)
        // {
        // Console.WriteLine(node.Name + ":" + node.InnerText);
        //    Response = node.InnerText;
        // }

        //  }
        // return Response;
        // }
        //  } 

        public static string SendSMS()
        {
            String message = "HAI it is texting massage from our project :-project k  kiran did you got it???";
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "WWd4QiuHPmw-o0sG75UDNrrVLTRJtEATGCUR05srOy"},
                {"numbers" , "919526654150"},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
        internal static void GetSupplierBalance(DateTime dateTime, int p1, DataController DBConn, int p2, int p3, ref float wtbal, ref double cashbal, ref double mcbal)
        {
            throw new NotImplementedException();
        }
    }
}
