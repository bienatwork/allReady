﻿using System.Threading.Tasks;
using AllReady.Services;
using MediatR;

namespace AllReady.Features.Manage
{
    public class SendResetPasswordEmailHandlerAsync : AsyncRequestHandler<SendResetPasswordEmail>
    {
        private readonly IEmailSender emailSender;

        public SendResetPasswordEmailHandlerAsync(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        protected override async Task HandleCore(SendResetPasswordEmail message)
        {
            await emailSender.SendEmailAsync(message.Email, "Reset allReady Password", 
                $"Please reset your allReady password by clicking here: <a href=\"{message.CallbackUrl}\">link</a>")
                .ConfigureAwait(false);
        }
    }
}
