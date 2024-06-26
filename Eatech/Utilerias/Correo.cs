﻿using System.Net;
using System.Net.Mail;

namespace Eatech.Utilerias
{
    public class Correo
    {
        public static bool EnviarCorreo(string receptor, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("noreply@eatech.me");
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

            NetworkCredential credencial = new NetworkCredential("noreply@eatech.me", "Sopadepapa22#");
            smtp.Credentials = credencial;
            smtp.Send(mail);

            return true;

        }
        public static bool PedidoCorreo(string receptor, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("pedidos@eatech.me");
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

            NetworkCredential credencial = new NetworkCredential("pedidos@eatech.me", "Sopadepapa22#");
            smtp.Credentials = credencial;
            smtp.Send(mail);

            return true;

        }
        public static bool EscuelaCorreo(string receptor, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("escuela.soporte@eatech.me");
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

            NetworkCredential credencial = new NetworkCredential("escuela.soporte@eatech.me", "Sopadepapa22#");
            smtp.Credentials = credencial;
            smtp.Send(mail);

            return true;

        }
        public static bool LicenciasCorreo(string receptor, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("licencias@eatech.me");
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

            NetworkCredential credencial = new NetworkCredential("licencias@eatech.me", "Sopadepapa22#");
            smtp.Credentials = credencial;
            smtp.Send(mail);

            return true;

        }
    }
}
