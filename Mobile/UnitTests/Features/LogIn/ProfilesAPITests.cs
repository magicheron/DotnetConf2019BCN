using System.Threading.Tasks;
using NUnit.Framework;
using Refit;
using DotnetConf2019BCN.Mobile.Features.LogIn;
using DotnetConf2019BCN.Mobile.Features.Settings;
using DotnetConf2019BCN.Mobile.Helpers;
using UnitTests.Framework;

namespace UnitTests.Features.LogIn
{
#if !DEBUG
    [Ignore(Constants.IgnoreReason)]
#endif
    public class ProfilesAPITests : BaseAPITest
    {
        [Test]
        public async Task GetAsync()
        {
            var profileAPI = RestService.For<IProfilesAPI>(HttpClientFactory.Create(DefaultSettings.RootApiUrl));
            var profiles = await PreauthenticateAsync(() => profileAPI.GetAsync(authenticationBearer));

            Assert.IsNotEmpty(profiles);
        }
    }
}
