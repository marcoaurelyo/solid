namespace Daycoval.Solid.Domain.Services
{
    public interface INotificacao
    {
        void enviar(string toAddress, string message);
    }
}
