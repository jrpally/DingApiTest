using NUnit.Framework;
using PetApiLib.Api;

namespace PetStoreTest.Base
{
    public class SwaggerTests
    {
        protected PetApi _petApi;

        [SetUp]
        public void SetupTest()
        {
            string webAppUrl = Configuration.BaseUrl;
            this._petApi = new PetApi(webAppUrl);
            
        }
    }
}