using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Utilities.PagedList.Models;
using System.Collections.Generic;
using System.Collections;

namespace Portal.Utilities.PagedList.Tests.Models
{
    /// <summary>
    /// Classe de Testes para navegador de urls
    /// </summary>
    [TestClass]
    public class UrlNavigatorTests
    {
        /// <summary>
        /// URL base para testes
        /// </summary>
        private string url = "http://www.mundipagg.com/";

        /// <summary>
        /// Testa a criação da primeira página
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_FirstPage()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);

            // Obtem a página
            PageLink page = nav.firstPage;

            // Verifica se está na página 1, nao é atual e a url
            Assert.AreEqual(page.pageNumber, 1);
            Assert.AreEqual(page.isCurrent, false);
            Assert.AreEqual(page.pageUrl, url+"?pageNumber=1");
        }

        /// <summary>
        /// Testa a criação da página anterior
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_PreviousPage()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);

            // Obtem a página
            PageLink page = nav.previousPage;

            // Verifica se está na página 3, nao é atual e a url
            Assert.AreEqual(page.pageNumber, 3);
            Assert.AreEqual(page.isCurrent, false);
            Assert.AreEqual(page.pageUrl, url + "?pageNumber=3");
        }

        /// <summary>
        /// Testa a criação da página atual
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_CurrentPage()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);

            // Obtem a página
            PageLink page = nav.currentPage;

            // Verifica se está na página 4, é atual e a url
            Assert.AreEqual(page.pageNumber, 4);
            Assert.AreEqual(page.isCurrent, true);
            Assert.AreEqual(page.pageUrl, url + "?pageNumber=4");
        }

        /// <summary>
        /// Testa a criação da página seguinte
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_NextPage()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);

            // Obtem a página
            PageLink page = nav.nextPage;

            // Verifica se está na página 5, nao é atual e a url
            Assert.AreEqual(page.pageNumber, 5);
            Assert.AreEqual(page.isCurrent, false);
            Assert.AreEqual(page.pageUrl, url + "?pageNumber=5");
        }

        /// <summary>
        /// Testa a criação da ultima pagina
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_LastPage()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 10, null);

            // Obtem a página
            PageLink page = nav.lastPage;

            // Verifica se está na página 10, nao é atual e a url
            Assert.AreEqual(page.pageNumber, 10);
            Assert.AreEqual(page.isCurrent, false);
            Assert.AreEqual(page.pageUrl, url + "?pageNumber=10");
        }

        /// <summary>
        /// Testa a não criação das paginas numericas a partir de navigatorsize invalido ou nulo
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_InvalidNavigatorSize()
        {
            // cria navegadores de url
            UrlNavigator nav1 = new UrlNavigator(url, 4, 10, null);
            UrlNavigator nav2 = new UrlNavigator(url, 4, 10, 0);
            UrlNavigator nav3 = new UrlNavigator(url, 4, 10, -2);

            // Verifica se navigatorsize não foi definido e se não foi gerado numericPages
            Assert.IsNull(nav1.navigatorSize);
            Assert.IsNull(nav1.numericPages);
            Assert.IsNull(nav2.navigatorSize);
            Assert.IsNull(nav2.numericPages);
            Assert.IsNull(nav3.navigatorSize);
            Assert.IsNull(nav3.numericPages);
        }

        /// <summary>
        /// Testa a criação navigatorsize maior que total de paginas
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_NavigatorSizeBiggerThenPageCount()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 4, 8, 10);

            // Verifica se navigatorsize ainda é 10
            Assert.AreEqual(nav.navigatorSize, 10);
            // Verifica se numericpages recebeu apenas 8 itens
            Assert.AreEqual(nav.numericPages.Count, 8);            
        }

        /// <summary>
        /// Testa a criação do navigatorsize 
        /// </summary>
        [TestMethod]
        public void UrlNavigator_Construct_NumericPages()
        {
            // cria navegador de url
            UrlNavigator nav = new UrlNavigator(url, 37, 300, 10);

            // obtem numericpages
            List<PageLink> numPages = (List<PageLink>)nav.numericPages;

            // Verifica se navigatorsize é 10
            Assert.AreEqual(nav.navigatorSize, 10);
            // Verifica se numericpages recebeu apenas 10 itens
            Assert.AreEqual(nav.numericPages.Count, 10);
            // Verifica se populou corretamente
            Assert.AreEqual(numPages[9].pageNumber, 42);
        }
    }
}
