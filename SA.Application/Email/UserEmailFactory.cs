using System;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using SA.Application.Account;
using SA.Application.Records;
using SA.Core.Model;

namespace SA.Application.Email
{
    public class UserEmailFactory : IUserEmailFactory
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        public UserEmailFactory(
            IEmailConfiguration emailConfiguration,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _emailConfiguration = emailConfiguration;
            _emailService = emailService;
            _configuration = configuration;
        }

        public EmailMessage ResetPassword(UserSimpleDto user, UserActivation activation)
        {
            var email = new EmailMessage();
            email.FromAddresses.Add(new EmailAddress
            {
                Name = "JeraTrading s.r.o.",
                Address = _emailConfiguration.NoReplyEmail
            });

            email.ToAddresses.Add(new EmailAddress
            {
                Name = user.Email,
                Address = user.Email
            });

            var resetPasswordHyperlink = $"<a href='{_configuration["ApiUrl:Url"]}/userActivations/userPasswordReset?token={activation.Token}'>Reset hesla</a>";

            email.Subject = $"Reset hesla uživatele { user.UserName }";
            email.Content = $@"<p>Bylo zažádáno o obnovení hesla pro uživatele <strong>{ user.UserName }</strong>. Pokud jste o změnu nežádali, dejte nám prosím vědět a žádný úkon neprovádějte.</p>
<p>Pro obnovení hesla přejděte na stránky prostřednictvím odkazu { resetPasswordHyperlink }</p>
<p>Váš tým <strong>Jera Trading s.r.o.</strong></p>";

            _emailService.Send(email);

            return email;
        }

        public EmailMessage SendActivationEmail(User user, UserActivation activation)
        {
            var email = new EmailMessage();
            email.FromAddresses.Add(new EmailAddress
            {
                Name = "JeraTrading s.r.o.",
                Address = _emailConfiguration.NoReplyEmail
            });

            email.ToAddresses.Add(new EmailAddress
            {
                Name = $"{user.Customer.FirstName} {user.Customer.LastName}",
                Address = user.Customer.Email
            });

            var registrationHyperlink = $"<a href='{_configuration["ApiUrl:Url"]}/userActivations/userValidation?token={activation.Token}'>Potvrdit registraci</a>";

            var language = "Český";
            switch (user.Language)
            {
                case "en":
                    language = "Anglický";
                    break;
                case "de":
                    language = "Německý";
                    break;
                case "ru":
                    language = "Ruský";
                    break;
                case "sk":
                    language = "Slovenský";
                    break;
            }

            email.Subject = "Registrace na webu Jera Trading s.r.o.";
            email.Content = $@"<h1>Děkujeme za registraci na portálu Jera Trading s.r.o.</h1>
<p>Rekapitulace reigstrovaných informací</p>
<h4>Uživatel</h4>
<ul>
    <li>Uživatelské jméno: <strong>{user.UserName}</strong></li>
    <li>Souhlas s obchodními podmínkami: <strong>{ (user.IsAgreementToTerms ? "Ano" : "Ne") }</strong></li>
    <li>Zasílání novinek: <strong>{ (user.SendingNews ? "Ano" : "Ne") }</strong></li>
    <li>Preferovaný jazyk: <strong>{ language }</strong></li>
</ul>
<h4>Zákazník</h4>
<ul>
    <li>Jméno a Příjmení: <strong>{ user.Customer.TitleBefore} { user.Customer.FirstName} {user.Customer.LastName} {user.Customer.TitleAfter}</strong></li>    
    <li>Rodné číslo: <strong>{ user.Customer.BirthNumber }</strong></li>
    <li>Email: <strong>{ user.Customer.Email }</strong></li>
    <li>Telefonní číslo: <strong>{ user.Customer.PhoneNumber }</strong></li>
    <li>Společnost: <strong>{ user.Customer.CompanyName }</strong></li>
    <li>IČO: <strong>{ user.Customer.CompanyNumber }</strong></li>
    <li>DIČ: <strong>{ user.Customer.CompanyLegalNumber }</strong></li>
    <li>Webové stránky: <strong>{ user.Customer.WebPageUrl }</strong></li>
</ul>
<h4>Adresa</h4>
<ul>
    <li>Ulice a PSČ: { user.Customer.Address.Street } { user.Customer.Address.PostCode }</strong></li>    
    <li>Město: { user.Customer.Address.City }</li>
</ul><br />
<p>Pro dokončení registrace prosím potvrďte kliknutím na tento odkaz { registrationHyperlink }</p>
<p>Váš tým <strong>Jera Trading s.r.o.</strong></p>";

            _emailService.Send(email);

            return email;
        }

        public EmailMessage SendAuctionWonEmail(User user, RecordDetailDto record)
        {
            var email = new EmailMessage();
            email.FromAddresses.Add(new EmailAddress
            {
                Name = "JeraTrading s.r.o.",
                Address = _emailConfiguration.NoReplyEmail
            });

            email.ToAddresses.Add(new EmailAddress
            {
                Name = $"{user.Customer.FirstName} {user.Customer.LastName}",
                Address = user.Customer.Email
            });

            email.Subject = $"Výhra v aukci Jera Trading s.r.o. na položku { record.Name }";
            email.Content = $@"<h1>Gratulujeme k výhře v aukci ""{ record.Name }""</h1>
<h3>Rekapitulace aukce</h3>
<ul>
    <li>Název: <strong>{ record.Name }</strong></li>
    <li>Vydraženo za: <strong>{ record.CurrentPrice.ToString("C", new CultureInfo("cs-CZ")) }</strong></li>    
</ul>
<p>Brzy vás budeme kontaktovat pro další postup platby a předávky draženého předmětu</p>";

            _emailService.Send(email);

            return email;
        }
    }
}
