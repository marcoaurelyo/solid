using Daycoval.Solid.Domain.Entidades;
using Daycoval.Solid.Domain.Services.Notificar;

namespace Daycoval.Solid.Domain.Services
{
    public class NotificarService : INotificar
    {
        public void RealizarNotificacao(Cliente cliente, bool notificarClienteEmail, bool notificarClienteSms)
        {
            if (notificarClienteEmail)
            {
                if (!string.IsNullOrWhiteSpace(cliente.Email))
                {
                    var _emailMessageService = new NotificarEmailService();
                    _emailMessageService.Subject = "Dados da sua compra";
                    _emailMessageService.enviar(cliente.Email, $"Obrigado por efetuar sua compra conosco.");
                }
            }

            if (notificarClienteSms)
            {
                if (!string.IsNullOrWhiteSpace(cliente.Celular))
                {
                    var _smsService = new NotificarSmsService();
                    _smsService.enviar(cliente.Celular, "Obrigado por sua compra");
                }
            }
        }
    }
}
