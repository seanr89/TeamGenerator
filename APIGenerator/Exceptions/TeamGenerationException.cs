

using System;

namespace APIGenerator.Exceptions
{
    /// <summary>
    /// Custom Exception type for Team Generation exceptions
    /// </summary>
    public class TeamGenerationException : Exception
    {
        public TeamGenerationException()
        { }

        public TeamGenerationException(string message)
            : base(message)
        { }

        public TeamGenerationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}