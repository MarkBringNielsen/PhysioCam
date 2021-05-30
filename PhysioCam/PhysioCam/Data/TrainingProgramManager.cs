using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PhysioCam.Models;
using Xamarin.Forms;
using System.IO;
using System.Collections.ObjectModel;
using Plugin.Media.Abstractions;

namespace PhysioCam.Data
{
    class TrainingProgramManager
    {
        private ApiClient apiClient;
        private const string endPoint = "exercise-plans";

        public TrainingProgramManager()
        {
            apiClient = DependencyService.Get<ApiClient>();
        }

        public async Task<ObservableCollection<TrainingProgram>> GetTrainingPrograms()
        {
            HttpClient client = await apiClient.GetClientAsync();
            HttpResponseMessage responseMessage = await client.GetAsync(ApiClient.uri.AbsoluteUri+endPoint);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ObservableCollection<TrainingProgram>>(responseContent);
            }
            else
            {
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }
        }

        public async Task PostTrainingProgram(TrainingProgram program)
        {

            HttpClient client = await apiClient.GetClientAsync();

            List<int> exerciseIDs = new List<int>();

            foreach (var exercise in program.Exercises)
            {
                exerciseIDs.Add(await PostExercise(client, exercise));
            }

            TrainingProgramDTO dto = new TrainingProgramDTO 
            { 
                Title = program.Title,
                Description = program.Description,
                Exercises = exerciseIDs 
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(ApiClient.uri.AbsoluteUri + endPoint, content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }
           
        }

        private async Task<int> PostExercise(HttpClient client, Exercise exercise)
        {
            
            var ex = new Exercise(exercise.Name, exercise.Description, new List<MediaFile>());
            var imgs = new List<MediaFile>(exercise.Images);
            

            MultipartFormDataContent content = new MultipartFormDataContent();
            content.Add(new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json"),"data");
            foreach (var img in imgs)
            {

                var stream = img.GetStream();
                var bytes = new byte[stream.Length];
                await stream.ReadAsync(bytes, 0, (int)stream.Length);
                string imageBase64 = Convert.ToBase64String(bytes);
                //Task<string> sendFotoResult = restClient.SendImage(imageBase64);
                //string result = await sendFotoResult;



                using (var memoryStream = new MemoryStream())
                {
                    img.GetStream().CopyTo(memoryStream);
                    img.Dispose();
                    
                    content.Add(new ByteArrayContent(new MemoryStream(bytes).ToArray()), "files.Image");
                }
                
            }


            



            HttpResponseMessage responseMessage = await client.PostAsync(ApiClient.uri.AbsoluteUri + "exercises", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }
            JsonConvert.PopulateObject(await responseMessage.Content.ReadAsStringAsync(), exercise);
            return exercise.ID;
        }
        
    }
}
