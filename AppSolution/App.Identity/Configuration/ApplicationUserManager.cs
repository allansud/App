using App.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using System;

namespace App.Identity.Configuration
{
    public class ApplicationUserManager : UserManager<AppUser, int>
    {
        public ApplicationUserManager(IUserStore<AppUser, int> store)
            : base(store)
        {
            // Configurando validator para nome de usuario
            UserValidator = new UserValidator<AppUser, int>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Logica de validação e complexidade de senha
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configuração de Lockout
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;

            // Providers de Two Factor Autentication
            RegisterTwoFactorProvider("Código via SMS", new PhoneNumberTokenProvider<AppUser, int>
            {
                MessageFormat = "Seu código de segurança é: {0}"
            });

            RegisterTwoFactorProvider("Código via E-mail", new EmailTokenProvider<AppUser, int>
            {
                Subject = "Código de Segurança",
                BodyFormat = "Seu código de segurança é: {0}"
            });

            // Definindo a classe de serviço de e-mail
            EmailService = new EmailService();

            // Definindo a classe de serviço de SMS
            SmsService = new SmsService();

            var provider = new DpapiDataProtectionProvider("Eduardo");
            var dataProtector = provider.Create("ASP.NET Identity");

            UserTokenProvider = new DataProtectorTokenProvider<AppUser, int>(dataProtector);
        }
    }
}
