using CWC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CWC.MVC.Helpers
{
    public static class ExtensionMetbods
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<Trainor> producteurs)
        {
            return
                producteurs.OrderBy(prod => prod.FirstName)
                      .Select(prod =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = prod.FirstName + " " + prod.LastName,
                              Value = prod.Id.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItemsProd(
this IEnumerable<Product> products)
        {
            return
                products.OrderBy(prod => prod.Name)
                      .Select(prod =>
                          new SelectListItem
                          {
                              Text = prod.Name,
                              Value = prod.ProductId.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItemsProv(
this IEnumerable<Provider> providers)
        {
            return
                providers.OrderBy(prov => prov.Name)
                      .Select(prov =>
                          new SelectListItem
                          {
                              Text = prov.Name,
                              Value = prov.ProviderId.ToString()
                          });
        }

        public static IEnumerable<SelectListItem> ToSelectListItems(
              this IEnumerable<string> types)
        {
            return
                types.OrderBy(type => type)
                      .Select(type =>
                          new SelectListItem
                          {

                              Text = type,
                              Value = type
                          });
        }
		
		 public static IEnumerable<SelectListItem> ToSelectListItemsProject(
             this IEnumerable<Project> producteurs)
        {
            return
                producteurs.OrderBy(prod => prod.Name)
                      .Select(prod =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = prod.Name,
                              Value = prod.ProjectId.ToString()
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItemsEmployee(
            this IEnumerable<Employee> emp)
        {
            return
                emp.OrderBy(prod => prod.LastName)
                      .Select(prod =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = prod.FirstName + " " + prod.LastName,
                              Value = prod.Id.ToString()
                          });
        }


        public static IEnumerable<SelectListItem> ToSelectListItemsTypeProd(
           this IEnumerable<string> types)
        {
            return
                types.OrderBy(type => type)
                      .Select(type =>
                          new SelectListItem
                          {

                              Text = type,
                              Value = type
                          });
        }
        public static IEnumerable<SelectListItem> ToSelectListItemsInt(
             this IEnumerable<int> types)
        {
            return
                types.OrderBy(type => type)
                      .Select(type =>
                          new SelectListItem
                          {

                              Text = type.ToString(),
                              Value = type.ToString()
                          });
        }

    }



}