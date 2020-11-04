using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Interfaces.IGenerateRequest
{
    public interface IGenerateRequest
    {
        public List<T> ConsultarApiRest<T>(string uri, RestRequest request);
        public string GetUri(int option);
        public void LeerClaims();
    }
}