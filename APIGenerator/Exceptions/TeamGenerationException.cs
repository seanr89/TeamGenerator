

using System;

namespace APIGenerator.Exceptions
{
    /// <summary>
    /// Custom Exception type for Team Generation exceptions
    /// </summary>
    public class TeamGenerationException : Exception
    {
        /// <summary>
        /// Base Constructor
        /// </summary>
        public TeamGenerationException()
        { }

        /// <summary>
        /// 2nd Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        public TeamGenerationException(string message)
            : base(message)
        { }

        /// <summary>
        /// 3rd Constructor
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <param name="innerException">Exception that was triggered</param>
        public TeamGenerationException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}