﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Core.Helpers
{
  public static partial class Helpers
  {
    public static partial class Http
    {
      public struct Actions
      {
        public const string Get = "GET";
        public const string Post = "POST";
        public const string Put = "PUT";
        public const string Patch = "PATCH";
        public const string Delete = "DELETE";
      }
    }
  }
}