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
        List<Crop> getAllCrops();
        // Gets a crop by time of year
        List<Crop> getCropsByTimeOfYear();
        // Gets a crop by its name
        Crop getCropByName();

        // Adds a crop to the database
        void addCrop();
        // Deletes a crop from the database
        void deleteCrop();

    }
}