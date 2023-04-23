using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace UsuariosAPI.Models
{
    public class Mesensagem
    {
        public List<MailboxAddress>  Destinatario { get; set;}
        public string Assunto { get; set;}
        public int UsuarioIdentityId { get; set;}
        public string Conteudo { get; set; }

        public Mesensagem(IEnumerable<string> destinatario, string assunto, int usuarioIdentityId, string code)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d)));
            Assunto = assunto;
            UsuarioIdentityId = usuarioIdentityId;
            Conteudo = $"https://localhost:6001/ConfirmarEmail?UsuarioId={usuarioIdentityId}&CodigoAtivacao={code}";
        }


    }
}