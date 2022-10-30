using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp.API
{
    public class Call_API
    {
        public Call_API()
        {

        }

         

        public class Job
        {
            public Job(string name, string jobName)
            {
                Name = name;
                Job_Name = jobName;
            }
            public string Name { get; set; }
            public string Job_Name { get; set; }
        }
    }
}
