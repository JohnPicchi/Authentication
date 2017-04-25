using System;

namespace Authentication.Repository
{
  public interface IEntity
  {
    DateTime DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }
}
