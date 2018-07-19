using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Carbon.Json;

namespace Constellix.Dns
{
    public class ConstellixClient
    {
        const string version = "v1";
        const string baseUrl = "https://api.dns.constellix.com/v1";  // include version

        private readonly string apiKey;
        private readonly string secretKey;

        private readonly HttpClient httpClient;

        public ConstellixClient(string apiKey, string secretKey)
            : this(apiKey, secretKey, new HttpClient()) { }

        public ConstellixClient(string apiKey, string secretKey, HttpClient httpClient)
        {
            this.apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            this.secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
            this.httpClient = this.httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Domain[]> ListDomainsAsync()
        {
            var json = await SendAsync(new HttpRequestMessage(HttpMethod.Get, baseUrl + "/domains"));

            return json.ToArrayOf<Domain>();

        }

        public async Task<CreateDomainResult[]> CreateDomainAsync(CreateDomainRequest request)
        {
            var json = await PostAsync("/domains", request);

            return json.ToArrayOf<CreateDomainResult>();
        }

        public Task<Domain> GetDomainAsync(long id)
        {
            return GetAsync<Domain>("/domains/" + id);
        }


        public async Task UpdateDomainAsync(UpdateDomainRequest request)
        {
            await PutAsync("/domains/" + request.Id, request);
        }

        public async Task DeleteDomainAsync(long id)
        {
            await DeleteAsync("/domains/" + id);
        }

        // TODO: Type, GtdRegion

        public async Task<Record[]> ListRecordsAsync(long domainId)
        {
            var json = await SendAsync(new HttpRequestMessage(HttpMethod.Get, baseUrl + $"/domains/{domainId}/records?gtdRegion=1"));

            return json.ToArrayOf<Record>();
        }

        public async Task<Record[]> CreateRecordAsync(CreateRecordRequest request)
        {
            var type = request.Type.ToString().ToLower();

            var result = await PostAsync($"/domains/{request.DomainId}/records/{type}", request);

            try
            {
                return result.ToArrayOf<Record>();
            }
            catch (Exception ex)
            {
                throw new Exception("cannot convert:" + result.ToString() + "/" + ex.Message);
            }
        }

        public async Task<Record[]> CreateMXRecordsAsync(CreateMXRecordRequest request)
        {
           

            var result = await PostAsync($"/domains/{request.DomainId}/records/mx", request);

            try
            {
                return result.ToArrayOf<Record>();
            }
            catch (Exception ex)
            {
                throw new Exception("cannot convert:" + result.ToString() + "/" + ex.Message);
            }
        }

        public async Task DeleteRecordAsync(DeleteRecordRequest request)
        {
            var type = request.RecordType.ToString().ToLower();

            await DeleteAsync($"/domains/{request.DomainId}/records/{type}/{request.RecordId}");

        }
        
        /*
        public void UpdateRecordAsync() { }

        public void CreateTemplateAsync() { }

        public void UpdateTemplateAsync() { }

        public void GetTemplateAsync() { }

        public void DeleteTemplateAsync() { }

        public void GetTemplateRecordsAsync() { }

        public void CreateTemplateRecordAsync() { }

        public void DeleteTemplateRecordAsync() { }
        */

        private async Task DeleteAsync(string path)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, baseUrl + path);

            await SendAsync(request);
        }

        private async Task<T> GetAsync<T>(string path)
            where T : new()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + path);

            var result = await SendAsync(request);

            return result.As<T>();
        }

        private async Task<JsonNode> PostAsync(string path, object data)
        {
            var jsonText = JsonNode.FromObject(data).ToString();

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + path)
            {
                Content = new StringContent(jsonText, Encoding.UTF8, "application/json")
            };

            return await SendAsync(request);
        }

        private async Task<JsonNode> PutAsync(string path, object data)
        {
            var jsonText = JsonNode.FromObject(data).ToString();

            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + path)
            {
                Content = new StringContent(jsonText, Encoding.UTF8, "application/json")
            };

            return await SendAsync(request);
        }

        private async Task<JsonNode> SendAsync(HttpRequestMessage request)
        {
            // x-cns-security-token: xxx

            // HMAC_SHA1

            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

            byte[] hmacValue;

            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretKey)))
            {
                hmacValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp));
            }

            var securityToken = string.Join(":", new[] { apiKey, Convert.ToBase64String(hmacValue), timestamp });

            request.Headers.TryAddWithoutValidation("x-cns-security-token", securityToken);

            using (var response = await httpClient.SendAsync(request))
            {
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(responseText);
                }

                return JsonNode.Parse(responseText);
            }
        }
    }
}

// ref: https://api-dns-docs.constellix.com/