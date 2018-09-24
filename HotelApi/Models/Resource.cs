using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NJsonSchema;
using Remotion.Linq.Clauses;

namespace HotelApi.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}
