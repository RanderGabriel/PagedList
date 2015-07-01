using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portal.Utilities.PagedList.Models;
using Portal.Utilities.PagedList.Helpers;
using Portal.Utilities.PagedList;
using Newtonsoft.Json;

namespace PagedListTest
{
    [TestClass]
    public class PageOptionsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //PageOptions options = new PageOptions(81,3,40);


            string url = "?tipo=1&filtro=asdasd&pageNumber=5&cod=123123";
            //url = "http://www.google.com";

            string urlbase = UrlHelper.GetUrlWithoutQueryString(url);

            //string querystring = UrlHelper.GetQueryStringFromUrl(url);

            string[] par = new string[] { "tipo","filtsro" };
            string xx = UrlHelper.RemoveParameterFromQueryString(url,par);

            PagedList pagedList = new PagedList(url, 88, 8, 10);

            String json = JsonConvert.SerializeObject(pagedList);
            
            string x = "wait";

        }
    }
}
