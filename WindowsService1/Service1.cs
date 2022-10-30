using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //thực hiện công việc cần làm.
            /// đọc thông tin máy
            /// Kiếm tra trong csdl , có thì update, chưa thì insert.
            
            DateTime dte = DateTime.Now;
            if (dte.Hour == 9 || dte.Hour == 15)
            {
                TestingApp.Program program = new TestingApp.Program();
                program.DisplayTimeEvent();
            }
        }

        protected override void OnStop()
        {
        }
    }
}
