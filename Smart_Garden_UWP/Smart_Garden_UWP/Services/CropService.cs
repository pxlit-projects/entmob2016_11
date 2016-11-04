using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP_Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Garden_UWP.Services
{
    public class CropService : ICropService
    {
        private CropRepository cropRepository = new CropRepository();

        public async Task<Boolean> addCrop(Crop crop)
        {
            return await cropRepository.addCrop(crop);
        }

        public async Task<Boolean> deleteCrop(Crop crop)
        {
            return await cropRepository.deleteCrop(crop);
        }

        public async Task<List<Crop>> getAllCrops()
        {
            return await cropRepository.getAllCrops();
        }

        public async Task<Crop> getCropByName(String name)
        {
            return await cropRepository.getCropByName(name);
        }
    }
}
