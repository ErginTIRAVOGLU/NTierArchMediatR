using System.Net.Mail;
using System.Net;
using NTierArch.DataAccess.Context;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;
using NTierArch.Entities.Extentions;

namespace NTierArch.DataAccess.Repositories;
internal sealed class EmailParameterRepository : Repository<EmailParameter>, IEmailParameterRepository
{
    private readonly IEmailParameterRepository _emailParameterRepository;
    public EmailParameterRepository(AppDbContext context, IEmailParameterRepository emailParameterRepository) : base(context)
    {
        _emailParameterRepository = emailParameterRepository;
    }

    public async Task<Result<string>> Send(SendMailDto request, CancellationToken cancellationToken)
    {
        using (MailMessage mail = new MailMessage())
        {
            var emailParameter = await _emailParameterRepository.GetFirst();
            string[] setEmails = request.emails.Split(",");
            mail.From = new MailAddress(emailParameter.Email);
            foreach (var email in setEmails)
            {
                mail.To.Add(email);
            }
            mail.Subject = request.subject;
            mail.Body = request.body;
            mail.IsBodyHtml = emailParameter.Html;
            //mail.Attachments.Add();
            using (SmtpClient smtp = new SmtpClient(emailParameter.Smtp))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailParameter.Email, emailParameter.Password);
                smtp.EnableSsl = emailParameter.SSL;
                smtp.Port = emailParameter.Port;
                await smtp.SendMailAsync(mail);
            }
        }
        return await Task.FromResult(Result<string>.Succeed("Mail başarıyla gönderildi"));
    }
}
