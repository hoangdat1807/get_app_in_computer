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
      
        public string sqlstr = "";
        public string Manufacturer = "";
       // public string Manufacture = "";
        public  string Product = "";
        public string SerialNumber = "";
        private string databaseName = "getlistapp";
        static string connection = "SERVER=localhost; UID=root; password=123456; database=getlistapp;SslMode = none;Allow User Variables=True;Character Set=UTF8";
        string strSQLInsert = "";
        public string INSERT_APP = "";
        public string id = "";
        
        MySqlConnection connec = new MySqlConnection(connection);
       
        static void InsertDatabase(string strSQLInsert)
        {
            MySqlConnection connec = new MySqlConnection(connection);
            connec.Open();
            MySqlCommand command = new MySqlCommand(strSQLInsert, connec);
            int value = command.ExecuteNonQuery();
             //Console.WriteLine(value.ToString());
            
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
                //Console.WriteLine(result);
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
           // string sqlstr = "INSERT INTO computer_configuration (Manufacture,ID_Computer,DiskDrive,MemoryDevice,PhysicalMemory,Processor,VideoController, Display1) VALUES (";
            // InsertDatabase();
            // Doc cau hinh may tinh
            string id = "";
            string Manufacturer = "";
            string DiskDrive = "";
            string Memory = "";
            string Capacity = "";
            string Processor = "";
            string Render = "";
            string Display1 = "";
            string Display2 = "";
            Connection wmiConnection = new Connection();
            Win32_BaseBoard a = new Win32_BaseBoard(wmiConnection);
            // string sqlstr = "INSERT INTO computer_configuration (ID_Computer,Battery,BIOS,DiskDrive,MemoryDevice,PhysicalMemory,Processor,VideoController) VALUES (";
         
            foreach (string property in a.GetPropertyValues())
            {
           //     Console.WriteLine(property);
                //Console.WriteLine("xxxxx"+m);
                if (TextSlice(property, "Manufacturer: ").Length > 0)
                {
                    //sqlstr += "'" + TextSlice(property, "Manufacturer: ");
                     Manufacturer  = TextSlice(property, "Manufacturer: ").Replace(".", "");
                }
                if (TextSlice(property, "SerialNumber: ").Length > 0)
                {
                     id = TextSlice(property, "SerialNumber: ");
                    Console.WriteLine(id);
                    //sqlstr += "'" + TextSlice(property, "SerialNumber: ");
                }

            }
            //----@hoang dat: 
            Console.WriteLine(id);
            
         /*   Win32_Battery b = new Win32_Battery(wmiConnection);
            Console.WriteLine("------| " + b.GetType().ToString() + " |------");
            foreach (string property in b.GetPropertyValues())
            {
                Console.WriteLine(property);
                // string Availability= TextSlice(property, "Availability: ");
                if (TextSlice(property, "Description: ").Length > 0)
                {
                    sqlstr += "'"+ TextSlice(property, "Description: ");
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
            
            sqlstr += "',";
            //Loop all the properties
            Win32_BIOS c = new Win32_BIOS(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + c.GetType().ToString() + " |------");
            foreach (string property in c.GetPropertyValues())
            {
                Console.WriteLine(property);
                if (TextSlice(property, "Caption: ").Length > 0)
                {
                    sqlstr += "'" + TextSlice(property, "Caption: ");
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
            sqlstr += "',";
            */
            Win32_DiskDrive f = new Win32_DiskDrive(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + f.GetType().ToString() + " |------");
            foreach (string property in f.GetPropertyValues())
            {
                Console.WriteLine(property);
                if (TextSlice(property, "Caption: ").Length > 0)
                {
                    DiskDrive = TextSlice(property, "Caption: ");
                    //sqlstr += "'" + TextSlice(property, "Caption: ");
                }
                //if (TextSlice(property, "SerialNumber: ").Length > 0)
                //{
                //    sqlstr += "\n" + TextSlice(property, "SerialNumber: ");
                //}
                //TextSlice(property, "CurrentLanguage: ");
                //TextSlice(property, "Description:");
                //TextSlice(property, "InstallableLanguages: ");
                //TextSlice(property, "Manufacturer: ");
                //TextSlice(property, "Name: ");
                //TextSlice(property, "SystemName: ");
            }
            
            Win32_MemoryDevice n = new Win32_MemoryDevice(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + n.GetType().ToString() + " |------");
            foreach (string property in n.GetPropertyValues())
            {
               // Console.WriteLine(property);
                //TextSlice(property, "EndingAddress: ");

                if (TextSlice(property, "EndingAddress: ").Length > 0)
                {
                   Memory = TextSlice(property, "EndingAddress: ");
                    //sqlstr += "'" + TextSlice(property, "EndingAddress: ");
                }
                //string EndingAddress = TextSlice(property, "EndingAddress: ");
                //TextSlice(property, "Description:");
                //TextSlice(property, "InstallableLanguages: ");
                //TextSlice(property, "Manufacturer: ");
                //TextSlice(property, "Name: ");
                //TextSlice(property, "SystemName: ");
                //TextSlice(property, "SerialNumber: ");
            }
          
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
                    Capacity= TextSlice(property, "Capacity: ");
                }
                //if (TextSlice(property, "Manufacturer: ").Length > 0)
                //{
                //    sqlstr += "\n" + TextSlice(property, "Manufacturer: ");
                //}
                //if (TextSlice(property, "SerialNumber: ").Length > 0)
                //{
                //    sqlstr += "\n" + TextSlice(property, "SerialNumber: ");
                //}

                //sqlstr += Capacity + "\n" + Manufacturer + "\n" + SerialNumber + ",";
            }
     
            Win32_Processor y = new Win32_Processor(wmiConnection);
            Console.WriteLine("");
            Console.WriteLine("------| " + y.GetType().ToString() + " |------");
            foreach (string property in y.GetPropertyValues())
            {
                  Console.WriteLine(property);
                if (TextSlice(property, "Name: ").Length > 0)
                {
                    Processor = TextSlice(property, "Name: ");
                }
                //string name= TextSlice(property, "Name: ");
                //TextSlice(property, "ProcessorId: ");
                //TextSlice(property, "SocketDesignation:");
                //TextSlice(property, "SystemName: ");
               
            }
            //sqlstr += "',";
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
            Console.WriteLine(jj.GetPropertyValues());
            foreach (string property in jj.GetPropertyValues())
            {
               Console.WriteLine(property);
                //@hoangdat: Caption : tên card đồ họa Render 
                //if (TextSlice(property, "Caption: ").Length > 0)
                //{
                //    sqlstr += "'" + TextSlice(property, "Caption: ");
                //}
                ////@hoangdat: Description : tên card đồ họa Render
                //if (TextSlice(property, "Description: ").Length > 0)
                //{
                //    sqlstr += "\n" + TextSlice(property, "Description: ");
                //}
                ////----@hoangdat :Name  tên card đồ họa Render và card màn hình 
                if (TextSlice(property, "Name: ").Length > 0)
                {
                    if (Render == "")
                    {
                        Render = TextSlice(property, "Name: ");
                    }
                    else
                    {
                        Display1 = TextSlice(property, "Name: ");
                    }
                    //sqlstr += ",'"+"\n" + TextSlice(property, "Name: ") + "'";
                }
                ////  sqlstr += Caption + "\n" + Description ;
            }
           string sqlstr = String.Format("INSERT INTO computer_configuration ( ID_Computer,Manufacture, DiskDrive, MemoryDevice, PhysicalMemory, Processor, Render, Display1 ) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')ON DUPLICATE KEY UPDATE  Manufacture = '{1}', DiskDrive='{2}', MemoryDevice='{3}', PhysicalMemory='{4}', Processor='{5}',  Render= '{6}', Display1='{7}';", id, Manufacturer, DiskDrive, Memory, Capacity, Processor, Render, Display1 );
         //   string INSERT_APP = String.Format("INSERT INTO list_app_installing ( ID_Computer,List_app_Installing, Version, Installation_Date ) VALUES ('{0}','{1}','{2}','{3}')ON DUPLICATE KEY UPDATE  Version = '{4}', Installation_Date='{5}';", id, item.DisplayName, item.DisplayVersion, item.InstallDate, item.DisplayVersion, item.InstallDate);
            InsertDatabase(sqlstr);
            //  Doc danh sach phan mem da cai
            //foreach (var item in GetFullListInstalledApplication())
            //{
            //    Console.WriteLine(item.InstallDate + " --- " + item.DisplayName + " --- " + item.DisplayVersion);
            //    string INSERT_APP = String.Format("INSERT INTO list_app_installing ( List_app_Installing, Version, Installation_Date ) VALUES ('{0}','{1}','{2}');", item.DisplayName, item.DisplayVersion, item.InstallDate);
            //    InsertDatabase(INSERT_APP);
            //}
            foreach (var item in GetFullListInstalledApplication())
            {
                Console.WriteLine(id);
                Console.WriteLine(item.InstallDate + " --- " + item.DisplayName + " --- " + item.DisplayVersion);

                //count= select (count*) from table where idcomputer= and listap = lisap

                //if (count>0)
                //{
                //    string INSERT_APP = String.Format("UPDATE SQL", id, item.DisplayName, item.DisplayVersion, item.InstallDate);
                //    InsertDatabase(INSERT_APP);
                //}
                //else
                //{
                    string INSERT_APP = String.Format("INSERT INTO list_app_installing ( ID_Computer,List_app_Installing, Version, Installation_Date ) VALUES ('{0}','{1}','{2}','{3}')ON DUPLICATE KEY UPDATE  Version = '{4}', Installation_Date='{5}';", id, item.DisplayName, item.DisplayVersion, item.InstallDate, item.DisplayVersion, item.InstallDate);
                    InsertDatabase(INSERT_APP);
                
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

