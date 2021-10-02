using Cat.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cat.Web.Services
{
    public interface ICatService
    {
        /// <summary>
        /// Returns all the cat breeds
        /// </summary>
        /// <returns></returns>
        Task<IList<BreedModel>> GetBreeds();


        /// <summary>
        /// search for specific breeds
        /// </summary>
        /// <param name="breedName"></param>
        /// <returns></returns>
        Task<IList<BreedModel>> SearchBreed(string breedName);
    }
}
