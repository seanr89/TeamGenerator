
namespace APIGenerator.Models.Utility
{
    /// <summary>
    /// Object model to handle the location and storage of all error message codes
    /// for the purpose of logging events
    /// </summary>
    public class LoggingEvents
    {
        public const int GENERIC_ERROR = 0001;

        public const int METHOD_CALL = 0002;

        public const int INFORMATION = 0003;
    }
}