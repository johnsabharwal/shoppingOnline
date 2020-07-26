using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Interface
{
    public interface IEmailSenderService
    {
        bool SendEmail(string email, string name, string subject, string link, string path);
    }
}
