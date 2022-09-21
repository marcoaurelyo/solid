namespace Daycoval.Solid.Domain.Services
{
    public interface IEmailMessage : INotificacao
    {
        string Subject { get; set; }
    }
}
