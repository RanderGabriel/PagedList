using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Utilities.PagedList.Models;

namespace Portal.Utilities.PagedList.Tests.Models
{
    /// <summary>
    /// Classe que testa modelo de PageOptions
    /// </summary>
    [TestClass]
    public class PageOptionsTests
    {
        /// <summary>
        /// Testa atribuição de valores padrões
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_Defaults()
        {
            // instancia passando apenas total de itens
            PageOptions options = new PageOptions(100);

            // Verifica padrões de pagina atual 1 e itens por pagina 10
            Assert.AreEqual(options.pageNumber, 1);
            Assert.AreEqual(options.pageSize, 10);
        }

        /// <summary>
        /// Testa calculo de total de paginas
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_PageCount()
        {
            // Total 100 itens, pagina atual 1, itens por pagina 5
            PageOptions options = new PageOptions(100,1,5);

            // Verifica se total de páginas dá 20
            Assert.AreEqual(options.pageCount, 20);
        }

        /// <summary>
        /// Testa atribuição de itens negativo
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_InvalidItemCount()
        {
            // Total -100 itens, pagina atual 1, itens por pagina 5
            PageOptions options = new PageOptions(-100, 1, 5);

            // Verifica se total de páginas dá 0
            Assert.AreEqual(options.pageCount, 0);
            // Verifica se total de itens dá 0
            Assert.AreEqual(options.itemCount, 0);
        }

        /// <summary>
        /// Testa atribuição de numero da página negativa ou zero
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_InvalidPageNumber()
        {
            // Total 100 itens, pagina atual 0, itens por pagina 5
            PageOptions options1 = new PageOptions(100, 0, 5);
            // Total 100 itens, pagina atual -5, itens por pagina 5
            PageOptions options2 = new PageOptions(100, -5, 5);

            // Verifica se numero da página é 1
            Assert.AreEqual(options1.pageNumber, 1);
            // Verifica se numero da página é 1
            Assert.AreEqual(options2.pageNumber, 1);
        }

        /// <summary>
        /// Testa atribuição de numero itens por pagina negativa ou zero
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_InvalidPageSize()
        {
            // Total 100 itens, pagina atual 1, itens por pagina 0
            PageOptions options1 = new PageOptions(100, 1, 0);
            // Total 100 itens, pagina atual 1, itens por pagina -5
            PageOptions options2 = new PageOptions(100, 1, -5);

            // Verifica se total de itens na pagina da 10 (default)
            Assert.AreEqual(options1.pageSize, 10);
            // Verifica se total de itens na pagina da 10 (default)
            Assert.AreEqual(options2.pageSize, 10);
        }

        /// <summary>
        /// Testa atribuição de numero da pagina maior que o máximo
        /// </summary>
        [TestMethod]
        public void PageOptions_Construct_PageNumberOver()
        {
            // Total 100 itens, pagina atual 25, itens por pagina 5, deve dar 20 paginas
            PageOptions options = new PageOptions(100, 25, 5);

            // Verifica se numero da página é igual ao total de páginas
            Assert.AreEqual(options.pageNumber, options.pageCount);
            // Verifica se numero do total de páginas é 20
            Assert.AreEqual(20, options.pageCount);
        }

    }
}
