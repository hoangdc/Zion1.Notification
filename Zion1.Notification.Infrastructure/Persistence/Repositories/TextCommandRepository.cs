using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Zion1.Common.Infrastructure.Persistence.Repositories;
using Zion1.Notification.Application.Repositories;
using Zion1.Notification.Domain.Entities;

namespace Zion1.Notification.Infrastructure.Persistence.Repositories
{
    public class TextCommandRepository : CommandRepository<Text>, ITextCommandRepository
    {
        private readonly IConfiguration _config;
        public TextCommandRepository(IConfiguration configuration, NotificationDbContext notificationDbContext) : base(notificationDbContext)
        {
            _config = configuration;
        }

        public async Task<int> SaveTextAsync(Text item)
        {
            var notification = await AddAsync(item);
            return notification.Id;
        }

        public async Task<bool> SendTextAsync(Text text)
        {
            bool isSuccess = true;

            await Task.Run(() =>
            {
                //Mine
                //string accountSid = "ACa0d44cddde8096f5a4207d82eaecf2bd";
                //string authToken = "7922ba659d76fb0a6c79d37657826e39";
                //string fromPhoneNumber = "+12058437337";

                //Aperia
                //string accountSid = "AC39313b0a9f23438a435e6de2a85686e8";
                //string authToken = "92bc84da7b4c0c8042823b7efbe20533";
                //string fromPhoneNumber = "+19722365717";//"+14699494178";

                var smsSettings = _config.GetSection("SmsSettings").Get<SmsSettings>();

                if (smsSettings == null)
                {
                    isSuccess = false;
                }
                else
                {
                    TwilioClient.Init(smsSettings.AccountId, smsSettings.Token);

                    List<Uri> includedImages = new List<Uri>();
                    includedImages.Add(new Uri("https://i.ibb.co/0f25fBJ/benefit.jpg"));

                    var message = MessageResource.Create(
                        from: new PhoneNumber(smsSettings.FromPhoneNumber),
                        body: text.Message,
                        to: new PhoneNumber(GetRealPhoneNumber(text.To))
                        , mediaUrl: includedImages
                    );
                    string? result = message.ErrorMessage;
                }
            });

            return isSuccess;
        }

        private string GetRealPhoneNumber(string phoneNumber)
        {
            if (!phoneNumber.StartsWith("+1"))
                phoneNumber = "+1" + phoneNumber;

            return phoneNumber.Trim().Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Replace(".", "");
        }
    }
}
