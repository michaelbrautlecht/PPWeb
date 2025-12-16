using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PPData.Models
{
    internal class CostGroup
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string CostGroupName { get; set; } = null!;

        public ICollection<CostType> CostTypes { get; set; }
    }
}
