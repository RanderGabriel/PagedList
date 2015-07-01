using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Utilities.PagedList.Models;

namespace Portal.Utilities.PagedList.Tests.Models
{
    /// <summary>
    /// Classe que testa modelo de link de pagina
    /// </summary>
    [TestClass]
    public class PageLinkTests
    {
        /// <summary>
        /// Testa a geração da url passando uma url base
        /// </summary>
        [TestMethod]
        public void PageLink_Constructor_GenerateURLWithBaseUrl()
        {
            // URL a ser passada
            string url = "http://www.google.com";
            // URL a ser passada
            string urlreturn = "http://www.google.com?pageNumber=3";

            // Cria objeto
            PageLink link = new PageLink(url, 3);

            // Verifica a url recebida
            Assert.AreEqual(urlreturn, link.url);
        }

        /// <summary>
        /// Testa a geração da url passando uma url completa
        /// </summary>
        [TestMethod]
        public void PageLink_Constructor_GenerateURLWithFullUrl()
        {
            // URL a ser passada
            string url = "http://www.google.com/xxx?teste=123";
            // URL a ser passada
            string urlreturn = "http://www.google.com/xxx?teste=123&pageNumber=3";

            // Cria objeto
            PageLink link = new PageLink(url, 3);

            // Verifica a url recebida
            Assert.AreEqual(urlreturn, link.url);
        }

        /// <summary>
        /// Testa a geração da url passando uma querystring
        /// </summary>
        [TestMethod]
        public void PageLink_Constructor_GenerateURLWithQueryString()
        {
            // URL a ser passada
            string url = "?teste=123";
            // URL a ser passada
            string urlreturn = "?teste=123&pageNumber=3";

            // Cria objeto
            PageLink link = new PageLink(url, 3);

            // Verifica a url recebida
            Assert.AreEqual(urlreturn, link.url);
        }
    }
}
