using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPModel
{
    public class CostTypePublicationItem
    {
        public PublicationItem Publication { get; set; }
        public CostTypeItem CostType { get; set; }

        public decimal PriceIndex { get; set; }
    }
}
