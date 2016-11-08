using System;
using System.Collections.Generic;
using System.ComponentModel;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP.Utilities;
using Smart_Garden_UWP.Services.Interfaces;

namespace Smart_Garden_UWP.ViewModels
{
    public class CropSettingsViewModel : INotifyPropertyChanged
    {
        private ICropService cropService;
        private INavigationService navigationService;

        #region Properties of the ViewModel
        private String deleteCropName;
        public String DeleteCropName
        {
            get
            {
                return deleteCropName;
            }
            set
            {
                deleteCropName = value;
                NotifyPropertyChanged("CropName");
                DeleteCrop = null;
                Error = null;
            }
        }

        private String cropName;
        public String CropName
        {
            get
            {
                return cropName;
            }
            set
            {
                cropName = value;
                NotifyPropertyChanged("CropName");
                Error = null;
            }
        }

        private double humidity;
        public double Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                humidity = value;
                NotifyPropertyChanged("Humidity");
                Error = null;
            }
        }

        private double light;
        public double Light
        {
            get
            {
                return light;
            }
            set
            {
                light = value;
                NotifyPropertyChanged("Light");
                Error = null;
            }
        }

        private double temperature;
        public double Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                temperature = value;
                NotifyPropertyChanged("Temperature");
                Error = null;
            }
        }

        private DateTime timeOfYear;
        public DateTime TimeOfYear
        {
            get
            {
                return timeOfYear;
            }
            set
            {
                timeOfYear = value;
                NotifyPropertyChanged("TimeOfYear");
                Error = null;
            }
        }


        private List<Crop> cropList;
        public List<Crop> CropList
        {
            get
            {
                return cropList;
            }
            set
            {
                cropList = value;
                NotifyPropertyChanged("CropList");
                Error = null;
            }
        }

        private String error;
        public String Error
        {
            get
            {
                return error;
            }
            set
            {
                error = value;
                NotifyPropertyChanged("Error");
            }
        }

        private Crop deleteCrop;
        public Crop DeleteCrop
        {
            get
            {
                return deleteCrop;
            }
            set
            {
                deleteCrop = value;
                NotifyPropertyChanged("DeleteCrop");
                Error = null;
            }
        }
        #endregion

        public CropSettingsViewModel(ICropService cropService, INavigationService navigationService)
        {
            this.cropService = cropService;
            this.navigationService = navigationService;

            LoadCommands();
        }

        #region Commands section
        public CustomCommand DeleteCropCommand { get; set; }
        public CustomCommand AddCropCommand { get; set; }
        public CustomCommand GetAllCropsCommand { get; set; }

        private void LoadCommands()
        {
            DeleteCropCommand = new CustomCommand(DeleteCropMethod, CanExecute);
            AddCropCommand = new CustomCommand(AddCrop, CanExecute);
            GetAllCropsCommand = new CustomCommand(GetAllCrops, CanExecute);
        }

        private async void DeleteCropMethod(object obj)
        {
            if (!String.IsNullOrEmpty(DeleteCropName) || DeleteCrop != null)
            {
                Crop crop = DeleteCrop;
                if (DeleteCrop == null)
                {
                    crop = await cropService.getCropByName(DeleteCropName);
                }
                
                if (!(await cropService.deleteCrop(crop)))
                {
                    Error = "Error bij het verwijderen van het gewas. Probeer het later opnieuw!";
                }

                NotifyPropertyChanged("CropList");
            }
        }

        private async void AddCrop(object obj)
        {
            if (!String.IsNullOrEmpty(CropName) && TimeOfYear != null)
            {
                Crop crop = new Crop();
                crop.Name = CropName;
                crop.Temperature = Temperature;
                crop.Humidity = Humidity;
                crop.Light = Light;
                crop.FinalDate = TimeOfYear;

                if (!(await cropService.addCrop(crop)))
                {
                    Error = "Error bij het toevoegen van het gewas. Probeer het later opnieuw!";
                }

                NotifyPropertyChanged("CropList");
            }
        }

        public async void GetAllCrops(object obj)
        {
            CropList = await cropService.getAllCrops();
        }

        private bool CanExecute(object obj)
        {
            return true;
        }
        #endregion

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
