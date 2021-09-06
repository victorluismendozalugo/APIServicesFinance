using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;

namespace apiServices
{
    public class Emailer
    {

        public void EnviarEmail(string correoCliente, string GUID)
        {

            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            string strHost = smtpSection.Network.Host;
            int port = smtpSection.Network.Port;
            string strUserName = smtpSection.Network.UserName;
            string strFromPass = smtpSection.Network.Password;

            SmtpClient smtp = new SmtpClient(strHost, port);
            NetworkCredential cert = new NetworkCredential(strUserName, strFromPass);
            smtp.Credentials = cert;
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage(smtpSection.From, correoCliente);

            msg.Subject = "FinanceApp, activación de cuenta";
            msg.IsBodyHtml = true;
            msg.Body += "<h1> FinanceAPP </a></h1>";
            msg.Body += "<p><h3>Para habilitar su cuenta haga click en el botón de abajo</h3></p>";

            msg.Body += "<td valign='top' align='left' width='630'>";
            msg.Body += "<div style='margin:0;outline:none;padding:0;text-align:center'>";
            msg.Body += "<a href='http://localhost:49890/activation/user?guid=" + GUID + "'";
            msg.Body += "style='margin:0;outline:none;padding:12px;color:#ffffff;background:#0088cc;background-color:#0088cc;border:1px solid #b5b5b5;border-radius:3px;font-family:Open Sans,Roboto,San Francisco,Helvetica,Arial,sans-serif;font-size:19px;display:inline-block;line-height:1.1;text-align:center;text-decoration:none'";
            msg.Body += "data-saferedirecturl='http://localhost:49890/activation/user?guid=" + GUID + "'>";
            msg.Body += "<span";
            msg.Body += "style='color:#ffffff;font-family:Open Sans,Roboto,San Francisco,Helvetica,Arial,sans-serif;font-size:19px;font-weight:bold' >";
            msg.Body += "ACTIVAR MI CUENTA</span></a>";
            msg.Body += "</div>";
            msg.Body += "</td>";

            smtp.Send(msg);
        }
    }
}