using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tntroc.Domain.Entities;

namespace tntroc.WebApplication.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
             this IEnumerable<goods> goodss)
        {
            return
                goodss.OrderBy(prod => prod.label)
                      .Select(prod =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = prod.label + " " + prod.brand,
                              Value = prod.id_goods.ToString()
                          });
        }

    }
}