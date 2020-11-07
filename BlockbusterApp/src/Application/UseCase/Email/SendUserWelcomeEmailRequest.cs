using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email
{
    public class SendUserWelcomeEmailRequest : IRequest
    {
        public const string EMAIL_FROM = "blockbuster@email.com";
        public const string EMAIL_SUBJECT = "Welcome email";


        public SendUserWelcomeEmailRequest
        (
            string email,
            string firstName,
            string lastName
        )
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string EmailBody()
        {
            return "Gracias por registrarte "+FirstName+" "+LastName+". Recuerda que para iniciar sesión en nuestra aplicación debes usar tu email "+Email+" y tu contraseña.";
        }
    }
}
