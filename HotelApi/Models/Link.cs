using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotelApi.Models
{
    public class Link
    {
        public const string GetMethod = "Get";


        public static Link To(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod

            };


        public static Link ToCollection(string routeName, object routeValues = null)
            => new Link
            {
                RouteName = routeName,
                RouteValues = routeValues,
                Method = GetMethod,
                Relations = new[] {"collection"}
            };


        [JsonProperty(Order=-4)]
        public string Href { get; set; }
        [JsonProperty(Order = -3, PropertyName = "rel" ,  NullValueHandling = NullValueHandling.Ignore)]
        public string[] Relations { get; set; }
        [JsonProperty(Order = -2 , DefaultValueHandling =  DefaultValueHandling.Ignore,NullValueHandling =NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        [JsonIgnore]
        public string RouteName { get; set; }
        
        [JsonIgnore]
        public object RouteValues { get; set; }

    }
}
