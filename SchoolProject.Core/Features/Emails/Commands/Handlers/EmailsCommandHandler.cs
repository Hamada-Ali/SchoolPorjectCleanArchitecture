using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Emails.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Interface;

namespace SchoolProject.Core.Features.Emails.Commands.Handlers
{
    public class EmailsCommandHandler : ResponseHandler, IRequestHandler<SendEmailCommand, ResponseInformation<string>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IEmailsService _emailsService;

        public EmailsCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IEmailsService emailsService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _emailsService = emailsService;
        }

        public async Task<ResponseInformation<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _emailsService.SendEmail(request.Email, request.Message, null);

            if (response == "Success")
            {
                return Success("Email Send Successfully");
            }

            return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.OperationFailed]);
        }
    }
}
