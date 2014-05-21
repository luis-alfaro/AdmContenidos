using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitarioEnvioData.Entidades;
using AccessLayer;
using System.Net.Mail;

namespace UtilitarioEnvioData.EnvioData
{
    public class EnvioEmail : Singleton<EnvioEmail>
    {
        public void AdjuntarFile(ref MailMessage message, List<EmailFile> files)
        {
            if (files != null)
            {
                foreach (EmailFile file in files)
                {
                    if (!string.IsNullOrEmpty(file.url))
                    {
                        //FileStream fs = new FileStream(file.url, FileMode.Open);
                        //Attachment attachF = new Attachment(fs, fs.Name);
                        //message.Attachments.Add(attachF);

                        /* Create the email attachment with the uploaded file */
                        Attachment attach = new Attachment(file.url);
                        //attach.Name = file.nombreCompleto;
                        /* Attach the newly created email attachment */
                        message.Attachments.Add(attach);
                    }
                }
            }
        }

        public bool SendEmailDefaultFrom(string to, string subject, string body, List<EmailFile> fileAttach)
        {
            bool result = false;
            MailMessage message = new MailMessage();
            try
            {
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = body;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;

                //adjuntar archivo
                AdjuntarFile(ref message, fileAttach);

                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                result = true;
            }
            catch (Exception ex)
            {
                string inner = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            }
            finally
            {
                message.Dispose();
            }
            return result;

        }

        public bool SendEmailPersonalFrom(string to, string subject, string body, List<EmailFile> fileAttach, string from, string password, string host, int port, bool enableSsl)
        {
            bool result = false;
            MailMessage message = new MailMessage();
            try
            {
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(from);
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = body;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;

                //adjuntar archivo
                AdjuntarFile(ref message, fileAttach);

                SmtpClient smtp = new SmtpClient(host, port);
                smtp.EnableSsl = enableSsl;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(from, password);

                smtp.Send(message);
                result = true;
            }
            catch (SmtpException ex)
            {
                string inner = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            }
            finally
            {
                message.Dispose();
            }
            return result;
        }

        public bool SendEmailMasivoDefaultFrom(List<EmailMessage> addresses, string subject, string body, List<EmailFile> fileAttach)
        {
            bool result = false;
            MailMessage message = new MailMessage();
            try
            {
                foreach (EmailMessage email in addresses)
                {
                    message.To.Add(new MailAddress(email.To));
                }
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = body;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;

                //adjuntar archivo
                AdjuntarFile(ref message, fileAttach);

                SmtpClient smtp = new SmtpClient();
                smtp.Send(message);
                result = true;
            }
            catch (SmtpException ex)
            {
                string inner = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            }
            finally
            {
                message.Dispose();
            }
            return result;
        }

        public bool SendEmailMasivoPersonalFrom(List<EmailMessage> addresses, string subject, string body, List<EmailFile> fileAttach, string from, string password, string host, int port, bool enableSsl)
        {
            bool result = false;
            MailMessage message = new MailMessage();
            try
            {
                message.From = new MailAddress(from);
                foreach (EmailMessage email in addresses)
                {
                    message.To.Add(new MailAddress(email.To));
                }
                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = body;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;

                //adjuntar archivo
                AdjuntarFile(ref message, fileAttach);

                SmtpClient smtp = new SmtpClient(host, port);
                smtp.EnableSsl = enableSsl;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(from, password);

                smtp.Send(message);
                result = true;
            }
            catch (SmtpException ex)
            {
                string inner = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
            }
            finally
            {
                message.Dispose();
            }
            return result;
        }

    }
}
