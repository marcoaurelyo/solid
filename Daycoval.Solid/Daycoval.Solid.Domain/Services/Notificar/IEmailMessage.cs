namespace Daycoval.Solid.Domain.Services
{
    public interface IEmailMessage : INotificar
    {
        string Subject { get; set; }
    }
}
