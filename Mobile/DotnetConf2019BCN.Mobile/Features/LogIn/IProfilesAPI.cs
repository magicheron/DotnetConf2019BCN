using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using DotnetConf2019BCN.Mobile.Features.Settings;

namespace DotnetConf2019BCN.Mobile.Features.LogIn
{
    public interface IProfilesAPI
    {
        [Get("/profiles")]        
        Task<IEnumerable<ProfileDTO>> GetAsync(
            [Header(DefaultSettings.ApiAuthorizationHeader)] string authorizationHeader);
    }
}
