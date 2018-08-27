using SA.Application.Account;
using SA.Application.Records;
using SA.Core.Model;

namespace SA.Application.Email
{
    public interface IUserEmailFactory
    {
        EmailMessage SendActivationEmail(User user, UserActivation activation);

        EmailMessage SendAuctionWonEmail(User user, RecordDetailDto record);

        EmailMessage ResetPassword(UserSimpleDto user, UserActivation activation);
    }
}
