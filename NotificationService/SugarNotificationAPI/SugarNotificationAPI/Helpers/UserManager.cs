using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace SugarNotificationAPI.Helpers
{
    public class UserManager
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<dynamic> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            string userDataApiUrl = ConfigurationManager.AppSettings["UserDataApiUrl"];
            string queryString = "?phoneNumber=" + phoneNumber;

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var result = await _httpClient.GetAsync($"{userDataApiUrl}{queryString}"))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }

        public async Task<dynamic> VerifyPhoneNumber(string phoneNumber)
        {
            string userDataApiUrl = ConfigurationManager.AppSettings["VerifyUserDataApiUrl"];
            string queryString = "?phoneNumber=" + phoneNumber;

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using (var result = await _httpClient.GetAsync($"{userDataApiUrl}{queryString}"))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}