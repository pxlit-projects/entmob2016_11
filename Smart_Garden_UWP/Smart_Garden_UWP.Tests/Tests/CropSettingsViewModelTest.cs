using Smart_Garden_UWP.Extensions;
using Smart_Garden_UWP.Services;
using Smart_Garden_UWP.Services.Interfaces;
using Smart_Garden_UWP.Tests.Mocks;
using Smart_Garden_UWP.ViewModels;
using Smart_Garden_UWP_Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Smart_Garden_UWP.Tests.Tests
{
    public class CropSettingsViewModelTest
    {

        ICropService cropService;

        public CropSettingsViewModelTest()
        {
            cropService = new MockCropService(new MockCropRepository());
        }

        
        [Fact]
        public void TestAllCropsLoaded()
        {
            //Arrange
            List<Crop> crops = null;
            ObservableCollection<Crop> expectedCrops = ListExtensions.ToObservableCollection(cropService.getAllCrops().Result);

            //Act
            var cropManagementViewModel = new CropSettingsViewModel(this.cropService, new NavigationService());
            cropManagementViewModel.GetAllCrops(null);
            while (crops == null)
            {
                crops = cropManagementViewModel.CropList;
            }

            

            //Assert
            Assert.Equal(ListExtensions.ToObservableCollection(crops), expectedCrops);
        }
        


        [Fact]
        public void TestCommand1NotNull()
        {
            var cropManagementViewModel = new CropSettingsViewModel(this.cropService, new NavigationService());

            Assert.NotNull(cropManagementViewModel.AddCropCommand);
        }

        [Fact]
        public void TestCommand2NotNull()
        {
            var cropManagementViewModel = new CropSettingsViewModel(this.cropService, new NavigationService());

            Assert.NotNull(cropManagementViewModel.DeleteCropCommand);
        }

        [Fact]
        public void TestCommand3NotNull()
        {
            var cropManagementViewModel = new CropSettingsViewModel(this.cropService, new NavigationService());

            Assert.NotNull(cropManagementViewModel.GetAllCropsCommand);
        }
    }
}
