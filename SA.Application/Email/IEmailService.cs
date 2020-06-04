using System.Collections.Generic;
using System.Threading.Tasks;

namespace SA.Application.Email
{
    public interface IEmailService
    {
        Task Send(EmailMessage emailMessage);
        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}
