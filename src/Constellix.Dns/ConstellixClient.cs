using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Constellix.Dns
{
    public sealed class ConstellixClient
    {
        private const string baseUrl = "https://api.dns.constellix.com/v1";  // include version

        private static readonly JsonSerializerOptions jso = new JsonSerializerOptions { 
            IgnoreNullValues = true, 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly IConstellixCredential credential;

        private readonly HttpClient httpClient;

        public ConstellixClient(string apiKey, string secretKey)
            : this(new ConstellixCredential(apiKey, secretKey))
        { }

        public ConstellixClient(IConstellixCredential credential)
            : this(credential, new HttpClient())
        { }

        public ConstellixClient(IConstellixCredential credential, HttpClient httpClient)
        {
            this.credential = credential ?? throw new ArgumentNullException(nameof(credential));
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Domain[]> ListDomainsAsync()
        {
            return await SendAsync<Domain[]>(new HttpRequestMessage(HttpMethod.Get, baseUrl + "/domains")).ConfigureAwait(false);
        }

        public async Task<CreateDomainResult[]> CreateDomainAsync(CreateDomainRequest request)
        {
            return await PostAsync<CreateDomainResult[]>("/domains", request).ConfigureAwait(false);
        }

        public Task<Domain> GetDomainAsync(long id)
        {
            return GetAsync<Domain>("/domains/" + id);
        }

        public async Task UpdateDomainAsync(UpdateDomainRequest request)
        {
            await PutAsync<object>("/domains/" + request.Id, request);
        }

        public async Task DeleteDomainAsync(long id)
        {
            await DeleteAsync("/domains/" + id);
        }

        // TODO: Type, GtdRegion

        public async Task<Record[]> ListRecordsAsync(long domainId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + $"/domains/{domainId}/records?gtdRegion=1");

            return await SendAsync<Record[]>(request).ConfigureAwait(false);
        }

        public async Task<Record[]> CreateRecordAsync(CreateRecordRequest request)
        {
            string type = request.Type.ToString().ToLower();

            try
            {
                return await PostAsync<Record[]>($"/domains/{request.DomainId}/records/{type}", request);
            }
            catch (Exception ex)
            {
                throw new Exception("could not convert response to Record[]" + ex.Message, ex);
            }
        }

        public async Task<UpdateRecordResult> UpdateRecordAsync(UpdateRecordRequest request)
        {
            string type = request.Type.ToString().ToLower();

            // /domains/{{DomainId}}/records/cname/{{CNAMERecordId}}

            string path = $"/domains/{request.DomainId}/records/{type}/{request.RecordId}";

            try
            {
                return await PutAsync<UpdateRecordResult>(path, request).ConfigureAwait(false);
            }
            catch (ConstellixException ex)
            {
                if (ex.Message == "Record not found")
                {
                    throw new RecordNotFoundException(request.Type, request.RecordId);
                }

                throw ex;
            }
        }

        public async Task<Record[]> CreateMXRecordsAsync(CreateMXRecordRequest request)
        {
            try
            {
                return await PostAsync<Record[]>($"/domains/{request.DomainId}/records/mx", request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error converting to Record[]. "+ ex.Message, ex);
            }
        }

        public async Task DeleteRecordAsync(DeleteRecordRequest request)
        {
            var type = request.RecordType.ToString().ToLower();

            await DeleteAsync($"/domains/{request.DomainId}/records/{type}/{request.RecordId}");
        }

        /*
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

            await SendAsync<object>(request);
        }

        private async Task<T> GetAsync<T>(string path)
            where T : new()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, baseUrl + path);

            return await SendAsync<T>(request).ConfigureAwait(false);

        }

        private async Task<TResult> PostAsync<TResult>(string path, object data)
        {
            string jsonText = JsonSerializer.Serialize(data, jso);

            var request = new HttpRequestMessage(HttpMethod.Post, baseUrl + path)
            {
                Content = new StringContent(jsonText, Encoding.UTF8, "application/json")
            };

            return await SendAsync<TResult>(request);
        }

        private async Task<TResult> PutAsync<TResult>(string path, object data)
        {
            string jsonText = JsonSerializer.Serialize(data, jso);

            var request = new HttpRequestMessage(HttpMethod.Put, baseUrl + path)
            {
                Content = new StringContent(jsonText, Encoding.UTF8, "application/json")
            };

            return await SendAsync<TResult>(request);
        }

        private async Task<TResult> SendAsync<TResult>(HttpRequestMessage request)
        {
            if (credential.ShouldRenew)
            {
                await credential.RenewAsync().ConfigureAwait(false);
            }

            string timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();

            byte[] hmacValue;

            using (var hmac = new HMACSHA1(credential.SecretKey))
            {
                hmacValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(timestamp));
            }

            string securityToken = string.Join(":", new[] { credential.ApiKey, Convert.ToBase64String(hmacValue), timestamp });

            // x-cns-security-token: xxx

            request.Headers.TryAddWithoutValidation("x-cns-security-token", securityToken);

            using HttpResponseMessage response = await httpClient.SendAsync(request);

            string responseText = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                if (responseText.Length > 0 && responseText[0] == '{')
                {
                    throw new ConstellixException(JsonSerializer.Deserialize<ErrorResult>(responseText, jso));
                }

                throw new Exception(responseText);
            }


            if (typeof(TResult) == typeof(object))
            {
                return default!;
            }

            return JsonSerializer.Deserialize<TResult>(responseText, jso);
        }
    }
}

// ref: https://api-dns-docs.constellix.com/