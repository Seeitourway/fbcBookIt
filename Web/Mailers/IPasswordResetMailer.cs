using Mvc.Mailer;
using Web.Mailers.Models;

namespace Web.Mailers
{ 
    public interface IPasswordResetMailer
    {
			MvcMailMessage PasswordReset(MailerModel model);
	}
}