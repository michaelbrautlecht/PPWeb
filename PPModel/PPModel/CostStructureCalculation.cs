using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPModel
{
    public class CostStructureCalculation
    {
        public IndustryItem Industry {  get; set; }
        public CustomerItem Customer { get; set; }

        public PublicationItem PublicationFrom { get; set; }
        public PublicationItem PublicationTo { get; set; }

        public List<IndustryCostTypeRelation> CostTypeList { get; private set; }

        public void BuildTree()
        {

        }
    }
}
