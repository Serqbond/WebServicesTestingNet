using NUnit.Framework;
using RestAPITests.Models.PlaceHolder;
using Framework.HttpUtils;
using System.Net;

namespace RestAPITests.Tests.Placeholdertests
{
    [TestFixture]
    public class JsonPlaceholderTests : FunctionalTest
    {
        private string PostEndpoint => "/posts";
        private string HostName => "https://jsonplaceholder.typicode.com";


        [Test]
        public void PostDataStausCodeCorrectTest()
        {
            restClient.SetNewHost(HostName);
            User user = new User() {Title = "foo", Body = "bar", UserId = 1 };

            var actualStatusCode = restClient
                .HttpPostRequest
                .PostResponseStatusCode(PostEndpoint, StringContentCreator.Create(user));

            Assert.AreEqual(HttpStatusCode.Created, actualStatusCode);
        }

        [Test]
        public void PostDataResponseIdTest()
        {
            restClient.SetNewHost(HostName);
            User user = new User() { Title = "foo", Body = "bar", UserId = 1 };

            var actualPostResponseId = restClient
                .HttpPostRequest
                .PostResponseAsBusinessEntity<PostResponseId>(PostEndpoint, StringContentCreator.Create(user));

            Assert.AreEqual(101, actualPostResponseId.Id);
        }
    }
}
