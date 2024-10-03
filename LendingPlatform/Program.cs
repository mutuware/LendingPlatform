using LendingPlatform;

public class Program
{
    private static List<Application> _applications = []; // InMemory Collection rather than DB

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Lending Platform");
        Console.WriteLine("Enter [Loan Amount] [Asset Value] [Credit Score] e.g.");
        Console.WriteLine("200000 1000000 800");

        while (true)
        {
            Console.Write("> ");
            var command = Console.ReadLine() ?? "";
            var inputs = command.Split(' ');
            var application = new Application(int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2])); // TODO: Error handling
            _applications.Add(application);

            // Whether or not the applicant was successful
            Console.WriteLine("Application was " + (application.IsSuccess ? "succesful" : "failed"));

            var metrics = new Metrics(_applications);
            PrintMetrics(metrics);

            // Print all applicants
            Console.WriteLine("-------------");
            foreach (var app in _applications)
            {
                Console.WriteLine(app);
            }
            Console.WriteLine("-------------");
        }

    }
    private static void PrintMetrics(Metrics metrics)
    {
        Console.WriteLine($"Applicants by status: Total: {metrics.ApplicantsTotal}, Success: {metrics.ApplicantsSuccess}, Fail: {metrics.ApplicantsFail}");
        Console.WriteLine($"Total value of loans written to date {metrics.TotalLoans}");
        Console.WriteLine($"Average LTV:{metrics.AverageLTV}");
    }

}
