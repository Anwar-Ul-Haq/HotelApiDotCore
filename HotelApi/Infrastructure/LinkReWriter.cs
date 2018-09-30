using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Infrastructure
{
    public class LinkReWriter
    {
        private readonly IUrlHelper _urlHelper;

        public LinkReWriter(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }


        public Link Rewrite(Link original)
        {

            if (original == null) return null;

            return new Link
            {
                Href = _urlHelper.Link(original.RouteName, original.RouteValues),
                Method = original.Method,
                Relations = original.Relations
            };


        }
    }
}

