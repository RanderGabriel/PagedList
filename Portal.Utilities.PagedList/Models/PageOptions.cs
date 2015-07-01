using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Utilities.PagedList.Models
{
    /// <summary>
    /// Classe de opções de página para paginação
    /// </summary>
    public class PageOptions
    {
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public PageOptions(long _itemCount, int _pageNumber = PAGE_NUMBER_DEFAULT, int _pageSize = PAGE_SIZE_DEFAULT)
        {
            
            // Define a quantidade total de itens
            this.itemCount = _itemCount;

            // Define o número da página, se não informada, atribui valor padrão
            this.pageNumber = _pageNumber;

            // Define a quantidade de itens por página, se não informada, atribui valor padrão
            this.pageSize = _pageSize;

            // Calcula total de páginas possíveis
            this.CalculatePageCount();

            // Verifica o número da página recebido
            this.CheckPageNumber();
        }

        /// <summary>
        /// Valor default para número da página
        /// </summary>
        public const int PAGE_NUMBER_DEFAULT = 1;

        /// <summary>
        /// Valor default para itens por página
        /// </summary>
        public const int PAGE_SIZE_DEFAULT = 10;

        /// <summary>
        /// Número da página atual
        /// </summary>
        private int _pageNumber;
        
        /// <summary>
        /// Número da página atual
        /// </summary>
        public int pageNumber 
        {
            get { return _pageNumber; }
            private set {
                // se valor negativo ou zero, atribui valor default
                _pageNumber = (value<1) ? PAGE_NUMBER_DEFAULT : value ;
            }
        }

        /// <summary>
        /// Número de itens por página
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// Número de itens por página
        /// </summary>
        public int pageSize
        {
            get { return _pageSize; }
            private set
            {
                // se valor negativo ou zero, atribui valor default
                _pageSize = (value < 1) ? PAGE_SIZE_DEFAULT : value;
            }
        }

        /// <summary>
        /// Total de itens em todas as páginas
        /// </summary>
        private long _itemCount;

        /// <summary>
        /// Total de itens em todas as páginas
        /// </summary>
        public long itemCount
        {
            get { return _itemCount; }
            private set
            {
                // se valor negativo, atribui 0
                _itemCount = (value < 0) ? 0 : value;
            }
        }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int pageCount { get; private set; }

        /// <summary>
        /// Método para calcular total de páginas
        /// </summary>
        private void CalculatePageCount() {

            // Obtem total de páginas inteiras
            int totalPages = (int)itemCount / pageSize;

            // Verifica se existe mais alguma página com o resto e adciona nova página
            if (itemCount % pageSize != 0) totalPages++;

            // Seta total de páginas na classe
            this.pageCount = totalPages;
        }

        /// <summary>
        /// Método para verificar valor do numero da página
        /// </summary>
        private void CheckPageNumber()
        {
            // Verifica se a página existe dentro das possíveis páginas
            if (pageNumber > pageCount) 
            { 
                // Se é maior do que a última página, troca para a última
                pageNumber = pageCount;
            }
        }
    }
}
