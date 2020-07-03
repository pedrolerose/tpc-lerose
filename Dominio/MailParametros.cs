using System;

namespace Dominio
{
    public class MailParametros
    {
        public virtual string origen { get; set; }
        public virtual string de { get; set; }
        public virtual string para { get; set; }
        public virtual string paraCC { get; set; }
        public virtual string asunto { get; set; }
        public virtual string cuerpo { get; set; }
        public virtual bool conBodyHtml { get; set; }

        public string urlConfirmacion { get; set; }
    }
}
/*  <Emisor>no_reply@osprera.org.ar</Emisor>
	<UsuarioEnvioMail>no_reply</UsuarioEnvioMail>
	<UsuarioPasswordEnvioMail>Correo2019</UsuarioPasswordEnvioMail>

	<SmtpClient>10.10.0.26</SmtpClient>
	<Usuario>reporting</Usuario>
	<Puerto>25</Puerto>
	<Password>reporting1234</Password>  
 */
