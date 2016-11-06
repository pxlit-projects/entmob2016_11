using Smart_Garden_UWP.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP_Repo.Repository.Interfaces;

namespace Smart_Garden_UWP.Tests.Mocks
{
    class MockCropService : ICropService
    {

        ICropRepository repository;

        public MockCropService(ICropRepository repository)
        {
            this.repository = repository;
        }

        public Task<bool> addCrop(Crop crop)
        {
            return repository.addCrop(crop);
        }

        public Task<bool> deleteCrop(Crop crop)
        {
            return repository.deleteCrop(crop);
        }

        public Task<List<Crop>> getAllCrops()
        {
            return repository.getAllCrops();
        }

        public Task<Crop> getCropByName(string name)
        {
            return repository.getCropByName(name);
        }
    }
}
