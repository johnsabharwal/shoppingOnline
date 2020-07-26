using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Dal.Interface;

namespace Dal.Implementation
{
  public  class EmailSenderService:IEmailSenderService
    {
        public bool SendEmail(string email, string name, string subject,string link,string path)
        {

            var template =
                "<div width='100%' style='margin:0;padding:0!important;background-color:#f5f6f9;font-size:12.0pt;font-family:&quot;Source Sans Pro&quot;,Verdana;color:#6f727d'> <center style='width:100%;background-color:#f5f6f9'> <div style='max-width:600px;margin:0 auto'> <table align='center' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin:0 auto'> <tbody><tr> <td> <table align='center' cellspacing='0' cellpadding='0' border='0' width='100%' style='margin:0 auto'> <tbody><tr> <td height='40' style='font-size:0px;line-height:0px'> &nbsp; </td></tr><tr> <td style='background-color:#ffffff'> <img src='[path]' alt='alt_text' border='0' style='width:100%;max-width:600px;height:auto;background:#ffffff;margin:auto;display:block;outline:none;border:none' data-image-whitelisted='' class='CToWUd a6T' tabindex='0'><div class='a6S' dir='ltr' style='opacity: 0.01; left: 771.6px; top: 369.8px;'><div id=':n8' class='T-I J-J5-Ji aQv T-I-ax7 L3 a5q' role='button' tabindex='0' aria-label='Download attachment mailer-header@2x.png' data-tooltip-class='a1V' data-tooltip='Download'><div class='aSK J-J5-Ji aYr'></div></div><div id=':n9' class='T-I J-J5-Ji aQv T-I-ax7 L3 a5q' role='button' tabindex='0' aria-label='Save attachment to Drive mailer-header@2x.png' data-tooltip-class='a1V' data-tooltip='Add to Drive'><div class='wtScjd J-J5-Ji aYr XG'><div class='T-aT4' style='display: none;'><div></div><div class='T-aT4-JX'></div></div></div></div></div></td></tr></tbody></table> </td></tr><tr><td style='background-color:#ffffff;border-left:solid 1px #dfdfdf;border-right:solid 1px #dfdfdf'> <table border='0' width='100%' cellspacing='0' cellpadding='0'><tbody><tr><td style='padding:0 10%;text-align:left'><p> Hi [name],<br><br>Thanks for joining us at <strong>ShoppiMania</strong>.Over the next few weeks, we’ll be sending you a few more emails to help you gain maximum value from our products. We’ll share our favorite tips and provide some exciting behind-the-scenes information.<br>Please verify the email by clicking the link below.<br><a href='[verifylink]'> Verify Email</a> <p>Should you have any questions or concerns, please contact ShoppiMania Team.<br><br>Warm regards,<br>ShoppiMania&nbsp;</p></td></tr><tr><td style='font-size:0px;line-height:0px' height='25'>&nbsp;</td></tr></tbody></table></td></tr><tr><td style='font-size:0px;line-height:0px;background-color:#ffffff;border-right:1px solid #dfdfdf;border-left:1px solid #dfdfdf' height='40'>&nbsp;</td></tr><tr><td style='font-size:0px;line-height:0px' height='40'>&nbsp;</td></tr></tbody></table> </td></tr><tr> <td style='padding:0 65px;background-color:#ffffff'> <table cellspacing='0' cellpadding='0' border='0' width='100%'> <tbody><tr> <td height='1' style='background-color:#ebedf2'></td></tr></tbody></table> </td></tr><tr> <td height='100%' valign='top' width='100%' style='background-color:#ffffff;border-right:solid 1px #dfdfdf;border-left:solid 1px #dfdfdf;border-bottom:solid 1px #dfdfdf'> <table cellspacing='0' cellpadding='0' border='0' width='100%'> <tbody><tr> <td colspan='1' height='30' style='font-size:0px;line-height:0px'> &nbsp; </td></tr><tr> <td style='padding:0 90px'> <p>Powered by ShoppiMania 2020. All rights reserved.©</p></td></tr><tr> <td colspan='1' height='30' style='font-size:0px;line-height:0px'> &nbsp; </td></tr></tbody></table> </td></tr><tr> <td height='40' style='font-size:0px;line-height:0px'> &nbsp; </td></tr></tbody></table> </div></center> <img src='' alt='' width='1' height='1' border='0' style='height:1px!important;width:1px!important;border-width:0!important;margin-top:0!important;margin-bottom:0!important;margin-right:0!important;margin-left:0!important;padding-top:0!important;padding-bottom:0!important;padding-right:0!important;padding-left:0!important' class='CToWUd'></div>";
            var fromAddress = new MailAddress("hjohn636@gmail.com", "john");
            var toAddress = new MailAddress(email, email);
            const string fromPassword = "johnS@321";
            template= template.Replace("[name]", name);
            template= template.Replace("[verifylink]", link);
            template=template.Replace("[path]", path);


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = template,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }

            return true;
        }
    }
}
