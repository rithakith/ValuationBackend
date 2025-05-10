namespace ValuationBackend.Models
{
    public class UserWorkSummaryResponse : Dictionary<string, int>
    {
        public UserWorkSummaryResponse() : base() { }

        public UserWorkSummaryResponse(IDictionary<string, int> dictionary) : base(dictionary) { }
    }
}
