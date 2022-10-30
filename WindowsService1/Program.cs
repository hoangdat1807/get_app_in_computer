using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
   public  class Program
    {
        public  Program()
        { }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static  void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
        public  void LayThongMay()
        {
            /// thực công việc lưu thông tin vào CSLD
            string a = "xin chao";
        }
    }
}
