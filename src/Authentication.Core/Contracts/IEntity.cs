using System;

namespace Authentication.Core.Contracts
{
  public interface IEntity
  {
    DateTime DateCreated { get; set; }

    DateTime? DateUpdated { get; set; }
  }
}
