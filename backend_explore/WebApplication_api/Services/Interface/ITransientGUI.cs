namespace WebApplication_api.Services.Interface
{
    public interface ITransientGUI
    {
        public Guid transientGUID { get; }
        public Guid GetGuid();
    }
}
