using System;

namespace Authentication.Database
{
  public interface IEntity
  {
    DateTime DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }
}
