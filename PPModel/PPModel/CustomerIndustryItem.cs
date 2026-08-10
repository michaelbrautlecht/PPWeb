using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPModel
{
    public class CustomerIndustryItem : IndustryItem
    {
        public string CustomerIndustryKey { get; set; }
       
        public string CustomerIndustryName { get; set; }

        public int EmployeeCount { get; set; }
    }
}
