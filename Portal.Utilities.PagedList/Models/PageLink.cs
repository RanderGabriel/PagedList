using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Utilities.PagedList.Models
{
    /// <summary>
    /// Classe que define um link para determinada página
    /// </summary>
    public class PageLink
    {
        /// <summary>
        /// Construtor da Classe
        /// </summary>
        /// <param name="Url">URL sem pageNumber</param>
        /// <param name="PageNumber">Número da página</param>
        /// <param name="CurrentPageNumber">Número da página selecionada</param>
        public PageLink(string Url, int PageNumber, int CurrentPageNumber) {
            
            // Define o número da página
            pageNumber = PageNumber;

            // Verifica se URL possui flag de querystring, para inserir "?" ou "&"
            Url += (Url.Contains("?")) ? "&" : "?" ;

            // Define a URL com o número da página
            pageUrl = Url + "pageNumber=" + PageNumber.ToString();

            // Verifica se é a página atual
            isCurrent = (PageNumber == CurrentPageNumber);
        }

        /// <summary>
        /// URL para acessar a página
        /// </summary>
        public string pageUrl { get; private set; }

        /// <summary>
        /// Número da página
        /// </summary>
        public int pageNumber { get; private set; }

        /// <summary>
        /// Indica se é a página atual
        /// </summary>
        public bool isCurrent { get; private set; }
    }
}
