using SugarNotificationAPI.Models;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SugarNotificationAPI.Helpers
{
    public class UserManager
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task CreateOffer(CreateOfferModel request)
        {
            string dataApiUrl = ConfigurationManager.AppSettings["CreatePostingDataApiUrl"];

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestUri = dataApiUrl;

            var response = await _httpClient.PostAsJsonAsync(requestUri, request);
        }

        public async Task ConfirmMeeting(string consumerPhoneNumber, string producerPhoneNumber)
        {
            string dataApiUrl = ConfigurationManager.AppSettings["ConfirmMeetingDataApiUrl"];

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestUri = dataApiUrl;

            var response = await _httpClient.PostAsJsonAsync(dataApiUrl, new ConfirmMeetingModel
            {
                ConsumerPhoneNumber = consumerPhoneNumber,
                ProducerPhoneNumber = producerPhoneNumber
            });
        }

        public async Task<UserDataModel> GetProducerForAcceptedRequestByConsumerPhoneNumber(string phoneNumber)
        {
            string dataApiUrl = ConfigurationManager.AppSettings["LookupProducerForAcceptedRequestByConsumerDataApiUrl"];
            string queryString = "?cellNumber=" + phoneNumber.Replace("+", "");

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var result = await _httpClient.GetAsync($"{dataApiUrl}{queryString}"))
            {
                UserDataModel content = await result.Content.ReadAsAsync<UserDataModel>();
                return content;
            }
        }

        public async Task<UserDataModel> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            string dataApiUrl = ConfigurationManager.AppSettings["LookupUserDataApiUrl"];
            string queryString = "?cellNumber=" + phoneNumber.Replace("+", "");

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var result = await _httpClient.GetAsync($"{dataApiUrl}{queryString}"))
            {
                UserDataModel content = await result.Content.ReadAsAsync<UserDataModel>();
                return content;
            }
        }

        public async Task VerifyPhoneNumber(string phoneNumber)
        {
            string dataApiUrl = ConfigurationManager.AppSettings["VerifyUserDataApiUrl"];

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var requestUri = dataApiUrl + "/" + phoneNumber.Replace("+", "");

            var result = await _httpClient.PostAsync(requestUri, null);
        }
    }
}