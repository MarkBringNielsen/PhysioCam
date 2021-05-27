using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public async Task<IEnumerable<TrainingProgram>> GetTrainingPrograms()
        {
            HttpClient client = await apiClient.GetClientAsync();
            HttpResponseMessage responseMessage = await client.GetAsync(ApiClient.uri.AbsoluteUri+endPoint);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<TrainingProgram>>(responseContent);
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
            HttpContent content = new StringContent(JsonConvert.SerializeObject(exercise), Encoding.UTF8, "application/json");
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
