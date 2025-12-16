using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PPData.Models
{
    internal class CostType
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CostTypeName { get; set; }

    }
}
