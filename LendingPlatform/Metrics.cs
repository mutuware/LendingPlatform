namespace LendingPlatform
{
    public class Metrics
    {
        public int ApplicantsTotal { get; }
        public int ApplicantsSuccess { get; }
        public int ApplicantsFail { get; }
        public int TotalLoans { get; }
        public double AverageLTV { get; }

        public Metrics(List<Application> applications)
        {
            ApplicantsTotal = applications.Count;
            ApplicantsSuccess = applications.Where(x => x.IsSuccess)?.Count() ?? 0;
            ApplicantsFail = applications.Where(x => !x.IsSuccess)?.Count() ?? 0;
            TotalLoans = applications.Where(x => x.IsSuccess).Sum(x => x.LoanAmount);
            AverageLTV = applications.Average(x => x.LTV);
        }
    }
}
