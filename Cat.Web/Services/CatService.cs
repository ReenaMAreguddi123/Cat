using Cat.Web.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cat.Web.Services
{
    public class CatService : BaseService, ICatService
    {
        private IList<BreedModel> _breeds;

        public CatService(ILogger<CatService> logger) : base(logger)
        {

        }

        /// <summary>
        /// Returns all the cat breeds
        /// </summary>
        /// <returns></returns>
        public async Task<IList<BreedModel>> GetBreeds()
        {
            using (var httpClient = GetHttpClient())
            {
                //see if there is a cached version
                if (_breeds != null)
                    return await Task.FromResult(_breeds);

                Logger.LogDebug($"Calling {httpClient.BaseAddress.AbsoluteUri}breeds");

                var response = await httpClient.GetStringAsync("breeds");
                _breeds = JsonConvert.DeserializeObject<IList<BreedModel>>(response);

                Logger.LogDebug($"Total Breeds:{_breeds?.Count}");

                return await Task.FromResult(_breeds);
            }
        }

        /// <summary>
        /// search for specific breeds
        /// </summary>
        /// <param name="breedName">search parameter - breed name</param>
        /// <returns></returns>
        public async Task<IList<BreedModel>> SearchBreed(string breedName)
        {
            using (var httpClient = GetHttpClient())
            {
                Logger.LogDebug($"Calling {httpClient.BaseAddress.AbsoluteUri}breeds/search?q={breedName}");

                var response = await httpClient.GetStringAsync($"breeds/search?q={breedName}");
                var breeds = JsonConvert.DeserializeObject<IList<BreedModel>>(response);

                Logger.LogDebug($"Total search results:{breeds?.Count}");

                return breeds;
            }
        }
    }
}
