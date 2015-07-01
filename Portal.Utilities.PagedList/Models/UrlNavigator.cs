using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Utilities.PagedList.Models
{
    /// <summary>
    /// Classe que define URLs de navegação para uma lista paginada
    /// </summary>
    public class UrlNavigator
    {
        /// <summary>
        /// Método Construtor do Navegador de URLs
        /// </summary>
        /// <param name="Url">Url sem pageNumber</param>
        /// <param name="PageNumber">Número da página</param>
        /// <param name="PageCount">Número máximo de páginas</param>
        /// <param name="NavigatorSize">Tamanho do navegador, se nulo, zero ou negativo, não gera navegador numérico</param>
        public UrlNavigator(string Url, int PageNumber, int PageCount, int? NavigatorSize) {

            // Globaliza variaveis na classe
            _pageNumber = PageNumber;
            _pageCount = PageCount;
            _url = Url;

            // se tamanho do navegador definido e valido, atribui valor e gera navegação numerica
            if (NavigatorSize != null && NavigatorSize > 0) 
            {
                navigatorSize = NavigatorSize;
                GenerateNumericNavigation();
            }

            // Gera navegação básica
            GenerateBasicNavigation();
        }

        /// <summary>
        /// Número da Página
        /// </summary>
        private int _pageNumber;

        /// <summary>
        /// Número máximo de páginas
        /// </summary>
        private int _pageCount;

        /// <summary>
        /// Url sem pageNumber
        /// </summary>
        private string _url;

        /// <summary>
        /// Tamanho do navegador de páginas
        /// </summary>
        public int? navigatorSize { get; private set; }

        /// <summary>
        /// URL da primeira página
        /// </summary>
        public PageLink first { get; private set; }

        /// <summary>
        /// URL da página anterior 
        /// </summary>
        public PageLink previous { get; private set; }

        /// <summary>
        /// URL da próxima página
        /// </summary>
        public PageLink next { get; private set; }

        /// <summary>
        /// URL da última página
        /// </summary>
        public PageLink last { get; private set; }

        /// <summary>
        /// Todas as páginas numéricas
        /// </summary>
        public IList<PageLink> numerics { get; private set; }

        /// <summary>
        /// Gera as páginas básicas (primeira, anterior, atual, próxima e ultima)
        /// </summary>
        /// <param name="Url">URL sem o pageNumber</param>
        /// <param name="PageNumber">Número da página</param>
        /// <param name="PageCount">Total de Páginas</param>
        private void GenerateBasicNavigation() { 
            // Apenas se não for pagina atual
            if (_pageNumber != 1)
            {
                // Primeira Página
                first = new PageLink(_url, 1);

                // Página Anterior
                int previousNumber = _pageNumber - 1;
                previous = new PageLink(_url, previousNumber);
            }

            // Apenas se não for pagina atual
            if (_pageNumber != _pageCount && _pageCount != 0)
            {
                // Página Seguinte
                int nextNumber = _pageNumber + 1;
                next = new PageLink(_url, nextNumber);

                // Última Página
                last = new PageLink(_url, _pageCount);
            }
        }

        /// <summary>
        /// Gera páginas numéricas (1, 2, 3, 4, 5 (...))
        /// </summary>
        public void GenerateNumericNavigation() 
        {
            // Se não tiver paginas, não gera 
            if (_pageCount == 0) return;

            // Recupera limites da exibição da listagem numérica
            int[] limits = GetComplexLimits();
            
            // inicializa variaveis locais de inicio e fim da lista numerica
            int start = limits[0];
            int end = limits[1];

            // Instancia lista
            numerics = new List<PageLink>();

            // Cria itens da lista
            for(int i=start; i<=end; i++)
            {
                //Cria item na lista
                numerics.Add( new PageLink(_url, i) );
            }
        }

        /// <summary>
        /// Calcula o inicio e o fim da navegação complexa
        /// </summary>
        /// <returns>array de inteiro com inicio e fim</returns>
        public int[] GetComplexLimits() {

            // Verifica se o inicio e o fim serão o 1 e a última págima do total de páginas
            if(_pageCount<=navigatorSize)
            {
                // retorna limite definido
                return new int[] { 1 , _pageCount};
            }

            // Calcula distância da página atual para os extremos
            int pageNumberPositionRelativeOfStart = _pageNumber - 1;
            int pageNumberPositionRelativeOfEnd = _pageCount - _pageNumber;
                
            // Calcula espaçamento para cada item nas laterais
            int leftNavigationSize = (int)navigatorSize / 2;
            int rightNavigationSize = (int)navigatorSize / 2;
                
            // Verifica se precisa remover 1 item do espaçamento da 
            // esquerda para casos de tamanho do navegador par
            if (navigatorSize % 2 == 0 && leftNavigationSize>0)
                leftNavigationSize--;

            // Caso esteja nas primeiras páginas
            if (leftNavigationSize >= pageNumberPositionRelativeOfStart)
            {
                return new int[] { 1, (int)navigatorSize };
            }
            // Caso esteja nas últimas páginas
            else if (rightNavigationSize >= pageNumberPositionRelativeOfEnd) 
            {
                return new int[] { _pageCount - ((int)navigatorSize - 1), _pageCount };
            }
            // Senão está solto no meio, retorna valor de acordo com a posição do número da página atual
            else 
            {
                return new int[] { _pageNumber - leftNavigationSize, _pageNumber + rightNavigationSize };
            }
        }
    }
}
