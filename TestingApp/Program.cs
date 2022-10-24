using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using baileysoft.Wmi;
using MySql.Data.MySqlClient;

namespace TestingApp
{
    public class InstalledApp
    {
        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
        public string InstallDate { get; set; }
        public string Product { get; set; }
    }
    class Program
    {
        StringBuilder sb = new StringBuilder();
        //AccessIni.GetPrivateProfileString("CONFIG", "URL", "", sb, 150, iniPath);
        //        string dbHost = sb.ToString().Trim();
        //AccessIni.GetPrivateProfileString("CONFIG", "DB_User", "", sb, 150, iniPath);
        //        string dbUser = sb.ToString().Trim();
        //AccessIni.GetPrivateProfileString("CONFIG", "DB_Password", "", sb, 150, iniPath);
        //        string dbPassword = sb.ToString().Trim();
        //AccessIni.GetPrivateProfileString("CONFIG", "DB_Name", "", sb, 150, iniPath);
        //        string dbName = sb.ToString().Trim();
        /* [DllImport("kernel32.dll")]
         static extern IntPtr GetConsoleWindow();
         [DllImport("user32.dll")]
         static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
         const int SW_HIDE = 0;
         const int SW_SHOW = 5;
         IntPtr hWnd = FindWindow(null, "Your console windows caption");
         // Usage:
         //  private handle = GetConsoleWindow();

         // Hide
         ShowWindow(hWnd, SW_HIDE);

         // Show
         // ShowWindow(extern, SW_SHOW);
         */
        /* //----Đạt tạm khóa---- 
       private string databaseName = "getlistapp";
       string constring = "Server=localhost; database= getlistapp; UID=root; password=123456; SslMode = none;Allow User Variables=True;Character Set=UTF8";
       MySqlConnection conn =new MySqlConnection(constring);
       conn.Open();
       string query = "select * from employee";
       // connection = new MySqlConnection(connstring);
       connection.Open();
       }
       catch 
       {

       }
       */
        public string sqlstr = "";
        public string Manufacturer = "";
       // public string Manufacture = "";
        public  string Product = "";
        public string SerialNumber = "";
        private string databaseName = "getlistapp";
        static string connection = "SERVER=localhost; UID=root; password=123456; database=getlistapp;SslMode = none;Allow User Variables=True;Character Set=UTF8";
        string strSQLInsert = "";
        /* private void Form1;_Load(object sender, System.EventArgs e)
         {
             checkifconnected();
         }
         */
        /*
        public void checkifconnected()
        {
            MySqlConnection connect = new MySqlConnection(connection);
            try
            {
                connect.Open();
                Console.WriteLine("Database connected");
            }
            catch
            {
                Console.WriteLine("you are not connected to database");
            }
        }
        */
        MySqlConnection connec = new MySqlConnection(connection);
        //public CSharp_MySQL_Insert()
        //{
        //    InitializeComponent();
        //}
        static void InsertDatabase(string strSQLInsert)
        {
            MySqlConnection connec = new MySqlConnection(connection);
            //  var dbCon1 = ConnectMySQL.Instance();
            // string strSQLInsert = "INSERT INTO computer_configuration (ID_Computer,Battery,BIOS,DiskDrive,MemoryDevice,PhysicalMemory,Processor,VideoController  ) VALUES (Manufacturer+, '" + 2 + "', '" +2 + "', '" + 2 + "')";
            //string strSQLInsert = "INSERT INTO computer_configuration (ID_Computer,Battery,BIOS) VALUES ('" + 2 + "', '" + 2 + "', '" + 2 + "')";
            //  MessageBox.Show(strSQLInsert); // @HoangDat Hiện ra câu Query truy vấn Databas
            //  string strSQLUpdate = "UPDATE lot_data SET BoardNo = '" + Convert.ToInt32(DataBoard) + "', Pcs = '" + Convert.ToInt32(DataPcs) + "' WHERE RouteStepPara ='" + txtRoute_Step_Para.Text.ToString() + "';";
            // richTextBox1.AppendText(strSQLUpdate + "\n");
            // string strSQLInsert = sqlstr;
            connec.Open();
            MySqlCommand command = new MySqlCommand(strSQLInsert, connec);
            int value = command.ExecuteNonQuery();
              Console.WriteLine(value.ToString());
            
           // var cmdUpdate = new MySqlCommand(strSQLInsert, dbCon1.Connection);
                //var readerUpdate = cmdUpdate.ExecuteReader();
                //readerUpdate.Close();
                //readerUpdate.Dispose();
                connec.Close();
            
        }


        static InstalledApp iapp = new InstalledApp();
        static string TextSlice(string str1, string str2)
        {
            string result = "";
            if (str1.IndexOf(str2) == 0)
            {
                result = str1.Replace(str2, "");
                Console.WriteLine(result);
            }
            return result;
        }
        static string TextSliceResult(string str1, string str2)
        {
            string result = "";
            if (str1.IndexOf(str2) == 0)
            {                
                result = str1.Replace(str2, "");              
            }

            return result;
        }
        public static void Main(string[] args)
        {
            string sqlstr = "INSERT INTO computer_configuration (ID_Computer,Battery,BIOS,DiskDrive,MemoryDevice,PhysicalMemory,Processor,VideoController) VALUES (";
            // InsertDatabase();
            // Doc cau hinh may tinh
            Connection wmiConnection = new Connection();
            Win32_BaseBoard a = new Win32_BaseBoard(wmiConnection);
          // string sqlstr = "INSERT INTO computer_configuration (ID_Computer,Battery,BIOS,DiskDrive,MemoryDevice,PhysicalMemory,Processor,VideoController) VALUES (";
            foreach (string property in a.GetPropertyValues())
            {
                //  Console.WriteLine(property);
                //Console.WriteLine("xxxxx"+m);
                if (TextSlice(property, "Manufacturer: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Manufacturer: ");
                    sqlstr = sqlstr.Replace(".", "");
                }
                //Console.WriteLine( property);
                if (TextSlice(property, "Product: ").Length > 0)
                {
                    sqlstr += "\n"+ TextSlice(property, "Product: ");
                }
                if (TextSlice(property, "SerialNumber: ").Length > 0)
                {
                    sqlstr += "\n"+ TextSlice(property, "SerialNumber: ");
                }
                //sqlstr +="\n"+ Product;
                //sqlstr +="\n" + SerialNumber+",";
            }
            //----@hoang dat: 
            sqlstr += ",";
            Win32_Battery b = new Win32_Battery(wmiConnection);
            Console.WriteLine("------| " + b.GetType().ToString() + " |------");
            foreach (string property in b.GetPropertyValues())
            {
                Console.WriteLine(property);
                // string Availability= TextSlice(property, "Availability: ");
                if (TextSlice(property, "Description: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Description: ");
                }
                if (TextSlice(property, "Name: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "Name: ");
                }
                if (TextSlice(property, "SystemName: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "SystemName: ");
                }
                
            }
            sqlstr += ",";
            //Loop all the properties
            Win32_BIOS c = new Win32_BIOS(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + c.GetType().ToString() + " |------");
            foreach (string property in c.GetPropertyValues())
            {
                Console.WriteLine(property);
                if (TextSlice(property, "Caption: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Caption: ");
                }
                if (TextSlice(property, "CurrentLanguage: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "CurrentLanguage: ");
                }
                if (TextSlice(property, "Version: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "Version: ");
                }
          
             // sqlstr += Caption + "\n" + CurrentLanguage + "\n" + Version + ",";
            }
            sqlstr += ",";
            Win32_DiskDrive f = new Win32_DiskDrive(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + f.GetType().ToString() + " |------");
            foreach (string property in f.GetPropertyValues())
            {
                Console.WriteLine(property);
                if (TextSlice(property, "Caption: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Caption: ");
                }
                if (TextSlice(property, "SerialNumber: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "SerialNumber: ");
                }
                //TextSlice(property, "CurrentLanguage: ");
                //TextSlice(property, "Description:");
                //TextSlice(property, "InstallableLanguages: ");
                //TextSlice(property, "Manufacturer: ");
                //TextSlice(property, "Name: ");
                //TextSlice(property, "SystemName: ");
            }
            sqlstr += ",";
            Win32_MemoryDevice n = new Win32_MemoryDevice(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + n.GetType().ToString() + " |------");
            foreach (string property in n.GetPropertyValues())
            {
                Console.WriteLine(property);
                //TextSlice(property, "EndingAddress: ");

                if (TextSlice(property, "EndingAddress: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "EndingAddress: ");
                }
                //string EndingAddress = TextSlice(property, "EndingAddress: ");
                //TextSlice(property, "Description:");
                //TextSlice(property, "InstallableLanguages: ");
                //TextSlice(property, "Manufacturer: ");
                //TextSlice(property, "Name: ");
                //TextSlice(property, "SystemName: ");
                //TextSlice(property, "SerialNumber: ");
            }
            sqlstr += ",";
            //Win32_MemoryDevice o = new Win32_MemoryDevice(wmiConnection);
            //Console.WriteLine("");
            //   Console.WriteLine("------| " + o.GetType().ToString() + " |------");
            //   foreach (string property in o.GetPropertyValues())
            //   {
            //       Console.WriteLine(property);
            //   }
            Win32_PhysicalMemory u = new Win32_PhysicalMemory(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + u.GetType().ToString() + " |------");
            foreach (string property in u.GetPropertyValues())
            {
                Console.WriteLine(property);
                if (TextSlice(property, "Capacity: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Capacity: ");
                }
                if (TextSlice(property, "Manufacturer: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "Manufacturer: ");
                }
                if (TextSlice(property, "SerialNumber: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "SerialNumber: ");
                }
               
                //sqlstr += Capacity + "\n" + Manufacturer + "\n" + SerialNumber + ",";
            }
            sqlstr += ",";
            Win32_Processor y = new Win32_Processor(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + y.GetType().ToString() + " |------");
            foreach (string property in y.GetPropertyValues())
            {
                //  Console.WriteLine(property);
                if (TextSlice(property, "Name: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Name: ");
                }
                //string name= TextSlice(property, "Name: ");
                //TextSlice(property, "ProcessorId: ");
                //TextSlice(property, "SocketDesignation:");
                //TextSlice(property, "SystemName: ");
               
            }
            sqlstr += ",";
            //Win32_SystemEnclosure dd = new Win32_SystemEnclosure(wmiConnection);
            //Console.WriteLine("");
            //Console.WriteLine("------| " + dd.GetType().ToString() + " |------");
            //foreach (string property in dd.GetPropertyValues())
            //{
            //   // Console.WriteLine(property);
            //    if (TextSlice(property, "SerialNumber: ").Length > 0)
            //    {
            //        sqlstr += TextSlice(property, "SerialNumber: ");
            //    }
            // //   string SerialNumber =  TextSlice(property, "SerialNumber: ");
                
            //}
            //sqlstr += ",";

            Win32_VideoController jj = new Win32_VideoController(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + jj.GetType().ToString() + " |------");
            foreach (string property in jj.GetPropertyValues())
            {
                // Console.WriteLine(property);
                if (TextSlice(property, "Caption: ").Length > 0)
                {
                    sqlstr += TextSlice(property, "Caption: ");
                }
                if (TextSlice(property, "Description: ").Length > 0)
                {
                    sqlstr += "\n" + TextSlice(property, "Description: ");
                }
                
              //  sqlstr += Caption + "\n" + Description ;
            }
            sqlstr += ")";
           string test=" INSERT INTO computer_configuration(ID_Computer, Battery, BIOS, DiskDrive, MemoryDevice, PhysicalMemory, Processor, VideoController) VALUES('" +"a"+ "', '" + "a" + "', '" + "a" + "', '" + "a" + "', '" + "a" + "', '" + "a" + "', '" + "a" + "', '" + "a" + "')";

           InsertDatabase(test);
            //  Doc danh sach phan mem da cai
            foreach (var item in GetFullListInstalledApplication())
            {
                Console.WriteLine(item.InstallDate + " --- " + item.DisplayName + " --- " + item.DisplayVersion);
            }

            Console.WriteLine(System.Environment.MachineName); // PC name
        /* ------Hoang Dat test connect MySQL 
         * string connection = "SERVER=localhost; UID=root; password=123456; database=getlistapp;SslMode = none;Allow User Variables=True;Character Set=UTF8";
            MySqlConnection connect = new MySqlConnection(connection);
            try
            {
                connect.Open();
                Console.WriteLine("Database connected");
            }
            catch
            {
                Console.WriteLine("you are not connected to database");
            }
        */
            Console.ReadLine();
            Console.ReadKey();
        }

        class PC_Configuration
        {
            public string Manufacturer { get; set; }
            public bool PoweredOn { get; set; }
            public string Caption { get; set; }
        }
        private static List<InstalledApp> GetFullListInstalledApplication()
        {
            IEnumerable<InstalledApp> finalList = new List<InstalledApp>();

            string registry_key_32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string registry_key_64 = @"SOFTWARE\WoW6432Node\Microsoft\Windows\CurrentVersion\Uninstall";

            List<InstalledApp> win32AppsCU = GetInstalledApplication(Registry.CurrentUser, registry_key_32);
            List<InstalledApp> win32AppsLM = GetInstalledApplication(Registry.LocalMachine, registry_key_32);
            List<InstalledApp> win64AppsCU = GetInstalledApplication(Registry.CurrentUser, registry_key_64);
            List<InstalledApp> win64AppsLM = GetInstalledApplication(Registry.LocalMachine, registry_key_64);

            finalList = win32AppsCU.Concat(win32AppsLM).Concat(win64AppsCU).Concat(win64AppsLM);

            finalList = finalList.GroupBy(d => d.DisplayName).Select(d => d.First());

            return finalList.OrderBy(o => o.DisplayName).ToList();
        }

        private static List<InstalledApp> GetInstalledApplication(RegistryKey regKey, string registryKey)
        {
            List<InstalledApp> list = new List<InstalledApp>();
            using (Microsoft.Win32.RegistryKey key = regKey.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    foreach (string name in key.GetSubKeyNames())
                    {
                        using (RegistryKey subkey = key.OpenSubKey(name))
                        {
                            string displayName = (string)subkey.GetValue("DisplayName");
                            string displayVersion = (string)subkey.GetValue("DisplayVersion");
                            string installDate = (string)subkey.GetValue("InstallDate");

                            if (!string.IsNullOrEmpty(displayName)) // && !string.IsNullOrEmpty(installLocation)
                            {
                                list.Add(new InstalledApp()
                                {
                                    DisplayName = displayName.Trim(),
                                    DisplayVersion = displayVersion,
                                    InstallDate = installDate
                                });
                            }
                        }
                    }
                }
            }

            return list;
        }

    }
}

