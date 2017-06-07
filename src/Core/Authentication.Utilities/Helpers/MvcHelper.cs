using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Utilities.Helpers
{
  public static partial class Helper
  {
    public static string NameOfController<TController>() 
      where TController : Controller
    {
      return typeof(TController).Name.EndsWith("Controller")
        ? typeof(TController).Name.Replace("Controller", String.Empty)
        : typeof(TController).Name;
    }

    public static string LocalPath<TController>(string action = "Index")
      where TController : Controller
    {
      var controller =  typeof(TController).Name.EndsWith("Controller")
        ? typeof(TController).Name.Replace("Controller", String.Empty)
        : typeof(TController).Name;

      return $"/{controller}/{action}";
    }
  }
}
