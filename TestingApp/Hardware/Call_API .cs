using System;
using System.Collections.Generic;
using System.Linq;
 
using System.Text;
using System.Threading.Tasks;

namespace API_SERVICE.Controllers
{
    public class TestCallApi
    {
       

        public TestCallApi()
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
