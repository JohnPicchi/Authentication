using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Domain
{
  public interface IFactory <TEntity>
    where TEntity: IDomainEntity
  {
    TEntity Create();
  }
}
