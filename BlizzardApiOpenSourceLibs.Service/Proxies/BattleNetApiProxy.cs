using BlizzardApiOpensourceLibs.Core.Interfaces;
using BlizzardApiOpensourceLibs.Core.POCOs;
using BlizzardApiOpenSourceLibs.Service.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardApiOpenSourceLibs.Service.Proxies
{
    /// <summary>
    /// Default url is 'https://eu.battle.net/oauth/token', if you need to change, just send new url to constructor
    /// </summary>
    public class BattleNetApiProxy : IBattleNetApiProxy
    {
        private HttpClient _httpClient = new HttpClient();

        private readonly string _url = "";

        public BattleNetApiProxy()
        {

        }

        /// <summary>
        /// Set new token url
        /// </summary>
        /// <param name="url">https://{local}.battle.net/oauth/token</param>
        public BattleNetApiProxy(string url)
        {
            _url = url;
        }

        /// <summary>
        /// Method for OAuth2
        /// </summary>
        /// <param name="cliendId">string data from developer portal</param>
        /// <param name="secret">string data from developer portal</param>
        /// <returns>if all is ok you will get token</returns>
        public async Task<string> GetToken(string cliendId, string secret)
        {
            // 1) combine parameters and convert ty byte[]
            var template = string.Format("{0}:{1}", cliendId, secret);
            var byteArray = Encoding.UTF8.GetBytes(template);

            // 2) put it into header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            // 3) create url
            var url = new Uri(_url, UriKind.Absolute);

            // 4) attache params
            var requestParams = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("grant_type", "client_credentials")
                                };

            // 5) convert params to url, send request and convert result as string
            var content = new FormUrlEncodedContent(requestParams);
            var webresponse = await _httpClient.PostAsync(url, content);
            var responseBodyString = await webresponse.Content.ReadAsStringAsync();

            // 6) deserialize result to object
            var result = JsonConvert.DeserializeObject<AuthorizationResponceModel>(responseBodyString, new JsonSerializerSettings()
            {
                ContractResolver = new UnderscorePropertyNamesContractResolver()
            });
            
            return result.AccessToken;
        }

        public void Dispose()
        {
            if (_httpClient != null)
            {
                _httpClient.Dispose();
                _httpClient = null;
            }
        }
    }
}
