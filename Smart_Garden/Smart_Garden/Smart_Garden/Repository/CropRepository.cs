using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden.Repository.Interfaces;
using Smart_Garden.Models;

namespace Smart_Garden.Repository
{
    public class CropRepository : ICropRepository
    {
        public Task<bool> addCrop(Crop crop)
        {
            throw new NotImplementedException();
        }

        public Task<bool> deleteCrop(Crop crop)
        {
            throw new NotImplementedException();
        }

        public Task<List<Crop>> getAllCrops()
        {
            throw new NotImplementedException();
        }

        public Task<Crop> getCropByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
