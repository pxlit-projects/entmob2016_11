using Smart_Garden_UWP_Repo.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;

namespace Smart_Garden_UWP.Tests.Mocks
{
    class MockCropRepository : ICropRepository
    {
        List<Crop> cropList;

        public MockCropRepository()
        {
            loadData();
        }

        private void loadData()
        {
            cropList = new List<Crop> { new Crop { Id = 1, Temperature = 5, Humidity = 7, Light = 8, Name = "Wortelen", FinalDate = DateTime.Now },
                                        new Crop { Id = 2, Temperature = 5, Humidity = 7, Light = 8, Name = "Rode kool", FinalDate = DateTime.Now },
                                        new Crop { Id = 3, Temperature = 5, Humidity = 7, Light = 8, Name = "Broccoli", FinalDate = DateTime.Now }};
        }

        public Task<bool> addCrop(Crop crop)
        {
            cropList.Add(crop);
            Task<Boolean> task = Task.Factory.StartNew(() => true);
            return task;
        }

        public Task<bool> deleteCrop(Crop crop)
        {
            cropList.Remove(crop);
            Task<Boolean> task = Task.Factory.StartNew(() => true);
            return task;
        }

        public Task<List<Crop>> getAllCrops()
        {
            Task<List<Crop>> task = Task.Factory.StartNew(() => cropList);
            return task;
        }

        public Task<Crop> getCropByName(string name)
        {
            Task<Crop> task = Task.Factory.StartNew(() => cropList.Find(x => x.Name.Equals(name)));
            return task;
        }
    }
}
