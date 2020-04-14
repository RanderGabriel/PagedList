using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
    Essa linha foi modificada
*/
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
        private string urlAfterMountingWithoutPageNumber = "http://portal.mundipagg.com/transactions/debitonlinetransaction?sortField=OrderReference&sortMode=DESC&pageSize=10&pageNumber=";

        /// <summary>
        /// Testa a criação do objeto
        /// </summary>
        [TestMethod]
        public void PagedList_Construct_GenerateProps()
        {
            // total de itens existente em todas as páginas
            int itemCount = 347;
            // Itens por página
            int pageSize = 12;
            // Página atual
            int pageNumber = 1;

            // Cria lista paginada
            PagedList pagedList = new PagedList(url, itemCount, pageNumber, pageSize);

            // Verifica se conseguiu criar objetos filhos
            Assert.IsNotNull(pagedList.options);
            Assert.IsNotNull(pagedList.navigator);
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
            Assert.IsNotNull(pagedList.options);
            Assert.IsNotNull(pagedList.navigator);

            // Verifica valores padrões nulo para navigatorsize e numericpages
            Assert.IsNull(pagedList.navigator.navigatorSize);
            Assert.IsNull(pagedList.navigator.numerics);

            // Verifica valores padrões para pagenumber e pagesize
            Assert.AreEqual(pagedList.options.pageNumber, 1);
            Assert.AreEqual(pagedList.options.pageSize, 10);
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
            Assert.IsNotNull(pagedList.options);

            // Verifica tamanho maximo de paginas calculadas e se numero e tamanho da pagina estao corretos
            Assert.AreEqual(pagedList.options.pageCount, 35);
            Assert.AreEqual(pagedList.options.pageNumber, pageNumber);
            Assert.AreEqual(pagedList.options.pageSize, pageSize);
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
            Assert.IsNotNull(pagedList.navigator);

            // Verifica tamanho do navegador e das paginas numericas
            Assert.AreEqual(pagedList.navigator.navigatorSize, 6);
            Assert.AreEqual(pagedList.navigator.numerics.Count, 6);

            // Verifica se populou corretamente
            Assert.AreEqual(pagedList.navigator.numerics[2].number, pageNumber);
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
            Assert.AreEqual(pagedList.options.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(1, pagedList.navigator.first.number);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + "1",
                pagedList.navigator.first.url);
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
            Assert.AreEqual(pagedList.options.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageNumber - 1, pagedList.navigator.previous.number);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + (pageNumber - 1).ToString(),
                pagedList.navigator.previous.url);
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
            Assert.AreEqual(pagedList.options.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageNumber + 1, pagedList.navigator.next.number);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + (pageNumber + 1).ToString(),
                pagedList.navigator.next.url);
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
            Assert.AreEqual(pagedList.options.pageNumber, pageNumber);

            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(pageCount, pagedList.navigator.last.number);
            // verifica se recebeu número da pagina corretamente
            Assert.AreEqual(
                urlAfterMountingWithoutPageNumber + pageCount.ToString(),
                pagedList.navigator.last.url);
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
            Assert.AreEqual(30, pagedList.navigator.numerics[0].number);
            Assert.AreEqual(31, pagedList.navigator.numerics[1].number);
            Assert.AreEqual(32, pagedList.navigator.numerics[2].number);
            Assert.AreEqual(33, pagedList.navigator.numerics[3].number);
            Assert.AreEqual(34, pagedList.navigator.numerics[4].number);
            Assert.AreEqual(35, pagedList.navigator.numerics[5].number);
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

            // verifica se bão foram construidas
            Assert.IsNull(pagedList.navigator.first);
            Assert.IsNull(pagedList.navigator.previous);
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

            // verifica se bão foram construidas
            Assert.IsNull(pagedList.navigator.last);
            Assert.IsNull(pagedList.navigator.next);
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
            string jsonExpected = "{\"options\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},\"next\":{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},{\"url\":\"?pageSize=10&pageNumber=5\",\"number\":5},{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6}]}}";

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
            string jsonExpected = "{\"options\":{\"pageNumber\":5,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":null,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=4\",\"number\":4},\"next\":{\"url\":\"?pageSize=10&pageNumber=6\",\"number\":6},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":null}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }

        /// <summary>
        /// Testa a conversão para uma string json com navegador e na primeira página
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithUrlNavigator_FirstPage()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 100;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 1;
            // Tamanho do navegador de url
            int navigatorSize = 3;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // Json esperado
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":{\"url\":\"?pageSize=10&pageNumber=2\",\"number\":2},\"last\":{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10},\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},{\"url\":\"?pageSize=10&pageNumber=2\",\"number\":2},{\"url\":\"?pageSize=10&pageNumber=3\",\"number\":3}]}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }

        /// <summary>
        /// Testa a conversão para uma string json com navegador na ultima página
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithUrlNavigator_LastPage()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 100;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 10;
            // Tamanho do navegador de url
            int navigatorSize = 3;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // Json esperado
            string jsonExpected = "{\"options\":{\"pageNumber\":10,\"pageSize\":10,\"itemCount\":100,\"pageCount\":10},\"navigator\":{\"navigatorSize\":3,\"first\":{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1},\"previous\":{\"url\":\"?pageSize=10&pageNumber=9\",\"number\":9},\"next\":null,\"last\":null,\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=8\",\"number\":8},{\"url\":\"?pageSize=10&pageNumber=9\",\"number\":9},{\"url\":\"?pageSize=10&pageNumber=10\",\"number\":10}]}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }

        /// <summary>
        /// Testa a conversão para uma string json com navegador na unica pagina existente
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithUrlNavigator_OnlyPage()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 10;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 1;
            // Tamanho do navegador de url
            int navigatorSize = 3;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // Json esperado
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":10,\"pageCount\":1},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":null,\"last\":null,\"numerics\":[{\"url\":\"?pageSize=10&pageNumber=1\",\"number\":1}]}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }

        /// <summary>
        /// Testa a conversão para uma string json com navegador na unica pagina existente
        /// </summary>
        [TestMethod]
        public void PagedList_ToJson_WithUrlNavigator_EmptyItems()
        {
            // define url curta
            string minimalUrl = "";
            // total de itens existente em todas as páginas
            int itemCount = 0;
            // Itens por página
            int pageSize = 10;
            // Página atual
            int pageNumber = 1;
            // Tamanho do navegador de url
            int navigatorSize = 3;

            // Cria lista paginada 
            PagedList pagedList = new PagedList(minimalUrl, itemCount, pageNumber, pageSize, navigatorSize);

            // Json esperado
            string jsonExpected = "{\"options\":{\"pageNumber\":1,\"pageSize\":10,\"itemCount\":0,\"pageCount\":0},\"navigator\":{\"navigatorSize\":3,\"first\":null,\"previous\":null,\"next\":null,\"last\":null,\"numerics\":null}}";

            // Converte para string json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pagedList);

            Assert.AreEqual(json, jsonExpected);
        }
    }    
}
