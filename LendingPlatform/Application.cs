public class Application
{
    public int AssetValue { get; private set; }
    public int LoanAmount { get; private set; }
    public int CreditScore { get; private set; }
    public bool IsSuccess { get; private set; }

    public double LTV => (double)LoanAmount / (double)AssetValue;

    public Application(int loanAmount, int assetValue, int creditScore)
    {
        LoanAmount = loanAmount;
        AssetValue = assetValue;
        CreditScore = creditScore;
        IsSuccess = IsSuccessful();
    }

    private bool IsSuccessful()
    {
        // If the value of the loan is more than £1.5 million or less than £100,000 then the application must be declined
        if (LoanAmount > 1_500_000 || LoanAmount < 100_000)
        {
            return false;
        }

        // If the value of the loan is £1 million or more then the LTV must be 60% or less and the credit score of the applicant must be 950 or more
        if (LoanAmount >= 1_000_000 && LTV <= 0.6 && CreditScore >= 950)
        {
            return true;
        }

        // If the value of the loan is less than £1 million then the following rules apply
        if (LoanAmount <= 1_000_000)
        {
            // If the LTV is less than 60%, the credit score of the applicant must be 750 or more
            if (LTV <= 0.6)
            {
                return CreditScore >= 750;
            }

            // If the LTV is less than 80%, the credit score of the applicant must be 800 or more
            if (LTV <= 0.8)
            {
                return CreditScore >= 800;
            }

            // If the LTV is less than 90%, the credit score of the applicant must be 900 or more
            if (LTV <= 0.9)
            {
                return CreditScore >= 900;
            }

            // If the LTV is 90% or more, the application must be declined
            if (LTV >= 0.9)
                return false;
        }

        return false;
    }

    public override string ToString() => $"Loan Amount: {LoanAmount}, Asset Value: {AssetValue}, Credit Score: {CreditScore}, Success: {IsSuccess}";
}
