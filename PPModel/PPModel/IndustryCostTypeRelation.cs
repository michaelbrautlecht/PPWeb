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

        private List<IndustryCostTypeRelation> _childitems;
        private CostTypeItem _costtype;
        public CostTypeItem CostType {
            get { return _costtype; }
            set { _costtype = value;
                if(value.CostTypeUsage == CostTypeUsage.CostGroup)
                {
                    _childitems = new List<IndustryCostTypeRelation>();
                }
            }
        }

        private IndustryCostTypeRelation _parentitem;
        public IndustryCostTypeRelation ParentItem
        {
            get { return _parentitem; }
            set { _parentitem = value; }
        }

        public decimal PercentageShare { get; set; }
        public decimal CustomerPercentageShare { get; set; }

        public decimal PriceIndexChange { get; private set; }
        public decimal PriceIndexCustomerChange { get; private set; }

        public void UpdatePriceIndex()
        {
            if (_costtype.CostTypeUsage == CostTypeUsage.CostGroup)
            {
                decimal _piFrom = 0;
                decimal _piTo = 0;

                foreach (var item in _childitems)
                {
                    _piFrom += item.FromPublication.PriceIndex * item.PercentageShare / 100;
                    _piTo += item.ToPublication.PriceIndex * item.PercentageShare / 100;
                }


                PriceIndexChange = (_piTo - _piFrom) * 100 / _piTo;

                _piFrom = 0;
                _piTo = 0;

                foreach (var item in _childitems)
                {
                    _piFrom += item.FromPublication.PriceIndex * item.CustomerPercentageShare / 100;
                    _piTo += item.ToPublication.PriceIndex * item.CustomerPercentageShare / 100;
                }

                PriceIndexCustomerChange = (_piTo - _piFrom) * 100 / _piTo;
            }
            else
            {
                PriceIndexChange = (ToPublication.PriceIndex - FromPublication.PriceIndex) * 100 / ToPublication.PriceIndex;
                PriceIndexCustomerChange = PriceIndexChange;
            }
        }

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
