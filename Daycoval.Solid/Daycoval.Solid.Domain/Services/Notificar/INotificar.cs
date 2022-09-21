using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Daycoval.Solid.Domain.Services.Notificar
{
    public interface INotificar
    {
        void RealizarNotificacao(Cliente cliente, bool notificarClienteEmail, bool notificarClienteSms);
    }
}
