namespace internship_consoleApp.models
{

    public class GlobalCOADataParameter
    {
        public string AccountCategory { get; set; }
        public string AccountHeader { get; set; }
        public string AccountSubHeader { get; set; }
        public string AssessmentClassification { get; set; }
        public string DrCrAllowed { get; set; }
        public string GLCode { get; set; }
        public string GLName { get; set; }
        public string GLRangeEnd { get; set; }
        public string GLRangeStart { get; set; }
        public string MainAccount { get; set; }
        public string ProjectionClassification { get; set; }
    }
    public class LineItem
    {
        public int COAId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public List<GlobalCOADataParameter> GlobalCOAData { get; set; }
    }
    public class HeadSub
    {
        public string? COAHeadId { get; set; }
        public string? COAId { get; set; }
        public string? MainAccountId { get; set; }
        public string? LegalEntityTypeId { get; set; }
        public string? Name { get; set; }
        public bool? IsParent { get; set; } // Logic can be written here
        public string? ParentId { get; set; } // Logic can be written here
        public string? GLCode { get; set; }
        public string? GLRangeStart { get; set; }
        public string? GLRangeEnd { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        List<LineItem>? LineItems { get; set; }

    }
    public class COAs
    {
        public string? COAId { get; set; }
        public string? CountryId { get; set; }
        public string? LegalEntityTypeId { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }

        public List<HeadSub>? HeadSubs { get; set; }


    }
}
