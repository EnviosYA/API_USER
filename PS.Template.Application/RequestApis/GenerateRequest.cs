using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PS.Template.Domain.Interfaces.IGenerateRequest;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PS.Template.Application.RequestApis
{
    public class GenerateRequest : IGenerateRequest
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public GenerateRequest(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public string GetUri(int option)
        {
            string uri = null;
            switch (option)
            {
                case 1:
                    uri = _configuration.GetSection("URL:URI_Direccion").Value;
                    break;
                case 2:
                    uri = _configuration.GetSection("URL:URI_Cuenta").Value;
                    break;
                case 3:
                    uri = null;
                    break;
            }
            return uri;
        }
        public List<T> ConsultarApiRest<T>(string uri, RestRequest request)
        {
            IRestClient client;
            IRestResponse queryResult;
            List<T> hash = new List<T>();
            T instancia;
            var headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" }
            };
            try
            {
                //client = new RestClient(uri)
                //{
                //    Authenticator = new JwtAuthenticator("")
                //};
                client = new RestClient(uri);
                request.AddHeaders(headers);
                request.RequestFormat = DataFormat.Json;
                queryResult = client.Execute(request);


                if (queryResult.ResponseStatus == ResponseStatus.Completed )
                {
                    if (queryResult.Content.Contains("["))
                    {
                        hash = JsonConvert.DeserializeObject<List<T>>(queryResult.Content);
                    }
                    else
                    {
                        instancia = JsonConvert.DeserializeObject<T>(queryResult.Content);
                        hash.Add(instancia);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return hash;
        }

        public void LeerClaims()
        {
            IEnumerable<Claim> cp = _contextAccessor.HttpContext.User.Claims;
            var a = _contextAccessor.HttpContext.Request.Headers.GetCommaSeparatedValues("Authorization");
        }
    }
}