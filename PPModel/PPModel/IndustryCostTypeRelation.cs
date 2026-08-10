using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPModel
{
    public class IndustryCostTypeRelation
    {
        public IndustryItem Industry { get; set; }
        public Customer Customer { get; set; }
        public CostTypePublicationItem FromPublication { get; set; }
        public CostTypePublicationItem ToPublication { get; set; }

        public decimal PercentageShare { get; set; }
        public decimal CustomerPercentageShare { get; set; }

        public decimal EffectiveChange { 
            get {                 
                decimal result = 0;

                result = (ToPublication.PriceIndex - FromPublication.PriceIndex) * 100 / ToPublication.PriceIndex  * PercentageShare;

                return result;
            }

        }

        public decimal EffectiveCustomerChange
        {
            get
            {
                decimal result = 0;

                result = (ToPublication.PriceIndex - FromPublication.PriceIndex) * 100 / ToPublication.PriceIndex * CustomerPercentageShare;

                return result;
            }

        }
    }
}
