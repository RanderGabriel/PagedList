using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Portal.Utilities.PagedList.Tests
{
    /// <summary>
    /// Classe de testes para classe de paginação principal
    /// </summary>
    [TestClass]
    public class PageListTests
    {
        /// <summary>
        /// URL para testes
        /// </summary>
        private string url = "http://portal.mundipagg.com/transactions/debitonlinetransaction?pageNumber=5&sortField=OrderReference&sortMode=DESC";
        
        /// <summary>
        /// URL para testes com url depois de processada, sem o número da página
        /// </summary>
        private string urlAfterMountingWithoutPageNumber = "http://portal.mundipagg.com/transactions/debitonlinetransaction?sortField=OrderReference&sortMode=DESC&pageNumber=";

        /// <summary>
        /// Testa a criação do objeto
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_GenerateProps()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize= 12;
            // Página atual
            int pageNumber = 1;

            // Cria lista paginada
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize);
            
            // Verifica se conseguiu criar objetos filhos
            Assert.IsNotNull(pagedList.pageOptions);
            Assert.IsNotNull(pagedList.urlNavigator);
        }

        /// <summary>
        /// Testa a criação do objeto com valores defaults
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_Default()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;

            // Cria lista paginada
            PagedList pagedList = new PagedList(url, itemCount);

            // Verifica se conseguiu criar objetos filhos
            Assert.IsNotNull(pagedList.pageOptions);
            Assert.IsNotNull(pagedList.urlNavigator);

            // Verifica valores padrões nulo para navigatorsize e numericpages
            Assert.IsNull(pagedList.urlNavigator.navigatorSize);
            Assert.IsNull(pagedList.urlNavigator.numericPages);

            // Verifica valores padrões para pagenumber e pagesize
            Assert.AreEqual(pagedList.pageOptions.pageNumber, 1);
            Assert.AreEqual(pagedList.pageOptions.pageSize, 10);
        }

        /// <summary>
        /// Testa a criação das opções da página
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptions()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // Verifica se conseguiu criar opções
            Assert.IsNotNull(pagedList.pageOptions);

            // Verifica tamanho maximo de paginas calculadas e se numero e tamanho da pagina estao corretos
            Assert.AreEqual(pagedList.pageOptions.pageCount, 35);
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);
            Assert.AreEqual(pagedList.pageOptions.pageSize, pageSize);
        }

        /// <summary>
        /// Testa a criação do navegador de urls
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_UrlNavigator()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada com navegador { 5 6 [7] 8 9 10 }
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // Verifica se conseguiu criar navegador de url
            Assert.IsNotNull(pagedList.urlNavigator);

            // Verifica tamanho do navegador e das paginas numericas
            Assert.AreEqual(pagedList.urlNavigator.navigatorSize, 6);
            Assert.AreEqual(pagedList.urlNavigator.numericPages.Count, 6);

            // Verifica se populou corretamente
            Assert.AreEqual(pagedList.urlNavigator.numericPages[2].pageNumber, pageNumber);
        }

        /// <summary>
        /// Testa a relação dos parametros passados e atribuidos as opções e ao navegador de url para pagina atual
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_CurrentPage()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica numera da página nas opções
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageNumber, pagedList.urlNavigator.currentPage.pageNumber);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber+pageNumber.ToString(), 
                pagedList.urlNavigator.currentPage.pageUrl);
            // verifica se é página atual
            Assert.IsTrue(pagedList.urlNavigator.currentPage.isCurrent);
        }

        /// <summary>
        /// Testa a relação dos parametros passados e atribuidos as opções e ao navegador de url para primeira pagina
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_FirstPage()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica numera da página nas opções
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(1, pagedList.urlNavigator.firstPage.pageNumber);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + "1",
                pagedList.urlNavigator.firstPage.pageUrl);
            // verifica se não é página atual
            Assert.IsFalse(pagedList.urlNavigator.firstPage.isCurrent);
        }

        /// <summary>
        /// Testa a relação dos parametros passados e atribuidos as opções e ao navegador de url para pagina anterior
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_PreviousPage()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica numera da página nas opções
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageNumber-1, pagedList.urlNavigator.previousPage.pageNumber);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + (pageNumber-1).ToString(),
                pagedList.urlNavigator.previousPage.pageUrl);
            // verifica se não é página atual
            Assert.IsFalse(pagedList.urlNavigator.previousPage.isCurrent);
        }

        /// <summary>
        /// Testa a relação dos parametros passados e atribuidos as opções e ao navegador de url para proxima pagina
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_NextPage()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica numera da página nas opções
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageNumber + 1, pagedList.urlNavigator.nextPage.pageNumber);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + (pageNumber + 1).ToString(),
                pagedList.urlNavigator.nextPage.pageUrl);
            // verifica se não é página atual
            Assert.IsFalse(pagedList.urlNavigator.nextPage.isCurrent);
        }

        /// <summary>
        /// Testa a relação dos parametros passados e atribuidos as opções e ao navegador de url para ultima pagina
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_PageOptionsAndUrlNavigator_LastPage()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 7;
            // Tamanho do navegador de url
            int navigatorSize = 6;
            // Tamanho maximo de paginas
            int pageCount = 35;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica numera da página nas opções
            Assert.AreEqual(pagedList.pageOptions.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageCount, pagedList.urlNavigator.lastPage.pageNumber);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + pageCount.ToString(),
                pagedList.urlNavigator.lastPage.pageUrl);
            // verifica se não é página atual
            Assert.IsFalse(pagedList.urlNavigator.lastPage.isCurrent);
        }

        /// <summary>
        /// Testa a criação de paginas numericas com navegador navegador de url 
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_UrlNavigator_NumericPages()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 35;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada com navegador { 30 31 32 33 34 [35] }
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica se recebeu numeração correta nas paginas
            Assert.AreEqual(30, pagedList.urlNavigator.numericPages[0].pageNumber);
            Assert.AreEqual(31, pagedList.urlNavigator.numericPages[1].pageNumber);
            Assert.AreEqual(32, pagedList.urlNavigator.numericPages[2].pageNumber);
            Assert.AreEqual(33, pagedList.urlNavigator.numericPages[3].pageNumber);
            Assert.AreEqual(34, pagedList.urlNavigator.numericPages[4].pageNumber);
            Assert.AreEqual(35, pagedList.urlNavigator.numericPages[5].pageNumber);
        }

        /// <summary>
        /// Testa a criação de navegador com paginas primera e anterior sendo atuais (estando na primeira página)
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_UrlNavigator_FirstAndPreviousIsCurrent()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 1;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada com navegador { [1] 2 3 4 5 6 }
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica se são paginas atuais
            Assert.IsTrue(pagedList.urlNavigator.firstPage.isCurrent);
            Assert.IsTrue(pagedList.urlNavigator.previousPage.isCurrent);
        }

        /// <summary>
        /// Testa a criação de navegador com paginas ultima e proxima sendo atuais (estando na ultima pagina)
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_UrlNavigator_LastAndNextIsCurrent()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 35;
            // Tamanho do navegador de url
            int navigatorSize = 6;

            // Cria lista paginada com navegador { 30 31 32 33 34 [35] }
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize, navigatorSize);

            // verifica se são paginas atuais
            Assert.IsTrue(pagedList.urlNavigator.lastPage.isCurrent);
            Assert.IsTrue(pagedList.urlNavigator.nextPage.isCurrent);
        }

        /// <summary>
        /// Testa a conversão para uma string json completo
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithUrlNavigator()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 100;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 5;
            // Tamanho do navegador de url
            int navigatorSize = 3;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // Json esperado
            string jsonExpected = "{\"pageOptions\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"urlNavigator\":{\"navigatorSize\":3,\"firstPage\":{\"pageUrl\":\"?pageNumber=1\",\"pageNumber\":1,\"isCurrent\":false},\"previousPage\":{\"pageUrl\":\"?pageNumber=4\",\"pageNumber\":4,\"isCurrent\":false},\"currentPage\":{\"pageUrl\":\"?pageNumber=5\",\"pageNumber\":5,\"isCurrent\":true},\"nextPage\":{\"pageUrl\":\"?pageNumber=6\",\"pageNumber\":6,\"isCurrent\":false},\"lastPage\":{\"pageUrl\":\"?pageNumber=10\",\"pageNumber\":10,\"isCurrent\":false},\"numericPages\":[{\"pageUrl\":\"?pageNumber=4\",\"pageNumber\":4,\"isCurrent\":false},{\"pageUrl\":\"?pageNumber=5\",\"pageNumber\":5,\"isCurrent\":true},{\"pageUrl\":\"?pageNumber=6\",\"pageNumber\":6,\"isCurrent\":false}]}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }

        /// <summary>
        /// Testa a conversão para uma string json sem navegador de url
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithoutUrlNavigator()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 100;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 5;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize);

            // Json esperado
            string jsonExpected = "{\"pageOptions\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"urlNavigator\":{\"navigatorSize\":null,\"firstPage\":{\"pageUrl\":\"?pageNumber=1\",\"pageNumber\":1,\"isCurrent\":false},\"previousPage\":{\"pageUrl\":\"?pageNumber=4\",\"pageNumber\":4,\"isCurrent\":false},\"currentPage\":{\"pageUrl\":\"?pageNumber=5\",\"pageNumber\":5,\"isCurrent\":true},\"nextPage\":{\"pageUrl\":\"?pageNumber=6\",\"pageNumber\":6,\"isCurrent\":false},\"lastPage\":{\"pageUrl\":\"?pageNumber=10\",\"pageNumber\":10,\"isCurrent\":false},\"numericPages\":null}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }
    }
}
