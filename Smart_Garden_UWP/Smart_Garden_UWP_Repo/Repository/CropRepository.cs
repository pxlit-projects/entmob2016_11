using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smart_Garden_UWP_Models;
using Smart_Garden_UWP_Repo.Repository.Interfaces;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Smart_Garden_UWP.Converter;

namespace Smart_Garden_UWP_Repo.Repository
{
    public class CropRepository : ICropRepository
    {
        #region Helper methods
        public string val(String userName, String userPassword)
        {
            string authInfo = userName + ":" + userPassword;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            return authInfo;
        }
        #endregion

        #region Repository implementation
        public async Task<bool> addCrop(Crop crop)
        {
            var baseUri = "crop/add";

            if (await JsonApiClientPostRequestWithCropObj(baseUri, crop))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> deleteCrop(Crop crop)
        {
            var baseUri = "crop/delete";

            if (await JsonApiClientDeleteRequestWithCropObj(baseUri, crop))
            {
                return true;
            }

            return false;
        }

        public async Task<List<Crop>> getAllCrops()
        {
            List<Crop> crops = null;
            var baseUri = "http://localhost:9999/crop";

            String json = await JsonApiClientGetRequest(baseUri);
            if (json != null)
            {
                crops = JsonConvert.DeserializeObject<List<Crop>>(json, new MyDateTimeConverter());
            }

            return crops;
        }

        public async Task<Crop> getCropByName(string name)
        {
            Crop crop = null;
            var baseUri = "http://localhost:9999/crop/getByName/" + name;

            String json = await JsonApiClientGetRequest(baseUri);
            if(json != null)
            {
                crop = JsonConvert.DeserializeObject<Crop>(json, new MyDateTimeConverter());
            }

            return crop;
        }
        #endregion

        #region JsonApiClient section
        private async Task<String> JsonApiClientGetRequest(String baseUri)
        {
            String json = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseUri);
                    if (response.IsSuccessStatusCode)
                    {
                        json = await response.Content.ReadAsStringAsync();
                    }

                    return json;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

        private async Task<Boolean> JsonApiClientPostRequestWithCropObj(String baseUri, Crop crop)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9999/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    StringContent stringContent = new StringContent(JsonConvert.SerializeObject(crop, new MyDateTimeConverter()), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(baseUri, stringContent);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }

        private async Task<Boolean> JsonApiClientDeleteRequestWithCropObj(String baseUri, Crop crop)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:9999/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Authorization = (new AuthenticationHeaderValue("Basic", val("mkyong", "123456")));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage response = await client.DeleteAsync(baseUri + "/" + crop.Id);

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return false;
        }
        #endregion
    }
}