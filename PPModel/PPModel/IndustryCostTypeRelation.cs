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
        public CustomerItem Customer { get; set; }
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

        public int? ParentId { get; private set; }
        private IndustryCostTypeRelation _parentitem;
        public IndustryCostTypeRelation ParentItem
        {
            get { return _parentitem; }
            set { 
                _parentitem = value;
                _parentitem.UpdatePriceIndex();
            }
        }

        public decimal PercentageShare { get; private set; }

        private decimal _CustomerPercentageShare;
        public decimal CustomerPercentageShare {
            get { return _CustomerPercentageShare;  } 
            set { 
                _CustomerPercentageShare = value;
                _parentitem?.UpdatePriceIndex();
            } 
        }

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

        public void Init(int iCostTypeId, string sCostTypeCode, string sCostTypeName, CostTypeUsage eCostTypeUsage, int? iParentId, decimal dPercentageShare)
        {
            _costtype = new CostTypeItem();
            _costtype.CostTypeId = iCostTypeId;
            _costtype.CostTypeCode = sCostTypeCode;
            _costtype.CostTypeUsage = eCostTypeUsage;
            _costtype.CostTypeName = sCostTypeName;

            ParentId = iParentId;
            PercentageShare = dPercentageShare;
        }

        public void Init(int iCostTypeId, string sCostTypeCode, string sCostTypeName, CostTypeUsage eCostTypeUsage, int? iParentId, decimal dPercentageShare, decimal dCustomerPercentageShare)
        {
            Init(iCostTypeId, sCostTypeCode, sCostTypeName, eCostTypeUsage, iParentId, dPercentageShare);
            CustomerPercentageShare = dCustomerPercentageShare;
        }

        public void AddPriceIndizies(decimal dPriceIndexFrom, decimal dPriceIndexTo)
        {
            PriceIndexChange = 0;
            PriceIndexCustomerChange = 0;

            if (dPriceIndexFrom != 0)
            {
                PriceIndexChange = (dPriceIndexTo - dPriceIndexFrom) * 100 / dPriceIndexFrom;
                PriceIndexCustomerChange = PriceIndexChange;
            }
        }

        public void AddPriceIndizies(decimal dPriceIndexFrom, decimal dPriceIndexTo, decimal dPriceIndexCustomerFrom, decimal dPriceIndexCustomerTo)
        {
            AddPriceIndizies(dPriceIndexFrom, dPriceIndexTo);
            if (dPriceIndexCustomerFrom != 0)
            {
                PriceIndexCustomerChange = (dPriceIndexCustomerTo - dPriceIndexCustomerFrom) * 100 / dPriceIndexCustomerFrom;
            }

        }
    }
}
