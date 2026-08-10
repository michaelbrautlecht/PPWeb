namespace PPModel
{
    public enum CostTypeUsage
    {
        Material,
        Energy,
        CostGroup
    }

    public class CostTypeItem
    {
        public int CostTypeId { get; set; }
        public string CostTypeCode { get; set; }
        public string CostTypeName { get; set; }
        public CostTypeUsage CostTypeUsage { get; set; }
    }
}
