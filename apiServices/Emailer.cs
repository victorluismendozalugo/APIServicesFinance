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

        public void EnviarEmail(string correoCliente)
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

            msg.Subject = "Para habilitar su cuenta ingrese en la direccion de abajo";
            msg.IsBodyHtml = true;
            msg.Body += "<h1> FinanceAPP </a></h1>";
            msg.Body += "<p></p>";

            msg.Body += "<ul>";
            msg.Body += "<li>Usuario:" + "" + "</li>";
            msg.Body += "<li>Sucursal:" + "" + "</li>";
            msg.Body += "<li>Datos Enviados:" + "" + "</li>";
            msg.Body += "<li>Pantalla:" + "" + "</li>";
            msg.Body += "<li><p>" + "" + "</p></li>";

            msg.Body += "<img src ='http://erpsite.tecnosin.com.mx/images/LogoWeb-300x138.png' alt='Sistema'/>";
            msg.Body += "</ul>";

            smtp.Send(msg);
        }
    }
}