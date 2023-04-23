using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class EmailService
    {
        IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviaEmailConfirmacao(string [] destinatario, string assunto, int usuarioIdentityId, string code)
        {
            Mesensagem mesensagem = new Mesensagem(destinatario, assunto, usuarioIdentityId, code);
            var mensagemDeEmail = CriarCorpoDoEmail(mesensagem);
            EnviarEmail(mensagemDeEmail);
        }

        private void EnviarEmail(MimeMessage mensagemDeEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect( _configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    client.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));

                    client.Send(mensagemDeEmail);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Dispose();
                }
            }
        }

        private MimeMessage CriarCorpoDoEmail(Mesensagem mensagem)
        {
            var corpoDoEmail = new BodyBuilder();

            corpoDoEmail.HtmlBody = @"
                <!DOCTYPE html>
                <html>
                    <head>
                        <title>Confirmação de E-mail - Filmes API</title>
                    </head>
                    <body style='background-color: #f1f1f1;'>
                        <div style='background-color: #ffffff; max-width: 600px; margin: 0 auto; padding: 20px; border-radius: 10px;'>
                            <h1 style='color: #007bff;'>Confirmação de E-mail - Filmes API</h1>
                            <p>Olá, obrigado por se cadastrar em nossa plataforma Filmes API!</p>
                            <p>Para poder utilizar nossos serviços e continuar com o login, é necessário confirmar o seu e-mail.</p>
                            <p>Clique no botão abaixo para confirmar o seu e-mail e começar a utilizar nossos serviços.</p>
                            <p>Caso tenha alguma dúvida, entre em contato com a nossa equipe de suporte.</p>
                            <p>Atenciosamente,</p>
                            <p>A equipe de suporte da Filmes API.</p>
                            <a href='" + mensagem.Conteudo + @"' style='background-color: #007bff; color: #fff; padding: 10px 15px; text-decoration: none; border-radius: 5px; display: inline-block;'>Confirmar E-mail</a>
                        </div>
                    </body>
                </html>";

            var mensagemDeEmail = new MimeMessage();
            mensagemDeEmail.From.Add(new MailboxAddress(_configuration.GetValue<string>("EmailSettings:From")));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = corpoDoEmail.ToMessageBody();
    
            return mensagemDeEmail;
        }

    }
}