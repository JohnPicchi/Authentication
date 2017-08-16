using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Authentication.Core.ServiceContracts;

namespace Authentication.Services
{
  public class SmsService : ISmsService
  {
   // private readonly Lazy<AmazonSimpleNotificationServiceClient> simpleNotificationServiceClient;
   //
   // public SmsService()
   // {
   //   simpleNotificationServiceClient = new Lazy <AmazonSimpleNotificationServiceClient>(() => new AmazonSimpleNotificationServiceClient(
   //     awsAccessKeyId: "", 
   //     awsSecretAccessKey: "", 
   //     region: RegionEndpoint.USEast1));
   // }
   //
   // public async Task<PublishResponse> SendSmsMessageAsync(string phoneNumber, string subject, string message)
   // {
   //   var publishRequest = new PublishRequest
   //   {
   //     PhoneNumber = phoneNumber,
   //     Subject = subject,
   //     Message = message,
   //   };
   //   return await simpleNotificationServiceClient.Value.PublishAsync(publishRequest);
   // }
  }
}
