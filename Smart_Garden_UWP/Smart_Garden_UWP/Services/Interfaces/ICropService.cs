using Smart_Garden_UWP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP.Services.Interfaces
{
    public interface ICropService
    {
        Task<Boolean> addCrop(Crop crop);

        Task<Boolean> deleteCrop(Crop crop);

        Task<List<Crop>> getAllCrops();

        Task<Crop> getCropByName(String name);
    }
}
