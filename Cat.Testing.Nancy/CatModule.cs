using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Cat.Core;
using Nancy;
using Nancy.Responses;

namespace Cat.Hosting.Nancy
{
    public class CatModule : NancyModule
    {
        public CatModule()
        {
            Get["/cats"] = p =>
                {
                    var returns = new Dictionary<String, String>();
                    var cats = new CatCollection(ConfigurationManager.AppSettings["CatLocation"]);
                    foreach (var cat in cats)
                    {
                        var meow = cat.Meow();
                        returns.Add(meow.MeowCode, meow.Message);
                    }
                    return new JsonResponse(returns, new DefaultJsonSerializer());
                };
        }
    }
}