using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Utilities.PagedList.Helpers;
using System.Collections.Specialized;

namespace Portal.Utilities.PagedList.Tests.Helpers
{
    /// <summary>
    /// Classe de teste para helper de URL
    /// </summary>
    [TestClass]
    public class UrlHelperTests
    {
        /// <summary>
        /// Testa captura de URL sem querystring a partir de URL com querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithQueryString()
        {
            // Url passada
            string urlWithQueryString = "http://www.google.com/teste?parametro=valor";
            // Url que devera receber
            string urlWithoutQueryString = "http://www.google.com/teste";

            // Executa processamento
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned, urlWithoutQueryString);
        }

        /// <summary>
        /// Testa captura de URL sem querystring a partir de URL com flag de querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithFlagQueryString()
        {
            // Url passada
            string urlWithQueryString = "http://www.google.com/teste?";
            // Url que devera receber
            string urlWithoutQueryString = "http://www.google.com/teste";
            
            // Executa processamento
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned, urlWithoutQueryString);
        }

        /// <summary>
        /// Testa captura de URL sem querystring a partir de URL sem querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_UrlWithourQueryString()
        {
            // Url passada
            
            string urlWithQueryString = "http://www.google.com/teste";
            // Url que devera receber
            string urlWithoutQueryString = "http://www.google.com/teste";

            // Executa processamento
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);

            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned, urlWithoutQueryString);
        }

        /// <summary>
        /// Testa captura de URL sem querystring a partir de URL parcial com de querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_PartialUrlWithQueryString()
        {
            // Url passada
            string urlWithQueryString = "/teste?parametro=valor";
            // Url que devera receber
            string urlWithoutQueryString = "/teste";
            
            // Executa processamento
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);
            
            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned, urlWithoutQueryString);
        }

        /// <summary>
        /// Testa captura de URL sem querystring a partir de URL parcial sem querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_PartialUrlWithoutQueryString()
        {
            // Url passada
            string urlWithQueryString = "teste.asp";
            // Url que devera receber
            string urlWithoutQueryString = "teste.asp";

            // Executa processamento
            string urlReturned = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString);
            
            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned, urlWithoutQueryString);
        }

        /// <summary>
        /// Testa captura de URL sem querystring a partir de querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_GetUrlWithoutQueryString_OnlyQueryString()
        {
            // Url que sera passada
            string urlWithQueryString1 = "?parametro=valor";
            string urlWithoutQueryString1 = "";

            // Url esperada
            string urlWithQueryString2 = "?";
            string urlWithoutQueryString2 = "";

            // Executa processamento
            string urlReturned1 = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString1);
            string urlReturned2 = UrlHelper.GetUrlWithoutQueryString(urlWithQueryString2);

            // compara a string recebida com a esperada
            Assert.AreEqual(urlReturned1, urlWithoutQueryString1);
            Assert.AreEqual(urlReturned2, urlWithoutQueryString2);
        }

        /// <summary>
        /// Testa remoção de parâmetro inexistente de query string de url completa
        /// </summary>
        [TestMethod]
        public void UrlHelper_RemoveParameterFromQueryString_NotExistingParameter()
        {
            string urlWithParameter = "http://www.google.com/teste?parametro=valor&parametro2=valor";
            string urlWithoutParameter = "http://www.google.com/teste?parametro=valor&parametro2=valor";

            string[] parameters = { "parametro3" };
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter, parameters);

            Assert.AreEqual(urlReturned, urlWithoutParameter);
        }

        /// <summary>
        /// Testa remoção de parâmetro existente de query string de url completa
        /// </summary>
        [TestMethod]
        public void UrlHelper_RemoveParameterFromQueryString_ExistingParameterAndUrlFull()
        {
            string urlWithParameter = "http://www.google.com/teste?parametro=valor&parametro2=valor";
            string urlWithoutParameter = "http://www.google.com/teste?parametro2=valor";

            string[] parameters = {"parametro"};
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter,parameters);

            Assert.AreEqual(urlReturned, urlWithoutParameter);
        }

        /// <summary>
        /// Testa remoção de parâmetro existente de query string de querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_RemoveParameterFromQueryString_ExistingParameterAndQueryString()
        {
            string urlWithParameter = "?parametro=valor&parametro2=valor";
            string urlWithoutParameter = "?parametro2=valor";

            string[] parameters = { "parametro" };
            string urlReturned = UrlHelper.RemoveParameterFromQueryString(urlWithParameter, parameters);

            Assert.AreEqual(urlReturned, urlWithoutParameter);
        }

        /// <summary>
        /// Testa conversão de querystring para collection de pares passando url completa
        /// </summary>
        [TestMethod]
        public void UrlHelper_ParseQueryString_UrlFull()
        {
            string urlToConvert = "http://www.xyz.com?parametro=valor&parametro2=valor2";

            NameValueCollection collection = UrlHelper.ParseQueryString(urlToConvert);

            Assert.AreEqual(collection.Count, 2);
            Assert.AreEqual(collection.Get("parametro"), "valor");
            Assert.AreEqual(collection.Get("parametro2"), "valor2");
        }

        /// <summary>
        /// Testa conversão de querystring para collection de pares passando querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_ParseQueryString_QueryString()
        {
            string urlToConvert = "parametro=valor&parametro2=valor2";

            NameValueCollection collection = UrlHelper.ParseQueryString(urlToConvert);

            Assert.AreEqual(collection.Count, 2);
            Assert.AreEqual(collection.Get("parametro"), "valor");
            Assert.AreEqual(collection.Get("parametro2"), "valor2");
        }

        /// <summary>
        /// Testa conversão de querystring para collection de pares passando url completa
        /// </summary>
        [TestMethod]
        public void UrlHelper_ParseQueryString_WithoutParameter()
        {
            string urlToConvert1 = "http://www.xyz.com?";
            string urlToConvert2 = "http://www.xyz.com";

            NameValueCollection collection1 = UrlHelper.ParseQueryString(urlToConvert1);
            NameValueCollection collection2 = UrlHelper.ParseQueryString(urlToConvert2);

            Assert.AreEqual(collection1.Count, 0);
            Assert.AreEqual(collection2.Count, 0);
        }

        /// <summary>
        /// Testa conversão de collection vazia para querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_ToParseQueryString_CollectionEmpty()
        {
            NameValueCollection collection = new NameValueCollection();

            string result = UrlHelper.ToQueryString(collection);

            Assert.AreEqual(result, String.Empty);
        }

        /// <summary>
        /// Testa conversão de collection populada para querystring
        /// </summary>
        [TestMethod]
        public void UrlHelper_ToParseQueryString_CollectionNotEmpty()
        {
            NameValueCollection collection = new NameValueCollection();
            collection.Add("parametro", "valor");
            collection.Add("parametro2", "valor2");

            string result = UrlHelper.ToQueryString(collection);

            Assert.AreEqual(result, "parametro=valor&parametro2=valor2");
        }
    }
}
