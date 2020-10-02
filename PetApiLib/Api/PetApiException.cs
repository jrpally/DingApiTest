using System;

namespace PetApiLib.Api
{
    public class PetApiException : Exception
    {  
        public int ErrorCode { get; set; }

        public dynamic ErrorContent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PetApiException"/> class.
        /// </summary>
        public PetApiException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PetApiException"/> class.
        /// </summary>
        /// <param name="errorCode">HTTP status code.</param>
        /// <param name="message">Error message.</param>
        public PetApiException(int errorCode, string message) : base(message)
        {
            this.ErrorCode = errorCode;
        }
    }
}