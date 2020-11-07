using BlockbusterApp.src.Infrastructure.Service.Mailer;
using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.Email
{
    public class SendUserWelcomeEmailUseCase : IUseCase
    {
        private IMailer mailer;
        private SendUserWelcomeEmailConverter sendUserWelcomeEmailConverter;
        public SendUserWelcomeEmailUseCase(IMailer mailer, SendUserWelcomeEmailConverter sendUserWelcomeEmailConverter)
        {
            this.mailer = mailer;
            this.sendUserWelcomeEmailConverter = sendUserWelcomeEmailConverter;
        }

        public IResponse Execute(IRequest req)
        {
            SendUserWelcomeEmailRequest request = req as SendUserWelcomeEmailRequest;
            string email = request.Email;
            string firstName = request.FirstName;
            string lastName = request.LastName;
            string body = request.EmailBody();

            mailer.Send(SendUserWelcomeEmailRequest.EMAIL_FROM, email, SendUserWelcomeEmailRequest.EMAIL_SUBJECT, body);

            return sendUserWelcomeEmailConverter.Convert();
        }
    }
}
