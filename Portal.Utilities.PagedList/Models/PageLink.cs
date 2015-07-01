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
        public PageLink(string Url, int PageNumber) {
            
            // Define o número da página
            number = PageNumber;

            // Verifica se URL possui flag de querystring, para inserir "?" ou "&"
            Url += (Url.Contains("?")) ? "&" : "?" ;

            // Define a URL com o número da página
            url = Url + "pageNumber=" + PageNumber.ToString();
        }

        /// <summary>
        /// URL para acessar a página
        /// </summary>
        public string url { get; private set; }

        /// <summary>
        /// Número da página
        /// </summary>
        public int number { get; private set; }
    }
}
