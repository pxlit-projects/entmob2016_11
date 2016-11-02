using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP_Repo.Repository.Interfaces
{
    public interface ICropRepository
    {
        // Gets a list of all crops
        Task<List<Crop>> getAllCrops();
        // Gets a crop by its name
        Task<Crop> getCropByName(String name);
        // Adds a crop to the database
        Task<Boolean> addCrop(Crop crop);
        // Deletes a crop from the database
        Task<Boolean> deleteCrop(Crop crop);

    }
}