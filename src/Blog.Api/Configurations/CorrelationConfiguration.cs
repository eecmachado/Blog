namespace Blog.Api.Configurations
{
    public class CorrelationConfiguration
    {
        public const string Correlation = "Correlation";

        public string RequestHeader { get; set; }

        public bool AddToLoggingScope { get; set; }

        public bool UpdateTraceIdentifier { get; set; }
    }
}
