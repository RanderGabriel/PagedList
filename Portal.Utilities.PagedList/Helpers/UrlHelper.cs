using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Portal.Utilities.PagedList.Helpers
{
    /// <summary>
    /// Classe de apoio para manipular URL
    /// </summary>
    public static class UrlHelper
    {
        /// <summary>
        /// Remove a querystring da URL
        /// </summary>
        /// <param name="Url">URL Completa</param>
        /// <returns>URL sem a QueryString</returns>
        public static string GetUrlWithoutQueryString(string Url)
        {
            // Verifica se não contém querystring
            if(!(Url.Contains("?") || Url.Contains("&"))) 
            {
                //Retorna a própria Url
                return Url;
            }
            // Verifica se e querystring pura
            else if((Url.Contains("&") && !Url.Contains("?")) || (Url.Contains("?") && Url.IndexOf("?")==0))
            {
                // Retorna URL base vazia
                return String.Empty;
            }
            // Se não, corta a querystring
            else
            {
                // Recupera posição de início da querystring
                int startPositionQueryString = Url.IndexOf("?");

                // Define posição de corte da Url
                int endPostionUrlBase = (startPositionQueryString >= 0) ? startPositionQueryString : Url.Length;

                // Retorna a URL base sem querystring
                return Url.Substring(0, endPostionUrlBase);
            }
        }

        /// <summary>
        /// Remove determinado(s) parametro(s) da querystring de uma URL
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Parameter">Parâmetros</param>
        /// <returns></returns>
        public static string RemoveParameterFromQueryString(string Url, string[] Parameters = null)
        {
            // Verifica se possui querystring na URL
            if (Url.Contains("?") || Url.Contains("&")) { 
                
                // Transforma querystring em collection
                NameValueCollection collection = ParseQueryString(Url);

                // Passa pelos parametros recebidos
                foreach(string parameter in Parameters) {
                    collection.Remove(parameter);
                }

                // Retorna em string
                return GetUrlWithoutQueryString(Url) + "?" + ToQueryString(collection);
            }
            else // Se não tiver querystring
            {
                // Retorna a própria URL
                return Url;
            }
        }

        /// <summary>
        /// Converte uma string de querystring para uma collection
        /// </summary>
        /// <param name="querystring">Url ou apenas a QueryString</param>
        /// <returns>Coleção com parâmetros</returns>
        public static NameValueCollection ParseQueryString(string querystring)
        {
            NameValueCollection collection = new NameValueCollection();

            // Remove qualquer coisa da url mantendo apenas a query string
            if (querystring.Contains("?"))
            {
                querystring = querystring.Substring(querystring.IndexOf('?') + 1);
            }

            // Se a quertstring for vazia, retorna collection vazia
            if (querystring.Trim().Length == 0 || !(querystring.Contains("?") || querystring.Contains("&") || querystring.Contains("=")))
                return collection;

            // Passa pelos parâmetros da querystring
            foreach (string parameters in Regex.Split(querystring, "&"))
            {
                // Recupera nome do parâmetro e valor
                string[] singlePair = Regex.Split(parameters, "=");

                // Se recebeu nome do parametro e valor, adiciona par
                if (singlePair.Length == 2)
                {
                    collection.Add(singlePair[0], singlePair[1]);
                }
                else // se recebeu apenas nome do parâmetro, adciona com valor vazio
                {
                    collection.Add(singlePair[0], string.Empty);
                }
            }

            // Retorna conversão da querystring
            return collection;
        }

        /// <summary>
        /// Converte uma coleção de pares em querystring 
        /// </summary>
        /// <param name="url">coleção de parametros/valor</param>
        /// <returns>Querystring</returns>
        public static string ToQueryString(NameValueCollection collection)
        {
            // Inicializa variavel local
            string querystring = String.Empty;

            // Passa pelos parâmetros da querystring
            for(int i=0; i < collection.Count ; i++)
            {
                // se não for o primeiro loop, adciona caracter para concatenar parametros
                if(i>0) querystring += "&";

                // Recupera par chave/valor
                string key = collection.GetKey(i);
                string value = collection.Get(i);

                // Concatena chave/valor
                querystring += key + "=" + value;
            }
            
            // Retorna conversão da collection
            return querystring;
        }
    }
}
