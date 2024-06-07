﻿using System.Net;
using System.Net.Mail;

namespace Eatech.Utilerias
{
    public class Correo
    {
        public static bool EnviarCorreo(string receptor, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("noreply@eatech.mx");//
            mail.To.Add(new MailAddress(receptor));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.ionos.mx";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            NetworkCredential credencial = new NetworkCredential("noreply@eatech.mx", "Test0102@01");
            smtp.Credentials = credencial;
            smtp.Send(mail);

            return true;

        }
    }
}
