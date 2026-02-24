namespace WebApplication_api.Services.Interface
{
    public interface ISingletonGUI
    {
        public Guid singletonGUID { get; }
        public Guid GetGuid();
    }
}
