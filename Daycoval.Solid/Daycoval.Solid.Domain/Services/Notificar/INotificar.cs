namespace Daycoval.Solid.Domain.Services
{
    public interface INotificar
    {
        void enviar(string toAddress, string message);
    }
}
