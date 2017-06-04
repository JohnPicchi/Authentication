using System;
using System.Linq;
using System.Reflection;
using Authentication.Domain;
using Castle.DynamicProxy;

namespace Authentication.Container.Interceptors
{
  public class DomainTransaction : IInterceptor
  {
    public void Intercept(IInvocation invocation)
    {
     // invocation.Proceed();
     //
     // var ignoreMutation = invocation.Method.Name.Contains(nameof(IDomainEntity.IsDirty));
     // ignoreMutation |= (invocation.Method.IsSpecialName && invocation.Method.Name.StartsWith("get_"));
     //
     // if (!ignoreMutation)
     // {
     //   var mutatedDomainModel = invocation.InvocationTarget as IDomainEntity;
     //   //if (!mutatedDomainModel.IsDirty)
     //   //{
     //     var domainMutation = (DomainMutation) invocation.Method
     //       .GetCustomAttributes(typeof(DomainMutation))
     //       .FirstOrDefault();
     //
     //   if (domainMutation != null)
     //   {
     //     mutatedDomainModel.IsDirty = true;
     //     Console.WriteLine($"{invocation.Method.Name}");
     //   }
     //
     //   else if (invocation.Method.IsSpecialName && invocation.Method.Name.StartsWith("set_"))
     //       mutatedDomainModel.IsDirty = true;
     //   //}
     // }
    }
  }
}