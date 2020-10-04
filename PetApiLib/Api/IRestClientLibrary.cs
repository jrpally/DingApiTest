namespace PetApiLib.Api
{
    public interface IRestClientLibrary
    {
        /// <summary>
        /// Post Client
        /// </summary>
        /// <typeparam name="T">Type of data to send</typeparam>
        /// <param name="body">Object to send</param>
        /// <param name="path">Current Path to send</param>
        void Post<T>(T body, string path);

        /// <summary>
        /// Perform a GET query to the server
        /// </summary>
        /// <typeparam name="T">Type parameter</typeparam>
        /// <param name="queryPath">Query</param>
        /// <returns>Object in the given type</returns>
        T Get<T>(string queryPath);

        /// <summary>
        /// Delete Verb
        /// </summary>
        /// <param name="queryPath">Query Path</param>
        /// <param name="key">Key to delete</param>
        void Delete(string queryPath);

        /// <summary>
        /// Update verb
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="body">Body / Object </param>
        /// <param name="queryPath">Query Path</param>
        void Update<T>(T body, string queryPath);

        /// <summary>
        /// Add Header to Request
        /// </summary>
        /// <param name="key">Header</param>
        /// <param name="value">Value</param>
        void AddHeader(string key, string value);
    }
}