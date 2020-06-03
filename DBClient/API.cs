using DBClient.ExtensionMethods;
using DBClient.Models;
using DBClient.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DBClient
{
    class API
    {
        private static API _instance;
        private HttpClient _client;

        public User CurrentUser { get; set; }

        public API()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static API GetInstance()
        {
            if (_instance == null)
                _instance = new API();
            return _instance;
        }

        public void SetAuthData(string token, User user)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            CurrentUser = user;
        }

        public async Task<CompanyDetails> GetCompanyDetails()
        {
            try
            {
                var response = await _client.GetAsync($"{Settings.Default.API}/company");
                var contents = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<CompanyDetails>(contents);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task PostCompanyDetails(CompanyDetails company)
        {
            var json = JsonConvert.SerializeObject(company, new JsonSerializerSettings { ContractResolver = new JsonContractResolver() });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{Settings.Default.API}/company", data);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Не удалось обновить реквизиты компании");
            }
        }

        public async Task<bool> AsyncLogin(User user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user, new JsonSerializerSettings { ContractResolver = new JsonContractResolver() });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync($"{Settings.Default.API}/auth", data);
                var contents = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var def = new
                    {
                        access_token = "",
                        _user = new User()
                    };
                    var token = JsonConvert.DeserializeAnonymousType(contents, def);
                    SetAuthData(token.access_token, token._user);

                    return true;
                }
                else
                {
                    throw new Exception(JsonConvert.DeserializeObject<string>(contents));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<T>> AsyncGetCatalog<T>()
        {
            var catalog = (typeof(T).Name).GetPluralForm();
            try
            {
                var response = await _client.GetAsync($"{Settings.Default.API}/{catalog}");
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"Не удалось получить список {catalog}.");
                var contents = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(contents);
            }
            catch (Exception)
            {
                throw new Exception("Не удалось получить данные с сервера");
            }
        }

        public async Task AsyncRemoveItem<T>(long id)
        {
            var catalog = (typeof(T).Name).GetPluralForm();
            try
            {
                var response = await _client.DeleteAsync($"{Settings.Default.API}/{catalog}/{id}");
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception($"Не удалось удалить {catalog} с Id {id}.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AsyncPostItem<T>(T item)
        {
            var catalog = (typeof(T).Name).GetPluralForm();
            try
            {
                var json = JsonConvert.SerializeObject(item, new JsonSerializerSettings { ContractResolver = new JsonContractResolver() });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync($"{Settings.Default.API}/{catalog}", data);
                var contents = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    try
                    {
                        var definition = new { errors = new Dictionary<string, string[]>() };
                        var dict = JsonConvert.DeserializeAnonymousType(contents, definition);
                        string exMessage = "";
                        foreach (var str in dict.errors)
                        {
                            exMessage += str.Value[0] + '\n';
                        }
                        throw new Exception(exMessage);
                    }
                    catch (JsonSerializationException)
                    {
                        var exMessage = JsonConvert.DeserializeObject<string>(contents);
                        throw new Exception(exMessage);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AsyncUpdateItem<T>(T item, long id)
        {
            var catalog = (typeof(T).Name).GetPluralForm();
            try
            {
                var json = JsonConvert.SerializeObject(item, new JsonSerializerSettings { ContractResolver = new JsonContractResolver() });
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PutAsync($"{Settings.Default.API}/{catalog}/{id}", data);
                var contents = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    try
                    {
                        var definition = new { errors = new Dictionary<string, string[]>() };
                        var dict = JsonConvert.DeserializeAnonymousType(contents, definition);
                        string exMessage = "";
                        foreach (var str in dict.errors)
                        {
                            exMessage += str.Value[0] + '\n';
                        }
                        throw new Exception(exMessage);
                    }
                    catch (JsonSerializationException)
                    {
                        var exMessage = JsonConvert.DeserializeObject<string>(contents);
                        throw new Exception(exMessage);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
