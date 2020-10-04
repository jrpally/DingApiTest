using NUnit.Framework;

namespace PetStoreTest.Base
{
    public static class Configuration
    {
        private static string _baseUrl;
        
        /// <summary>
        /// Return Base URL
        /// </summary>
        public static string BaseUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(_baseUrl))
                {
                    return _baseUrl;
                }

                if (!TestContext.Parameters.Exists("baseUrl"))
                    throw new System.ArgumentException(
                        $"The parameter 'baseUrl' was not found, please provide a value for this parameter.");
                TestContext.WriteLine("Hello");
                _baseUrl = TestContext.Parameters["baseUrl"];
                return _baseUrl;
            }
        }
    }
}