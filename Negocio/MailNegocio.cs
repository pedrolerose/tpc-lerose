using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class MailNegocio
    {
        public void EnvioMail(MailParametros mailParametros)
        {
            MailMessage msg = new MailMessage();

            #region Datos
            var __usuarioEnvioMail = "mail";
            var __usuarioPasswordEnvioMail = "pass";
            var __smtpClient = "smtp.gmail.com";
            var __usuario = "Tape";
            var __password = "";
            var __puerto = "587";
            #endregion

            SmtpClient client = new SmtpClient(__smtpClient, int.Parse(__puerto));
            try
            {
                msg.Subject = mailParametros.asunto;
                msg.SubjectEncoding = Encoding.UTF8;
                msg.Body = mailParametros.cuerpo;
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = mailParametros.conBodyHtml;
                msg.From = new MailAddress(mailParametros.de);// new MailAddress("TuUsuarioRemitente@dominio.com");
                msg.To.Add(mailParametros.para);

                client.EnableSsl = true;
                client.Host = __smtpClient; /* ó Ip de tu equipo ()*/
                msg.Priority = MailPriority.High;
                NetworkCredential basicauthenticationinfo = new NetworkCredential(__usuarioEnvioMail, __usuarioPasswordEnvioMail);

                client.Port = int.Parse(__puerto);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.UseDefaultCredentials = false;
                client.Credentials = basicauthenticationinfo;


                client.Send(msg);
            }
            catch (Exception ex)
            {
                if (ex is SmtpException)
                {
                    System.Threading.Thread.Sleep(10000); // Lo hacemos esperar 20 segundos 
                }
            }
        }

        public MailParametros ParametrizarEnvioMailCompra(Carrito carrito, Usuario usuario)
        {

            MailParametros envioMail = new MailParametros
            {
                de = "mail",
                para = usuario.Mail,
                asunto = "Compra de Mercado Pepe, Gracias por elegirnos ",
                conBodyHtml = true
            };


            envioMail.cuerpo = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                                "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                                "<head>" +
                                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                                "<title>Mail to gsb</title>" +
                                "<meta name='viewport' content='width=device-width, initial-scale=1.0' />" +
                                "</head>" +
                                "<body style='margin: 0; padding: 0;' >" +
                                    "<table border='0' cellpadding='0' cellspacing='0 width='100%'>" +
                                        "<tr>" +
                                            "<td style='padding: 10px 0 30px 0;' >" +
                                                "<table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border: 1px solid #eee; border-collapse: collapse;'>" +
                                                    "<tr>" +
                                                        "<td bgcolor='#ffffff' style='padding: 40px 30px 10px 30px;' >" +
                                                            "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                                                "<tr>" +
                                                                    "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 20px; text-align: center;'>" +
                                                                        "Compra de " + usuario.Nombre  +
                                                                     "</td>" +
                                                                        "</tr>" +
                                                                     "<tr>" +
                                                                     "<br/>" +
                                                                    "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                        "Gasto Total: " + carrito.Monto +
                                                                     "</td>" +
                                                                     "</tr>" +
                                                                     "<tr>" +
                                                                     "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                       "Te lo enviaremos a: " + usuario.Calle + " " + usuario.NumeroCalle +
                                                                     "</td>" +
                                                                     "</tr>" +
                                                                     "<tr>" +
                                                                     "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                        " " +
                                                                     "</td>" +
                                                                     "</tr>" +
                                                            "</table>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                "<tr>" +
                                                    "<td style='padding: 0 0 30px 0; color: #999; font-family: Arial, sans-serif; font-size: 12px; line-height: 20px; text-align: center;' >" +
                                                        "Sede Central | pepe | Capital Federal<br/>" +
                                                        "(011) 1111 - 2222 | consultas@pepe.com" +
                                                    "</td>" +
                                                "</tr>" +
                                            "</table>" +
                                        "</td>" +
                                    "</tr>" +
                                "</table>" +
                            "</body>" +
                        "</html>";

            return envioMail;
        }

        public MailParametros ParametrizarEnvioMailOlvide(string mail, long documento)
        {

            MailParametros envioMail = new MailParametros
            {
                de = "pedrolerose@gmail.com",
                para = mail,
                asunto = "Cambio contraseña ",
                conBodyHtml = true
            };


            envioMail.cuerpo = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>" +
                                "<html xmlns='http://www.w3.org/1999/xhtml'>" +
                                "<head>" +
                                "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />" +
                                "<title>Mail to gsb</title>" +
                                "<meta name='viewport' content='width=device-width, initial-scale=1.0' />" +
                                "</head>" +
                                "<body style='margin: 0; padding: 0;' >" +
                                    "<table border='0' cellpadding='0' cellspacing='0 width='100%'>" +
                                        "<tr>" +
                                            "<td style='padding: 10px 0 30px 0;' >" +
                                                "<table align='center' border='0' cellpadding='0' cellspacing='0' width='600' style='border: 1px solid #eee; border-collapse: collapse;'>" +
                                                    "<tr>" +
                                                        "<td bgcolor='#ffffff' style='padding: 40px 30px 10px 30px;' >" +
                                                            "<table border='0' cellpadding='0' cellspacing='0' width='100%'>" +
                                                                "<tr>" +
                                                                    "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 20px; text-align: center;'>" +
                                                                        "Recibimos que olvido su pass. " +
                                                                     "</td>" +
                                                                        "</tr>" +
                                                                     "<tr>" +
                                                                     "<br/>" +
                                                                    "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                        ""+
                                                                     "</td>" +
                                                                     "</tr>" +
                                                                     "<tr>" +
                                                                     "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                       "Siga este link para cambiarla:   https://localhost:44368/CambioPass.aspx?doc=" + documento +
                                                                     "</td>" +
                                                                     "</tr>" +
                                                                     "<tr>" +
                                                                     "<td style='color: #3A4658; font-family: Arial, sans-serif; font-size: 15px; text-align: center;'>" +
                                                                        " " +
                                                                     "</td>" +
                                                                     "</tr>" +
                                                            "</table>" +
                                                        "</td>" +
                                                    "</tr>" +
                                                "<tr>" +
                                                    "<td style='padding: 0 0 30px 0; color: #999; font-family: Arial, sans-serif; font-size: 12px; line-height: 20px; text-align: center;' >" +
                                                        "Sede Central | pepe | Capital Federal<br/>" +
                                                        "(011) 1111 - 2222 | consultas@pepe.com" +
                                                    "</td>" +
                                                "</tr>" +
                                            "</table>" +
                                        "</td>" +
                                    "</tr>" +
                                "</table>" +
                            "</body>" +
                        "</html>";

            return envioMail;
        }
    }
}
